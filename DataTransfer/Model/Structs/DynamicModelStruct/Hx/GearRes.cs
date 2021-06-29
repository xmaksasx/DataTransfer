﻿using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{


	/// <summary>
	/// Результирующие параметры единичной стойки шасси
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class GearRes
	{
		/// <summary>
		/// относительной перемещение амортизатора стойки, 0-1,
		/// нуль  соответствует полностью разжатому положению, а единица - полностью обжатому
		/// </summary>
		[Description("Обжатие стойки  0 - разжатому положению, 1 - полностью обжатому")]
		public double RodShift;

		/// <summary>
		/// перемещения обжатия пневматика, по правилу, аналогичному описанному выше
		/// </summary>
		[Description("перемещения обжатия пневматика  0 - разжатому положению, 1 - полностью обжатому")]
		public double TireShift;

		/// <summary>
		/// угол проворота колеса относительно начального положения, град,
		/// без знака, фактическое приращение возможно вычислить самостоятельно (град)  0 - 360
		/// </summary>
		[Description("угол проворота колеса относительно начального положения, град")]

		public double WheelRot;

		/// <summary>
		/// угол поворота самоориентирующегося колеса (стойки) в путевом направлении,
		/// со знаком, положительный соответствует повороту влево. (град)
		/// </summary>
		[Description("угол поворота самоориентирующегося колеса (стойки) в путевом направлении, град")]
		public double WheelSteer;
	}
}