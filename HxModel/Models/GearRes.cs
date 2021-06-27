﻿using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// Результирующие параметры единичной стойки шасси:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct GearRes
	{
		double RodShift;    // относительной перемещение амортизатора стойки, 0-1, нуль  соответствует полностью разжатому положению, а единица - полностью обжатому
		double TireShift;   // перемещения обжатия пневматика, по правилу, аналогичному описанному выше
		double WheelRot;    // угол проворота колеса относительно начального положения, град, без знака, фактическое приращение возможно вычислить самостоятельно (град)  0 - 360
		double WheelSteer;  // угол поворота самоориентирующегося колеса (стойки) в путевом направлении, со знаком, положительный соответствует повороту влево. (град)
	}
}