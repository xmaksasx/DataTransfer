using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct
{
	/// <summary>
	/// Параметры состояния для единичной стойки шасси
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct GearState
	{
		/// <summary>
		/// относительная величина степени торможения колеса  стойки, 0-1,
		/// нуль соответствует отсутствию торможения, единица – максимально возможному торможению
		/// </summary>
		private double Brake;

		/// <summary>
		/// величина премещения стойки в убранное положение, 0-1,
		/// нуль соответствует выпущенному положению, единица - полностью выпущенному
		/// </summary>
		private double Retract;
	}
}