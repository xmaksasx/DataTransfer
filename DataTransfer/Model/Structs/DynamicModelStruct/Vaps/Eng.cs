using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Vaps
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Eng
	{

		/// <summary>
		/// обороты вентилятора двигателя 1, (% от номинальной величины)
		/// </summary>
		[Description("обороты вентилятора двигателя 1, (% от номинальной величины)")]
		private double N;

		/// <summary>
		/// обороты турбокомпрессора, (% от номинальной величины)
		/// </summary>
		[Description("режим работы двигателя 1, (% от номинальной величины)")]
		private double Mode;

		/// <summary>
		/// температура газов за турбиной, (град С)
		/// </summary>
		[Description("температура газов за турбиной, (град С)")]
		private double Egt;


		/// <summary>
		/// МАКСИМАНОЕ ДОПУСТИМОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)
		/// </summary>
		[Description("МАКСИМАНОЕ ДОПУСТИМОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)")]
		private double MaxAllowedEgt;

		/// <summary>
		/// АВАРИЙНОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)
		/// </summary>
		[Description("АВАРИЙНОЕ ЗНАЧЕНИЕ температуры газов двигателя 1, (град С)")]
		private double EmergencyEgt;



		/// <summary>
		/// состояние двигателя 1 (ЗАПУСК, ВЫКЛЮЧЕНИЕ, АВАРИЙНОЕ ОТКЛЮЧЕНИЕ, ПОЖАР)
		/// </summary>
		[Description("состояние двигателя 1 (ЗАПУСК, ВЫКЛЮЧЕНИЕ, АВАРИЙНОЕ ОТКЛЮЧЕНИЕ, ПОЖАР)")]
		private double EngState;

		/// <summary>
		/// расход топлива данным двигателем, кг/ч
		/// </summary>
		[Description("расход топлива данным двигателем, кг/ч")]
		private double FuelFlow;
	}
}
