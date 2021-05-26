using System.Runtime.InteropServices;
using DataTransfer.Model.Component.Derived;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DynamicModelStruct : DirectObject
	{
		#region Fields
		/// <summary>
		/// Исходная воздушная скорость полета     км/ч
		/// </summary>
		float in_V;

		/// <summary>
		/// Исходная (Текущая) геометрическая высота полёта, м Относительно колеса основной стойки шасси
		/// </summary>
		float in_Hgeom;

		/// <summary>
		/// Текущее время     с
		/// </summary>
		float in_t;

		/// <summary>
		/// Шаг интегрирования     с   (не более 0.02 )
		/// </summary>
		float in_Shag;

		/// <summary>
		/// Текущее значение продольного управления    мм хода ручки + от себя +190, -115
		/// </summary>
		float in_UprTang;

		/// <summary>
		/// Текущее значение поперечного управления    мм хода ручки + влево 130
		/// </summary>
		float in_UprKren;

		/// <summary>
		/// Текущее значение путевого    управления     мм хода педалей  + правая педаль вперёд 81.5
		/// </summary>
		float in_UprPedal;

		/// <summary>
		/// Текущее значение общего шага несущего винта    Град. 0-30 рычаг, 0-20 винт (в модель)
		/// </summary>
		float in_UprShag;

		/// <summary>
		/// Исходная температура наружного воздуха    Гр. С
		/// </summary>
		float in_TemperatVozd0;

		/// <summary>
		/// Исходная масса вертолета    Кгс ср=10400, макс=10800, перегон=12200
		/// </summary>
		float in_Massa0;

		/// <summary>
		/// Исходная центровка, продольная    м    0.04 … 0.125, средняя   0.08
		/// </summary>
		float in_Center0;

		/// <summary>
		/// Горизонтальная составляющая силы ветра (Исходная, Текущая):     м/с
		/// </summary>
		float in_WindPwrHorz;

		/// <summary>
		/// Исходное (Текущее) направление ветра град.  В навигацион-ной системе координат
		/// </summary>
		float in_WindDir;

		/// <summary>
		/// Исходная заправка топлива     кгс    1500
		/// </summary>
		float in_Toplivo;

		/// <summary>
		/// Отклонение текущей температуры от стандартного градиента по барометрической высоте    Гр. С (При стандартном градиенте=0)
		/// </summary>
		float in_dTVozd;

		/// <summary>
		/// Исходный курс вертолёта    град  Навигационный (+ вправо), по умолчанию =0
		/// </summary>
		float in_Kurs0;

		/// <summary>
		/// Исходная координаты Хg     м      По  умолчанию =0
		/// </summary>
		float in_Xg0;

		/// <summary>
		/// Исходная координаты Zg    м      По  умолчанию =0
		/// </summary>
		float in_Zg0;

		/// <summary>
		/// [19..22] of single;
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] in_19_22;

		/// <summary>
		/// Исходная барометрическая высота  полёта вертолёта    м
		/// </summary>
		float in_Hbar;

		/// <summary>
		/// Расход продольного управления от автопилота    Мм хода штока АП Используются при работе внешнего автопилота, хода штоков АП  =  +-6.8 мм
		/// </summary>
		float in_APTang;

		/// <summary>
		/// Расход поперечного управления от автопилота    Мм хода штока АП
		/// </summary>
		float in_APKren;

		/// <summary>
		/// Расход путевого управления от автопилота    Мм хода штока АП
		/// </summary>
		float in_APPedal;

		/// <summary>
		/// Расход общего шага от автопилота    Мм хода штока АП
		/// </summary>
		float in_APShag;

		/// <summary>
		/// Угол поворота пушки в горизонтальной плоскости    Град. + влево от оси
		/// </summary>
		float in_AlfaPushkaHorz;

		/// <summary>
		/// Угол поворота пушки  в вертикальной плоскости    Град.   + вверх от оси
		/// </summary>
		float in_AlfaPushkaVert;

		/// <summary>
		/// array[30..41] of single
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		private float[] in_30_41;

		/// <summary>
		/// Вертикальная составляющая силы ветра
		/// </summary>
		float in_WindPwrVert;

		/// <summary>
		/// array[43..100] of single
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 58)]
		private float[] in_43_100;

		// управляющие сигналы

		/// <summary>
		/// Признак переключения на работу внешнего автопилота    б/р    (1,2)    0-внутренний а.п.,1- внешний
		/// </summary>
		int upr_AP_Out;

		/// <summary>
		/// признак полного отключения автопилота     б/р  2    (0-вкл.  1 - выкл.)
		/// </summary>
		int upr_AP_Off;

		/// <summary>
		/// триммирование углов тангажа, крена, курса  б/р    2  Кнопка трим-мера (0 - отжата, 1 - нажата)
		/// </summary>
		int upr_TrimAngles;

		/// <summary>
		/// Тумблер включения ЧР двигателя    б/р  (1,2)    1-вкл. 0-откл.
		/// </summary>
		int upr_EngineCritical;

		/// <summary>
		/// признак отключения левого двигателя  б/р    2    (0-вкл.  1 - выкл.)
		/// </summary>
		int upr_EngineLeftOff;

		/// <summary>
		/// признак отключения правого двигателя      б/р    2    (0-вкл.  1 - выкл.)
		/// </summary>
		int upr_EngineRightOff;

		/// <summary>
		/// триммирование канала высоты  автопилота         б/р    2    (0 - отжата,1 - нажата)
		/// </summary>
		int upr_TrimHeight;

		/// <summary>
		///  признак отключения канала тангажа   автопилота      б/р    2    (0-вкл.  1 - выкл.)
		/// </summary>
		int upr_APTangOff;

		/// <summary>
		/// признак отключения канала крена   автопилота     б/р    2    (0-вкл.  1 - выкл.)
		/// </summary>
		int upr_APKrenOff;

		/// <summary>
		/// признак отключения канала курса   автопилота          б/р    2    (0-вкл.  1 - выкл.)
		/// </summary>
		int upr_APKursOff;

		/// <summary>
		/// признак отключения канала высоты  автопилота б/р 2 (0-вкл.  1 - выкл.) как правило выключен
		/// </summary>
		int upr_APHeightOff; // 11  

		/// <summary>
		/// Режим работы СОС-В2     0- штатный 1- СМУ, ночь
		/// </summary>
		int upr_SOS;

		/// <summary>
		/// Скорострельность пушки    выст/мин    Задается темп стрельбы 600 или 300
		/// </summary>
		int upr_PushkaFreq;

		/// <summary>
		/// Боезапас пушки    штук
		/// </summary>
		int upr_PushkaCount;

		/// <summary>
		/// Кол-во снарядов в залпе НУРС    штук    Задаётся одно из значений 1, 10, 20
		/// </summary>
		int upr_NURSZalpCount;

		/// <summary>
		/// Признак подвески на левый пилон    Б/р    0-нет подвески 1-есть подвеска
		/// </summary>
		int upr_PodveskaL;

		/// <summary>
		/// Признак подвески на правый пилон    Б/р    0-нет подвески 1- подвеска
		/// </summary>
		int upr_PodveskaR;

		/// <summary>
		/// Признак нажатия на гашетку     Б/р     0-отжата 1-нажата
		/// </summary>
		int upr_Gashetka;

		/// <summary>
		/// Признак учебной стрельбы    Б/р    0-учеб 1-боевой
		/// </summary>
		int upr_Train;

		/// <summary>
		/// Выбор пушки    Б/р    Выбор оружия 0-    откл. 1-    выбрано
		/// </summary>
		int upr_SelectPushka;

		/// <summary>
		/// Выбор НУРС    Б/р
		/// </summary>
		int upr_SelectNURS;

		/// <summary>
		/// Выбор ПТУРС    Б/р
		/// </summary>
		int upr_SelectPTURS;

		/// <summary>
		/// Тип ПТУРС    Б/р        0-    "Вихрь" 1-    "Атака"
		/// </summary>
		int upr_PTURSType;


		// 24-29 Разовые команды срабатывания сигнализации по крену и тангажу, перегрузке и максимально допустимой скорости: 1-срабатывание 0-нет Звуковая и световая сигнализация
		/// <summary>
		/// прав крен
		/// </summary>
		int upr_SingalKrenR;
		/// <summary>
		/// лев крен
		/// </summary>
		int upr_SingalKrenL;

		/// <summary>
		/// тан кабр
		/// </summary>
		int upr_SignalTangKabr;

		/// <summary>
		/// тан пик
		/// </summary>
		int upr_SignalTangPikir;

		/// <summary>
		/// по перегрузке
		/// </summary>
		int upr_SignalOverload;

		/// <summary>
		/// по скорости    Б\р    2
		/// </summary>
		int upr_SignalVelocity;

		/// <summary>
		/// Перенастройка оборотов Н.В. б/р 1-кнопка нажата на повышение 0-отжата
		/// </summary>
		int upr_NVOborotUP;

		/// <summary>
		/// б/р 1- кнопка нажата на понижение 0-отжата
		/// </summary>
		int upr_NVOborotDOWN;

		/// <summary>
		/// Превышение скорости выхода из пикирования 1-срабатывание сигнализации 0-нет
		/// </summary> 
		int upr_SignalPikir;


		/// <summary>
		///  array[33..100] of integer
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
		private int[] upr_33_100;

		// выходные параметры

		/// <summary>
		/// Текущая воздушная скорость полета     км/ч      2
		/// </summary>
		float out_Vx;

		/// <summary>
		/// Текущий тангаж    град.    2
		/// </summary>
		float out_Tang;

		/// <summary>
		/// Текущий крен    град    2
		/// </summary>
		float out_Kren;

		/// <summary>
		/// Вертикальная скорость в земной системе координат    м/с    2
		/// </summary>
		float out_Vy;

		/// <summary>
		/// Вертикальная перегрузка ny в центре масс вертолёта    Б/р    2    В связанной системе координат
		/// </summary>
		float out_ny;

		/// <summary>
		/// Приборная скорость полёта    км/ч    2
		/// </summary>
		float out_Vprib;

		/// <summary>
		/// Скольжение     град.    2
		/// </summary>
		float out_Skolj;

		/// <summary>
		/// Текущие значения  d /dt    град./с    2
		/// </summary>
		float out_dTeta;

		/// <summary>
		/// Текущие значения  d /dt    град./с    2
		/// </summary>
		float out_dGamma;


		/// <summary>
		/// Текущая относительная высота полёта (относительно исходной точки)     м    2    Текущий результат интегрирования Vyg с нулевыми начальными условиями
		/// </summary>
		float out_Hotn;


		/// <summary>
		/// Текущие обороты несущего винта    %    2
		/// </summary>
		float out_Nnv;

		/// <summary>
		/// Xg     м    2    Текущие координаты в земной системе
		/// </summary>
		float out_Xg; // 12  

		/// <summary>
		/// 13  Zg     м    2
		/// </summary>
		float out_Zg;

		/// <summary>
		/// Текущий угол курса    град.    2    Навигационный (+ вправо)
		/// </summary>
		float out_Kurs;

		/// <summary>
		/// Исходный балансировочный тангаж    град    1
		/// </summary>
		float out_BalTang;

		/// <summary>
		/// Исходный балансировочный крен    град.    1
		/// </summary>
		float out_BalKren;

		/// <summary>
		/// Текущая температура наружного воздуха    Град.С    2
		/// </summary>
		float out_TemperatVozd;

		/// <summary>
		/// 
		/// </summary>
		float out_18;

		/// <summary>
		/// Текущее значение продольного отклонения равнодействующей  z    град.    2    + на себя
		/// </summary>
		float out_19;

		/// <summary>
		/// Текущее значение поперечного отклонения равнодействующей  x    град.    2    + вправо
		/// </summary>
		float out_20;

		/// <summary>
		/// Текущее значение общего шага несущего винта    град    2
		/// </summary>
		float out_OShag;

		/// <summary>
		/// Балансировочное значение продольного управления    мм хода ручки    1    + от себя
		/// </summary>
		float out_BalUprTang;

		/// <summary>
		/// Балансировочное значение поперечного управления    мм хода ручки     1    + влево
		/// </summary>
		float out_BalUprKren;


		/// <summary>
		/// Балансировочное значение путевого управления    мм хода педалей    1    + правая педаль вперёд
		/// </summary>
		float out_BalUprPedal;


		/// <summary>
		/// Балансировочное значение общего шага несущего винта    град.    1
		/// </summary>
		float out_BalUprShag;

		/// <summary>
		/// Температура газов левого двигателя    град.С    2
		/// </summary>
		float out_TGazL;

		/// <summary>
		/// Температура газов правого двигателя    град.С    2
		/// </summary>
		float out_TGazR;

		/// <summary>
		/// Мощность лев. двигателя    Л.с    2
		/// </summary>
		float out_EngPwrL;

		/// <summary>
		/// Мощность прав. двигателя    Л.с.    2
		/// </summary>
		float out_EngPwrR;

		/// <summary>
		/// Обороты газогенератора левого двигателя    % 2
		/// </summary>
		float out_NOborotL;

		/// <summary>
		/// Обороты газогенератора правого двигателя    %    2
		/// </summary>
		float out_NOborotR;

		/// <summary>
		/// Максимально допустимая скорость полёта    км/ч    2
		/// </summary>
		float out_Vmax;

		/// <summary>
		/// Текущий расход топлива лев. двигателя     Кгс/ч    2
		/// </summary>
		float out_ToplivoCurL;

		/// <summary>
		/// Текущий расход топлива прав. двигателя     Кгс/ч    2
		/// </summary>
		float out_ToplivoCurR;

		/// <summary>
		/// d /dt    Гр./с    2
		/// </summary>
		float out_dPsi;

		/// <summary>
		/// Vxg    М/с    2
		/// </summary>
		float out_36;

		/// <summary>
		/// Vzg    М/с    2
		/// </summary>
		float out_37;

		/// <summary>
		/// Боковая перегрузка nz    Б/р    2
		/// </summary>
		float out_nz;

		/// <summary>
		/// Текущая полётный вес    кгс    2    см. примечание
		/// </summary>
		float out_MassaCur;

		/// <summary>
		/// Текущий остаток топлива    кгс    2    см. примечание
		/// </summary>
		float out_ToplivoCur;


		/// <summary>
		///  x    Град./с    2    угловые ско-рости в связан-ной системе к-т (для внешнего автопилота)
		/// </summary>
		float out_omegax;


		/// <summary>
		/// y    Град./с    2
		/// </summary>
		float out_omegay;

		/// <summary>
		/// z    Град./с    2
		/// </summary>
		float out_omegaz;

		/// <summary>
		/// Максимально допустимая перегрузка ny    Ед.    2
		/// </summary>
		float out_nyMax;

		/// <summary>
		/// Максимально допустимый крен    Град.    2    правый и левый равны по модулю
		/// </summary>
		float out_KrenMax;

		/// <summary>
		/// Максимально допустимый тангаж на кабрирование    Град.    2
		/// </summary>
		float out_TangMaxKabr;

		/// <summary>
		/// Максимально допустимый тангаж на пикирование    Град.    2
		/// </summary>
		float out_TangMaxPikir;

		/// <summary>
		/// Расход боеприпасов пушки    Шт.    2
		/// </summary>
		float out_PushkaRashod;

		/// <summary>
		/// Расход НУРС    Шт.    2
		/// </summary>
		float out_NURSRashod;

		/// <summary>
		/// Расход ПТУРС    Шт.    2
		/// </summary>
		float out_PTURSRashod;

		/// <summary>
		/// Расход ракет возд.-возд.    Шт.    2    Не задействован
		/// </summary>
		float out_51;

		/// <summary>
		/// Признак схода НУРС слева    Б/р    2    Для визуализа-ции полёта ракет 1-выстрел 0-нет
		/// </summary>
		float out_52;

		/// <summary>
		/// Признак схода НУРС справа    Б/р    2
		/// </summary>
		float out_53;

		/// <summary>
		/// Признак схода ПТУРС слева    Б/р    2
		/// </summary>
		float out_54;

		/// <summary>
		/// Признак схода ПТУРС справа    Б/р    2
		/// </summary>
		float out_55;

		/// <summary>
		/// Признак схода "возд-возд" слева    Б/р    2    Не задействованы
		/// </summary>
		float out_56;

		/// <summary>
		/// Признак схода "возд-возд" справа    Б/р    2
		/// </summary>
		float out_57;

		/// <summary>
		/// По оси Х    м    1,2    Координаты центра масс вертолёта относительно геометрического центра вертолёта
		/// </summary>
		float out_CenterX;

		/// <summary>
		/// По оси Y    м    1,2
		/// </summary>
		float out_CenterY;

		/// <summary>
		/// По оси Z    м    1,2
		/// </summary>
		float out_CenterZ;

		/// <summary>
		/// Максимально допустимая скорость пологого пикирования    Км/ч    1,2
		/// </summary>
		float out_VMaxPikir;

		/// <summary>
		/// Приборная скорость Vz    Км/ч    1,2
		/// </summary>
		float out_Vzprib;

		/// <summary>
		/// Приборная скорость Vx        1,2       НА ПРИБОР !!!!!!!!!!!!
		/// </summary>
		float out_Vxprib;

		/// <summary>
		/// Приборная скорость вывода из пикирования        2
		/// </summary>
		float out_VpribPikirOut;


		/// <summary>
		/// array[65..89] of single
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
		private float[] out_65_89;


		/// <summary>
		/// Vy   (синие окошки) воздушная
		/// </summary>
		float out_Vy_SSK;

		/// <summary>
		///  Vz   (синие окошки) воздушная
		/// </summary>
		float out_Vz_SSK;

		/// <summary>
		/// Продольное упр-ние    Т
		/// </summary>
		float out_92;

		/// <summary>
		/// Поперечное упр-е    К
		/// </summary>
		float out_93;

		/// <summary>
		/// Путевое упр-е    Н
		/// </summary>
		float out_94;

		/// <summary>
		/// По ош    В
		/// </summary>
		float out_95;

		/// <summary>
		/// Vxg  ДИСС  Путевые скорости (км/ч)
		/// </summary>
		float out_Wxg;

		/// <summary>
		/// Vzg  ДИСС  Путевые скорости (км/ч)
		/// </summary>
		float out_Wzg;

		/// <summary>
		/// Vz пр (синие окошки) - слева, + справа (дискретность отображения 5 км/ч)
		/// </summary>
		float out_VzPrib_SSK;

		/// <summary>
		/// 
		/// </summary>
		float out_99; //

		/// <summary>
		/// 
		/// </summary>
		float out_100; // 
		#endregion
	}
}
