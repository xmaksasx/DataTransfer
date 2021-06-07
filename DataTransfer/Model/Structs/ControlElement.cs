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

		
			if (joystickState.Y > 22767)
				Joystick.Elevator = (float) ((1 - joystickState.Y / 42768.0) * 114.99);
			else
				Joystick.Elevator = (float) ((1 - joystickState.Y / 22767.0) * 189.99);
			Joystick.Aileron = (float) ((1 - joystickState.X / 32767.0) * 129.99);

			//	Joystick.MasIn[82] : = (lpInfoEx.wButtons and & 00000002) shr 1;
			//	Joystick.MasIn[81] : = (lpInfoEx.wButtons and & 00000002) shr 1;
			//	uso.MasIn[20] : = (lpInfoEx.wButtons and & 00000004) shr 2;
			//	uso.MasIn[52] : = (lpInfoEx.wButtons and & 00000004) shr 2;
		}

		public void UpdatePedals(JoystickState joystickState)
		{
			Joystick.Rudder  = (float)(-(1 - joystickState.Z / 32767.0) * 81.49);
		}

		public void UpdateRud(JoystickState joystickState)
		{
			Joystick.Throttle  = (float)((65535.0 - joystickState.RotationZ) / 65535.0 * 20);
		}
	}
}