namespace DataTransfer.Model.Structs.SvvoStruct
{

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

	struct Preamble
	{
		ushort wSync;
		byte ProtVers;
		ushort wLength;
	};

	struct HeaderSvvo
	{
		ushort _type;
		int Number;
		int Flag;
		int Res;
	};

	struct tpacket_cam
	{
		public Preamble Preamble;
		public HeaderSvvo Header;
		public ushort Id;
		public ushort Size;
		public CameraPosition Packetcam;
	};
}
