using System.Runtime.InteropServices;

namespace Ka50Model.Models
{  
	/// <summary>
	/// Рассчитанное результирующее состояние ЛА
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct VhclOutp
	{

		#region Рассчитанные параметры стоек шасси

		private GearRes NoseGear;
		private GearRes MainGearLeft;
		private GearRes MainGearRight;

		#endregion

		#region Состояния встроенных моделей двигателей

		private Eng EngLeft;
		private Eng EngRight;

		#endregion

		/// <summary>
		/// обороты несущей системы, % от номинального
		/// </summary>
		private double RotorRPM;

		/// <summary>
		/// результирующий общий шаг несущей системы, град
		/// </summary>
		private double CollectivePitch;
	}
}