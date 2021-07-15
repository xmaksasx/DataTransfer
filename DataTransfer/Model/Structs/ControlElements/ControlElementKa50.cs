using System;
using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Structs.Brunner;
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

		#region Джойстик

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

        #endregion

        #region Сеть и брюннер

        public override void UpdateRus(EthernetControlElement joystickState, CLSEState clseState)
		{
			#region Левый РУС

			//тангаж на себя=675 от себя = 488
			//крен влево = 455 вправо=610
			//педали: левая=545 правая=410
			//ош: вниз=990 вверх=770
			//рудлев: на себя = 694 от себя = 948
			//рудправ: на себя = 627 от себя = 972
			//тормоз: не нажат = 15 нажат=300

			//РАДИО НАЖАТИЕ
			_cyclicStepHandleLeft.BtnGh = 1 - joystickState.Buttons[31];

            _cyclicStepHandleLeft.BtnGhPosition = 0;
            //ФАРА ВВЕРХ
            if (joystickState.Buttons[30] == 0)
                _cyclicStepHandleLeft.BtnGhPosition = 1;
            //ФАРА ВЛЕВО
            if (joystickState.Buttons[32] == 0)
                _cyclicStepHandleLeft.BtnGhPosition = 2;
            //ФАРА ВНИЗ
            if (joystickState.Buttons[29] == 0)
                _cyclicStepHandleLeft.BtnGhPosition = 3;
            //ФАРА ВПРАВО
            if (joystickState.Buttons[28] == 0)
                _cyclicStepHandleLeft.BtnGhPosition = 4;


            //ФАРА ВЛЕВО
            _cyclicStepHandleLeft.BtnJoystickX = -(1 - joystickState.Buttons[25]);
            //ФАРА ВНИЗ
            _cyclicStepHandleLeft.BtnJoystickY = -(1 - joystickState.Buttons[26]);
            //ФАРА ВВЕРХ
            _cyclicStepHandleLeft.BtnJoystickX = 1 - joystickState.Buttons[27];
            //ФАРА ВПРАВО
            _cyclicStepHandleLeft.BtnJoystickY = 1 - joystickState.Buttons[24];


            //ОТКЛ АП
            _cyclicStepHandleLeft.BtnAutopilotOff = 1 - joystickState.Buttons[23];
            //ТРИМ УГЛОВ
            _cyclicStepHandleLeft.BtnTrim = 1 - joystickState.Buttons[12];
            //ВИСЕНИЕ
            _cyclicStepHandleLeft.BtnHover = 1 - joystickState.Buttons[20];

            _cyclicStepHandleLeft.BtnCargoOff = 1 - joystickState.Buttons[22];
            _cyclicStepHandleLeft.BtnWheelBrake = 0;

            //ТАНГАЖ
            _cyclicStepHandleLeft.Elevator = (float)Map(joystickState.Sliders[8], 488, 675, 0.0, 1.0);
			//КРЕН
			_cyclicStepHandleLeft.Aileron = (float)Map(joystickState.Sliders[9], 455, 610, 0.0, 1.0);
			//ПЕДАЛИ
			_pedalsLeft.Pedal = (float)Map(joystickState.Sliders[10], 545, 410, 0.0, 1.0);

            #endregion

            #region Правый РУС

            //РАДИО НАЖАТИЕ
            if (clseState.Buttons == 262144)
                _cyclicStepHandleRight.BtnGh = 1;

            _cyclicStepHandleRight.BtnGhPosition = 0;
            //ФАРА ВВЕРХ
            if (clseState.Buttons == 2147483648)
                _cyclicStepHandleRight.BtnGhPosition = 1;
            //ФАРА ВЛЕВО
            if (clseState.Buttons == 268435456)
                _cyclicStepHandleRight.BtnGhPosition = 2;
            //ФАРА ВНИЗ
            if (clseState.Buttons == 1073741824)
                _cyclicStepHandleRight.BtnGhPosition = 3;
            //ФАРА ВПРАВО
            if (clseState.Buttons == 536870912)
                _cyclicStepHandleRight.BtnGhPosition = 4;


            //ФАРА ВВЕРХ
            if (clseState.Buttons == 1024)
                _cyclicStepHandleRight.BtnJoystickY = 1;
            //ФАРА ВПРАВО
            if (clseState.Buttons == 2048)
                _cyclicStepHandleRight.BtnJoystickX = 1;
            //ФАРА ВНИЗ
            if (clseState.Buttons == 4096)
                _cyclicStepHandleRight.BtnJoystickY = -1;
            //ФАРА ВЛЕВО  
            if (clseState.Buttons == 8192)
                _cyclicStepHandleRight.BtnJoystickX = -1;


            //ОТКЛ АП
            if (clseState.Buttons == 2)
                _cyclicStepHandleRight.BtnAutopilotOff = 1;
            //ТРИМ УГЛОВ
            if (clseState.Buttons == 1)
                _cyclicStepHandleRight.BtnTrim = 1;
            //ВИСЕНИЕ
            _cyclicStepHandleRight.BtnHover = 0;

            if (clseState.Buttons == 4)
                _cyclicStepHandleRight.BtnCargoOff = 1;
            if (clseState.Buttons == 8)
                _cyclicStepHandleRight.BtnWheelBrake = 0;

            //ТАНГАЖ
            _cyclicStepHandleRight.Elevator = (float)clseState.PositionZ;
            //КРЕН
            _cyclicStepHandleRight.Aileron = (float)clseState.PositionX;
            //ПЕДАЛИ
            _pedalsRight.Pedal = (float)Map(joystickState.Sliders[10], 545, 410, 0.0, 1.0);
            #endregion
        }

        public override void UpdateRud(EthernetControlElement joystickState)
		{
			#region Левый РУД

			//тангаж на себя=675 от себя = 488
			//крен влево = 455 вправо=610
			//педали: левая=545 правая=410
			//ош: вниз=990 вверх=770
			//рудлев: на себя = 694 от себя = 948
			//рудправ: на себя = 627 от себя = 972
			//тормоз: не нажат = 15 нажат=300

			//ФАРА НАЖАТИЕ
			_generalStepHandleLeft.BtnGh = Convert.ToInt32(joystickState.Buttons[39]);

            _generalStepHandleLeft.BtnGhPosition = 0;

            //ФАРА ВВЕРХ
            if (joystickState.Buttons[40] == 0)
                _generalStepHandleLeft.BtnGhPosition = 1;
            //ФАРА ВПРАВО
            if (joystickState.Buttons[37] == 0)
                _generalStepHandleLeft.BtnGhPosition = 2;
            //ФАРА ВНИЗ
            if (joystickState.Buttons[36] == 0)
                _generalStepHandleLeft.BtnGhPosition = 3;
            //ФАРА ВЛЕВО
            if (joystickState.Buttons[38] == 0)
                _generalStepHandleLeft.BtnGhPosition = 4;

            //??????
            _generalStepHandleLeft.BtnMode1 = 0;
            //??????
            _generalStepHandleLeft.BtnMode2 = 0;

            //ТРИМ ВЫС
            _generalStepHandleLeft.BtnStabilizer = 1 - joystickState.Buttons[11];
            //АВАР СБРОС
            _generalStepHandleLeft.BtnCargoOff = 0;

            //??????
            _generalStepHandleLeft.BtnTrigger = 0;

            //СТОП ЛЕВ ЗАКРЫТО
            _generalStepHandleLeft.EmergencyBrakeEng1 = 1 - joystickState.Buttons[7];
            //СТОП ПРАВ ЗАКРЫТО
            _generalStepHandleLeft.EmergencyBrakeEng2 = 1 - joystickState.Buttons[8];
            //РУД ТОРМОЗ ЗАТОРМОЖЕНО
            _generalStepHandleLeft.EmergencyBrakeRotor = 1 - joystickState.Buttons[9];
            //РОШ
            _generalStepHandleLeft.GeneralStep = (float)Map(joystickState.Sliders[11], 990, 770, 0.0, 1.0);
			//РУД ЛЕВ
			_generalStepHandleLeft.Throttle1 = (float)Map(joystickState.Sliders[12], 694, 948, 0.0, 1.0);
			//РУД ПРАВ
			_generalStepHandleLeft.Throttle2 = (float)Map(joystickState.Sliders[13], 972, 948, 0.0, 1.0);

            #endregion

            #region Правый РУД

            //тангаж на себя=675 от себя = 488
            //крен влево = 455 вправо=610
            //педали: левая=545 правая=410
            //ош: вниз=990 вверх=770
            //рудлев: на себя = 694 от себя = 948
            //рудправ: на себя = 627 от себя = 972
            //тормоз: не нажат = 15 нажат=300

            //ФАРА НАЖАТИЕ
            _generalStepHandleRight.BtnGh = Convert.ToInt32(joystickState.Buttons[47]);

            _generalStepHandleRight.BtnGhPosition = 0;

            //ФАРА ВВЕРХ
            if (joystickState.Buttons[48] == 0)
                _generalStepHandleRight.BtnGhPosition = 1;
            //ФАРА ВПРАВО
            if (joystickState.Buttons[49] == 0)
                _generalStepHandleRight.BtnGhPosition = 2;
            //ФАРА ВНИЗ
            if (joystickState.Buttons[46] == 0)
                _generalStepHandleRight.BtnGhPosition = 3;
            //ФАРА ВЛЕВО
            if (joystickState.Buttons[45] == 0)
                _generalStepHandleRight.BtnGhPosition = 4;


            _generalStepHandleRight.BtnMode1 = 0;
            if (joystickState.Buttons[2] == 0)
            {
                _generalStepHandleRight.BtnMode1 = 1;
            }
            if (joystickState.Buttons[3] == 0)
            {
                _generalStepHandleRight.BtnMode1 = 2;
            }

            _generalStepHandleRight.BtnMode2 = 0;
            if (joystickState.Buttons[4] == 0)
            {
                _generalStepHandleRight.BtnMode2 = 1;
            }
            if (joystickState.Buttons[5] == 0)
            {
                _generalStepHandleRight.BtnMode2 = 2;
            }


            //ТРИМ ВЫС
            _generalStepHandleRight.BtnStabilizer = 0;
            //АВАР СБРОС
            _generalStepHandleRight.BtnCargoOff = 1 - joystickState.Buttons[6];

            //??????
            _generalStepHandleRight.BtnTrigger = 0;

            //СТОП ЛЕВ ЗАКРЫТО
            _generalStepHandleRight.EmergencyBrakeEng1 = 1 - joystickState.Buttons[7];
            //СТОП ПРАВ ЗАКРЫТО
            _generalStepHandleRight.EmergencyBrakeEng2 = 1 - joystickState.Buttons[8];
            //РУД ТОРМОЗ ЗАТОРМОЖЕНО
            _generalStepHandleRight.EmergencyBrakeRotor = 1 - joystickState.Buttons[9];
            //РОШ
            _generalStepHandleRight.GeneralStep = (float)Map(joystickState.Sliders[11], 990, 770, 0.0, 1.0);
            //РУД ЛЕВ
            _generalStepHandleRight.Throttle1 = (float)Map(joystickState.Sliders[12], 694, 948, 0.0, 1.0);
            //РУД ПРАВ
            _generalStepHandleRight.Throttle2 = (float)Map(joystickState.Sliders[13], 972, 948, 0.0, 1.0);

            #endregion
        }
        #endregion
	}
}