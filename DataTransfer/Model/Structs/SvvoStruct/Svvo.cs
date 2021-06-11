using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs.SvvoStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Svvo: Base
	{
		public Preamble Preamble;
		public HeaderSvvo Header;
		public ushort Id;
		public ushort Size;
		public CameraPosition Packetcam;

		
	}
}