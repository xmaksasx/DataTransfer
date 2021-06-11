using System.Runtime.InteropServices;



namespace Ka50Model.SvvoStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Svvo
	{
		public Preamble Preamble;
		public HeaderSvvo Header;
		public ushort Id;
		public ushort Size;
		public CameraPosition Packetcam;
	}
}