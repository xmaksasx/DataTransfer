using System;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Component.Derived
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ReverseObject:Base
	{
		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}
		
	}
}
