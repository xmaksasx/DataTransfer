﻿using System.Runtime.InteropServices;

using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs.DynamicModelStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	abstract class DynamicModel : Base
	{
		public virtual byte[] GetPosition()
		{
			return new byte[1];
		}
	}
}
