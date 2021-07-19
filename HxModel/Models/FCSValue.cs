using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// вспомогательный класс - значение уставочного параметра автоматической системы управления:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct FCSValue
	{
        public double Value; // величина параметра
        public byte Activated; // признак активности данного параметра
	}
}
