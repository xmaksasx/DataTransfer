using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class SpecialWindowStruct : Base
	{
		#region Fields
		/// <summary>
		/// положение 1 окна X (дисп 4К)
		/// </summary>
		double WindowPosX1;

		/// <summary>
		/// положение 1 окна Y
		/// </summary>
		double WindowPosY1;

		/// <summary>
		/// высота 1 окна (пикс)
		/// </summary>
		double tWindowHeight1;

		/// <summary>
		/// ширина 1 окна (пикс)
		/// </summary>
		double WindowWidth1;

		/// <summary>
		/// положение 1 окна X (дисп 4К)
		/// </summary>
		double WindowPosX2;

		/// <summary>
		/// положение 1 окна Y
		/// </summary>
		double WindowPosY2;

		/// <summary>
		/// высота 1 окна (пикс)
		/// </summary>
		double tWindowHeight2;

		/// <summary>
		/// ширина 1 окна (пикс)
		/// </summary>
		double WindowWidth2;

		/// <summary>
		/// положение 1 окна X (дисп 4К)
		/// </summary>
		double WindowPosX3;

		/// <summary>
		/// положение 1 окна Y
		/// </summary>
		double WindowPosY3;

		/// <summary>
		/// высота 1 окна (пикс)
		/// </summary>
		double tWindowHeight3;

		/// <summary>
		/// ширина 1 окна (пикс)
		/// </summary>
		double WindowWidth3;

		/// <summary>
		/// положение 1 окна X (дисп 4К)
		/// </summary>
		double WindowPosX4;

		/// <summary>
		/// положение 1 окна Y
		/// </summary>
		double WindowPosY4;

		/// <summary>
		/// высота 1 окна (пикс)
		/// </summary>
		double tWindowHeight4;

		/// <summary>
		/// ширина 1 окна (пикс)
		/// </summary>
		double WindowWidth4;

		/// <summary>
		/// видим (1) невидим (0)
		/// </summary>
		char WindowVisibility1;

		/// <summary>
		/// видим (1) невидим (0)
		/// </summary>
		char WindowVisibility2;

		/// <summary>
		/// видим (1) невидим (0)
		/// </summary>
		char WindowVisibility3;

		/// <summary>
		/// видим (1) невидим (0)
		/// </summary>
		char WindowVisibility4;

		/// <summary>
		/// тип изображения первого окна
		/// </summary>
		char WindowType1;

		/// <summary>
		/// тип изображения второго окна
		/// </summary>
		char WindowType2;

		/// <summary>
		/// тип изображения третьего окна
		/// </summary>
		char WindowType3;

		/// <summary>
		/// тип изображения четвертого окна
		/// </summary>
		char WindowType4;
		
		#endregion
	}
}
