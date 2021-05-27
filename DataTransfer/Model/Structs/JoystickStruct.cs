using System.Runtime.InteropServices;
using SharpDX.DirectInput;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class JoystickStruct
	{
		public void UpdateRus(JoystickState joystickState)
		{
			MasADC[0] = joystickState.X;
			MasADC[1] = joystickState.Y;
		}

		public void UpdateRud(JoystickState joystickState)
		{
			MasADC[0] = joystickState.X;
			MasADC[1] = joystickState.Y;
		}

		#region Fields

		/// <summary>
		/// контрольная сумма (значений всех байт)
		/// </summary>
		private int CRC;
		///// <summary>
		///// ФАРА ВВЕРХ РОШ ЛЕВ
		///// </summary>
		//private int btn0;
		///// <summary>
		///// ФАРА ВЛЕВО РОШ ЛЕВ
		///// </summary>
		//private int btn1;
		///// <summary>
		///// ФАРА ВНИЗ РОШ ЛЕВ
		///// </summary>
		//private int btn2;
		///// <summary>
		///// ФАРА ВПРАВО РОШ ЛЕВ
		///// </summary>
		//private int btn3;
		///// <summary>
		///// ТИП ЦЕЛИ РОШ ЛЕВ
		///// </summary>
		//private int btn4;
		///// <summary>
		///// РЕЖИМ СБРОС РОШ ЛЕВ
		///// </summary>
		//private int btn5;
		///// <summary>
		///// УВ ПУСК/ОСТАНОВ ВНИЗ (стоп) РОШ ЛЕВ
		///// </summary>
		//private int btn6;
		///// <summary>
		///// УВ ПУСК/ОСТАНОВ ВВЕРХ (старт) РОШ ЛЕВ
		///// </summary>
		//private int btn7;
		///// <summary>
		///// АСП ВВЕРХ РОШ ЛЕВ
		///// </summary>
		//private int btn8;
		///// <summary>
		///// АСП ВЛЕВО РОШ ЛЕВ
		///// </summary>
		//private int btn9;
		///// <summary>
		///// АСП ВНИЗ РОШ ЛЕВ
		///// </summary>
		//private int btn10;
		///// <summary>
		///// АСП ВПРАВО РОШ ЛЕВ
		///// </summary>
		//private int btn11;
		///// <summary>
		///// ПРИВЯЗКА РОШ ЛЕВ
		///// </summary>
		//private int btn12;
		///// <summary>
		///// ТВ-ТПВ РОШ ЛЕВ
		///// </summary>
		//private int btn13;
		///// <summary>
		///// ПОЛЕ ЗРЕНИЯ ВНИЗ РОШ ЛЕВ
		///// </summary>
		//private int btn14;
		///// <summary>
		///// ПОЛЕ ЗРЕНИЯ ВВЕРХ РОШ ЛЕВ
		///// </summary>
		//private int btn15;
		///// <summary>
		///// РАМКА ВВЕРХ РОШ ЛЕВ
		///// </summary>
		//private int btn16;
		///// <summary>
		///// РАМКА ВНИЗ РОШ ЛЕВ
		///// </summary>
		//private int btn17;
		///// <summary>
		///// ДОВОРОТ РОШ ЛЕВ
		///// </summary>
		//private int btn18;
		///// <summary>
		///// СНИЖЕНИЕ РОШ ЛЕВ
		///// </summary>
		//private int btn19;
		///// <summary>
		///// ТРИММЕР ВЫСОТЫ РОШ ЛЕВ
		///// </summary>
		//private int btn20;
		///// <summary>
		///// ЧАСТОТА ТУРБИНЫ ВНИЗ РОШ ЛЕВ
		///// </summary>
		//private int btn21;
		///// <summary>
		///// ЧАСТОТА ТУРБИНЫ ВВЕРХ РОШ ЛЕВ
		///// </summary>
		//private int btn22;
		///// <summary>
		///// ПРИВЕДЕНИЕ К ГОРИЗ РППУ ЛЕВ
		///// </summary>
		//private int btn23;
		///// <summary>
		///// ОТКЛ АП РППУ ЛЕВ
		///// </summary>
		//private int btn24;
		///// <summary>
		///// ВИСЕНИЕ РППУ ЛЕВ
		///// </summary>
		//private int btn25;
		///// <summary>
		///// СКОБА ВВЕРХ РППУ ЛЕВ
		///// </summary>
		//private int btn26;
		///// <summary>
		///// МАЛАЯ ГАШЕТКА РППУ ЛЕВ
		///// </summary>
		//private int btn27;
		///// <summary>
		///// БОЛЬШАЯ ГАШЕТКА РППУ ЛЕВ
		///// </summary>
		//private int btn28;
		///// <summary>
		///// ЦУ РППУ ЛЕВ
		///// </summary>
		//private int btn29;
		///// <summary>
		///// РАДИО-СПУ ВНИЗ РППУ ЛЕВ
		///// </summary>
		//private int btn30;
		///// <summary>
		///// РАДИО-СПУ ВВЕРХ РППУ ЛЕВ
		///// </summary>
		//private int btn31;
		///// <summary>
		///// ФАРА ВВЕРХ РОШ ПРАВ
		///// </summary>
		//private int btn32;
		///// <summary>
		///// ФАРА ВЛЕВО РОШ ПРАВ
		///// </summary>
		//private int btn33;
		///// <summary>
		///// ФАРА ??? РОШ ПРАВ
		///// </summary>
		//private int btn34;
		///// <summary>
		///// ФАРА ??? РОШ ПРАВ
		///// </summary>
		//private int btn35;
		///// <summary>
		///// ТИП ЦЕЛИ РОШ ПРАВ
		///// </summary>
		//private int btn36;
		///// <summary>
		///// РЕЖИМ СБРОС РОШ ПРАВ
		///// </summary>
		//private int btn37;
		///// <summary>
		///// УВ ПУСК/ОСТАНОВ ВНИЗ (стоп) РОШ ПРАВ
		///// </summary>
		//private int btn38;
		///// <summary>
		///// УВ ПУСК/ОСТАНОВ ВВЕРХ (старт) РОШ ПРАВ
		///// </summary>
		//private int btn39;
		///// <summary>
		///// АСП ВВЕРХ РОШ ПРАВ
		///// </summary>
		//private int btn40;
		///// <summary>
		///// АСП ВЛЕВО РОШ ПРАВ
		///// </summary>
		//private int btn41;
		///// <summary>
		///// АСП ВНИЗ РОШ ПРАВ
		///// </summary>
		//private int btn42;
		///// <summary>
		///// АСП ВПРАВО РОШ ПРАВ
		///// </summary>
		//private int btn43;
		///// <summary>
		///// ПРИВЯЗКА РОШ ПРАВ
		///// </summary>
		//private int btn44;
		///// <summary>
		///// ТВ-ТПВ РОШ ПРАВ
		///// </summary>
		//private int btn45;
		///// <summary>
		///// ПОЛЕ ЗРЕНИЯ ВНИЗ РОШ ПРАВ
		///// </summary>
		//private int btn46;
		///// <summary>
		///// ПОЛЕ ЗРЕНИЯ ВВЕРХ РОШ ПРАВ
		///// </summary>
		//private int btn47;
		///// <summary>
		///// РАМКА ВВЕРХ РОШ ПРАВ
		///// </summary>
		//private int btn48;
		///// <summary>
		///// РАМКА ВНИЗ РОШ ПРАВ
		///// </summary>
		//private int btn49;
		///// <summary>
		///// ДОВОРОТ РОШ ПРАВ
		///// </summary>
		//private int btn50;
		///// <summary>
		///// СНИЖЕНИЕ РОШ ПРАВ
		///// </summary>
		//private int btn51;
		///// <summary>
		///// ТРИММЕР ВЫСОТЫ РОШ ПРАВ
		///// </summary>
		//private int btn52;
		///// <summary>
		///// ЧАСТОТА ТУРБИНЫ ВНИЗ РОШ ПРАВ
		///// </summary>
		//private int btn53;
		///// <summary>
		///// ЧАСТОТА ТУРБИНЫ ВВЕРХ РОШ ПРАВ
		///// </summary>
		//private int btn54;
		///// <summary>
		///// ПРИВЕДЕНИЕ К ГОРИЗ РППУ ПРАВ
		///// </summary>
		//private int btn55;
		///// <summary>
		///// ОТКЛ АП РППУ ПРАВ
		///// </summary>
		//private int btn56;
		///// <summary>
		///// ВИСЕНИЕ РППУ ПРАВ
		///// </summary>
		//private int btn57;
		///// <summary>
		///// СКОБА ВВЕРХ РППУ ПРАВ
		///// </summary>
		//private int btn58;
		///// <summary>
		///// МАЛАЯ ГАШЕТКА РППУ ПРАВ
		///// </summary>
		//private int btn59;
		///// <summary>
		///// БОЛЬШАЯ ГАШЕТКА РППУ ПРАВ
		///// </summary>
		//private int btn60;
		///// <summary>
		///// ЦУ РППУ ПРАВ
		///// </summary>
		//private int btn61;
		///// <summary>
		///// РАДИО-СПУ ВНИЗ РППУ ПРАВ
		///// </summary>
		//private int btn62;
		///// <summary>
		///// РАДИО-СПУ ВВЕРХ РППУ ПРАВ
		///// </summary>
		//private int btn63;
		///// <summary>
		///// Ц1-Ц2 РУК ЛЕВ
		///// </summary>
		//private int btn64;
		///// <summary>
		///// ЛПО РУК ЛЕВ
		///// </summary>
		//private int btn65;
		///// <summary>
		///// ПОЛЕ ЗРЕНИЯ ВПЕРЕД РУК ЛЕВ
		///// </summary>
		//private int btn66;
		///// <summary>
		///// ПОЛЕ ЗРЕНИЯ НАЗАД РУК ЛЕВ
		///// </summary>
		//private int btn67;
		///// <summary>
		///// ТВ-ТПВ РУК ЛЕВ
		///// </summary>
		//private int btn68;
		///// <summary>
		///// РАМКА ВНИЗ РУК ЛЕВ
		///// </summary>
		//private int btn69;
		///// <summary>
		///// РАМКА ВВЕРХ РУК ЛЕВ
		///// </summary>
		//private int btn70;
		///// <summary>
		///// ПРИВЯЗКА РУК ЛЕВ
		///// </summary>
		//private int btn71;
		///// <summary>
		///// ОГОНЬ УР РУК ПРАВ
		///// </summary>
		//private int btn72;
		///// <summary>
		///// ЦУ ИЛС РУК ПРАВ
		///// </summary>
		//private int btn73;
		///// <summary>
		///// РАДИО-СПУ ВНИЗ РУК ПРАВ
		///// </summary>
		//private int btn74;
		///// <summary>
		///// РАДИО-СПУ ВВЕРХ РУК ПРАВ
		///// </summary>
		//private int btn75;
		///// <summary>
		///// АСП ВВЕРХ РУК ЛЕВ
		///// </summary>
		//private int btn76;
		///// <summary>
		///// АСП ВЛЕВО РУК ЛЕВ
		///// </summary>
		//private int btn77;
		///// <summary>
		///// АСП ВНИЗ РУК ЛЕВ
		///// </summary>
		//private int btn78;
		///// <summary>
		///// АСП ВПРАВО РУК ЛЕВ
		///// </summary>
		//private int btn79;
		///// <summary>
		///// ЛЕВ-ПРАВ ПАНЕЛЬ ПРАВ
		///// </summary>
		//private int btn80;
		///// <summary>
		///// ТРИММЕР УГЛОВ РППУ ПРАВ
		///// </summary>
		//private int btn81;
		///// <summary>
		///// ТРИММЕР УГЛОВ РППУ ЛЕВ
		///// </summary>
		//private int btn82;
		///// <summary>
		///// СБРОС РУК ПРАВ
		///// </summary>
		//private int btn83;
		///// <summary>
		///// АС-СНЯТ РУК ПРАВ
		///// </summary>
		//private int btn84;
		///// <summary>
		///// ОЧИСТ РУК ПРАВ
		///// </summary>
		//private int btn85;
		///// <summary>
		///// УПР ВПЕРЕД РУК ПРАВ
		///// </summary>
		//private int btn86;
		///// <summary>
		///// УПР НАЗАД РУК ПРАВ
		///// </summary>
		//private int btn87;
		///// <summary>
		/////
		///// </summary>
		//private int btn88;
		///// <summary>
		/////
		///// </summary>
		//private int btn89;
		///// <summary>
		/////
		///// </summary>
		//private int btn90;
		///// <summary>
		/////
		///// </summary>
		//private int btn91;
		///// <summary>
		///// ТИП ЦЕЛИ ПУЛЬТ ЛЕВ
		///// </summary>
		//private int btn92;
		///// <summary>
		///// АС-СНЯТ ПУЛЬТ ЛЕВ
		///// </summary>
		//private int btn93;
		///// <summary>
		///// РЕЖИМ СБРОС ПУЛЬТ ЛЕВ
		///// </summary>
		//private int btn94;
		///// <summary>
		///// ГЛАВНЫЙ ПАНЕЛЬ ЛЕВ
		///// </summary>
		//private int btn95;


		/// <summary>
		/// дискретные каналы (разовые команды)
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
			public int[] MasIn = new int[96];
		/// <summary>
		/// аналоговые сигналы 0-ТАНГАЖ, 1-КРЕН, 2-ПЕДАЛИ, 3-ОШ
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public float[] MasADC = new float[12]; 
		#endregion
	}
}
