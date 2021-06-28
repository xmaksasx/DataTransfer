using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// вспомогательный класс - значение уставочного параметра автоматической системы управления:
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct FCSValue
	{
		double Value; // величина параметра
		double Activated; // признак активности данного параметра
	}
}
