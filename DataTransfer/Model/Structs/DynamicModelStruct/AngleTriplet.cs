using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct AngleTriplet
	{
		public double Fi;
		public double Psi;
		public double Gam;
	}
}