using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct XVECTOR3
	{
		public double X;
		public double Y;
		public double Z;
	}
}