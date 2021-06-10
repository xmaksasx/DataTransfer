using System;
using System.Runtime.InteropServices;
using DataTransfer.Model.Structs.DynamicModelStruct;

namespace DataTransfer.Services.FdmManager
{
	class FdmManager
	{
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
		public static extern void GetDllVersion(IntPtr version, IntPtr release, IntPtr releaseDay, IntPtr releaseMonth, IntPtr releaseYear);

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
		public static extern void Step(double dT, IntPtr hel, IntPtr contactEnv,  IntPtr resState,  IntPtr resHel);
		KinematicsState _initialState;
		public void Init()
		{

			_initialState.AbsSpeed = new XVECTOR3() {X = 10, Y = 0, Z = 0};
			_initialState.Angs.Psi = -161;
			_initialState.Pos.Elevation = 180;
			_initialState.Pos.Latitude = 52.6618694; 
			_initialState.Pos.Longitude = 39.4261806;
			
		}

		VhclInp Hel = new VhclInp();
		ContactEnvironment ContactEnv = new ContactEnvironment();
		XVECTOR3 _windSpeed = new XVECTOR3 { X = 0, Y = 0, Z = 0 };
		XVECTOR3 _inertialMoments = new XVECTOR3 { X = 0, Y = 0, Z = 0 };
		XVECTOR3 _posCg = new XVECTOR3 { X = 0, Y = 0, Z = 0 };
		XVECTOR3 _normal = new XVECTOR3 { X = 0, Y = 1, Z = 0 };


		private KinematicsState ResState;
		private VhclOutp ResHel;
		private bool _isFirstStep = true;
		public void Step()
		{
		
			if (_isFirstStep)
			{
				var size = Marshal.SizeOf(_initialState);
				IntPtr ksPtr = Marshal.AllocHGlobal(size);
				Marshal.StructureToPtr(_initialState, ksPtr, false);
				Init(ksPtr);
				Marshal.FreeHGlobal(ksPtr);
				_isFirstStep = false;
			}
		

			ContactEnv.Elevation = 170;
			ContactEnv.Normal = _normal;
			Hel.WindSpeed = _windSpeed;
			Hel.Mass = 10800.0;
			Hel.InertialMoments = _inertialMoments;
			Hel.PosCG = _posCg;
			Hel.vehicleCtrl.CyclicPitch = 0.0;
			Hel.vehicleCtrl.CyclicRoll = 0.0;
			Hel.vehicleCtrl.Direction = 0.0;
			Hel.vehicleCtrl.Collective = 0.0;


			IntPtr ptrHel = GetIntPtr(Hel);
			IntPtr ptrCe = GetIntPtr(ContactEnv);
			IntPtr ptrRs = GetIntPtr(ResState);
			IntPtr ptrRh = GetIntPtr(ResHel);

			Step(0.01, ptrHel, IntPtr.Zero,  ptrRs,  ptrRh);

			ResState = (KinematicsState)Marshal.PtrToStructure(ptrRs, typeof(KinematicsState));
			ResHel = (VhclOutp)Marshal.PtrToStructure(ptrRh, typeof(VhclOutp));
			
			//Marshal.PtrToStructure(ptrHel, Hel);
			//Marshal.PtrToStructure(ptrRs, ResState);
			//Marshal.PtrToStructure(ptrRh, ResHel);

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
	}
}
