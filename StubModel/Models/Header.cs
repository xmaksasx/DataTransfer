using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace StubModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Header
	{
		[Description("header")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
		public byte[] Head = new byte[68];

		public byte[] GetHead(string caption)
		{
			byte[] bytesCap = Encoding.UTF8.GetBytes(caption);
			byte[] head = new byte[68];
			bytesCap.CopyTo(head, 0);
			return head;
		}

		public void GetHeadDouble(string caption)
		{
			byte[] bytesCap = Encoding.UTF8.GetBytes(caption);
			byte[] head = new byte[68];
			Array.Copy(bytesCap, 0, head, 0, bytesCap.Length);
			Array.Copy(bytesCap, 0, head, 32, bytesCap.Length);
			head[67] = 0x02;
			Head= head;
		}
	}
}
