using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// общие параметры атмосферы
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct AirState
	{
		public double AirTemperatureGround;    //!< температура воздуха на уровне земли, С
		public double AirPressureGround;       //!< давление воздуха на уровне земли, ммрс
		public double AirHumidityGround;       //!< относительная влажность воздуха на уровне земли, %
		public XVECTOR3 WindSpeed; // компоненты текущей скорости ветра, в локальной с.к. (м/c)
	}
}
