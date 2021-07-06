using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Lptp
	{
		double scale; // масштаб
		double posx; // позиция центра на экране    
		double posy;
		double Dtrg; // дистанция до движущейся цели
		double Htrg; // превышение высоты над целью
		byte lptp1; // включить режим движущейся по нашему курсу цели с заданными дистанцией и высотой
		byte lptp2; // включить масштабирование ЛПТП
		byte lptp_show; // показать ЛПТП
		byte lptp_cel_show; // показать отметку цели
		byte lptp_tipgr; // тип груза (просто номер)
    }
}
