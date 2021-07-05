﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Model.Structs.Bmpi
{
	class PlanPoleta
	{

			// 31.		Заголовок (Тип маневра и т.д.)	BITS (16)	-	-	-	Таблица А2.1.1	567
			ushort reserv;  // = 0
			ushort NMarsh; // Номер маршрута	ЦСР: 64
			ushort OperChangeMarsh; // Оперативное изменение маршрута (без сохранения в ПЗУ)	0 – нет изменений 1 – есть изменения
			ushort UpdateFonInfo; // Обновление блока фоновой информации	0 – нет 1 - да
			ushort TypeManevr; // 0000 – навигация по плану 0001 – OBS 0010 – Дуга 0011 – Смещение 0100 – ЗО 0101 – ЗК 0110 – ЗПУ 0111 – Прямо-НА Остальные - резерв
								   // 32.		Направление на точку	BITS (32)	-	-	-	Таблица А2.1.2	599
			uint reserv2; // = 0
			uint Coord; // Координаты 	0 – Долгота/Широта 1 – Азимут/Дальность
			uint ProletZadUgol; // Пролет точки с заданным углом	0 – Магнитный 1 – Истинный (всегда 1)
			uint Regime; // Режим	0 – Автоматический 1 - Ручной 
			uint NPointFROM_Lo ; // Младшая  часть номера точки, от которой летим	Единицы
			uint NPointFROM_Hi; // Старшая часть номера точки, от которой летим	Десятки 
			uint NPointTo_Lo; // Младшая часть номера точки, на которую летим	Единицы
			uint NPointTo_Hi; // Старшая часть номера точки, на которую летим	Десятки 
									// 33.		Информация о ППМ	BITS (16)	-	-	-	Таблица А2.1.3	615
			ushort reserv3; // 0
			ushort PPM_type; // 7	Вид ППМ	0 – Без ЛУР (ППМ типа Flyover) 1 – С ЛУР (ППМтипа Flyby) 
			ushort PPM_cat; // Категория ППМ	000 – Вспомогательный ППМ 001 – СМВ 010 – СМП 100 – Точка маршрута 110 - Аэропорт 
			ushort PPM_prizn; // Функциональный признак ППМ в маршруте	00000 – ППМ промежуточный 00001 – Первый ППМ СМВ 00111 – Последний ППМ СМВ 01111 – Первый ППМ СМП 10110 – Последний ППМ СМП 11001 – Резерв 11010 – Точка центра дуги по часовой стрелке 11011 – Точка центра дуги против часовой стрелки
								  // 34.		Длина сообщения	BITS (32)	-	-	-	Таблица А2.1.4	647
			uint reserv4;
			uint Graph; // Графика	0 – Не графический 1 - Графический 
			uint Razryv; // Разрыв*	0 – Не установлен 1 – Установлен Всегда 0 
			uint PointInCenter; // Точка в центре маршрута	0 – Не в центре 1 – В центре Всегда 0 
			uint FMS; // Режим FMS	0 – Не выбран 1 – Выбран Всегда 0 
			uint NPoint; // Номер точки	ЦСР: 128 (Максимально 255) 
			uint InMarsh; // Принадлежность маршруту	0 – В маршруте 1 – Не в маршруте 
			uint PointType; // Тип точки	000 – UserWPT (Точка) 001 – Резерв 010 – Airport (Аэропорт) 011 – Маяк NDB 100 – Резерв 101 – Не рисовать символ 110 – VOR (Высокочастотный всенаправленный маяк) 111 – Intersection (Пересечение) 
			uint NWords; // Количество слов сообщения	ЦСР: 8 (Максимум 15)
							   // 35.		1-2 символы идентификатора НТ 	BITS (16)	-	-	-	Таблица А2.1.5	663
			ushort reserv5; // = 0;
			ushort SYM2; // Символ 2
			ushort SYM1; // Символ 1
							 // 36.		3-4 символы идентификатора НТ 	BITS (16)	-	-	-	Таблица А2.1.6	679
			ushort reserv6; // = 0;
			ushort SYM4; // Символ 4
			ushort SYM3; // Символ 3
							 // 37.		5-6 символы идентификатора НТ 	BITS (16)	-	-	-	Таблица А2.1.7	695
			ushort reserv7; // = 0;
			ushort SYM6; // Символ 6
			ushort SYM5; // Символ 5
			int latNT;    // 38.		Широта НТ	BС2	градусы	[-90;90]	90		727
			int lonNT;    // 39.		Долгота НТ	BС2	градусы	[-180;180]	90		759
							// 40.		Направление дуги	BITS (32)	-	-	-	Таблица А2.1.8	791
			uint reserv8; // = 0
			uint ArcDir; // Направление дуги	0 – пор часовой стрелке 1 – против часовой стрелки 
			uint ArcVal6; // Значащая часть	ЦСР: 180 ед.изм градусы 
			uint ArcZnak; // Знак
			ushort ArcR;    // 41.		Радиус дуги	BNR1	м.миля	-	128	-	807
			short ArcUgol;  // 42.		Угол изменения курса дуги	BС1	градусы	-	90	-	823
							// 43.		Направление путевого угла для зоны ожидания	BITS (32)	-	-	-	Таблица А2.1.9	855
			uint reserv9 ;
			uint ZoneDir ; // Направление	0 – влево 1 – вправо 
			uint ZoneVal ; // Значащая часть	ЦСР: 180 ед.изм градусы 
			uint ZoneZnak; //
			short MarshOffset;  // 44.		Смещение маршрута	BС1	м.миля	-	64	-	871
			short ZPU_OBS;      // 45.		Заданный путевой угол (для OBS)	BС1	градусы	-	90	15 бит - знак: 0 - если 180<ЗПУ<360; 1 - если ЗПУ>=180	887
			short ZK;           // 46.		Заданный курс	BС1	градусы	-	90		903
	}
}
