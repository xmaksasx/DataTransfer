using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// Рассчитанное результирующее состояние ЛА:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct VhclOutp
	{
		public InstrumentsState InstrumentsState;

		// рассчитанные параметры стоек шасси, левой передней, правой передней, левой задней и правой задней соответственно: 
		GearRes NoseGear;
		GearRes MainGearLeft;
		GearRes MainGearRight;

		// состояния встроенных моделей двигателей, описанные классом Eng, левого и правого соответственно: 
		Eng EngLeft;
		Eng EngRight;
	}
}
