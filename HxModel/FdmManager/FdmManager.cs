using HxModel.Models;
using HxModel.Models.Config.Base;
using HxModel.Models.FCSCommand;
using HxModel.SvvoStruct;
using StructHxModel.Models;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;



namespace HxModel.FdmManager
{
	class FdmManager
	{
        #region Импорт функций модели

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

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
		private bool _isRecord = false;

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
		private RecordFlight _recordFlight;
		private DataOut _dataOut;
		private float _gmTerrainH;
        private FCSCmds fCSCmds;
		private Config _config;
		public FdmManager()
		{
			_config = Config.Instance();
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
            fCSCmds = new FCSCmds();

            InitThread();
			StartThread();
		}

		private void InitThread()
		{
			_receiveThread = new Thread(Receive);
			_sendThread = new Thread(Cik_Step);

		}

		private void StartThread()
		{
			_receiveThread.Start();
			_sendThread.Start();
		}

		public void StopAll()
		{
			_isStart = false;
			_isReceive = false;
			_isSend = false;
			Thread.Sleep(10);
			_udpHelper.Stop();
			Thread.Sleep(10);
			_receiveThread?.Abort();
			_sendThread?.Abort();
			Thread.Sleep(10);
			StopRecord();
		}

		private void InitModel(StartPosition startPosition)
		{

			Hel.FCSState.TurnCoordSpd = 80;
			Hel.FCSState.TurnCoordination = 1;
			Hel.FCSState.PitchChnl.StickTrimmedPos = 0.5;
			Hel.FCSState.PitchChnl.StickAngleSpd = 9;
			Hel.FCSState.PitchChnl.StickDeadzone = 0.02;
			Hel.FCSState.PitchChnl.MinAngle = -12;
			Hel.FCSState.PitchChnl.MaxAngle = 16;

			Hel.FCSState.RollChnl.StickTrimmedPos = 0.5;
			Hel.FCSState.RollChnl.StickAngleSpd = 22;
			Hel.FCSState.RollChnl.StickDeadzone = 0.02;
			Hel.FCSState.RollChnl.MinAngle = -24;
			Hel.FCSState.RollChnl.MaxAngle = 24;


			KinematicsState initialState = default;
			initialState.AbsSpeed = new XVECTOR3() { X = 0, Y = 0, Z = 0 };
			initialState.Angs.Psi = startPosition.in_Kurs0;
			initialState.Pos.Elevation = startPosition.in_Hgeom+3;
			initialState.Pos.Latitude = startPosition.StartX;//= 43.44794255;
			initialState.Pos.Longitude = startPosition.StartY;// = 39.94518977;
			IntPtr ksPtr = GetIntPtr(initialState);
			Init(ksPtr);
			Marshal.FreeHGlobal(ksPtr);
		}

		public void Step(ControlElement controlElement)
		{
			Hel.VehicleCtrl.AltimeterBaroPressure = 761.2;
			ContactEnv.Elevation = _gmTerrainH;
			ContactEnv.Normal = _normal;
			Hel.AirState.WindSpeed = _windSpeed;
			Hel.Mass = 10800.0;
			Hel.InertialMoments = _inertialMoments;
			Hel.PosCG = _posCg;

			if (controlElement.Channel == 1)
			{
				Hel.VehicleCtrl.CyclicPitch = controlElement._cyclicStepHandleLeft.Elevator;
				Hel.VehicleCtrl.CyclicRoll = controlElement._cyclicStepHandleLeft.Aileron;
				Hel.VehicleCtrl.Direction = controlElement._pedalsLeft.Pedal;
				Hel.VehicleCtrl.Collective = controlElement._generalStepHandleLeft.GeneralStep;
				Hel.VehicleCtrl.Trimmer = (byte)controlElement._cyclicStepHandleLeft.BtnTrim;
				Hel.VehicleCtrl.Friction = (byte)controlElement._generalStepHandleLeft.BtnStabilizer;
				Hel.VehicleCtrl.NoseGear.Brake = controlElement._cyclicStepHandleLeft.BtnWheelBrake;
				Hel.VehicleCtrl.MainGearLeft.Brake = controlElement._cyclicStepHandleLeft.BtnWheelBrake;
				Hel.VehicleCtrl.MainGearRight.Brake = controlElement._cyclicStepHandleLeft.BtnWheelBrake;
			}
			else if (controlElement.Channel == 2)
			{
				Hel.VehicleCtrl.CyclicPitch = controlElement._cyclicStepHandleRight.Elevator;
				Hel.VehicleCtrl.CyclicRoll = controlElement._cyclicStepHandleRight.Aileron;
				Hel.VehicleCtrl.Direction = controlElement._pedalsLeft.Pedal;
				Hel.VehicleCtrl.Collective = controlElement._generalStepHandleRight.GeneralStep;
				Hel.VehicleCtrl.Trimmer = (byte)controlElement._cyclicStepHandleRight.BtnTrim;
				Hel.VehicleCtrl.Friction = (byte)controlElement._generalStepHandleRight.BtnStabilizer;
				Hel.VehicleCtrl.NoseGear.Brake = controlElement._cyclicStepHandleRight.BtnWheelBrake;
				Hel.VehicleCtrl.MainGearLeft.Brake = controlElement._cyclicStepHandleRight.BtnWheelBrake;
				Hel.VehicleCtrl.MainGearRight.Brake = controlElement._cyclicStepHandleRight.BtnWheelBrake;
			}

			Hel.VehicleCtrl.CyclicPitch = 0.5;
			Hel.VehicleCtrl.CyclicRoll = 0.5;
			Hel.VehicleCtrl.Direction = 0.5; ;
			Hel.VehicleCtrl.Collective = 0.0;
			Hel.VehicleCtrl.Trimmer = 0;
			Hel.VehicleCtrl.Friction = 0;
			Hel.VehicleCtrl.NoseGear.Brake = 1;
			Hel.VehicleCtrl.MainGearLeft.Brake = 1;
			Hel.VehicleCtrl.MainGearRight.Brake = 1;

			IntPtr ptrHel = GetIntPtr(Hel);
			IntPtr ptrCe = GetIntPtr(ContactEnv);
			IntPtr ptrRs = GetIntPtr(ResState);
			IntPtr ptrRh = GetIntPtr(ResHel);

			Step(0.01, ptrHel, ptrCe, ptrRs, ptrRh);

			ResState = (KinematicsState)Marshal.PtrToStructure(ptrRs, typeof(KinematicsState));
			ResHel = (VhclOutp)Marshal.PtrToStructure(ptrRh, typeof(VhclOutp));
			_dataOut.KinematicsState = ResState;
			_dataOut.VhclOutp = ResHel;
			_dataOut.VhclInp = Hel;



			foreach (var ippoint in _config.NetworkSettings.Svvo.Position.IPPoint)
				_udpHelper.Send(GetByte(ResState), ippoint.Ip, ippoint.Port);

			foreach (var ippoint in _config.NetworkSettings.DataTransfer.DynamicModel.IPPoint)
				_udpHelper.Send(GetByte(_dataOut), ippoint.Ip, ippoint.Port);

			if (_isRecord)
				_recordFlight.RecordData(_dataOut, ResState);
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
			_svvo.Packetcam.psi = (float)(state.Angs.Psi * Math.PI / 180D);
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
						Console.Write("\r\n\r\nИнициализация модели!");
					}

					if (_startPosition.flag == 1)
					{
						_isStart = true;
						Console.Write("\r\nИдет моделирование!");
					}

					if (_startPosition.flag == 2)
					{
						_isStart = false;
						Console.Write("\r\nПауза!");
					}

					if (_startPosition.flag == -1)
					{
						_isStart = false;
						Console.Write("\r\nСтоп!");
					}


					break;

				case "ControlElement":
					ConvertHelper.ByteToObject(receivedBytes, _controlElement);
					break;

				case "ModelState":
                    {
                        ConvertHelper.ByteToObject(receivedBytes, fCSCmds);
                        Hel.FCSState.Mode = (uint)fCSCmds.Mode;
                       // Hel.FCSState.RoolLimit = fCSCmds.RoolLimit;
                        Hel.FCSState.HorSpeedReq.Activated = (byte)fCSCmds.HorSpeedReq.Activated;
                        Hel.FCSState.HorSpeedReq.Value = fCSCmds.HorSpeedReq.Value;
                        Hel.FCSState.VertSpeedReq.Activated = (byte)fCSCmds.VertSpeedReq.Activated;
                        Hel.FCSState.VertSpeedReq.Value = fCSCmds.VertSpeedReq.Value;
                        Hel.FCSState.HdgReq.Activated = (byte)fCSCmds.HdgReq.Activated;
                        Hel.FCSState.HdgReq.Value = fCSCmds.HdgReq.Value;
                        Hel.FCSState.BaroAltitudeReq.Activated = (byte)fCSCmds.BaroAltitudeReq.Activated;
                        Hel.FCSState.BaroAltitudeReq.Value = fCSCmds.BaroAltitudeReq.Value;
                    }
					break;
                default:
					if (receivedBytes.Length == 4)
					{
						_gmTerrainH = BitConverter.ToSingle(receivedBytes, 0);
					}
					break;
			}
		}

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
            while (_isSend)
            {
                QueryPerformanceCounter(out long ET);
                DeltaT = (1000.0 * ((ET) - StartTime) / ClockRate); // миллисекунды
                dt_din = Convert.ToSingle(DeltaT / 10); // 100 Гц
                dt_din2 = Convert.ToSingle(DeltaT / 20); //  50 Гц

                if (Convert.ToSingle((Math.Truncate(dt_din))) > intval100)
                {
                    if (_isStart)
                        Step(_controlElement);
                    intval100++;
                }

                if (Convert.ToSingle((Math.Truncate(dt_din2))) > intval50)
                { intval50++; }
            }
        }

        void Send()
		{
			while (_isSend)
			{
				if (_isStart)
					Step(_controlElement);
				Thread.Sleep(10);


			}
		}

		#endregion

		public void StartRecord()
		{
			if (_isRecord)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\r\n\r\nНеобходимо остановить процесс записи");
				Console.ForegroundColor = ConsoleColor.Gray;
				return;
			}
			_recordFlight = new RecordFlight();
			_isRecord = true;
		}

		public void StopRecord() 
		{
			_isRecord = false;
			_recordFlight?.Stop();
		}
	}
}