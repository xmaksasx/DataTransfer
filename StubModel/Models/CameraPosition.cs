using System.Runtime.InteropServices;

namespace StubModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct CameraPosition
	{
		public double x;
		public double z;
		public float ht;
		public float tet;
		public float psi;
		public float gam;
		public byte flag;
	};
}
