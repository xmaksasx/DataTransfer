using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// Рассчитанное результирующее состояние ЛА:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct VhclOutp
	{
		public InstrumentsState InstrumentsState;

		// рассчитанные параметры стоек шасси, левой передней, правой передней, левой задней и правой задней соответственно: 
		public GearRes NoseGear;
		public GearRes MainGearLeft;
		public GearRes MainGearRight;

		// состояния встроенных моделей двигателей, описанные классом Eng, левого и правого соответственно: 
		public Eng EngLeft;
		public Eng EngRight;
	}
}
