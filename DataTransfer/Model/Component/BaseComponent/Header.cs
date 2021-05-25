using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace DataTransfer.Model.Component.BaseComponent
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Header
	{
		[Description("header")]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
		public byte[] Head = new byte[68];
		public byte[] GetHead(string caption)
		{
			byte[] bytesCap = Encoding.UTF8.GetBytes(caption);
			byte[] head = new byte[68];
			bytesCap.CopyTo(head, 0);
			return head;
		}

	}
}
