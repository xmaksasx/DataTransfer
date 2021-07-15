using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// Параметры органов управления аппаратом:
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct VehicleCtrl
	{
		public double CyclicPitch;     // нормированное положение органа управления в продольном канале, б/р, 0 – 1, 0 соответствует крайнему положению от себя, 1 – на себя
		public double CyclicRoll;      // нормированное положение органа управления в поперечном канале, б/р, 0 – 1, 0 соответствует крайнему левому положению, 1 – правому

		public double Direction;   // нормированное положение органа управления в путевом канале, б/р, 0 – 1,  0 соответствует крайнему левому положению, 1 – правому
		public double Collective;      // нормированное положение органа управления в канале общего шага, б/р, 0 – 1, 0 соответствует нижнему положению, 1 – верхнему

		// управляющие состояния стоек шасси: передней, левой задней и правой задней соответственно:
		public GearState NoseGear;
		public GearState MainGearLeft;
		public GearState MainGearRight;

		public byte Trimmer; // признак нажатия кнопки триммера продольно-поперечного упрвления
		public byte Friction; // признак нажатия кнопки фиркциона общего шага

		public double AltimeterBaroPressure; // давление, установленное на барометрическом высотомере, ммрс
	}
}