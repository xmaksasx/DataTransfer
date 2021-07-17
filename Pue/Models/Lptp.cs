using DataTransfer.Model.Component.BaseComponent;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Pue.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Lptp : Header
	{
		public Lptp()
		{
			GetHeadDouble("Lptp");
		}
		/// <summary>
		/// масштаб
		/// </summary>
		[Description("масштаб")]
		public double scale; // масштаб

		/// <summary>
		/// позиция центра на экране
		/// </summary>
		[Description("позиция центра на экране")]
		public double posx;

		/// <summary>
		/// позиция центра на экране
		/// </summary>
		[Description("позиция центра на экране")]
		public double posy;

		/// <summary>
		/// дистанция до движущейся цели
		/// </summary>
		[Description("дистанция до движущейся цели")]

		public double Dtrg;

		/// <summary>
		/// превышение высоты над целью
		/// </summary>
		[Description("превышение высоты над целью")]
		public double Htrg;

		/// <summary>
		/// включить режим движущейся по нашему курсу цели с заданными дистанцией и высотой
		/// </summary>
		[Description("включить режим движущейся по нашему курсу цели с заданными дистанцией и высотой")]
		public byte lptp1;

		/// <summary>
		/// включить масштабирование ЛПТП
		/// </summary>
		[Description("включить масштабирование ЛПТП")]
		public byte lptp2;

		/// <summary>
		/// показать ЛПТП
		/// </summary>
		[Description("показать ЛПТП")]
		public byte lptp_show;

		/// <summary>
		/// показать отметку цели
		/// </summary>
		[Description("показать отметку цели")]
		public byte lptp_cel_show;

		/// <summary>
		/// тип груза (просто номер)
		/// </summary>
		[Description("тип груза (просто номер)")]
		public byte lptp_tipgr;
	}
}

