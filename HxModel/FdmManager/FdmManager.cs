using HxModel.Models;
using HxModel.SvvoStruct;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;


namespace HxModel.FdmManager
{
	class FdmManager
	{
		#region Импорт функций модели

		/// <summary>
		/// Декларации экспортируемых пользовательских функций:
		/// получить параметры версии библиотеки: номер версии Version, номер подверсии Release;
		/// дату выхода версии: день ReleaseDay, месяц ReleaseMonth, год ReleaseYear
		/// </summary>
		/// <param name="version"></param>
		/// <param name="release"></param>
		/// <param name="releaseDay"></param>
		/// <param name="releaseMonth"></param>
		/// <param name="releaseYear"></param>
		[DllImport(@"DynamicsHX.dll", EntryPoint = "GetDllVersion", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetDllVersion(IntPtr version, IntPtr release, IntPtr releaseDay, IntPtr releaseMonth,
			IntPtr releaseYear);

		/// <summary>
		/// Начальная инициализация (переинициализация) модели и установка ее в заданное кинематическое состояние InitialState:
		/// Может быть вызвана в любой момент счета, дальнейший счет будет происходить с исходной точки
		/// </summary>
		/// <param name="initialState">KinematicsState*</param>
		[DllImport(@"DynamicsHX.dll", EntryPoint = "Init", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Init(IntPtr initialState);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dT">double</param>
		/// <param name="hel">VhclInp*</param>
		/// <param name="contactEnv">ContactEnvironment*</param>
		/// <param name="resState">KinematicsState*</param>
		/// <param name="resHel">VhclOutp*</param>
		[DllImport(@"DynamicsHX.dll", EntryPoint = "Step", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Step(double dT, IntPtr hel, IntPtr contactEnv, IntPtr resState, IntPtr resHel);
		#endregion

		private UdpHelper _udpHelper;
		private Thread _receiveThread;
		private Thread _sendThread;
		private bool _isSend = true;
		private bool _isReceive = true;
		private bool _isStart;

		private VhclInp Hel;
		private ContactEnvironment ContactEnv;
		private XVECTOR3 _windSpeed;
		private XVECTOR3 _inertialMoments;
		private XVECTOR3 _posCg;
		private XVECTOR3 _normal = new XVECTOR3 { X = 0, Y = 1, Z = 0 };
		private KinematicsState ResState;
		private VhclOutp ResHel;
		private StartPosition _startPosition;
		private ControlElement _controlElement;
		private Svvo _svvo;
		private DataOut _dataOut;
		private float _gmTerrainH;
		public FdmManager()
		{
			uint  version = 0;
			uint  release = 0;
			uint  releaseDay = 0;
			uint  releaseMonth = 0;
			uint  releaseYear = 0;
	    	IntPtr pversion = GetIntPtr(version);
			IntPtr prelease = GetIntPtr(release);
			IntPtr preleaseDay = GetIntPtr(releaseDay);
			IntPtr preleaseMonth = GetIntPtr(releaseMonth);
			IntPtr preleaseYear = GetIntPtr(releaseYear);
			GetDllVersion(pversion, prelease, preleaseDay, preleaseMonth, preleaseYear);
			version = (uint)Marshal.ReadInt32(pversion);
			release = (uint)Marshal.ReadInt32(prelease);
			releaseDay = (uint)Marshal.ReadInt32(preleaseDay);
			releaseMonth = (uint)Marshal.ReadInt32(preleaseMonth);
			releaseYear = (uint)Marshal.ReadInt32(preleaseYear);

			_udpHelper = new UdpHelper();
			_startPosition = new StartPosition();
			_controlElement = new ControlElement();
			_svvo = new Svvo();
			_dataOut = new DataOut();
			InitThread();
			StartThread();
		}

		private void InitThread()
		{
			_receiveThread = new Thread(Receive);
			_sendThread = new Thread(Send);

		}

		private void StartThread()
		{
			_receiveThread.Start();
			_sendThread.Start();
		}

		private void InitModel(StartPosition startPosition)
		{
			KinematicsState initialState = default;
			initialState.AbsSpeed = new XVECTOR3() { X = 1, Y = 0, Z = 0 };
			initialState.Angs.Psi = startPosition.in_Kurs0;
			initialState.Pos.Elevation = startPosition.in_Hbar = 50;
			initialState.Pos.Latitude = startPosition.StartX = 43.44794255;
			initialState.Pos.Longitude = startPosition.StartY = 39.94518977;
			IntPtr ksPtr = GetIntPtr(initialState);
			Init(ksPtr);
			Marshal.FreeHGlobal(ksPtr);
		}

		public void Step(ControlElement controlElement)
		{
			ContactEnv.Elevation =  _gmTerrainH;
			ContactEnv.Normal = _normal;
			Hel.AirState.WindSpeed = _windSpeed;
			Hel.Mass = 10800.0;
			Hel.InertialMoments = _inertialMoments;
			Hel.PosCG = _posCg;
			Hel.VehicleCtrl.CyclicPitch = controlElement._cyclicStepHandleLeft.Elevator;
			Hel.VehicleCtrl.CyclicRoll = controlElement._cyclicStepHandleLeft.Aileron;
			Hel.VehicleCtrl.Direction = controlElement._pedalsLeft.Pedal;
			Hel.VehicleCtrl.Collective = controlElement._generalStepHandleLeft.GeneralStep;
			Hel.AirState.AirHumidityGround = 60;
			Hel.AirState.AirPressureGround = 750;
			Hel.AirState.AirTemperatureGround = 20;

			IntPtr ptrHel = GetIntPtr(Hel);
			IntPtr ptrCe = GetIntPtr(ContactEnv);
			IntPtr ptrRs = GetIntPtr(ResState);
			IntPtr ptrRh = GetIntPtr(ResHel);

			Step(0.02, ptrHel, ptrCe, ptrRs, ptrRh);

			ResState = (KinematicsState)Marshal.PtrToStructure(ptrRs, typeof(KinematicsState));
			ResHel = (VhclOutp)Marshal.PtrToStructure(ptrRh, typeof(VhclOutp));
			_dataOut.KinematicsState = ResState;
			_dataOut.VhclOutp = ResHel;

			_udpHelper.Send(GetByte(ResState), "127.0.0.1", 6100);
			_udpHelper.Send(GetByte(_dataOut), "127.0.0.1", 20020);
			_udpHelper.Send(GetByte(ResState), "127.0.0.1", 6105);
			Marshal.FreeHGlobal(ptrHel);
			Marshal.FreeHGlobal(ptrCe);
			Marshal.FreeHGlobal(ptrRs);
			Marshal.FreeHGlobal(ptrRh);
		}

		private IntPtr GetIntPtr<T>(T obj)
		{
			var size = Marshal.SizeOf(obj);
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(obj, ptr, false);
			return ptr;
		}

		public byte[] GetByte(KinematicsState state)
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
			_svvo.Packetcam.psi = (float)(-state.Angs.Psi * Math.PI / 180D);
			_svvo.Packetcam.flag = 1;

			return ConvertHelper.ObjectToByte(_svvo);
		}

		public byte[] GetByte(DataOut dataOut)
		{
			return ConvertHelper.ObjectToByte(dataOut);
		}

		#region Method for thread

		private void Receive()
		{
			while (_isReceive)
			{
				var receivedBytes = _udpHelper.Receive();
				if (receivedBytes.Length == 0) continue;
				string header = "";
				if (receivedBytes.Length > 30)
					header = Encoding.UTF8.GetString(receivedBytes, 0, 30).Trim('\0');
				ProcessingPackage(header, receivedBytes);
			}
		}

		private void ProcessingPackage(string header, byte[] receivedBytes)
		{
			switch (header)
			{
				case "StartPosition":

					ConvertHelper.ByteToObject(receivedBytes, _startPosition);
					if (_startPosition.flag == 0)
					{
						_isStart = false;
						InitModel(_startPosition);
						Console.WriteLine("Инициализация модели!");
					}

					if (_startPosition.flag == 1)
					{
						_isStart = true;
						Console.WriteLine("Идет моделирование!");
					}

					if (_startPosition.flag == 2)
					{
						_isStart = false;
						Console.WriteLine("Пауза!");
					}

					if (_startPosition.flag == -1)
					{
						_isStart = false;
						Console.WriteLine("Стоп!");
					}


					break;

				case "ControlElement":
					ConvertHelper.ByteToObject(receivedBytes, _controlElement);
					break;

				default:
					if (receivedBytes.Length == 4)
					{
						_gmTerrainH = BitConverter.ToSingle(receivedBytes, 0);
					}
					break;
			}
		}

		void Send()
		{
			while (_isSend)
			{
				if (_isStart)
					Step(_controlElement);
				Thread.Sleep(20);


			}
		}




		#endregion
	}
}