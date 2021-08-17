using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// вспомогательный класс - значение уставочного параметра автоматической системы управления:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct FCSValue
	{
        public double Value; // величина параметра
        public byte Activated; // признак активности данного параметра
	}
}
