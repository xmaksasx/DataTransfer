using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	/// <summary>
	/// Параметры двигателя
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct Eng
	{
		/// <summary>
		/// обороты вентилятора, (% от номинальной величины)) 
		/// </summary>
		private double N1;

		/// <summary>
		/// обороты турбокомпрессора, (% от номинальной величины)
		/// </summary>
		private double N2;

		/// <summary>
		/// температура газов за турбиной, (град С)
		/// </summary>
		private double Egt;

		/// <summary>
		/// расход топлива данным двигателем, кг/ч
		/// </summary>
		private double FuelFlow;
	}
}