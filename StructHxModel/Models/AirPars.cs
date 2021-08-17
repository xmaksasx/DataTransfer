using System.ComponentModel;
using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// текущие воздушные параметры 
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AirPars
	{
		/// <summary>
		/// температруа окружающего воздуха, С
		/// </summary>
		[Description("температруа окружающего воздуха, С")]
		public double TAT;
		/// <summary>
		/// аэродинамический угол атаки (по продольной оси), град
		/// </summary>
		[Description("аэродинамический угол атаки (по продольной оси), град")]
		public double AOA;
		/// <summary>
		/// аэродинамический угол скольжения (по продольной оси), град
		/// </summary>
		[Description("аэродинамический угол скольжения (по продольной оси), град")]
		public double Beta;
	}
}
