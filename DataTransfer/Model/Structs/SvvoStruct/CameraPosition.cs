using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.SvvoStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct CameraPosition
	{
		double x;
		double z;
		float ht;
		float tet;
		float psi;
		float gam;
		byte flag;
	};
}
