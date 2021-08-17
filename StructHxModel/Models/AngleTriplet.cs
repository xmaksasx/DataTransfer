using System.ComponentModel;
using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// тройка углов Эйлера
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct AngleTriplet
	{
		/// <summary>
		/// угол Тангажа,  град
		/// </summary>
		[Description("угол Тангажа,  град")]
		public double Fi;
		/// <summary>
		/// угол Курса,  град
		/// </summary>
		[Description("угол Курса,  град")]
		public double Psi;
		/// <summary>
		/// угол Крена,  град
		/// </summary>
		[Description("угол Крена,  град")]
		public double Gam;
	}
}
