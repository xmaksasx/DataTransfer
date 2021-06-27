using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// текущие воздушные параметры 
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct AirPars
	{
		double TAT; // температруа окружающего воздуха, С
		double AOA; // аэродинамический угол атаки (по продольной оси), град
		double Beta; // аэродинамический угол скольжения (по продольной оси), град
	}
}
