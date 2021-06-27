﻿using System.Runtime.InteropServices;

namespace HxModel.SvvoStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct Preamble
	{
		public ushort wSync;
		public byte ProtVers;
		public ushort wLength;
	};
}