using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// параметры, необходимые для работы системы управления:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct FCSState
	{
      public  uint Mode;  // режим работы системы упрвления: 0 - Direct, 1 - AugmentedStability, 2 - TrimmeredStick(Classic), 3 - Auto

        // уставочные параметры системы управления, обрабатываются только при Mode = Auto :
        public FCSValue HorSpeedReq; // заданная горизонтальная скорость (приборная), м/с
        public FCSValue VertSpeedReq; // заданная вертикальная скорость, м/с
        public FCSValue HdgReq; // заданный угол курса, град
        public FCSValue BaroAltitudeReq; // заданная барометрическая высота, м

        public double RoolLimit; // велична ограничения по углу крена, град
	}
}