using System.Runtime.InteropServices;

namespace HxModel.Models.FCSCommand
{
    // вспомогательный класс - значение уставочного параметра автоматической системы управления:
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct FCSCmd
    {
        public double Value; // величина параметра
        public double Activated; // признак активности данного параметра
    }
}
