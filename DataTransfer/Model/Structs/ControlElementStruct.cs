using System.Runtime.InteropServices;
using DataTransfer.Model.Component.Derived;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElementStruct : JoystickObject
	{
		public JoystickStruct Rus;
		public JoystickStruct Rud;

		public ControlElementStruct()
		{
			Rus= new JoystickStruct();
			Rud = new JoystickStruct();
		}
		public override void Assign(byte[] dgram)
		{

		}


		public void UpdateRus(JoystickState joystickState)
		{
			Rus.X = joystickState.X;
			Rus.Y = joystickState.Y;
			for (int i = 0; i < joystickState.Buttons.Length; i++)
				if (joystickState.Buttons[i])
					Rus.Buttons[i] = 1;
		}
		public void UpdateRud(JoystickState joystickState)
		{
			Rud.SL0 = joystickState.Z;
			Rud.SL1 = joystickState.RotationZ;
			Rud.X = joystickState.X;
			Rud.Y = joystickState.Y;
			for (int i = 0; i < Rud.Buttons.Length; i++)
				if (joystickState.Buttons[i])
					Rud.Buttons[i] = 1;
				else
					Rud.Buttons[i] = 0;
		}
	}
}