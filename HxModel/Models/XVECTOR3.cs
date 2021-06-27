using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// Произвольный трехмерный вектор:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct XVECTOR3
	{ // в комментариях не нужнается...
		public double X;
		public double Y;
		public double Z;


	}
}
