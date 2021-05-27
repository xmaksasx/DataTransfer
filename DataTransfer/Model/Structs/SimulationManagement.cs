using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class SimulationManagement : Base
	{
		#region Fields
		/// <summary>
		/// 0 - стоп
		/// 1 - старт
		/// 2 - пауза
		/// Команда на управление 
		/// </summary>
		private double ModeState;

		/// <summary>
		/// 0 - автопилот
		/// 1 - сеть
		/// 2 - джойстик НИИЭС
		/// 3 - локальный джойстик
		/// Тип огранов управления
		/// </summary>
		private double TypeCockpit; 
		#endregion
	}
}
