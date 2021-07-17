using System.Runtime.InteropServices;

namespace StubModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct HeaderSvvo
	{
		public ushort _type;
		public int Number;
		public int Flag;
		public int Res;
	};
}