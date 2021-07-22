using HxModel.Models;
using HxModel.SvvoStruct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace HxModel.FdmManager
{

    class PlaybackInfo
    {
        public DataOut DataOut;
        public KinematicsState KinematicsState;
	
	}

	class PlaybackFlight

	{

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(out long lpFrequency);

		private UdpClient _sendClient;
		private Svvo _svvo;

		public PlaybackFlight()
		{
			_sendClient = new UdpClient();
			_svvo = new Svvo();
			Step();
		}



		private void Step()
		{
			double ClockRate, StartTime;
			double DeltaT;
			float dt_din, dt_din2;
			long intval100 = 0;
			long intval50 = 0;
			QueryPerformanceFrequency(out long QW);
			ClockRate = (QW);
			QueryPerformanceCounter(out QW);
			StartTime = (QW);
			List<PlaybackInfo> listOfPlay = new List<PlaybackInfo>();
			LoadFly(listOfPlay);
			int idx = 0;
			int lenght = listOfPlay.Count;
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("Нажмите Enter для остановки моделирования!\r\n");
			while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter))
			{
				
				QueryPerformanceCounter(out long ET);
				DeltaT = (1000.0 * ((ET) - StartTime) / ClockRate); // миллисекунды
				dt_din = Convert.ToSingle(DeltaT / 10); // 100 Гц
				dt_din2 = Convert.ToSingle(DeltaT / 20); //  50 Гц

				if (Convert.ToSingle((Math.Truncate(dt_din))) > intval100)
				{
					if (idx >= lenght) idx = 0;

					byte[] dataOutBytres = ConvertHelper.ObjectToByte(listOfPlay[idx].DataOut);
					byte[] ksBytres = GetByte(listOfPlay[idx].KinematicsState);

			
					Send(ksBytres, "192.168.0.2", 6100);
					Send(ksBytres, "192.168.0.4", 6100);
					Send(ksBytres, "192.168.0.5", 6100);
					Send(ksBytres, "192.168.0.6", 6100);
					Send(ksBytres, "192.168.0.9", 6100);
					Send(dataOutBytres, "127.0.0.1", 20020);
					Send(ksBytres, "255.255.255.255", 6105);



					idx++;
					double percent = (double)Math.Round((double)idx / (double)lenght * 100.0, 2);

					PrintProgress((int)percent, _processModeling, _finishModeling);
					intval100++;

				
					if (Convert.ToSingle((Math.Truncate(dt_din2))) > intval50)
					{ intval50++; }
				}
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("\r\n\r\nПроцесс моделирования окончен!");
			_sendClient.Close();
		}


		public void Stop()
		{
		}
		private byte[] GetByte(KinematicsState state)
		{
			_svvo.Preamble.wSync = 0xCDEF;
			_svvo.Preamble.ProtVers = 0x04;
			_svvo.Preamble.wLength = (ushort)Marshal.SizeOf(_svvo);
			_svvo.Header._type = 3;
			_svvo.Header.Number = 0;

			_svvo.Id = 1;
			_svvo.Size = (ushort)(Marshal.SizeOf(_svvo.Packetcam) + 4);
			_svvo.Packetcam.x = state.Pos.Latitude * Math.PI / 180D;
			_svvo.Packetcam.z = state.Pos.Longitude * Math.PI / 180D;
			_svvo.Packetcam.ht = (float)state.Pos.Elevation;
			_svvo.Packetcam.tet = (float)(state.Angs.Fi * Math.PI / 180D);
			_svvo.Packetcam.gam = (float)(state.Angs.Gam * Math.PI / 180D);
			_svvo.Packetcam.psi = (float)(state.Angs.Psi * Math.PI / 180D);
			_svvo.Packetcam.flag = 1;

			return ConvertHelper.ObjectToByte(_svvo);
		}

		public void Send(byte[] dgram, string hostname, int port)
		{
			try
			{
				_sendClient?.Send(dgram, dgram.Length, hostname, port);
			}
			catch (Exception expSend)
			{
				Console.WriteLine(expSend.ToString());
			}
		}
		static int progress = 0;
		string _processLoad = "Загрузка ";
		string _finishLoad = "Загрузка данных закончена! Загружено {0}%\r\n\r\n";

		string _processModeling = "Процесс моделирования";
		string _finishModeling = "Процесс моделирования";


		private void LoadFly(List<PlaybackInfo> listOfPlay)
		{

			if (File.Exists("FlyHxModel.bin"))
				using (BinaryReader br = new BinaryReader(File.Open("FlyHxModel.bin", FileMode.Open, FileAccess.Read)))
				{
					var lenght = br.BaseStream.Length;
					double pos = 0;
					Console.WriteLine("");
					while (br.BaseStream.Position != br.BaseStream.Length)
					{
						DataOut dataOut = new DataOut();
						KinematicsState kState = new KinematicsState();

						var dOutByte = br.ReadBytes(Marshal.SizeOf(dataOut));
						var ksByte = br.ReadBytes(Marshal.SizeOf(kState));

						ConvertHelper.ByteToObject(dOutByte, dataOut);
						kState = (KinematicsState)ConvertHelper.ByteToObject(ksByte, kState, typeof(KinematicsState));

						listOfPlay.Add(new PlaybackInfo() { DataOut = dataOut, KinematicsState = kState });
						pos += 838;
						decimal percent = (decimal)Math.Round(((pos / lenght) * 100.0), 2);
						PrintProgress((int)percent, _processLoad, _finishLoad);
				

					}
				}
		}


		private void PrintProgress(int percent, string process, string finish)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.SetCursorPosition(0, Console.CursorTop);
			if (percent < 100)
			 UpdateProgress(percent, process);
			else
				Console.Write(finish, percent);
			Console.ForegroundColor = ConsoleColor.Gray;
			
		}

		private void UpdateProgress(int percent, string process)
		{
			Console.SetCursorPosition(0, Console.CursorTop);
			const string animation = @"|/-\";
			string text = string.Format(process + " [{0}{1}] {2,3}% {3}", 
				new string('#', percent / 5), 
				new string('-', 20- (int)percent / 5),
				percent,
				animation[(int)percent++ % animation.Length]);
			Console.Write(text);
		}

	}
}
