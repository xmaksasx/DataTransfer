﻿using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class XVECTOR3
	{
		public double X;
		public double Y;
		public double Z;
	}
}