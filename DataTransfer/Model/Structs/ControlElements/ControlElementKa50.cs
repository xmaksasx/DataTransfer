using System;
using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs.ControlElements
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElementKa50 : ControlElement
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
			_cyclicStepHandleLeft.Elevator = (float) (1 - (65535.0 - joystickState.Y) / 65535.0 * 1);
			_cyclicStepHandleLeft.Aileron = (float) (1 - (65535.0 - joystickState.X) / 65535.0 * 1);
		}

		public override void UpdatePedals(JoystickState joystickState)
		{
			_pedalsLeft.Pedal = (float) (-(1 - joystickState.Z / 32767.0) * 81.49);
		}

		public override void UpdateRud(JoystickState joystickState)
		{

			_generalStepHandleLeft.BtnGh = Convert.ToInt32(joystickState.Buttons[1]);

			if (joystickState.Buttons[2])
				_generalStepHandleLeft.BtnGhPosition = 1;
			else if (joystickState.Buttons[3])
				_generalStepHandleLeft.BtnGhPosition = 2;
			else if (joystickState.Buttons[4])
				_generalStepHandleLeft.BtnGhPosition = 3;
			else if (joystickState.Buttons[5])
				_generalStepHandleLeft.BtnGhPosition = 4;
			else
				_generalStepHandleLeft.BtnGhPosition = 0;

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
			_generalStepHandleLeft.GeneralStep = (float) ((65535.0 - joystickState.Z) / 65535.0 * 1);
			_generalStepHandleLeft.Throttle1 = 0;
			_generalStepHandleLeft.Throttle2 = 0;

			_pedalsLeft.Pedal = (float) ((65535.0 - joystickState.Sliders[0]) / 65535.0 * 1);
		}

		public void Update(byte[] bytes)
		{
			ConvertHelper.ByteToObject(bytes, this);
			//_generalStepHandleLeft.GeneralStep = (float)((65535.0 - joystickState.Z) / 65535.0 * 1);
			//_pedalsLeft.Pedal = (float)(-(1 - joystickState.Z / 32767.0) * 81.49);
			//_cyclicStepHandleLeft.Elevator = (float)(1 - (65535.0 - joystickState.Y) / 65535.0 * 1);
			//_cyclicStepHandleLeft.Aileron = (float)(1 - (65535.0 - joystickState.X) / 65535.0 * 1);
		}



		public override void UpdateRus(EthernetControlElement joystickState)
		{
			//тангаж на себя=675 от себя = 488
			//крен влево = 455 вправо=610
			//педали: левая=545 правая=410
			//ош: вниз=990 вверх=770
			//рудлев: на себя = 694 от себя = 948
			//рудправ: на себя = 627 от себя = 972
			//тормоз: не нажат = 15 нажат=300

			//РАДИО НАЖАТИЕ
			_cyclicStepHandleLeft.BtnGh = 1 - joystickState.Buttons[30];

			_cyclicStepHandleLeft.BtnGhPosition = 0;
			//ФАРА ВВЕРХ
			if (joystickState.Buttons[31] == 0)
				_cyclicStepHandleLeft.BtnGhPosition = 1;
			//ФАРА ВЛЕВО
			if (joystickState.Buttons[28] == 0)
				_cyclicStepHandleLeft.BtnGhPosition = 2;
			//ФАРА ВНИЗ
			if (joystickState.Buttons[29] == 0)
				_cyclicStepHandleLeft.BtnGhPosition = 3;
			//ФАРА ВПРАВО
			if (joystickState.Buttons[32] == 0)
				_cyclicStepHandleLeft.BtnGhPosition = 4;


			//ФАРА ВЛЕВО
			_cyclicStepHandleLeft.BtnJoystickX = -(1 - joystickState.Buttons[25]);
			//ФАРА ВНИЗ
			_cyclicStepHandleLeft.BtnJoystickY = -(1 - joystickState.Buttons[26]);
			//ФАРА ВВЕРХ
			_cyclicStepHandleLeft.BtnJoystickX = 1 - joystickState.Buttons[24];
			//ФАРА ВПРАВО
			_cyclicStepHandleLeft.BtnJoystickY = 1 - joystickState.Buttons[27];


			//ОТКЛ АП
			_cyclicStepHandleLeft.BtnAutopilotOff = 1 - joystickState.Buttons[23];
			//ТРИМ УГЛОВ
			_cyclicStepHandleLeft.BtnTrim = 1 - joystickState.Buttons[12];
			//ВИСЕНИЕ
			_cyclicStepHandleLeft.BtnHover = 1 - joystickState.Buttons[20];

			_cyclicStepHandleLeft.BtnCargoOff = 0;
			_cyclicStepHandleLeft.BtnWheelBrake = 0;

			//тангаж на себя=675 от себя = 488
			//крен влево = 455 вправо=610
			//педали: левая=545 правая=410
			//ош: вниз=990 вверх=770
			//рудлев: на себя = 694 от себя = 948
			//рудправ: на себя = 627 от себя = 972
			//тормоз: не нажат = 15 нажат=300

			//ТАНГАЖ
			_cyclicStepHandleLeft.Elevator = (float)map(joystickState.Sliders[8], 488, 675, 0.0, 1.0);
			//КРЕН
			_cyclicStepHandleLeft.Aileron = (float)map(joystickState.Sliders[9], 610, 455, 0.0, 1.0);
			//ПЕДАЛИ
			_pedalsLeft.Pedal = (float)map(joystickState.Sliders[10], 545, 410, 0.0, 1.0);

		}

		public override void UpdateRud(EthernetControlElement joystickState)
		{
			//тангаж на себя=675 от себя = 488
			//крен влево = 455 вправо=610
			//педали: левая=545 правая=410
			//ош: вниз=990 вверх=770
			//рудлев: на себя = 694 от себя = 948
			//рудправ: на себя = 627 от себя = 972
			//тормоз: не нажат = 15 нажат=300

			//ФАРА НАЖАТИЕ
			_generalStepHandleLeft.BtnGh = Convert.ToInt32(joystickState.Buttons[48]);

			_generalStepHandleLeft.BtnGhPosition = 0;

			//ФАРА ВВЕРХ
			if (joystickState.Buttons[47] == 0)
				_generalStepHandleLeft.BtnGhPosition = 1;
			//ФАРА ВПРАВО
			if (joystickState.Buttons[49] == 0)
				_generalStepHandleLeft.BtnGhPosition = 2;
			//ФАРА ВНИЗ
			if (joystickState.Buttons[46] == 0)
				_generalStepHandleLeft.BtnGhPosition = 3;
			//ФАРА ВЛЕВО
			if (joystickState.Buttons[45] == 0)
				_generalStepHandleLeft.BtnGhPosition = 4;

			//??????
			_generalStepHandleLeft.BtnMode1 = 0;
			//??????
			_generalStepHandleLeft.BtnMode2 = 0;

			//ТРИМ ВЫС
			_generalStepHandleLeft.BtnStabilizer = 1 - joystickState.Buttons[11];
			//АВАР СБРОС
			_generalStepHandleLeft.BtnCargoOff = 1 - joystickState.Buttons[6];

			//??????
			_generalStepHandleLeft.BtnTrigger = 0;

			//СТОП ЛЕВ ЗАКРЫТО
			_generalStepHandleLeft.EmergencyBrakeEng1 = 1 - joystickState.Buttons[7];
			//СТОП ПРАВ ЗАКРЫТО
			_generalStepHandleLeft.EmergencyBrakeEng2 = 1 - joystickState.Buttons[8];
			//РУД ТОРМОЗ ЗАТОРМОЖЕНО
			_generalStepHandleLeft.EmergencyBrakeRotor = 1 - joystickState.Buttons[9];
			//РОШ
			_generalStepHandleLeft.GeneralStep = (float)map(joystickState.Sliders[11], 990, 770, 0.0, 1.0);
			//РУД ЛЕВ
			_generalStepHandleLeft.Throttle1 = (float)map(joystickState.Sliders[12], 694, 948, 0.0, 1.0);
			//РУД ПРАВ
			_generalStepHandleLeft.Throttle2 = (float)map(joystickState.Sliders[13], 972, 948, 0.0, 1.0);


		}

		private double map(double x, double inMin, double inMax, double outMin, double outMax)
		{
			return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		}

		#endregion
	}
}