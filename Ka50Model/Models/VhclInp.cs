using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	/// <summary>
	/// Входное состояние ЛА
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct VhclInp
	{
		public VehicleCtrl vehicleCtrl;

		/// <summary>
		/// компоненты текущей скорости ветра, в локальной с.к. (м/c)
		/// </summary>
		public XVECTOR3 WindSpeed;

		/// <summary>
		/// полная текущая масса ЛА (кг)
		/// </summary>
		public double Mass;

		/// <summary>
		/// моменты инерции ЛА относительно осей связной с.к (предполагается, что главные оси инерции совпадают со связными)
		/// </summary>
		public XVECTOR3 InertialMoments;

		/// <summary>
		/// абсолютное смещение цм. по осям связной с.к. от номинального положения (м)
		/// </summary>
		public XVECTOR3 PosCG;


	}
}