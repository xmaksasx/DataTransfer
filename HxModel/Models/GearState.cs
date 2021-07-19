﻿using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// Параметры состояния для единичной стойки шасси:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct GearState
	{
		public double Brake;   // относительная величина степени торможения колеса  стойки, 0-1,  нуль соответствует отсутствию торможения, единица – максимально возможному торможению
		double Retract; // величина премещения стойки в убранное положение, 0-1, нуль соответствует выпущенному положению, единица - полностью выпущенному
	}
}
