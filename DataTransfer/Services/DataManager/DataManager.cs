using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component;
using DataTransfer.Model.Structs;
using DataTransfer.Model.Structs.Bmpi;
using DataTransfer.Model.Structs.Brunner;
using DataTransfer.Model.Structs.Config.Base;
using DataTransfer.Model.Structs.ControlElements;
using DataTransfer.Model.Structs.DynamicModelStruct.Hx;
using DataTransfer.Model.Structs.DynamicModelStruct.Ka50;
using DataTransfer.Model.Structs.DynamicModelStruct.Ka52;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;
using DataTransfer.Services.ControlElements;
using ControlElement = DataTransfer.Model.Structs.ControlElements.ControlElement;
using DynamicModel = DataTransfer.Model.Structs.DynamicModelStruct.DynamicModel;
using Landing = DataTransfer.Model.Structs.RouteStruct.Landing;
using Route = DataTransfer.Model.Structs.RouteStruct.Route;

namespace DataTransfer.Services.DataManager
{
	public delegate void Message(string str);
	class DataManager
	{
		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(out long lpFrequency);


		[DllImport(@"CLSEConnector.dll", EntryPoint = "Initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Init(string path); //ConfigBrunner.xml

        [DllImport(@"CLSEConnector.dll", EntryPoint = "Step", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Step(IntPtr InpControl, IntPtr OutpState); //ConfigBrunner.xml
                                                                             
        [DllImport(@"CLSEConnector.dll", EntryPoint = "GetDllVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetDllVersion(IntPtr version, IntPtr release, IntPtr releaseDay, IntPtr releaseMonth,
            IntPtr releaseYear);

        private IntPtr GetIntPtr<T>(T obj)
        {
            var size = Marshal.SizeOf(obj);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, false);
            return ptr;
        }

        #region Objects

        private ChannelRadar _channelRadar;
		private DynamicModelToBmpi _dynamicModelToBmpi;
		private ChannelThermalEffect _channelThermalEffect;
		private ChannelTvHeadEffect _channelTvHeadEffect;
		private ControlElement _controlElement;
		private DynamicModel _dynamicModel;
		private DynamicModelToVaps _dynamicModelToVaps;
		private ModelState _modelState;
		private AircraftPosition _aircraftPosition;
		private StartPosition _startPosition;
		private DeviceControlElement _deviceControlElement;
		private Landing _landing;
		private Route _route;
		private EthernetControlElement _ethernetControlElement;
		private Config _config;
		private CLSEControl _cLSEControl;
		private CLSEState _cLSEState;


		#endregion

		private UdpHelper _udpHelper;
		public ObservableCollection<CollectionInfo> DynamicInfos = new ObservableCollection<CollectionInfo>();
		public ObservableCollection<CollectionInfo> ControlElementInfos = new ObservableCollection<CollectionInfo>();

		public event Message StatusModelEvent;
		public event Message StatusPacketEvent;
		public event Message MessageEvent;

		private Thread _receiveThread;
		private Thread _sendThread;
		private Thread _pollThread;
		private int _typeModel = 0;

		private int _stateModel =-1;
		private bool _isSend = true;
		private bool _isPoll = true;
		private bool _isReceive = true;
		private string _isCorrectModel;
		private string _typeControlElement;


		//_ipModel
		//_ipIup

		//_portModel			20030	Димамическая модель(команды)
		//						20031	Димамическая модель(ОУ)

		//_portIup				20040	Информационно-упраляющая система(ОУ) 
		//						20041	Информационно-упраляющая система(ДМ) 
		//						20042	Информационно-упраляющая система(ПУЭ)
		//						20043	Информационно-упраляющая система(СИВО)
		//						20044	Информационно-упраляющая система(РТО)

		//						20050	Индикаторы(ДМ)

		//_portTacticalEditor	20060	Редактор тактической обстановки

		//_portSvvo				20070	Система внекабинной обстановки(РТО)

		private DataManager()
		{
	
		}

		public void Init()
		{
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

		#region Init Thread
		private void InitThread()
		{
			_receiveThread = new Thread(Receive);
			_sendThread = new Thread(Send);
			_pollThread = new Thread(Poll);
		}

		public void StartThread()
		{
			_receiveThread.Start();
			_sendThread.Start();
			_pollThread.Start();
		}
		
		public void StopThread()
		{
			_isSend = false;
			_isReceive = false;
			_isPoll = false;

		}

		#endregion

		#region Init Object

		private void InitObject()
		{
			_config = Config.Instance();
			_udpHelper = new UdpHelper();
			_deviceControlElement = DeviceControlElement.GetInstance();
			_deviceControlElement.AddJoystick(_config.Default.DefaultControlElement.Rus.Guid);
			_deviceControlElement.AddJoystick(_config.Default.DefaultControlElement.Rud.Guid);
			_dynamicModelToBmpi = new DynamicModelToBmpi();
			_aircraftPosition = new AircraftPosition();
			_dynamicModelToVaps = new DynamicModelToVaps();
			_modelState = new ModelState();
			_channelRadar = new ChannelRadar();
			_channelThermalEffect = new ChannelThermalEffect();
			_channelTvHeadEffect = new ChannelTvHeadEffect();
			_ethernetControlElement = new EthernetControlElement();
			_cLSEControl = new CLSEControl();
			_cLSEState = new CLSEState();
			if (_typeModel == 0)
			{
				_controlElement = new ControlElementKa52();
				_dynamicModel = new ModelKa52();
			}
			_startPosition = new StartPosition();
			_landing = new Landing();
			_route = new Route();

            uint version = 0;
            uint release = 0;
            uint releaseDay = 0;
            uint releaseMonth = 0;
            uint releaseYear = 0;
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
            Init("ConfigBrunner.xml"); 

        }

		#endregion


		public void ChangeModel(string nameModel)
		{
			if (nameModel == "Ka52")
			{
				_dynamicModel = new ModelKa52();
				_controlElement = new ControlElementKa52();
				DynamicInfos.Clear();
			}

			if (nameModel == "Ka50")
			{
				_controlElement = new ControlElementKa50();
				_dynamicModel = new ModelKa50();
				DynamicInfos.Clear();
			}

			if (nameModel == "Hx")
			{
				_controlElement = new ControlElementKa50();
				_dynamicModel = new ModelHx();
				DynamicInfos.Clear();
			}
		}

		public void ChangeControlElement(string controlElement)
		{
			_typeControlElement = controlElement;
		}

		public void RestartControlElement()
		{
			_deviceControlElement = null;
			_deviceControlElement = DeviceControlElement.GetInstance();
			_deviceControlElement.AddJoystick("0402044f-0000-0000-0000-504944564944");
			_deviceControlElement.AddJoystick("0404044f-0000-0000-0000-504944564944");
		}

		#region Simulation control

		public void Start()
		{
			if (_stateModel==-1)
			{
				_startPosition.InitPosition(0);
				foreach (var ippoint in _config.NetworkSettings.Model.Command.IPPoint)
					_udpHelper.Send(_startPosition.GetBytes(), ippoint.Ip,	ippoint.Port);
			}
			
			_startPosition.InitPosition(1);
			foreach (var ippoint in _config.NetworkSettings.Model.Command.IPPoint)
				_udpHelper.Send(_startPosition.GetBytes(), ippoint.Ip, ippoint.Port);

			OnStatusModelEvent("Идет моделирование!");
			_stateModel = 1;
		}

		public void Pause()
		{
			_startPosition.InitPosition(2);
			foreach (var ippoint in _config.NetworkSettings.Model.Command.IPPoint)
				_udpHelper.Send(_startPosition.GetBytes(), ippoint.Ip, ippoint.Port);
			OnStatusModelEvent("Пауза!");
			_stateModel = 2;
		}

		public void Stop()
		{
			_startPosition.InitPosition(-1);
			foreach (var ippoint in _config.NetworkSettings.Model.Command.IPPoint)
				_udpHelper.Send(_startPosition.GetBytes(), ippoint.Ip, ippoint.Port);
			OnStatusModelEvent("Моделирование остановлено!"); 
			_stateModel = -1;
		}

        #endregion

        #region Method for thread

        private void Poll()
		{
			while (_isPoll)
			{
				if (_typeControlElement == "Joystick")
				{
					_controlElement.UpdateRud(_deviceControlElement?.ReadData(_config.Default.DefaultControlElement.Rud.Guid));
					_controlElement.UpdateRus(_deviceControlElement?.ReadData(_config.Default.DefaultControlElement.Rus.Guid));
				}

				if (_typeControlElement == "Ethernet")
				{
					IntPtr InpControl = GetIntPtr(_cLSEControl);
					IntPtr OutpState = GetIntPtr(_cLSEState);

					Step(InpControl, OutpState);

					_cLSEControl = (CLSEControl)Marshal.PtrToStructure(InpControl, typeof(CLSEControl));
					_cLSEState = (CLSEState)Marshal.PtrToStructure(OutpState, typeof(CLSEState));

					_controlElement.UpdateRud(_ethernetControlElement);
					_controlElement.UpdateRus(_ethernetControlElement, _cLSEState);

					Marshal.FreeHGlobal(InpControl);
					Marshal.FreeHGlobal(OutpState);
				}

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

				case "DynamicModelKa52":
					if (_dynamicModel.Assign(receivedBytes))
						_isCorrectModel = "Корректные данные!";
					else
						_isCorrectModel = "Некорректные данные!";

					OnStatusPacketEvent(_isCorrectModel);
					break;

				case "DynamicModelKa50":
					if (_dynamicModel.Assign(receivedBytes))
						_isCorrectModel = "Корректные данные!";
					else
						_isCorrectModel = "Некорректные данные!";
					OnStatusPacketEvent(_isCorrectModel);
					break;

				case "DynamicModelHx":
					if (_dynamicModel.Assign(receivedBytes))
						_isCorrectModel = "Корректные данные!";
					else
						_isCorrectModel = "Некорректные данные!";
					OnStatusPacketEvent(_isCorrectModel);
					break;

				case "Route":
					_route.Assign(receivedBytes);
					foreach (var ippoint in _config.NetworkSettings.IupVaps.Route.IPPoint)
						_udpHelper.Send(_route.GetReverseBytes(), ippoint.Ip,ippoint.Port);
					break;

				case "Landing":
					_landing.Assign(receivedBytes);
					break;

				case "ModelState":
					_modelState.AssignReverse(receivedBytes);
					break;

				case "USO":
					_ethernetControlElement.AssignReverse(receivedBytes);
					break;


				default:
					break;
			}
		}

		void Send()
		{
			while (_isSend)
			{
				var begin = DateTime.Now;
				var controlElementBytes = _controlElement.GetBytes();
				var controlElementBytesReverse = _controlElement.GetReverseBytes();
				var dynamicModelBytesReverse = _dynamicModel.GetForVaps(_dynamicModelToVaps);
				var landingBytesReverse = _landing.GetReverseBytes();
				var routeBytes = _route.GetBytes();
				var dynamicModelBytes = _dynamicModel.GetBytes();

				#region Отправка на модель


				foreach (var ippoint in _config.NetworkSettings.Model.ControlElement.IPPoint)
					_udpHelper.Send(controlElementBytes, ippoint.Ip, ippoint.Port);

				foreach (var ippoint in _config.NetworkSettings.Model.State.IPPoint)
					_udpHelper.Send(_modelState.GetBytes(), ippoint.Ip, ippoint.Port);

				#endregion

				#region Отправка на ИУП

				foreach (var ippoint in _config.NetworkSettings.IupVaps.ControlElement.IPPoint)
					_udpHelper.Send(controlElementBytesReverse, ippoint.Ip, ippoint.Port);

				foreach (var ippoint in _config.NetworkSettings.IupVaps.DynamicModel.IPPoint)
					_udpHelper.Send(dynamicModelBytesReverse, ippoint.Ip, ippoint.Port);

				foreach (var ippoint in _config.NetworkSettings.IupVaps.Landing.IPPoint)
					_udpHelper.Send(landingBytesReverse, ippoint.Ip, ippoint.Port);

				#endregion

				#region Отправка на отдельные индикаторы

				foreach (var ippoint in _config.NetworkSettings.Iup.DynamicModel.IPPoint)
					_udpHelper.Send(dynamicModelBytesReverse, ippoint.Ip, ippoint.Port);

				#endregion

				#region Отправка на тактический редактор

				foreach (var ippoint in _config.NetworkSettings.TacticalEditor.DynamicModel.IPPoint)
					_udpHelper.Send(_dynamicModel.GetPosition(_aircraftPosition), ippoint.Ip, ippoint.Port);

				#endregion

				#region Отправка на СВВО

				foreach (var ippoint in _config.NetworkSettings.TacticalEditor.DynamicModel.IPPoint)
					_udpHelper.Send(routeBytes, ippoint.Ip, ippoint.Port);

				#endregion

				#region Отправка на ЛПТП

				foreach (var ippoint in _config.NetworkSettings.TacticalEditor.DynamicModel.IPPoint)
					_udpHelper.Send(dynamicModelBytes, ippoint.Ip, ippoint.Port);

				#endregion

				#region Отправка на БПМИ

				foreach (var ippoint in _config.NetworkSettings.TacticalEditor.DynamicModel.IPPoint)
					_udpHelper.Send(_dynamicModel.GetForBmpi(_dynamicModelToBmpi), ippoint.Ip, ippoint.Port);

				#endregion

				#region Обновление коллекций

				App.Current.Dispatcher.Invoke(() =>
				{
					_dynamicModel.Update(DynamicInfos);
					_controlElement.Update(ControlElementInfos);
				});

				#endregion

				var end = DateTime.Now;

				Console.WriteLine((end - begin).Milliseconds);
				Thread.Sleep(20);
			}
		}

		#endregion

		#region Call events

		private void OnStatusModelEvent(string str)
		{
			StatusModelEvent?.Invoke(str);
		}

		private void OnStatusPacketEvent(string str)
		{
			StatusPacketEvent?.Invoke(str);
		}

		protected void OnMessageEvent(string str)
		{
			MessageEvent?.Invoke(str);
		}

		#endregion

		private void Cik_Step()
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
			while (true)
			{
				QueryPerformanceCounter(out long ET);
				DeltaT = (1000.0 * ((ET) - StartTime) / ClockRate); // миллисекунды
				dt_din = Convert.ToSingle(DeltaT / 10); // 100 Гц
				dt_din2 = Convert.ToSingle(DeltaT / 20); //  50 Гц

				if (Convert.ToSingle((Math.Truncate(dt_din))) > intval100)
				{ intval100++; }

				if (Convert.ToSingle((Math.Truncate(dt_din2))) > intval50)
				{ intval50++; }
			}
		}
	}
}
