using StructHxModel.Models;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// общая сводка параметров, пригодных для отображения на средствах индикации 
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct InstrumentsState
	{
		/// <summary>
		/// текущие воздушные параметры 
		/// </summary>
		[Description("текущие воздушные параметры")]
		public AirPars AirPars;

		/// <summary>
		/// приборная скорость, м/с
		/// </summary>
		[Description("приборная скорость, м/с")]
		public double IAS;

		/// <summary>
		/// истинная скорость (кинематическая), м/с
		/// </summary>
		[Description("истинная скорость (кинематическая), м/с")]
		public double TAS;


		/// <summary>
		/// барометрическая высота, измеряемая анероидным высотомером, c учетом переданных AirTemperatureGround, AirPressureGround, AirHumidityGround и AltimeterBaroPressure, м
		/// </summary>
		[Description("барометрическая высота")]
		public double Hbaro;

		/// <summary>
		/// вертикальная скорость с учетом особенностей работы анеродиного вариометра, м/с
		/// </summary>
		[Description("вертикальная скорость с учетом особенностей работы анеродиного вариометра, м/с")]
		public double VyVar;

		/// <summary>
		/// компоненты измеряемых перегрузок по трем осям, сглаженные, nd
		/// </summary>
		[Description("компоненты измеряемых перегрузок по трем осям, сглаженные, nd")]
		public XVECTOR3 GLoad;

		/// <summary>
		/// обобщенное положение механического шарика указателя угла скольжения, -1 до +1, соответствующее положениям от крайнего левого до крайнего правого, nd
		/// </summary>
		[Description("обобщенное положение механического шарика указателя угла скольжения, -1 до +1")]
		public double SlipBallPos;

		/// <summary>
		/// продольная составляющая путевой скорости, м/с
		/// </summary>
		[Description("продольная составляющая путевой скорости, м/с")]
		public double VsurfX;

		/// <summary>
		/// боковая составляющая путевой скорости, м/с
		/// </summary>
		[Description("боковая составляющая путевой скорости, м/с")]
		public double VsurfZ;

		/// <summary>
		/// текущая масса топлива, кг
		/// </summary>
		[Description("текущая масса топлива, кг")]
		public double FuelMass;

		/// <summary>
		/// обороты несущей системы, % от номинального
		/// </summary>
		[Description("обороты несущей системы, % от номинального")]
		public double RotorRPM;

		/// <summary>
		/// результирующий общий шаг несущей системы, град
		/// </summary>
		[Description("результирующий общий шаг несущей системы, град")]
		public double CollectivePitch;
	}
}