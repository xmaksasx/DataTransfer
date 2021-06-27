using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.DynamicModelStruct.Ka50;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Vaps
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DynamicModelToVaps:Header
	{

		public DynamicModelToVaps()
		{
			GetHeadDouble("ModelHx");
		}


		


		[Description("Двигатель1")]
		public Eng Eng1 = new Eng();
		[Description("Двигатель2")]
		public Eng Eng2 = new Eng();
		[Description("Двигатель3")]
		public Eng Eng3 = new Eng();
		[Description("Двигатель4")]
		public Eng Eng4 = new Eng();

		[Description("режим полета(шасси не на земле)")]
		public double ModeFly;
		[Description("остаток топлива, кг")]
		public double RemainingFuel;
		[Description("обороты винта")]
		public double RotorSpeed;
		[Description("максимально допустимое значение оборотов винта")]
		public double MaximumPermissibleRotor;
		[Description("общий шаг винта")]
		public double TotalRotor;
		[Description("рекомендуемое значение шага винта")]
		public double RecommendedValueRotor;
		[Description("курс текущий")]
		public double HeadingCurrent;
		[Description("курс путевой")]
		public double HeadingTrack;
		[Description("угол сноса")]
		public double AngleDrift;
		[Description("угол скольжения")]
		public double Angleslip;
		[Description("крен текущий")]
		public double RollCurrent;
		[Description("максимальное допустимое значение крена")]
		public double MaximumPermissibleRoll;
		[Description("рекомендуемое значение крена")]
		public double RecommendedRollVlue;
		[Description("тангаж текущий")]
		public double PitchCurrent;
		[Description("рекомендуемое значение тангажа")]
		public double RecommendedPitchValue;
		[Description("допустимое значение тангажа при кабрировании")]
		public double RermissiblePitchPitching;
		[Description("допустимое значение тангажа при пикировании")]
		public double PermissiblePitchDiving;
		[Description("угол атаки")]
		public double AngleAttack;
		[Description("допустимый угол атаки")]
		public double PermissibleAngleAttack;
		[Description("положение шарика(-1 - левый упор, +1 - правый упор)")]
		public double PositionBall;
		[Description("угол наклона траектории")]
		public double AngleTrajectory;
		[Description("скорость Vy в нормальной СК, м/сек")]
		public double Vy;
		[Description("минимальное допустимое значение Vy, м/сек")]
		public double MinVy;
		[Description("максимально допустимое значение Vy, м/сек")]
		public double MaxVy;
		[Description("приборная скорость текущая")]
		public double InstrumentSpeedCurrent;
		[Description("максимальное значение приборной скорости")]
		public double MaxInstrumentSpeed;
		[Description("минимальное значение приборной скорости")]
		public double MinInstrumentSpeed;
		[Description("составляющие скорости по оси X в нормальной СК")]
		public double SpeedX;
		[Description("составляющие скорости по оси Z в нормальной СК")]
		public double SpeedZ;
		[Description("рекомендуемая скорость пикирования")]
		public double RecommendedDiveSpeed;
		[Description("рекомендуемая скорость выхода из пикирования")]
		public double RecommendedSpeedDiveEnd;
		[Description("истинная скорость текущая")]
		public double TrueSpeedCurrent;
		[Description("составляющая путевой скорости по оси X в нормальной СК ЛА")]
		public double GroundSpeedX;
		[Description("составляющая путевой скорости по оси Z в нормальной СК ЛА")]
		public double GroundSpeedZ;
		[Description("число Маха")]
		public double Mach;
		[Description("Высота относительная")]
		public double RelativeHeight;
		[Description("Высота барометрическая")]
		public double BarometricHeight;
		[Description("Установленное давление, мм рт ст")]
		public double Pressure;
		[Description("Высота от радиовысотомера")]
		public double HeightAltimeter;
		[Description("Опасная высота")]
		public double DangerousHeight;
		[Description("Перегрузка Ny")]
		public Overload Ny = new Overload();
		[Description("Перегрузка Nx")]
		public Overload Nx = new Overload();
		[Description("Перегрузка Nz")]
		public Overload Nz = new Overload();
		[Description("курс метеорологического ветра(откуда дует), град")]
		public double HeadingWind;
		[Description("горизонтальная скорость ветра, м/с")]
		public double HorizontalWindSpeed;
		[Description("Максимально допустимая скорость ветра")]
		public double MaPermissibleWindSpeed;
		[Description("Механизация")]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
		public double[] Mechanization = new double[30];

		
	}
}