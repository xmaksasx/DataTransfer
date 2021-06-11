using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct AngleTriplet
	{
		public double Fi;
		public double Psi;
		public double Gam;
	}
}