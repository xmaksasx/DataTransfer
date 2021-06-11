using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component;
using DataTransfer.Model.Structs;
using DataTransfer.Services.ControlElements;

namespace DataTransfer.Services.DataManager
{
	class DataManager
	{
		[DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceCounter(out Int64 lpPerformanceCount);

		[DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceFrequency(out Int64 lpFrequency);

		#region Objects

		private ChannelRadar _channelRadar;
		private ChannelThermalEffect _channelThermalEffect;
		private ChannelTvHeadEffect _channelTvHeadEffect;
		private CockpitKa52 _cockpitKa52;
		private CockpitKa50 _cockpitKa50;
		private DynamicModel _dynamicModel;
		private StartPosition _startPosition;
		private DeviceControlElement _deviceControlElement;
		private Landing _landing;
		private Route _route;

		#endregion
		
		private UdpHelper _udpHelper;
		public ObservableCollection<CollectionInfo> DynamicInfos = new ObservableCollection<CollectionInfo>();
		public ObservableCollection<CollectionInfo> ControlElementInfos = new ObservableCollection<CollectionInfo>();
		private Thread _receiveThread;
		private Thread _sendThread;
		private Thread _pollThread;
		private string _ipIup = "127.0.0.1";
		private string _ipModel = "127.0.0.1";
		private string _broadcast = "127.0.0.1";

		private bool _isSend = true;
		private bool _isPoll = true;
		private bool _isReceive = true;


		//_ipModel
		//_ipIup

		//_portModel			20030	Димамическая модель
		//_portSvvo				6001	Система внекабинной обстановки
		//_portIup				20040	Информационно-упраляющая система(ОУ) 
		//						20041	Информационно-упраляющая система(ДМ) 
		//						20042	Информационно-упраляющая система(ПУЭ)
		//						20043	Информационно-упраляющая система(СИВО)
		//						20044	Информационно-упраляющая система(РТО)
		//_portTacticalEditor	20060	Редактор тактической обстановки

		private DataManager()
		{
	

			_udpHelper = new UdpHelper();
			_deviceControlElement = DeviceControlElement.GetInstance();
			_deviceControlElement.AddJoystick("0402044f-0000-0000-0000-504944564944");
			_deviceControlElement.AddJoystick("0404044f-0000-0000-0000-504944564944");
			InitObject();
			InitThread();
			StartThread();
		}

		private static DataManager _instance;


		public static DataManager GetInstance()
		{
			if (_instance == null)
			{
				_instance = new DataManager();
			}

			return _instance;
		}

		#region Thread control

		public void StartThread()
		{
			_receiveThread.Start();
			_sendThread.Start();
			_pollThread.Start();
		}

		private void InitThread()
		{
			_receiveThread = new Thread(Receive);
			_sendThread = new Thread(Send);
			_pollThread = new Thread(Poll);
		}

		public void StopThread()
		{
			_isSend = false;
			_isReceive = false;
			_isPoll = false;

		}

		#endregion

		private void InitObject()
		{
			_channelRadar = new ChannelRadar();
			_channelThermalEffect = new ChannelThermalEffect();
			_channelTvHeadEffect = new ChannelTvHeadEffect();
			_cockpitKa52 = new CockpitKa52();
			_cockpitKa50 = new CockpitKa50();
			_dynamicModel = new DynamicModel();
			_startPosition = new StartPosition();
			_landing = new Landing();
			_route = new Route();
		}

		public void Start()
		{
			_startPosition.InitPosition(0);
			_udpHelper.Send(_startPosition.GetBytes(), _ipModel, 20030);
			_startPosition.InitPosition(1);
			_udpHelper.Send(_startPosition.GetBytes(), _ipModel, 20030);
		}

		public void Pause()
		{
			_startPosition.InitPosition(2);
			_udpHelper.Send(_startPosition.GetBytes(), _ipModel, 20030);
		}

		public void Stop()
		{
			_startPosition.InitPosition(-1);
			_udpHelper.Send(_startPosition.GetBytes(), _ipModel, 20030);
		}

		public void RestartControlElement()
		{
			_deviceControlElement = null;
			_deviceControlElement = DeviceControlElement.GetInstance();
			_deviceControlElement.AddJoystick("0402044f-0000-0000-0000-504944564944");
			_deviceControlElement.AddJoystick("0404044f-0000-0000-0000-504944564944");
		}

		#region Method for thread

		private void Poll()
		{
			while (_isPoll)
			{
				_cockpitKa52.UpdateRus(_deviceControlElement?.ReadData("0402044f-0000-0000-0000-504944564944"));
				_cockpitKa52.UpdateRud(_deviceControlElement?.ReadData("0404044f-0000-0000-0000-504944564944"));
				_cockpitKa50.UpdateRus(_deviceControlElement?.ReadData("0402044f-0000-0000-0000-504944564944"));
				_cockpitKa50.UpdateRud(_deviceControlElement?.ReadData("0404044f-0000-0000-0000-504944564944"));
				Thread.Sleep(20);
			}
		}

		private void Receive()
		{
			while (_isReceive)
			{
				var receivedBytes = _udpHelper.Receive();
				if (receivedBytes.Length == 0) continue;
				string header = Encoding.UTF8.GetString(receivedBytes, 0, 30).Trim('\0');
				ProcessingPackage(header, receivedBytes);
			}
		}

		private void ProcessingPackage(string header, byte[] receivedBytes)
		{
			switch (header)
			{
				case "ChannelRadar":
					_channelRadar.Assign(receivedBytes);
					break;

				case "ChannelThermalEffect":
					_channelThermalEffect.Assign(receivedBytes);
					break;

				case "ChannelTvHeadEffect":
					_channelTvHeadEffect.Assign(receivedBytes);
					break;

				case "DynamicModel":
					_dynamicModel.Assign(receivedBytes);
					break;

				case "Route":
					_route.Assign(receivedBytes);
					break;

				case "Landing":
					_landing.Assign(receivedBytes);
					break;

				default:
					break;
			}
		}

		void Send()
		{
			while (_isSend)
			{
				//_fdmManager.Step();
				//Отправка на СВВО
				// Send(_sendSvvo.GetByte(_receiveModel), _broadcast, 6100);
				//_udpHelper.Send(_sendSvvo.GetByte(_receiveModel), _broadcast, 33333);

				//Отправка на модель
				_udpHelper.Send(_cockpitKa52.GetBytes(), _ipModel, 20031);
				_udpHelper.Send(_cockpitKa50.GetBytes(), _ipModel, 20030);

				//Отправка на ИУП
				_udpHelper.Send(_dynamicModel.GetReverseBytes(), _ipIup, 20040);
				//_udpHelper.Send(_channelThermalEffect.GetBytes(), _ipIup, 20041);
				//_udpHelper.Send(_channelTvHeadEffect.GetBytes(), _ipIup, 20042);
				_udpHelper.Send(_route.GetReverseBytes(), _ipIup, 20044);

				//Отправка на спец изображение
				//_udpHelper.Send(_dynamicModel.GetBytes(), _ipIup, 20040);
				//_udpHelper.Send(_channelThermalEffect.GetBytes(), _ipIup, 20041);
				//_udpHelper.Send(_channelTvHeadEffect.GetBytes(), _ipIup, 20042);



				//Отправка на УСО
				//_udpHelper.Send(_cockpit.GetBytes(), _broadcast, 20050);

				//Отправка на редактор
				//_udpHelper.Send(_sendTacticalEditor.GetByte(_receiveModel), _ipTacticalEditor, 20060);

				//Отправка на ПУЭ
				//_udpHelper.Send(_sendPostExperiment.GetByte(_receiveUso, _receiveModel), _broadcast, 20070);

				_dynamicModel.Update(DynamicInfos);
				_cockpitKa52.Update(ControlElementInfos);

				Thread.Sleep(20);








			}
		}

		#endregion



		//static void Cik_Step()
		//{
		//	Int64 QW, ET;
		//	double ClockRate, StartTime;
		//	double DeltaT;
		//	Single dt_din, dt_din2;
		//	Int64 intval100 = 0;
		//	Int64 intval50 = 0;
		//	QueryPerformanceFrequency(out QW);
		//	ClockRate = (QW);
		//	QueryPerformanceCounter(out QW);
		//	StartTime = (QW);
		//	while (ims_bool)
		//	{
		//		if (snw.Count != 0)
		//		{
		//			string switch_on;
		//			if (snw.TryDequeue(out switch_on))
		//			{
		//				switch (switch_on)
		//				{
		//					case "init":

		//						break;

		//					case "PrepareAndStart":

		//						break;


		//					case "Start":

		//						break;
		//					case "Pause":

		//					case "Stop":

		//						break;


		//					default:
		//						break;

		//				}
		//			}
		//		}

		//		QueryPerformanceCounter(out ET);
		//		DeltaT = (1000.0 * ((ET) - StartTime) / ClockRate); // миллисекунды
		//		dt_din = Convert.ToSingle(DeltaT / 10); // 100 Гц
		//		dt_din2 = Convert.ToSingle(DeltaT / 20); //  50 Гц

		//		if (Convert.ToSingle((Math.Truncate(dt_din))) > intval100)
		//		{
		//			intval100++;

		//		}

		//		if (Convert.ToSingle((Math.Truncate(dt_din2))) > intval50)
		//		{
		//			intval50++;
		//		}
		//	}
		//}
	}
}
