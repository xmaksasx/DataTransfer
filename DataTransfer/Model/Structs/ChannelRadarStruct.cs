using System.Runtime.InteropServices;
using DataTransfer.Model.Component.Derived;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ChannelRadarStruct: ReverseObject
	{
		#region Fields

		/// <summary>
		/// яркость РЛ изображения, 0..1
		/// </summary>
		double Brightness;

		/// <summary>
		/// усиление РЛ изображения, 0..1
		/// </summary>
		double Koeff;

		/// <summary>
		/// соотношение сигнал/шум "ФОН" РЛ изображения, 0..1
		/// </summary>
		double Fon;

		/// <summary>
		/// соотношение сигнал/шум "ЦЕЛЬ" РЛ изображения, 0..1
		/// </summary>
		double Target;

		/// <summary>
		/// Масштаб зоны обзора РЛС (0 - 25км, 1 - 50км, 2 - 100км, 3 - 200км, 4 - 400км)
		/// </summary>
		char Masht;

		/// <summary>
		/// Тип изображения 0 - НР, 1 - ВР, 2 - СВР
		/// </summary>
		char pType;

		/// <summary>
		/// Номер выбранной цели для работы на РЛС, 1..4
		/// </summary>
		char SelTrg;

		#endregion
	}
}
