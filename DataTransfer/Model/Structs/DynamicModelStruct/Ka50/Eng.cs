using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	/// <summary>
	/// Параметры двигателя
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Eng
	{
		/// <summary>
		/// обороты вентилятора, (% от номинальной величины)) 
		/// </summary>
		[Description("обороты вентилятора, (% от номинальной величины))")]
		private double N1;

		/// <summary>
		/// обороты турбокомпрессора, (% от номинальной величины)
		/// </summary>
		[Description("обороты турбокомпрессора, (% от номинальной величины)")]
		private double N2;

		/// <summary>
		/// температура газов за турбиной, (град С)
		/// </summary>
		[Description("температура газов за турбиной, (град С)")]
		private double Egt;

		/// <summary>
		/// расход топлива данным двигателем, кг/ч
		/// </summary>
		[Description("расход топлива данным двигателем, кг/ч")]
		private double FuelFlow;
	}
}