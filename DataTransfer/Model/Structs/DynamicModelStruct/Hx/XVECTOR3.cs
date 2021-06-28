using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct XVECTOR3
	{
		public double X;
		public double Y;
		public double Z;
	}
}