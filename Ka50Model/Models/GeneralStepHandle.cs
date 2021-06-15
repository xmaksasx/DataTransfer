using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class GeneralStepHandle
	{
		/// <summary>
		/// Центральное нажатие чпп
		/// </summary>
		[Description("Центральное нажатие чпп")] public int BtnGh;

		/// <summary>
		/// Чпп
		/// </summary>
		[Description("Чпп")]
		public int BtnGhPosition;

		/// <summary>
		/// Трехпозиционный тумблер 1
		/// </summary>
		[Description("Трехпозиционный тумблер 1")] public int BtnMode1;

		/// <summary>
		/// Трехпозиционный тумблер 2
		/// </summary>
		[Description("Трехпозиционный тумблер 2")] public int BtnMode2;

		/// <summary>
		/// Стабилизация груза
		/// </summary>
		[Description("Стабилизация груза")] public int BtnStabilizer;

		/// <summary>
		/// Аварийный сброс груза
		/// </summary>
		[Description("Аварийный сброс груза")] public int BtnCargoOff;

		/// <summary>
		/// 
		/// </summary>
		[Description("Гашетка")] public int BtnTrigger;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Стоп кран первого двигателя")] public int EmergencyBrakeEng1;
		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Стоп кран второго двигателя")] public int EmergencyBrakeEng2;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("тормоз несущего винта")] public int EmergencyBrakeRotor;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("ОШ")] public float GeneralStep;
		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Двигатель 1")] public float Throttle1;
		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Двигатель 2")] public float Throttle2;
	}
}
