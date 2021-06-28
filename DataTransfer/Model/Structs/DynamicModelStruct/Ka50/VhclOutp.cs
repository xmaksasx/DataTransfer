using System.ComponentModel;
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

		public GearRes NoseGear = new GearRes();
		public GearRes MainGearLeft = new GearRes();
		public GearRes MainGearRight = new GearRes();

		#endregion

		#region Состояния встроенных моделей двигателей

		public Eng EngLeft = new Eng();
		public Eng EngRight = new Eng();

		#endregion

		/// <summary>
		/// обороты несущей системы, % от номинального
		/// </summary>
		[Description("обороты несущей системы, % от номинального")]
		public double RotorRPM;

		/// <summary>
		/// результирующий общий шаг несущей системы, град
		/// </summary>
		[Description("результирующий общий шаг несущей системы, градо")]
		public double CollectivePitch;
	}
}