using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElement : Base
	{
		public JoystickStruct Joystick;

		public ControlElement()
		{
			Joystick = new JoystickStruct();

			Head[67] = (byte)'a';
		}

		public override void Assign(byte[] dgram)
		{

		}

		public void UpdateRus(JoystickState joystickState)
		{
			Joystick.MasADC[0] = joystickState.X;
			Joystick.MasADC[1] = joystickState.Y;

			if (joystickState.Y > 22767)
				Joystick.MasADC[0] = (float) ((1 - joystickState.Y / 42768) * 114.99);
			else
				Joystick.MasADC[0] = (float) ((1 - joystickState.Y / 22767) * 189.99);
			Joystick.MasADC[1] = (float) ((1 - joystickState.X / 32767) * 129.99);

			//	Joystick.MasIn[82] : = (lpInfoEx.wButtons and & 00000002) shr 1;
			//	Joystick.MasIn[81] : = (lpInfoEx.wButtons and & 00000002) shr 1;
			//	uso.MasIn[20] : = (lpInfoEx.wButtons and & 00000004) shr 2;
			//	uso.MasIn[52] : = (lpInfoEx.wButtons and & 00000004) shr 2;
		}

		public void UpdatePedals(JoystickState joystickState)
		{
			Joystick.MasADC[2]  = (float)(-(1 - joystickState.Z / 32767) * 81.49);
		}

		public void UpdateRud(JoystickState joystickState)
		{
			Joystick.MasADC[3]  = (float)((65535 - joystickState.RotationZ) / 65535 * 20);
		}
	}
}