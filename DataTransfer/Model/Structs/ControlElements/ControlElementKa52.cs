using System;
using System.Runtime.InteropServices;
using DataTransfer.Model.Structs.Brunner;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs.ControlElements
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElementKa52 : ControlElement
	{
		public ControlElementKa52()
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

			var tang_in_0 = 12768.0;
			var tang_in_dead = 0;
			var tang_in_max = 65535.0;
			var tang_v_min = -114.99;
			var tang_v_max = 189.99;
			var tang_gamma = 2.0;
			double tang_in_v = joystickState.Y;
			tang_in_v = tang_in_max - tang_in_v;
			var out_v = 0.0;
			if (tang_in_v >= tang_in_0 + tang_in_dead / 2)
			{
				out_v = (tang_in_v - tang_in_0 - tang_in_dead / 2) / (tang_in_max - tang_in_0 - tang_in_dead / 2) *
				        tang_v_max;
				_cyclicStepHandleLeft.Elevator = (float) (tang_v_max * Math.Pow(out_v / tang_v_max, tang_gamma));
			}
			else if (tang_in_v <= tang_in_0 - tang_in_dead / 2)
			{

				out_v = (tang_in_0 - tang_in_v - tang_in_dead / 2) / (tang_in_0 - tang_in_dead / 2) * tang_v_min;
				_cyclicStepHandleLeft.Elevator = (float) (tang_v_min * Math.Pow(out_v / tang_v_min, tang_gamma));
			}

			var kren_in_0 = 32768.0;
			var kren_in_dead = 0.0;
			var kren_in_max = 65535.0;
			var kren_v_min = -129.99;
			var kren_v_max = 129.99;
			var kren_gamma = 1.0;
			double kren_in_v = joystickState.X;
			kren_in_v = kren_in_max - kren_in_v;
			out_v = 0.0;
			if (kren_in_v >= kren_in_0 + kren_in_dead / 2)
			{

				out_v = (kren_in_v - kren_in_0 - kren_in_dead / 2) / (kren_in_max - kren_in_0 - kren_in_dead / 2) *
				        kren_v_max;
				_cyclicStepHandleLeft.Aileron = (float) (kren_v_max * Math.Pow(out_v / kren_v_max, kren_gamma));
			}

			else if (kren_in_v <= kren_in_0 - kren_in_dead / 2)
			{
				out_v = (kren_in_0 - kren_in_v - kren_in_dead / 2) / (kren_in_0 - kren_in_dead / 2) * kren_v_min;
				_cyclicStepHandleLeft.Aileron = (float) (kren_v_min * Math.Pow(out_v / kren_v_min, kren_gamma));
			}

			//if (joystickState.Y > 22767)
			//	_cyclicStepHandleLeft.Elevator = (float)((1-joystickState.Y/42768.0) * 114.99);
			//else
			//_cyclicStepHandleLeft.Elevator = (float)((1 - joystickState.Y/ 22767.0 ) * 189.99);

			//_cyclicStepHandleLeft.Aileron = (float)((1 - joystickState.X / 32767.0) * 129.99);
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

			_generalStepHandleLeft.Throttle1 = 0;
			_generalStepHandleLeft.Throttle2 = 0;

			var rud1_in_0 = 0.0;
			var rud1_in_dead = 0.0;
			var rud1_in_max = 65535.0;
			var rud1_v_min = 20.0;
			var rud1_v_max = 0.0;
			var rud1_gamma = 1.0;
			var rud1_in_v = joystickState.RotationZ;
			double out_v = rud1_v_min;
			if (rud1_in_v >= rud1_in_dead)
			{
				out_v = rud1_v_min + (rud1_in_v - rud1_in_dead) / (rud1_in_max - rud1_in_dead) *
				        (rud1_v_max - rud1_v_min);
			}

			_generalStepHandleLeft.GeneralStep = (float) out_v;
			//_generalStepHandleLeft.GeneralStep = (float)((65535.0 - joystickState.RotationZ) / 65535.0 * 20);


			var ped_in_0 = 32768.0;
			var ped_in_dead = 5000.0;
			var ped_in_max = 65535;
			var ped_v_min = -81.49;
			var ped_v_max = 81.49;
			var ped_gamma = 2.0;
			var ped_in_v = joystickState.Z;
			out_v = 0.0;
			if (ped_in_v >= ped_in_0 + ped_in_dead / 2)
			{
				out_v = (ped_in_v - ped_in_0 - ped_in_dead / 2) / (ped_in_max - ped_in_0 - ped_in_dead / 2) * ped_v_max;
				out_v = ped_v_max * Math.Pow(out_v / ped_v_max, ped_gamma);
			}

			else if (ped_in_v <= ped_in_0 - ped_in_dead / 2)
			{
				out_v = (ped_in_0 - ped_in_v - ped_in_dead / 2) / (ped_in_0 - ped_in_dead / 2) * ped_v_min;
				out_v = ped_v_min * Math.Pow(out_v / ped_v_min, ped_gamma);
			}

			_pedalsLeft.Pedal = (float)out_v;
			//_pedalsLeft.Pedal = (float)(-(1 - joystickState.Z / 32767.0) * 81.49);
		}

		#endregion

		#region Сеть

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
			_cyclicStepHandleLeft.Elevator = (float)(Map(joystickState.Sliders[8], 488, 675, 189.99, -114.99) / 1.0);
			if (_cyclicStepHandleLeft.Elevator >= 0) _cyclicStepHandleLeft.Elevator = (float)(189.99 * Math.Pow(_cyclicStepHandleLeft.Elevator / 189.99, 2.5));
			else _cyclicStepHandleLeft.Elevator = (float)(-114.99 * Math.Pow(_cyclicStepHandleLeft.Elevator / 114.99, 2));

			//КРЕН
			_cyclicStepHandleLeft.Aileron = (float)(Map(joystickState.Sliders[9], 610, 455, -129.99, 129.99) / 1.0);
			if (_cyclicStepHandleLeft.Aileron >= 0) _cyclicStepHandleLeft.Aileron = (float)(129.99 * Math.Pow(_cyclicStepHandleLeft.Aileron / 129.99, 2));
			else _cyclicStepHandleLeft.Aileron = (float)(-129.99 * Math.Pow(_cyclicStepHandleLeft.Aileron / 129.99, 2));
			//ПЕДАЛИ
			_pedalsLeft.Pedal = (float)Map(joystickState.Sliders[10], 545, 410, -81.49, 81.49);
			if (_pedalsLeft.Pedal >= 0) _pedalsLeft.Pedal = (float)(81.49 * Math.Pow(_pedalsLeft.Pedal / 81.49, 2));
			else _pedalsLeft.Pedal = (float)(-81.49 * Math.Pow(_pedalsLeft.Pedal / 81.49, 2));

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
			float elevator = (float)(Map((float)clseState.PositionZ, 0.0, 1.0, 189.99, -114.99) / 1.0);
			_cyclicStepHandleRight.Elevator = elevator;

			//КРЕН
			float aileron = (float)(Map(joystickState.Sliders[9], 0.0, 1.0, -129.99, 129.99) / 1.0);
			_cyclicStepHandleRight.Aileron = (float)clseState.PositionX;
			
			//ПЕДАЛИ
			_pedalsRight.Pedal = (float)Map(joystickState.Sliders[10], 545, 410, -81.49, 81.49);
			if (_pedalsRight.Pedal >= 0) _pedalsRight.Pedal = (float)(81.49 * Math.Pow(_pedalsRight.Pedal / 81.49, 2));
			else _pedalsRight.Pedal = (float)(-81.49 * Math.Pow(_pedalsRight.Pedal / 81.49, 2));

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
			_generalStepHandleLeft.GeneralStep = (float)Map(joystickState.Sliders[11], 990, 770, 0.0, 20.0);
			//РУД ЛЕВ
			_generalStepHandleLeft.Throttle1 = (float)Map(joystickState.Sliders[12], 694, 948, 0.0, 20.0);
			//РУД ПРАВ
			_generalStepHandleLeft.Throttle2 = (float)Map(joystickState.Sliders[13], 972, 948, 0.0, 20.0);

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