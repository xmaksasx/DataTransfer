using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Model.Structs.Bmpi
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DynamicModelToBmpi
	{
		/// <summary>
		/// Географическая широта СНС	BС2	градусы	[-90;90]	90		31
		/// </summary>
		public double lat_sns;

		/// <summary>
		/// Географическая долгота СНС	BС2	градусы	[-180;180]	90		63
		/// </summary>
		public double lon_sns;


		/// <summary>
		/// СНС высота WGS-84	BС1	м	[-100; 10000]	4993.8432		79
		/// </summary>
		public double H_sns;

		/// <summary>
		/// Дата текущая BITS (16) –	15…9 (ЦСР: 64); 8…5 (ЦСР: 8); 4…0 (ЦСР: 16)	год (число из 2-х цифр); месяц; день  95
		/// </summary>
		public ushort  Day;

		/// <summary>
		/// Дата текущая BITS (16) –	15…9 (ЦСР: 64); 8…5 (ЦСР: 8); 4…0 (ЦСР: 16)	год (число из 2-х цифр); месяц; день  95
		/// </summary>
		public ushort  Month;


		/// <summary>
		/// Дата текущая BITS (16) –	15…9 (ЦСР: 64); 8…5 (ЦСР: 8); 4…0 (ЦСР: 16)	год (число из 2-х цифр); месяц; день  95
		/// </summary>
		public ushort  Year;

		/// <summary>
		/// Время (часы, минуты)	BITS (16)	–	–	15…11 (ЦСР: 16); 10…5 (ЦСР: 32)	часы; минуты 	111
		/// </summary>
		public ushort  Minute;

		/// <summary>
		/// Время (часы, минуты)	BITS (16)	–	–	15…11 (ЦСР: 16); 10…5 (ЦСР: 32)	часы; минуты 	111
		/// </summary>
		public ushort  Hour;


		/// <summary>
		/// Время (секунды)	BITS (16)	–	–	15…10 (ЦСР: 32)	секунды	127
		/// </summary>
		public ushort  Second;

		/// <summary>
		/// ФПУ СНС	BC1	градусы	[-1800;1800]	90		143
		/// </summary>
		public short FPU_sns;

		/// <summary>
		/// Путевая скорость СНС	BC1	км/час	[0;500]	3792.896		159
		/// </summary>
		public short Vputev_sns;

		/// <summary>
		/// Вертикальная скорость СНС	BC1	м/с	[-50;50]	83.2307		175
		/// </summary>
		public float Vy_sns;

		/// <summary>
		/// N/S скорость (путевая, СЕВЕР-ЮГ)	BC1	узлы	[-4000;4000]	2048		191
		/// </summary>
		public float Vxg;

		/// <summary>
		/// E/W скорость (путевая, ВОСТОК-ЗАПАД)	BC1	узлы	[-4000;4000]	2048		207
		/// </summary>
		public float Vzg; // 11.		

		// Данные ИНС

		/// <summary>
		/// Географическая широта ИНС	BС2	градусы	[-90;90]	90		239
		/// </summary>
		public double lat_ins;

		/// <summary>
		/// Географическая долгота ИНС	BС2	градусы	[-180;180]	90		271
		/// </summary>
		public double lon_ins;

		/// <summary>
		/// Путевая скорость ИНС	BC1	км/час	[0;500]	3792.896		287
		/// </summary>
		public short Vputev_ins;

		/// <summary>
		/// Путевой угол	BC1	градусы	[-1800;1800]	90		303
		/// </summary>
		public float PU;

		/// <summary>
		/// Истинный курс	BC1	градусы	[-1800;1800]	90		319
		/// </summary>
		public float PsiIst;

		/// <summary>
		/// Скорость ветра	BC1	км/час	[0;500]	3792.896		335
		/// </summary>
		public float Uwind;

		/// <summary>
		/// Направление ветра	BC1	градусы	[-1800;1800]	90		351
		/// </summary>
		public float AlfaWind;

		/// <summary>
		/// Магнитный путевой угол	BC1	градусы	[-1800;1800]	90		367
		/// </summary>
		public short FPUmagn;

		/// <summary>
		/// Магнитный курс	BC1	градусы	[-1800;1800]	90		383
		/// </summary>
		public short PSImagn;

		/// <summary>
		/// Угол сноса	BC1	градусы	[-1800;1800]	90		399
		/// </summary>
		public short Snos;

		/// <summary>
		/// Угол тангажа	BC1	градусы	[-90;90]	90		415
		/// </summary>
		public float Teta;

		/// <summary>
		/// Угол крена	BC1	градусы	[-90;90]	90		431
		/// </summary>
		public float Gamma;

		/// <summary>
		/// Угловая скорость вокруг поперечной оси ЛА (тангажа)	BC1	град/с	[-128;128]	64		447
		/// </summary>
		public float OmegaZ;

		/// <summary>
		/// Угловая скорость вокруг продольной оси ЛА (крена)	BC1	град/с	[-128;128]	64		463
		/// </summary>
		public float OmegaX;

		/// <summary>
		/// Угловая скорость вокруг нормальной оси ЛА (рыскание)	BC1	град/с	[-128;128]	64		479
		/// </summary>
		public float OmegaY;

		/// <summary>
		/// Ускорение вдоль продольной оси ЛА	BC1	g	[-4;4]	2		495
		/// </summary>
		public float JX;

		/// <summary>
		/// Ускорение вдоль поперечной оси ЛА	BC1	g	[-4;4]	2		511
		/// </summary>
		public float JZ;

		/// <summary>
		/// Ускорение вдоль нормальной оси ЛА	BC1	g	[-4;4]	2		527
		/// </summary>
		public float JY;

		/// <summary>
		/// Вертикальное ускорение	BC1	g	[-4;4]	2		543
		/// </summary>
		public short JYg;

		// Данные СВС
		/// <summary>
		/// Высота барометрическая относительная (QFE)	BС1	м	[-100; 10000]	4993.8432		559
		/// </summary>
		public float Hotn_QFE;

		/// <summary>
		/// Высота барометрическая относительная (QNH)	BС1	м	[-100; 10000]	4993.8432		575
		/// </summary>
		public float Hotn_QNH;

		/// <summary>
		/// Приборная скорость	BC1	км/час	[0;500]	3792.896		591
		/// </summary>
		public float Vpr;

		/// <summary>
		/// Высота барометрическая абсолютная	BС1	м	[-100; 10000]	4993.8432		607
		/// </summary>
		public float Hbar_abs;

		/// <summary>
		/// Истинная воздушная скорость	BC1	км/час	[0;500]	3792.896		623
		/// </summary>
		public float Vist;

		/// <summary>
		/// Температура наружного воздуха	BC1	ºC	[-60;60]	256		639
		/// </summary>
		public float Tvozd;

		// Данные РВ
		/// <summary>
		/// Истинная высота	BС1	м	[-100; 10000]	4993.8432		655
		/// </summary>
		public float Hrv;

		// Навигационные данные
		/// <summary>
		/// Географическая широта торца ВПП	BС2	градусы	[-90;90]	90		687
		/// </summary>
		public int lat_vpp;

		/// <summary>
		/// Географическая долгота торца ВПП	BС2	градусы	[-180;180]	90		719
		/// </summary>
		public int lon_vpp;

		/// <summary>
		/// Заданная высота	BС1	м	[-100; 10000]	4993.8432		735
		/// </summary>
		public short Hzad;

		/// <summary>
		/// Временной сдвиг (часы, минуты)	BITS	–	–	15…11 (ЦСР: 16); 10…5 (ЦСР: 32)	часы; минуты 	751
		/// </summary>
		public ushort  TOffset_Minute;

		/// <summary>
		/// Временной сдвиг (часы, минуты)	BITS	–	–	15…11 (ЦСР: 16); 10…5 (ЦСР: 32)	часы; минуты 	751
		/// </summary>
		public ushort  TOffset_Hour;

		/// <summary>
		/// Временной сдвиг (секунды)	BITS (16)	–	–	15…10 (ЦСР: 32)	секунды	767
		/// </summary>
		public ushort  TOffset_Second;

	}
}