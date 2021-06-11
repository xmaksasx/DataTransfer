using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElement : Header
	{
		

		#region Fields
		/// <summary>
		/// контрольная сумма (значений всех байт)
		/// </summary>
		[Description("контрольная сумма (значений всех байт)")]
		private int CRC;
		/// <summary>
		/// ФАРА ВВЕРХ РОШ ЛЕВ
		/// </summary>
		[Description("ФАРА ВВЕРХ РОШ ЛЕВ")]
		private int btn0;
		/// <summary>
		/// ФАРА ВЛЕВО РОШ ЛЕВ
		/// </summary>
		[Description("ФАРА ВЛЕВО РОШ ЛЕВ")]
		private int btn1;
		/// <summary>
		/// ФАРА ВНИЗ РОШ ЛЕВ
		/// </summary>
		[Description("ФАРА ВНИЗ РОШ ЛЕВ")]
		private int btn2;
		/// <summary>
		/// ФАРА ВПРАВО РОШ ЛЕВ
		/// </summary>
		[Description("ФАРА ВПРАВО РОШ ЛЕВ")]
		private int btn3;
		/// <summary>
		/// ТИП ЦЕЛИ РОШ ЛЕВ
		/// </summary>
		[Description("ТИП ЦЕЛИ РОШ ЛЕВ")]
		private int btn4;
		/// <summary>
		/// РЕЖИМ СБРОС РОШ ЛЕВ
		/// </summary>
		[Description("РЕЖИМ СБРОС РОШ ЛЕВ")]
		private int btn5;
		/// <summary>
		/// УВ ПУСК/ОСТАНОВ ВНИЗ (стоп) РОШ ЛЕВ
		/// </summary>
		[Description("УВ ПУСК/ОСТАНОВ ВНИЗ (стоп) РОШ ЛЕВ")]
		private int btn6;
		/// <summary>
		/// УВ ПУСК/ОСТАНОВ ВВЕРХ (старт) РОШ ЛЕВ
		/// </summary>
		[Description("УВ ПУСК/ОСТАНОВ ВВЕРХ (старт) РОШ ЛЕВ")]
		private int btn7;
		/// <summary>
		/// АСП ВВЕРХ РОШ ЛЕВ
		/// </summary>
		[Description("АСП ВВЕРХ РОШ ЛЕВ")]
		private int btn8;
		/// <summary>
		/// АСП ВЛЕВО РОШ ЛЕВ
		/// </summary>
		[Description("АСП ВЛЕВО РОШ ЛЕВ")]
		private int btn9;
		/// <summary>
		/// АСП ВНИЗ РОШ ЛЕВ
		/// </summary>
		[Description("АСП ВНИЗ РОШ ЛЕВ")]
		private int btn10;
		/// <summary>
		/// АСП ВПРАВО РОШ ЛЕВ
		/// </summary>
		[Description("АСП ВПРАВО РОШ ЛЕВ")]
		private int btn11;
		/// <summary>
		/// ПРИВЯЗКА РОШ ЛЕВ
		/// </summary>
		[Description("ПРИВЯЗКА РОШ ЛЕВ")]
		private int btn12;
		/// <summary>
		/// ТВ-ТПВ РОШ ЛЕВ
		/// </summary>
		[Description("ТВ-ТПВ РОШ ЛЕВ")]
		private int btn13;
		/// <summary>
		/// ПОЛЕ ЗРЕНИЯ ВНИЗ РОШ ЛЕВ
		/// </summary>
		[Description("ПОЛЕ ЗРЕНИЯ ВНИЗ РОШ ЛЕВ")]
		private int btn14;
		/// <summary>
		/// ПОЛЕ ЗРЕНИЯ ВВЕРХ РОШ ЛЕВ
		/// </summary>
		[Description("ПОЛЕ ЗРЕНИЯ ВВЕРХ РОШ ЛЕВ")]
		private int btn15;
		/// <summary>
		/// РАМКА ВВЕРХ РОШ ЛЕВ
		/// </summary>
		[Description("РАМКА ВВЕРХ РОШ ЛЕВ")]
		private int btn16;
		/// <summary>
		/// РАМКА ВНИЗ РОШ ЛЕВ
		/// </summary>
		[Description("РАМКА ВНИЗ РОШ ЛЕВ")]
		private int btn17;
		/// <summary>
		/// ДОВОРОТ РОШ ЛЕВ
		/// </summary>
		[Description("ДОВОРОТ РОШ ЛЕВ")]
		private int btn18;
		/// <summary>
		/// СНИЖЕНИЕ РОШ ЛЕВ
		/// </summary>
		[Description("СНИЖЕНИЕ РОШ ЛЕВ")]
		private int btn19;
		/// <summary>
		/// ТРИММЕР ВЫСОТЫ РОШ ЛЕВ
		/// </summary>
		[Description("ТРИММЕР ВЫСОТЫ РОШ ЛЕВ")]
		private int btn20;
		/// <summary>
		/// ЧАСТОТА ТУРБИНЫ ВНИЗ РОШ ЛЕВ
		/// </summary>
		[Description("ЧАСТОТА ТУРБИНЫ ВНИЗ РОШ ЛЕВ")]
		private int btn21;
		/// <summary>
		/// ЧАСТОТА ТУРБИНЫ ВВЕРХ РОШ ЛЕВ
		/// </summary>
		[Description("ЧАСТОТА ТУРБИНЫ ВВЕРХ РОШ ЛЕВ")]
		private int btn22;
		/// <summary>
		/// ПРИВЕДЕНИЕ К ГОРИЗ РППУ ЛЕВ
		/// </summary>
		[Description("ПРИВЕДЕНИЕ К ГОРИЗ РППУ ЛЕВ")]
		private int btn23;
		/// <summary>
		/// ОТКЛ АП РППУ ЛЕВ
		/// </summary>
		[Description("ОТКЛ АП РППУ ЛЕВ")]
		private int btn24;
		/// <summary>
		/// ВИСЕНИЕ РППУ ЛЕВ
		/// </summary>
		[Description("ВИСЕНИЕ РППУ ЛЕВ")]
		private int btn25;
		/// <summary>
		/// СКОБА ВВЕРХ РППУ ЛЕВ
		/// </summary>
		[Description("СКОБА ВВЕРХ РППУ ЛЕВ")]
		private int btn26;
		/// <summary>
		/// МАЛАЯ ГАШЕТКА РППУ ЛЕВ
		/// </summary>
		[Description("МАЛАЯ ГАШЕТКА РППУ ЛЕВ")]
		private int btn27;
		/// <summary>
		/// БОЛЬШАЯ ГАШЕТКА РППУ ЛЕВ
		/// </summary>
		[Description("БОЛЬШАЯ ГАШЕТКА РППУ ЛЕВ")]
		private int btn28;
		/// <summary>
		/// ЦУ РППУ ЛЕВ
		/// </summary>
		[Description("ЦУ РППУ ЛЕВ")]
		private int btn29;
		/// <summary>
		/// РАДИО-СПУ ВНИЗ РППУ ЛЕВ
		/// </summary>
		[Description("РАДИО-СПУ ВНИЗ РППУ ЛЕВ")]
		private int btn30;
		/// <summary>
		/// РАДИО-СПУ ВВЕРХ РППУ ЛЕВ
		/// </summary>
		[Description("РАДИО-СПУ ВВЕРХ РППУ ЛЕВ")]
		private int btn31;
		/// <summary>
		/// ФАРА ВВЕРХ РОШ ПРАВ
		/// </summary>
		[Description("ФАРА ВВЕРХ РОШ ПРАВ")]
		private int btn32;
		/// <summary>
		/// ФАРА ВЛЕВО РОШ ПРАВ
		/// </summary>
		[Description("ФАРА ВЛЕВО РОШ ПРАВ")]
		private int btn33;
		/// <summary>
		/// ФАРА ??? РОШ ПРАВ
		/// </summary>
		[Description("ФАРА ??? РОШ ПРАВ")]
		private int btn34;
		/// <summary>
		/// ФАРА ??? РОШ ПРАВ
		/// </summary>
		[Description("ФАРА ??? РОШ ПРАВ")]
		private int btn35;
		/// <summary>
		/// ТИП ЦЕЛИ РОШ ПРАВ
		/// </summary>
		[Description("ТИП ЦЕЛИ РОШ ПРАВ")]
		private int btn36;
		/// <summary>
		/// РЕЖИМ СБРОС РОШ ПРАВ
		/// </summary>
		[Description("РЕЖИМ СБРОС РОШ ПРАВ")]
		private int btn37;
		/// <summary>
		/// УВ ПУСК/ОСТАНОВ ВНИЗ (стоп) РОШ ПРАВ
		/// </summary>
		[Description("УВ ПУСК/ОСТАНОВ ВНИЗ (стоп) РОШ ПРАВ")]
		private int btn38;
		/// <summary>
		/// УВ ПУСК/ОСТАНОВ ВВЕРХ (старт) РОШ ПРАВ
		/// </summary>
		[Description("УВ ПУСК/ОСТАНОВ ВВЕРХ (старт) РОШ ПРАВ")]
		private int btn39;
		/// <summary>
		/// АСП ВВЕРХ РОШ ПРАВ
		/// </summary>
		[Description("АСП ВВЕРХ РОШ ПРАВ")]
		private int btn40;
		/// <summary>
		/// АСП ВЛЕВО РОШ ПРАВ
		/// </summary>
		[Description("АСП ВЛЕВО РОШ ПРАВ")]
		private int btn41;
		/// <summary>
		/// АСП ВНИЗ РОШ ПРАВ
		/// </summary>
		[Description("АСП ВНИЗ РОШ ПРАВ")]
		private int btn42;
		/// <summary>
		/// АСП ВПРАВО РОШ ПРАВ
		/// </summary>
		[Description("АСП ВПРАВО РОШ ПРАВ")]
		private int btn43;
		/// <summary>
		/// ПРИВЯЗКА РОШ ПРАВ
		/// </summary>
		[Description("ПРИВЯЗКА РОШ ПРАВ")]
		private int btn44;
		/// <summary>
		/// ТВ-ТПВ РОШ ПРАВ
		/// </summary>
		[Description("ТВ-ТПВ РОШ ПРАВ")]
		private int btn45;
		/// <summary>
		/// ПОЛЕ ЗРЕНИЯ ВНИЗ РОШ ПРАВ
		/// </summary>
		[Description("ПОЛЕ ЗРЕНИЯ ВНИЗ РОШ ПРАВ")]
		private int btn46;
		/// <summary>
		/// ПОЛЕ ЗРЕНИЯ ВВЕРХ РОШ ПРАВ
		/// </summary>
		[Description("ПОЛЕ ЗРЕНИЯ ВВЕРХ РОШ ПРАВ")]
		private int btn47;
		/// <summary>
		/// РАМКА ВВЕРХ РОШ ПРАВ
		/// </summary>
		[Description("РАМКА ВВЕРХ РОШ ПРАВ")]
		private int btn48;
		/// <summary>
		/// РАМКА ВНИЗ РОШ ПРАВ
		/// </summary>
		[Description("РАМКА ВНИЗ РОШ ПРАВ")]
		private int btn49;
		/// <summary>
		/// ДОВОРОТ РОШ ПРАВ
		/// </summary>
		[Description("ДОВОРОТ РОШ ПРАВ")]
		private int btn50;
		/// <summary>
		/// СНИЖЕНИЕ РОШ ПРАВ
		/// </summary>
		[Description("СНИЖЕНИЕ РОШ ПРАВ")]
		private int btn51;
		/// <summary>
		/// ТРИММЕР ВЫСОТЫ РОШ ПРАВ
		/// </summary>
		[Description("ТРИММЕР ВЫСОТЫ РОШ ПРАВ")]
		private int btn52;
		/// <summary>
		/// ЧАСТОТА ТУРБИНЫ ВНИЗ РОШ ПРАВ
		/// </summary>
		[Description("ЧАСТОТА ТУРБИНЫ ВНИЗ РОШ ПРАВ")]
		private int btn53;
		/// <summary>
		/// ЧАСТОТА ТУРБИНЫ ВВЕРХ РОШ ПРАВ
		/// </summary>
		[Description("ЧАСТОТА ТУРБИНЫ ВВЕРХ РОШ ПРАВ")]
		private int btn54;
		/// <summary>
		/// ПРИВЕДЕНИЕ К ГОРИЗ РППУ ПРАВ
		/// </summary>
		[Description("ПРИВЕДЕНИЕ К ГОРИЗ РППУ ПРАВ")]
		private int btn55;
		/// <summary>
		/// ОТКЛ АП РППУ ПРАВ
		/// </summary>
		[Description("ОТКЛ АП РППУ ПРАВ")]
		private int btn56;
		/// <summary>
		/// ВИСЕНИЕ РППУ ПРАВ
		/// </summary>
		[Description("ВИСЕНИЕ РППУ ПРАВ")]
		private int btn57;
		/// <summary>
		/// СКОБА ВВЕРХ РППУ ПРАВ
		/// </summary>
		[Description("СКОБА ВВЕРХ РППУ ПРАВ")]
		private int btn58;
		/// <summary>
		/// МАЛАЯ ГАШЕТКА РППУ ПРАВ
		/// </summary>
		[Description("МАЛАЯ ГАШЕТКА РППУ ПРАВ")]
		private int btn59;
		/// <summary>
		/// БОЛЬШАЯ ГАШЕТКА РППУ ПРАВ
		/// </summary>
		[Description("БОЛЬШАЯ ГАШЕТКА РППУ ПРАВ")]
		private int btn60;
		/// <summary>
		/// ЦУ РППУ ПРАВ
		/// </summary>
		[Description("ЦУ РППУ ПРАВ")]
		private int btn61;
		/// <summary>
		/// РАДИО-СПУ ВНИЗ РППУ ПРАВ
		/// </summary>
		[Description("РАДИО-СПУ ВНИЗ РППУ ПРАВ")]
		private int btn62;
		/// <summary>
		/// РАДИО-СПУ ВВЕРХ РППУ ПРАВ
		/// </summary>
		[Description("РАДИО-СПУ ВВЕРХ РППУ ПРАВ")]
		private int btn63;
		/// <summary>
		/// Ц1-Ц2 РУК ЛЕВ
		/// </summary>
		[Description("Ц1-Ц2 РУК ЛЕВ")]
		private int btn64;
		/// <summary>
		/// ЛПО РУК ЛЕВ
		/// </summary>
		[Description("ЛПО РУК ЛЕВ")]
		private int btn65;
		/// <summary>
		/// ПОЛЕ ЗРЕНИЯ ВПЕРЕД РУК ЛЕВ
		/// </summary>
		[Description("ПОЛЕ ЗРЕНИЯ ВПЕРЕД РУК ЛЕВ")]
		private int btn66;
		/// <summary>
		/// ПОЛЕ ЗРЕНИЯ НАЗАД РУК ЛЕВ
		/// </summary>
		[Description("ПОЛЕ ЗРЕНИЯ НАЗАД РУК ЛЕВ")]
		private int btn67;
		/// <summary>
		/// ТВ-ТПВ РУК ЛЕВ
		/// </summary>
		[Description("ТВ-ТПВ РУК ЛЕВ")]
		private int btn68;
		/// <summary>
		/// РАМКА ВНИЗ РУК ЛЕВ
		/// </summary>
		[Description("РАМКА ВНИЗ РУК ЛЕВ")]
		private int btn69;
		/// <summary>
		/// РАМКА ВВЕРХ РУК ЛЕВ
		/// </summary>
		[Description("РАМКА ВВЕРХ РУК ЛЕВ")]
		private int btn70;
		/// <summary>
		/// ПРИВЯЗКА РУК ЛЕВ
		/// </summary>
		[Description("ПРИВЯЗКА РУК ЛЕВ")]
		private int btn71;
		/// <summary>
		/// ОГОНЬ УР РУК ПРАВ
		/// </summary>
		[Description("ОГОНЬ УР РУК ПРАВ")]
		private int btn72;
		/// <summary>
		/// ЦУ ИЛС РУК ПРАВ
		/// </summary>
		[Description("ЦУ ИЛС РУК ПРАВ")]
		private int btn73;
		/// <summary>
		/// РАДИО-СПУ ВНИЗ РУК ПРАВ
		/// </summary>
		[Description("РАДИО-СПУ ВНИЗ РУК ПРАВ")]
		private int btn74;
		/// <summary>
		/// РАДИО-СПУ ВВЕРХ РУК ПРАВ
		/// </summary>
		[Description("РАДИО-СПУ ВВЕРХ РУК ПРАВ")]
		private int btn75;
		/// <summary>
		/// АСП ВВЕРХ РУК ЛЕВ
		/// </summary>
		[Description("АСП ВВЕРХ РУК ЛЕВ")]
		private int btn76;
		/// <summary>
		/// АСП ВЛЕВО РУК ЛЕВ
		/// </summary>
		[Description("АСП ВЛЕВО РУК ЛЕВ")]
		private int btn77;
		/// <summary>
		/// АСП ВНИЗ РУК ЛЕВ
		/// </summary>
		[Description("АСП ВНИЗ РУК ЛЕВ")]
		private int btn78;
		/// <summary>
		/// АСП ВПРАВО РУК ЛЕВ
		/// </summary>
		[Description("АСП ВПРАВО РУК ЛЕВ")]
		private int btn79;
		/// <summary>
		/// ЛЕВ-ПРАВ ПАНЕЛЬ ПРАВ
		/// </summary>
		[Description("ЛЕВ-ПРАВ ПАНЕЛЬ ПРАВ")]
		private int btn80;
		/// <summary>
		/// ТРИММЕР УГЛОВ РППУ ПРАВ
		/// </summary>
		[Description("ТРИММЕР УГЛОВ РППУ ПРАВ")]
		private int btn81;
		/// <summary>
		/// ТРИММЕР УГЛОВ РППУ ЛЕВ
		/// </summary>
		[Description("ТРИММЕР УГЛОВ РППУ ЛЕВ")]
		private int btn82;
		/// <summary>
		/// СБРОС РУК ПРАВ
		/// </summary>
		[Description("СБРОС РУК ПРАВ")]
		private int btn83;
		/// <summary>
		/// АС-СНЯТ РУК ПРАВ
		/// </summary>
		[Description("АС-СНЯТ РУК ПРАВ")]
		private int btn84;
		/// <summary>
		/// ОЧИСТ РУК ПРАВ
		/// </summary>
		[Description("ОЧИСТ РУК ПРАВ")]
		private int btn85;
		/// <summary>
		/// УПР ВПЕРЕД РУК ПРАВ
		/// </summary>
		[Description("УПР ВПЕРЕД РУК ПРАВ")]
		private int btn86;
		/// <summary>
		/// УПР НАЗАД РУК ПРАВ
		/// </summary>
		[Description("УПР НАЗАД РУК ПРАВ")]
		private int btn87;
		/// <summary>
		///
		/// </summary>
		[Description("btn88")] private int btn88;
		/// <summary>
		///
		/// </summary>
		[Description("btn88")] private int btn89;
		/// <summary>
		///
		/// </summary>
		[Description("btn88")] private int btn90;
		/// <summary>
		///
		/// </summary>
		[Description("btn88")] private int btn91;
		/// <summary>
		/// ТИП ЦЕЛИ ПУЛЬТ ЛЕВ
		/// </summary>
		[Description("ТИП ЦЕЛИ ПУЛЬТ ЛЕВ")]
		private int btn92;
		/// <summary>
		/// АС-СНЯТ ПУЛЬТ ЛЕВ
		/// </summary>
		[Description("АС-СНЯТ ПУЛЬТ ЛЕВ")]
		private int btn93;
		/// <summary>
		/// РЕЖИМ СБРОС ПУЛЬТ ЛЕВ
		/// </summary>
		[Description("РЕЖИМ СБРОС ПУЛЬТ ЛЕВ")]
		private int btn94;
		/// <summary>
		/// ГЛАВНЫЙ ПАНЕЛЬ ЛЕВ
		/// </summary>
		[Description("ГЛАВНЫЙ ПАНЕЛЬ ЛЕВ")]
		private int btn95;


		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("ТАНГАЖ")] public float Elevator;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("КРЕН")] public float Aileron;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("ПЕДАЛИ")] public float Rudder;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("ОШ")] public float Throttle;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev1;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev2;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev3;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev4;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev5;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev6;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev7;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Резерв")] private float Resev8;

		#endregion
	}
}