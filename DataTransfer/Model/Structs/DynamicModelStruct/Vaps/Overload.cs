using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Vaps
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Overload
	{
		[Description("Перегрузка")]
		double Value;
		[Description("Минимальная перегрузка")]
		double Min;
		[Description("Максимальная перегрузка")]
		double Max;
	}
}
