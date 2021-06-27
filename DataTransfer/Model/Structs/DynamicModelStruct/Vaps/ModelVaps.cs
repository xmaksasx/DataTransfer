using System.ComponentModel;
using System.Runtime.InteropServices;


namespace DataTransfer.Model.Structs.DynamicModelStruct.Vaps
{
	class DynamicModelToVaps
	{
		[Description("режим полета(шасси не на земле)")]
		double ModeFly;
		[Description("остаток топлива, кг")]
		double RemainingFuel;
		[Description("обороты винта")]
		double RotorSpeed;
		[Description("максимально допустимое значение оборотов винта")]
		double MaximumPermissibleRotor;
		[Description("общий шаг винта")]
		double TotalRotor;
		[Description("рекомендуемое значение шага винта")]
		double RecommendedValueRotor;
		[Description("курс текущий")]
		double HeadingCurrent;
		[Description("курс путевой")]
		double HeadingTrack;
		[Description("угол сноса")]
		double AngleDrift;
		[Description("угол скольжения")]
		double Angleslip;
		[Description("крен текущий")]
		double RollCurrent;
		[Description("максимальное допустимое значение крена")]
		double MaximumPermissibleRoll;
		[Description("рекомендуемое значение крена")]
		double RecommendedRollVlue;
		[Description("тангаж текущий")]
		double PitchCurrent;
		[Description("рекомендуемое значение тангажа")]
		double RecommendedPitchValue;
		[Description("допустимое значение тангажа при кабрировании")]
		double RermissiblePitchPitching;
		[Description("допустимое значение тангажа при пикировании")]
		double PermissiblePitchDiving;
		[Description("угол атаки")]
		double AngleAttack;
		[Description("допустимый угол атаки")]
		double PermissibleAngleAttack;
		[Description("положение шарика(-1 - левый упор, +1 - правый упор)")]
		double PositionBall;
		[Description("угол наклона траектории")]
		double AngleTrajectory;
		[Description("скорость Vy в нормальной СК, м/сек")]
		double Vy;
		[Description("минимальное допустимое значение Vy, м/сек")]
		double MinVy;
		[Description("максимально допустимое значение Vy, м/сек")]
		double MaxVy;
		[Description("приборная скорость текущая")]
		double InstrumentSpeedCurrent;
		[Description("максимальное значение приборной скорости")]
		double MaxInstrumentSpeed;
		[Description("минимальное значение приборной скорости")]
		double MinInstrumentSpeed;
		[Description("составляющие скорости по оси X в нормальной СК")]
		double SpeedX;
		[Description("составляющие скорости по оси Z в нормальной СК")]
		double SpeedZ;
		[Description("рекомендуемая скорость пикирования")]
		double RecommendedDiveSpeed;
		[Description("рекомендуемая скорость выхода из пикирования")]
		double RecommendedSpeedDiveEnd;
		[Description("истинная скорость текущая")]
		double TrueSpeedCurrent;
		[Description("составляющая путевой скорости по оси X в нормальной СК ЛА")]
		double GroundSpeedX;
		[Description("составляющая путевой скорости по оси Z в нормальной СК ЛА")]
		double GroundSpeedZ;
		[Description("число Маха")]
		double Mach;
		[Description("Высота относительная")]
		double RelativeHeight;
		[Description("Высота барометрическая")]
		double BarometricHeight;
		[Description("Установленное давление, мм рт ст")]
		double Pressure;
		[Description("Высота от радиовысотомера")]
		double HeightAltimeter;
		[Description("Опасная высота")]
		double DangerousHeight;
		[Description("Перегрузка Ny")]
		Overload Ny;
		[Description("Перегрузка Nx")]
		Overload Nx;
		[Description("Перегрузка Nz")]
		Overload Nz;
		[Description("курс метеорологического ветра(откуда дует), град")]
		double HeadingWind;
		[Description("горизонтальная скорость ветра, м/с")]
		double HorizontalWindSpeed;
		[Description("Максимально допустимая скорость ветра")]
		double MaPermissibleWindSpeed;
		[Description("Механизация")]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
		double[] Mechanization;
	}
}