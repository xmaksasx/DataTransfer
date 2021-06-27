using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HxModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class CyclicStepHandle
	{
		/// <summary>
		/// Центральное нажатие чпп
		/// </summary>
		[Description("Центральное нажатие чпп")]
		public int BtnGh;

		/// <summary>
		/// Чпп
		/// </summary>
		[Description("Чпп")]
		public int BtnGhPosition;

		/// <summary>
		/// Отключение автопилота
		/// </summary>
		[Description("Отключение автопилота")]
		public int BtnAutopilotOff;

		/// <summary>
		/// Кнюпель ось х
		/// </summary>
		[Description("Кнюпель ось х")]
		public float BtnJoystickX;
		/// <summary>
		/// Кнюпель ось х
		/// </summary>
		[Description("Кнюпель ось у")]
		public float BtnJoystickY;

		/// <summary>
		/// Триммер
		/// </summary>
		[Description("Триммер")]
		public int BtnTrim;

		/// <summary>
		/// Включение режима висения
		/// </summary>
		[Description("Включение режима висения")]
		public int BtnHover;

		/// <summary>
		/// Сброс груза
		/// </summary>
		[Description("Сброс груза")]
		public int BtnCargoOff;

		/// <summary>
		/// Колесный тормоз
		/// </summary>
		[Description("Колесный тормоз")]
		public int BtnWheelBrake;


		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("ТАНГАЖ")] public float Elevator;

		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("КРЕН")] public float Aileron;
	}
}
