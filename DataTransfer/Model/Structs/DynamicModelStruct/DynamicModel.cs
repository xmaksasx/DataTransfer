﻿using System.Runtime.InteropServices;

using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;

namespace DataTransfer.Model.Structs.DynamicModelStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	abstract class DynamicModel : Base
	{
		public virtual byte[] GetPosition()
		{
			return new byte[1];
		}

		public virtual byte[] GetForVaps(DynamicModelToVaps modelToVaps)
		{
			return new byte[1];
		}
	}
}
