using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
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
		private double RodShift;

		/// <summary>
		/// перемещения обжатия пневматика, по правилу, аналогичному описанному выше
		/// </summary>
		private double TireShift;

		/// <summary>
		/// угол проворота колеса относительно начального положения, град,
		/// без знака, фактическое приращение возможно вычислить самостоятельно (град)  0 - 360
		/// </summary>
		private double WheelRot;

		/// <summary>
		/// угол поворота самоориентирующегося колеса (стойки) в путевом направлении,
		/// со знаком, положительный соответствует повороту влево. (град)
		/// </summary>
		private double WheelSteer;
	}
}