using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// текущие воздушные параметры 
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct AirPars
	{
		/// <summary>
		/// температруа окружающего воздуха, С
		/// </summary>
		[Description("температруа окружающего воздуха, С")]
		double TAT; 
		/// <summary>
		/// аэродинамический угол атаки (по продольной оси), град
		/// </summary>
		[Description("аэродинамический угол атаки (по продольной оси), град")]
		double AOA; 
		/// <summary>
		/// аэродинамический угол скольжения (по продольной оси), град
		/// </summary>
		[Description("аэродинамический угол скольжения (по продольной оси), град")]
		double Beta;
	}
}
