using System;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.Brunner;
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


        public void SetChannel(int channel)
        {
            Channel = channel;
        }
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

		public virtual void UpdateRud(JoystickState joystickState)
		{
		}


		public virtual void UpdateRus(EthernetControlElement joystickState, CLSEState clseState)
		{
		}

		public virtual void UpdateRud(EthernetControlElement joystickState)
		{
		}

		protected double Map(double x, double inMin, double inMax, double outMin, double outMax)
		{
			return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		}
	}
}