using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs.ControlElements
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class EthernetControlElement: Base
	{

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public float[] Sliders = new float[16];

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 54)]
		public short[] Buttons = new short[54];
	}
}
