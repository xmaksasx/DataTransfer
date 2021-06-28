using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// Рассчитанное результирующее состояние ЛА:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	class VhclOutp
	{
		public InstrumentsState InstrumentsState = new InstrumentsState();

		// рассчитанные параметры стоек шасси, левой передней, правой передней, левой задней и правой задней соответственно: 
		public GearRes NoseGear = new GearRes();
		public GearRes MainGearLeft = new GearRes();
		public GearRes MainGearRight = new GearRes();

		// состояния встроенных моделей двигателей, описанные классом Eng, левого и правого соответственно: 
		public Eng EngLeft = new Eng();
		public Eng EngRight = new Eng();
	}
}
