using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Pue.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Eng
	{

		/// <summary>
		/// обороты вентилятора двигателя 1, (% от номинальной величины)
		/// </summary>
		[Description("обороты вентилятора двигателя 1, (% от номинальной величины)")]
		public double N;

		/// <summary>
		/// режим работы двигателя 1, (% от номинальной величины)
		/// </summary>
		[Description("режим работы двигателя 1, (% от номинальной величины)")]
		public double Mode;

		/// <summary>
		/// температура газов за турбиной, (град С)
		/// </summary>
		[Description("температура газов за турбиной, (град С)")]
		public double Egt;


		/// <summary>
		/// МАКСИМАНОЕ ДОПУСТИМОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)
		/// </summary>
		[Description("МАКСИМАНОЕ ДОПУСТИМОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)")]
		public double MaxAllowedEgt;

		/// <summary>
		/// АВАРИЙНОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)
		/// </summary>
		[Description("АВАРИЙНОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)")]
		public double EmergencyEgt;



		/// <summary>
		/// состояние двигателя 1 (ЗАПУСК, ВЫКЛЮЧЕНИЕ, АВАРИЙНОЕ ОТКЛЮЧЕНИЕ, ПОЖАР)
		/// </summary>
		[Description("состояние двигателя 1 (ЗАПУСК, ВЫКЛЮЧЕНИЕ, АВАРИЙНОЕ ОТКЛЮЧЕНИЕ, ПОЖАР)")]
		public double EngState;

		/// <summary>
		/// расход топлива данным двигателем, кг/ч
		/// </summary>
		[Description("расход топлива данным двигателем, кг/ч")]
		public double FuelFlow;
	}
}
