using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	/// <summary>
	/// Параметры органов управления аппаратом
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class VehicleCtrl
	{
		/// <summary>
		/// нормированное положение органа управления в продольном канале, б/р, 0 – 1,
		/// 0 соответствует крайнему положению от себя, 1 – на себя
		/// </summary>
		public double CyclicPitch;

		/// <summary>
		/// нормированное положение органа управления в поперечном канале, б/р, 0 – 1,
		/// 0 соответствует крайнему левому положению, 1 – правому
		/// </summary>
		public double CyclicRoll;

		/// <summary>
		/// нормированное положение органа управления в путевом канале, б/р, 0 – 1,
		/// 0 соответствует крайнему левому положению, 1 – правому
		/// </summary>
		public double Direction;

		/// <summary>
		/// нормированное положение органа управления в канале общего шага, б/р, 0 – 1,
		/// 0 соответствует нижнему положению, 1 – верхнему
		/// </summary>
		public double Collective;

		#region управляющие состояния стоек шасси: передней, левой задней и правой задней

		private GearState NoseGear ;
		private GearState MainGearLeft ;
		private GearState MainGearRight ;

		#endregion

		/// <summary>
		/// признак нажатия кнопки триммера продольно-поперечного упрвления
		/// </summary>
		private bool Trimmer;

		/// <summary>
		/// признак нажатия кнопки фиркциона общего шага
		/// </summary>
		private bool Friction;
	}
}