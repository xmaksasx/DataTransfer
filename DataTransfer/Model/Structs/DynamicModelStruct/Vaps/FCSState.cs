using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Vaps
{
	// параметры, необходимые для работы системы управления:
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct FCSState
	{
		public double Mode;  // режим работы системы упрвления: 0 - Direct, 1 - AugmentedStability, 2 - TrimmeredStick(Classic), 3 - Auto

		// уставочные параметры системы управления, обрабатываются только при Mode = Auto :
		FCSValue HorSpeedReq; // заданная горизонтальная скорость (приборная), м/с
		FCSValue VertSpeedReq; // заданная вертикальная скорость, м/с
		FCSValue HdgReq; // заданный угол курса, град
		FCSValue BaroAltitudeReq; // заданная барометрическая высота, м

		public double RoolLimit; // велична ограничения по углу крена, град
	}
}