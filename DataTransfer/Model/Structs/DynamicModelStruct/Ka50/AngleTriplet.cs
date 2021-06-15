using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class AngleTriplet
	{
		public double Fi;
		public double Psi;
		public double Gam;
	}
}