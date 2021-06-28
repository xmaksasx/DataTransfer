using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;
using System;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs
{
	// параметры, необходимые для работы системы управления:
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ModelState : Base
	{
		public FCSState FCSState;
		protected override void SetHead()
		{
			GetHeadDouble("ModelState");
		}
		public override void Reverse(ref byte[] dgram)
		{
			
			for (int i = 68; i < dgram.Length; i = i + 4)
				Array.Reverse(dgram, i, 4);
		}
	}
}