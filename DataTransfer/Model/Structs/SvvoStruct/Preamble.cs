using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.SvvoStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct Preamble
	{
		ushort wSync;
		byte ProtVers;
		ushort wLength;
	};
}