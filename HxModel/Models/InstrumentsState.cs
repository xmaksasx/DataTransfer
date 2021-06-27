using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// общая сводка параметров, пригодных для отображения на средствах индикации 
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct InstrumentsState
	{
		public AirPars AirPars;

		double IAS;     // приборная скорость, м/с
		double TAS;     // истинная скорость (кинематическая), м/с
		double Hbaro;       // барометрическая высота, измеряемая анероидным высотомером, c учетом переданных AirTemperatureGround, AirPressureGround, AirHumidityGround и AltimeterBaroPressure, м
		double VyVar;       // вертикальная скорость с учетом особенностей работы анеродиного вариометра, м/с

		XVECTOR3 GLoad;     // компоненты измеряемых перегрузок по трем осям, сглаженные, nd
		double SlipBallPos;// обобщенное положение механического шарика указателя угла скольжения, -1 до +1, соответствующее положениям от крайнего левого до крайнего правого, nd

		double VsurfX;      // продольная составляющая путевой скорости, м/с
		double VsurfZ;      // боковая составляющая путевой скорости, м/с

		double FuelMass;    // текущая масса топлива, кг

		double RotorRPM;    // обороты несущей системы, % от номинального
		double CollectivePitch; // результирующий общий шаг несущей системы, град
	}
}