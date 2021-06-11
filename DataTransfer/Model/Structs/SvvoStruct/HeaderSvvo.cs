using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.SvvoStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct HeaderSvvo
	{
		ushort _type;
		int Number;
		int Flag;
		int Res;
	};
}