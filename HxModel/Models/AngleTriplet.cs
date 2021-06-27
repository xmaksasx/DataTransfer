using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// тройка углов Эйлера
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct AngleTriplet
	{
		public double Fi;
		public double Psi;
		public double Gam;
	}
}
