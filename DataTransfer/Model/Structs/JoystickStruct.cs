using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class JoystickStruct
	{
		public int X;
		public int Y;
		public int Z;
		public int RX;
		public int RY;
		public int RZ;
		public int SL0;
		public int SL1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public int[] Buttons = new int[32];
		public int POV;
	}
}
