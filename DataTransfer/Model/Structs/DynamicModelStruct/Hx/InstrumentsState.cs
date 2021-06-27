using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// общая сводка параметров, пригодных для отображения на средствах индикации 
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct InstrumentsState
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
		double IAS;

		/// <summary>
		/// истинная скорость (кинематическая), м/с
		/// </summary>
		[Description("истинная скорость (кинематическая), м/с")]
		double TAS;


		/// <summary>
		/// барометрическая высота, измеряемая анероидным высотомером, c учетом переданных AirTemperatureGround, AirPressureGround, AirHumidityGround и AltimeterBaroPressure, м
		/// </summary>
		[Description("барометрическая высота")]
		double Hbaro;

		/// <summary>
		/// вертикальная скорость с учетом особенностей работы анеродиного вариометра, м/с
		/// </summary>
		[Description("вертикальная скорость с учетом особенностей работы анеродиного вариометра, м/с")]
		double VyVar;

		/// <summary>
		/// компоненты измеряемых перегрузок по трем осям, сглаженные, nd
		/// </summary>
		[Description("компоненты измеряемых перегрузок по трем осям, сглаженные, nd")]
		XVECTOR3 GLoad;

		/// <summary>
		/// обобщенное положение механического шарика указателя угла скольжения, -1 до +1, соответствующее положениям от крайнего левого до крайнего правого, nd
		/// </summary>
		[Description("обобщенное положение механического шарика указателя угла скольжения, -1 до +1")]
		double SlipBallPos;

		/// <summary>
		/// продольная составляющая путевой скорости, м/с
		/// </summary>
		[Description("")]
		double VsurfX;

		/// <summary>
		/// боковая составляющая путевой скорости, м/с
		/// </summary>
		[Description("")]
		double VsurfZ;

		/// <summary>
		/// текущая масса топлива, кг
		/// </summary>
		[Description("")]
		double FuelMass;

		/// <summary>
		/// обороты несущей системы, % от номинального
		/// </summary>
		[Description("")]
		double RotorRPM;

		/// <summary>
		/// результирующий общий шаг несущей системы, град
		/// </summary>
		[Description("")]
		double CollectivePitch; 
	}
}