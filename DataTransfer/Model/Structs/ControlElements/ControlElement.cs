using System;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs.ControlElements
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	abstract class ControlElement : Base
	{
		protected int Channel;
		protected CyclicStepHandle _cyclicStepHandleLeft;
		protected CyclicStepHandle _cyclicStepHandleRight;
		protected GeneralStepHandle _generalStepHandleLeft;
		protected GeneralStepHandle _generalStepHandleRight;
		protected Pedals _pedalsLeft;
		protected Pedals _pedalsRight;

	
		protected override void SetHead()
		{
			GetHeadDouble("ControlElement");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 4)
				Array.Reverse(dgram, i, 4);
		}

		public virtual void UpdateRus(JoystickState joystickState)
		{
		}

		public virtual void UpdatePedals(JoystickState joystickState)
		{
		}

		public virtual void UpdateRud(JoystickState joystickState)
		{
		}

		public void Update(byte[] bytes)
		{
		}
	}
}