using System.Runtime.InteropServices;

namespace HxModel.Models.FCSCommand
{
    // параметры, необходимые для работы системы управления:
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class FCSCmds:Header
    {
        public double Mode;  // режим работы системы упрвления: 0 - Direct, 1 - AugmentedStability, 2 - TrimmeredStick(Classic), 3 - Auto

        // уставочные параметры системы управления, обрабатываются только при Mode = Auto :
        public FCSCmd HorSpeedReq; // заданная горизонтальная скорость (приборная), м/с
        public FCSCmd VertSpeedReq; // заданная вертикальная скорость, м/с
        public FCSCmd HdgReq; // заданный угол курса, град
        public FCSCmd BaroAltitudeReq; // заданная барометрическая высота, м

        public double RoolLimit; // велична ограничения по углу крена, град
    }
}