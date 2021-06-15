using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{  
	/// <summary>
	/// Рассчитанное результирующее состояние ЛА
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class VhclOutp
	{
		public VhclOutp()
		{
			
		}

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