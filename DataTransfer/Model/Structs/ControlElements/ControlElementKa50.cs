using System;
using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs.ControlElements
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElementKa50:ControlElement
	{
	

		public ControlElementKa50()
		{
			_cyclicStepHandleLeft = new CyclicStepHandle();
			_cyclicStepHandleRight = new CyclicStepHandle();
			_generalStepHandleLeft = new GeneralStepHandle();
			_generalStepHandleRight = new GeneralStepHandle();
			_pedalsLeft = new Pedals();
			_pedalsRight = new Pedals();
		}
	
		#region Органы управления Ka50

		public override void UpdateRus(JoystickState joystickState)
		{
			_cyclicStepHandleLeft.BtnJoystickY = 0;
			_cyclicStepHandleLeft.BtnJoystickX = 0;
			_cyclicStepHandleLeft.BtnGhPosition = 0;
			_cyclicStepHandleLeft.BtnGh = Convert.ToInt32(joystickState.Buttons[18]);
			switch (joystickState.PointOfViewControllers[0])
			{
				case 0:
					_cyclicStepHandleLeft.BtnGhPosition = 1;
					break;
				case 9000:
					_cyclicStepHandleLeft.BtnGhPosition = 2;
					break;
				case 18000:
					_cyclicStepHandleLeft.BtnGhPosition = 3;
					break;
				case 27000:
					_cyclicStepHandleLeft.BtnGhPosition = 4;
					break;
			}

			if (joystickState.Buttons[10])
				_cyclicStepHandleLeft.BtnJoystickY = 1;
			if (joystickState.Buttons[11])
				_cyclicStepHandleLeft.BtnJoystickX = 1;
			if (joystickState.Buttons[12])
				_cyclicStepHandleLeft.BtnJoystickY = -1;
			if (joystickState.Buttons[13])
				_cyclicStepHandleLeft.BtnJoystickX = -1;

			_cyclicStepHandleLeft.BtnAutopilotOff = Convert.ToInt32(joystickState.Buttons[1]);
			_cyclicStepHandleLeft.BtnTrim = Convert.ToInt32(joystickState.Buttons[14]);
			_cyclicStepHandleLeft.BtnHover = Convert.ToInt32(joystickState.Buttons[2]);
			_cyclicStepHandleLeft.BtnCargoOff = Convert.ToInt32(joystickState.Buttons[0]);
			_cyclicStepHandleLeft.BtnWheelBrake = Convert.ToInt32(joystickState.Buttons[3]);
			_cyclicStepHandleLeft.Elevator = (float)(1 - (65535.0 - joystickState.Y) / 65535.0 * 1);
			_cyclicStepHandleLeft.Aileron = (float)(1 - (65535.0 - joystickState.X) / 65535.0 * 1);
		}

		public override void UpdatePedals(JoystickState joystickState)
		{
			_pedalsLeft.Pedal = (float)(-(1 - joystickState.Z / 32767.0) * 81.49);
		}

		public override void UpdateRud(JoystickState joystickState)
		{

			_generalStepHandleLeft.BtnGh = Convert.ToInt32(joystickState.Buttons[1]);

			if (joystickState.Buttons[18])
				_generalStepHandleLeft.BtnMode1 = 0;
			else
				_generalStepHandleLeft.BtnMode1 = 1;
			if (!joystickState.Buttons[18] && joystickState.Buttons[31])
				_generalStepHandleLeft.BtnMode1 = 2;

			if (joystickState.Buttons[17])
				_generalStepHandleLeft.BtnMode2 = 0;
			else
				_generalStepHandleLeft.BtnMode2 = 1;
			if (!joystickState.Buttons[18] && joystickState.Buttons[30])
				_generalStepHandleLeft.BtnMode2 = 2;

			_generalStepHandleLeft.BtnStabilizer = Convert.ToInt32(joystickState.Buttons[19]);
			_generalStepHandleLeft.BtnCargoOff = Convert.ToInt32(joystickState.Buttons[20]);
			_generalStepHandleLeft.BtnTrigger = Convert.ToInt32(joystickState.Buttons[14]);
			_generalStepHandleLeft.EmergencyBrakeEng1 = 0;
			_generalStepHandleLeft.EmergencyBrakeEng2 = 0;
			_generalStepHandleLeft.EmergencyBrakeRotor = 0;
			_generalStepHandleLeft.GeneralStep = (float)((65535.0 - joystickState.Z) / 65535.0 * 1);
			_generalStepHandleLeft.Throttle1 = 0;
			_generalStepHandleLeft.Throttle2 = 0;
		}

		public  void Update(byte[] bytes)
		{
			ConvertHelper.ByteToObject(bytes, this);
			//_generalStepHandleLeft.GeneralStep = (float)((65535.0 - joystickState.Z) / 65535.0 * 1);
			//_pedalsLeft.Pedal = (float)(-(1 - joystickState.Z / 32767.0) * 81.49);
			//_cyclicStepHandleLeft.Elevator = (float)(1 - (65535.0 - joystickState.Y) / 65535.0 * 1);
			//_cyclicStepHandleLeft.Aileron = (float)(1 - (65535.0 - joystickState.X) / 65535.0 * 1);
		}

	

		#endregion
	}
}
