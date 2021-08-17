using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	//Классы для передачи информации через функции интерфейса:
	//Входное состояние ЛА:
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct VhclInp
	{
		public VehicleCtrl VehicleCtrl; // содержит в себе параметры органов управления
		public AirState AirState;
		public FCSState FCSState;

		public double Mass;        // полная текущая масса ЛА (кг)
		public XVECTOR3 InertialMoments; // моменты инерции ЛА относительно осей связной с.к (предполагается, что главные оси инерции совпадают со связными)
		public XVECTOR3 PosCG;         // абсолютное смещение цм. по осям связной с.к. от номинального положения (м)
	}
}