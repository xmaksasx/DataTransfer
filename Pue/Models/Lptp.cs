using DataTransfer.Model.Component.BaseComponent;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Lptp: Header
	{

		/// <summary>
		/// масштаб
		/// </summary>
		[Description("масштаб")]
		double scale; // масштаб

		/// <summary>
		/// позиция центра на экране
		/// </summary>
		[Description("позиция центра на экране")]
		double posx;

		/// <summary>
		/// позиция центра на экране
		/// </summary>
		[Description("позиция центра на экране")]
		double posy;

		/// <summary>
		/// дистанция до движущейся цели
		/// </summary>
		[Description("дистанция до движущейся цели")]
		
		double Dtrg;

		/// <summary>
		/// превышение высоты над целью
		/// </summary>
		[Description("превышение высоты над целью")]
		double Htrg;

		/// <summary>
		/// включить режим движущейся по нашему курсу цели с заданными дистанцией и высотой
		/// </summary>
		[Description("включить режим движущейся по нашему курсу цели с заданными дистанцией и высотой")]
		byte lptp1;

		/// <summary>
		/// включить масштабирование ЛПТП
		/// </summary>
		[Description("включить масштабирование ЛПТП")]
		byte lptp2;

		/// <summary>
		/// показать ЛПТП
		/// </summary>
		[Description("показать ЛПТП")]
		byte lptp_show;

		/// <summary>
		/// показать отметку цели
		/// </summary>
		[Description("показать отметку цели")]
		byte lptp_cel_show;

		/// <summary>
		/// тип груза (просто номер)
		/// </summary>
		[Description("тип груза (просто номер)")]
		byte lptp_tipgr;
    }
}
