using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Vaps
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Overload
	{
		[Description("Перегрузка")]
		public double Value;
		[Description("Минимальная перегрузка")]
		public double Min;
		[Description("Максимальная перегрузка")]
		public double Max;
	}
}
