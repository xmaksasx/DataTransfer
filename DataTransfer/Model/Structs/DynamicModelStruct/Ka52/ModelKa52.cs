using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Structs.Bmpi;


namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka52
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ModelKa52: DynamicModel
	{
		protected override void SetHead()
		{
			GetHeadDouble("ModelKa52");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 4)
				Array.Reverse(dgram, i, 4);
		}
		
		public override byte[] GetPosition(AircraftPosition aircraftPosition)
		{
			aircraftPosition.IsDegree = 0;
			aircraftPosition.Tang = out_Tang;
			aircraftPosition.Kren =out_Kren;
			aircraftPosition.Risk = out_Kurs;
			aircraftPosition.GeoCoordinate.Latitude = 0;
			aircraftPosition.GeoCoordinate.Longitude = 0;
			aircraftPosition.GeoCoordinate.H = in_Hgeom;
			aircraftPosition.GeoCoordinate.X = out_Xg;
			aircraftPosition.GeoCoordinate.Z = out_Zg;
			return ConvertHelper.ObjectToByte(aircraftPosition);
		}

		public override byte[] GetForVaps(DynamicModelToVaps modelToVaps)
		{
			double Vpth = Math.Sqrt(out_36 * out_36 + out_37 * out_37); // м/с
			double PsiP = Math.Asin(out_37 / Vpth);
			double D2R = 180 / Math.PI;
			double Psi = out_Kurs;
			double psi_hi, psi_p_hi; // значения угла курса и путевого угла +-Pi (+-180)
			if (PsiP >= 0) psi_p_hi = PsiP;
			else psi_p_hi = PsiP - 2.0 * Math.PI; // путевой угол +-Pi (+-180)
			if (Psi >= 0) psi_hi = Psi;
			else psi_hi = Psi - 2.0 * Math.PI; // угол курса +-Pi (+-180)
			double hi = psi_p_hi - psi_hi; // угол сноса +-Pi (+-180)
			if (hi >= Math.PI) hi = hi - 2.0 * Math.PI;
			if (hi <= -Math.PI) hi = hi + 2.0 * Math.PI;

			double Tetr = 0; // угол наклона траектории, рад
							 // 1 вариант
							 //if (vhcloutp.instrumentsstate.tas != 0)
							 //	tetr = math.asin(kinematicsstate.absspeed.y / vhcloutp.instrumentsstate.tas);

			//// 2 вариант, альтернативно
			//// истинная воздушная скорость полета
			//double vp = math.sqrt(
			//	kinematicsstate.absspeed.x
			//	* kinematicsstate.absspeed.x
			//	+ kinematicsstate.absspeed.y
			//	* kinematicsstate.absspeed.y
			//	+ kinematicsstate.absspeed.z
			//	* kinematicsstate.absspeed.z);

			////(кинематическая)м / с
			//if (vp != 0)
			//	tetr = math.asin(kinematicsstate.absspeed.y / vp);

			//// ограничение для обоих вараинтов
			//if (tetr > math.pi / 2.0) tetr = tetr - math.pi / 2.0;
			//if (tetr < -math.pi / 2.0) tetr = tetr + math.pi / 2.0;

			//todo: тут нужно заполнить модель
			modelToVaps.Eng1.N = out_NOborotL;
			modelToVaps.Eng1.Mode = out_EngPwrL;
			modelToVaps.Eng1.Egt = out_TGazL;
			modelToVaps.Eng1.MaxAllowedEgt = 705;
			modelToVaps.Eng1.EmergencyEgt = 735;
			modelToVaps.Eng1.EngState = upr_EngineLeftOff;
			modelToVaps.Eng1.FuelFlow = out_ToplivoCurL;

			modelToVaps.Eng2.N = out_NOborotR;
			modelToVaps.Eng2.Mode = out_EngPwrR;
			modelToVaps.Eng2.Egt = out_TGazR;
			modelToVaps.Eng2.MaxAllowedEgt = 705;
			modelToVaps.Eng2.EmergencyEgt = 735;
			modelToVaps.Eng2.EngState = upr_EngineRightOff;
			modelToVaps.Eng2.FuelFlow = out_ToplivoCurR;

			modelToVaps.ModeFly = 1;
			modelToVaps.RemainingFuel = in_Massa0 -out_MassaCur;
			modelToVaps.RotorSpeed = out_Nnv;

			//todo: нужно написать условия о смене значения от скорости
			///98	-	до 200
			///93	-	от 200 до 270
			///91	-	от 270 до 300
			modelToVaps.MaximumPermissibleRotor = 93;
			modelToVaps.TotalRotor = out_OShag;
			modelToVaps.RecommendedValueRotor = 0;
			modelToVaps.HeadingCurrent = out_Kurs;
			modelToVaps.HeadingTrack = PsiP * D2R;
			modelToVaps.AngleDrift = hi * D2R;
			modelToVaps.Angleslip = out_Skolj;
			modelToVaps.RollCurrent = out_Kren;
			modelToVaps.MaximumPermissibleRoll = out_KrenMax;
			modelToVaps.RecommendedRollValue = 0;
			modelToVaps.PitchCurrent = out_Tang;
			modelToVaps.RecommendedPitchValue = 0;
			modelToVaps.RermissiblePitchPitching = out_TangMaxKabr;
			modelToVaps.PermissiblePitchDiving = out_TangMaxPikir;
			modelToVaps.AngleAttack = 0;
			modelToVaps.PermissibleAngleAttack = 0;
			modelToVaps.PositionBall = out_Skolj;
			modelToVaps.AngleTrajectory = 0;
			modelToVaps.Vy = out_Vy;
			modelToVaps.MinVy = -5;
			modelToVaps.MaxVy = +5;
			modelToVaps.InstrumentSpeedCurrent = out_Vprib;
			modelToVaps.MaxInstrumentSpeed = out_Vmax;
			modelToVaps.MinInstrumentSpeed = 50;
			modelToVaps.SpeedX = out_Vxprib;  //??
			modelToVaps.SpeedZ = out_Vzprib;  //??
			modelToVaps.RecommendedDiveSpeed = 0;
			modelToVaps.RecommendedSpeedDiveEnd = 0;
			modelToVaps.TrueSpeedCurrent = in_V;  //??
			modelToVaps.GroundSpeedX = out_Wxg; //??
			modelToVaps.GroundSpeedZ = out_Wzg; //??
			modelToVaps.Mach = 0;//??
			modelToVaps.RelativeHeight = out_Hotn;
			modelToVaps.BarometricHeight = in_Hbar;
			modelToVaps.Pressure =0;

			//минус высота рельефа
			modelToVaps.HeightAltimeter = out_Hotn;
			modelToVaps.DangerousHeight = 50;

			modelToVaps.Ny.Value = out_ny;
			modelToVaps.Ny.Min = -0.5;
			modelToVaps.Ny.Max = out_nyMax;

			modelToVaps.Nx.Value = 0;
			modelToVaps.Nx.Min = 0;
			modelToVaps.Nx.Max = 0;

			modelToVaps.Nz.Value = out_nz;
			modelToVaps.Nz.Min = 0;
			modelToVaps.Nz.Max = 0;

			modelToVaps.HeadingWind = in_WindDir;
			modelToVaps.HorizontalWindSpeed = in_WindPwrHorz;

			modelToVaps.MaxPermissibleWindSpeed = 25;

			modelToVaps.Mechanization[0] = 0;
			modelToVaps.Mechanization[1] = 0;
			modelToVaps.Mechanization[2] = 0;
			modelToVaps.Mechanization[3] = 0;
										   
			var dgram = ConvertHelper.ObjectToByte(modelToVaps);
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
			return dgram;
		}

		public override byte[] GetForBmpi(DynamicModelToBmpi modelToBmpi)
		{
			modelToBmpi.lat_sns = 0;
			modelToBmpi.lon_sns = 0;
			modelToBmpi.H_sns = out_Hotn;
			modelToBmpi.Day = (ushort)DateTime.Now.Day;
			modelToBmpi.Month = (ushort)DateTime.Now.Month;
			modelToBmpi.Year = (ushort)DateTime.Now.Year;
			modelToBmpi.Minute = (ushort)DateTime.Now.Minute;
			modelToBmpi.Hour = (ushort)DateTime.Now.Hour;
			modelToBmpi.Second = (ushort)DateTime.Now.Second;
			modelToBmpi.FPU_sns = 0;
			modelToBmpi.Vputev_sns = 0;//??
			modelToBmpi.Vy_sns = out_Vy;
			modelToBmpi.Vxg = (float)(out_Wxg/ 1.852);
			modelToBmpi.Vzg = (float)(out_Wzg/ 1.852);

			modelToBmpi.lat_ins = 0;
			modelToBmpi.lon_ins = 0;
			modelToBmpi.Vputev_ins = 0;//??
			modelToBmpi.PU = out_Kurs;//??
			modelToBmpi.PsiIst = out_Kurs;
			modelToBmpi.Uwind = (float)(in_WindPwrHorz * 3.6);
			modelToBmpi.AlfaWind = in_WindDir;
			modelToBmpi.FPUmagn = 0;//??
			modelToBmpi.PSImagn = 0;//??
			modelToBmpi.Snos = 0;//??
			modelToBmpi.Teta = out_Tang;
			modelToBmpi.Gamma = out_Kren;
			modelToBmpi.OmegaZ = out_omegaz;
			modelToBmpi.OmegaX = out_omegax;
			modelToBmpi.OmegaY = out_omegay;
			modelToBmpi.JX = 0;//??
			modelToBmpi.JZ = 0;//??
			modelToBmpi.JY = 0;//??
			modelToBmpi.JYg = 0;//??

			modelToBmpi.Hotn_QFE = in_Hbar;//??
			modelToBmpi.Hotn_QNH = in_Hbar;//??
			modelToBmpi.Vpr = out_Vprib;
			modelToBmpi.Hbar_abs = in_Hbar;
			modelToBmpi.Vist = out_Vx;
			modelToBmpi.Tvozd = 0;

			modelToBmpi.Hrv = in_Hbar;

			modelToBmpi.lat_vpp = 0;
			modelToBmpi.lon_vpp = 0;
			modelToBmpi.Hzad = 0;
			modelToBmpi.TOffset_Minute = 0;
			modelToBmpi.TOffset_Hour = 0;
			modelToBmpi.TOffset_Second = 0;
			return  ConvertHelper.ObjectToByte(modelToBmpi);
		}

		#region Fields

		/// <summary>
		/// Исходная воздушная скорость полета км/ч
		/// </summary>
		[Description("Исходная воздушная скорость полета км/ч")]
		float in_V;

		/// <summary>
		/// Исходная (Текущая) геометрическая высота полёта, м Относительно колеса основной стойки шасси
		/// </summary>
		[Description("Исходная (Текущая) геометрическая высота полёта, м Относительно колеса основной стойки шасси")]
		float in_Hgeom;

		/// <summary>
		/// Текущее время с
		/// </summary>
		[Description("Текущее время с")] float in_t;

		/// <summary>
		/// Шаг интегрирования с (не более 0.02 )
		/// </summary>
		[Description("Шаг интегрирования с (не более 0.02 )")]
		float in_Shag;

		/// <summary>
		/// Текущее значение продольного управления мм хода ручки + от себя +190, -115
		/// </summary>
		[Description("Текущее значение продольного управления мм хода ручки + от себя +190, -115")]
		float in_UprTang;

		/// <summary>
		/// Текущее значение поперечного управления мм хода ручки + влево 130
		/// </summary>
		[Description("Текущее значение поперечного управления мм хода ручки + влево 130")]
		float in_UprKren;

		/// <summary>
		/// Текущее значение путевого управления мм хода педалей + правая педаль вперёд 81.5
		/// </summary>
		[Description("Текущее значение путевого управления мм хода педалей + правая педаль вперёд 81.5")]
		float in_UprPedal;

		/// <summary>
		/// Текущее значение общего шага несущего винта Град. 0-30 рычаг, 0-20 винт (в модель)
		/// </summary>
		[Description("Текущее значение общего шага несущего винта Град. 0-30 рычаг, 0-20 винт (в модель)")]
		float in_UprShag;

		/// <summary>
		/// Исходная температура наружного воздуха Гр. С
		/// </summary>
		[Description("Исходная температура наружного воздуха Гр. С")]
		float in_TemperatVozd0;

		/// <summary>
		/// Исходная масса вертолета Кгс ср=10400, макс=10800, перегон=12200
		/// </summary>
		[Description("Исходная масса вертолета Кгс ср=10400, макс=10800, перегон=12200")]
		float in_Massa0;

		/// <summary>
		/// Исходная центровка, продольная м 0.04 … 0.125, средняя 0.08
		/// </summary>
		[Description("Исходная центровка, продольная м 0.04 … 0.125, средняя 0.08")]
		float in_Center0;

		/// <summary>
		/// Горизонтальная составляющая силы ветра (Исходная, Текущая): м/с
		/// </summary>
		[Description("Горизонтальная составляющая силы ветра (Исходная, Текущая): м/с")]
		float in_WindPwrHorz;

		/// <summary>
		/// Исходное (Текущее) направление ветра град. В навигацион-ной системе координат
		/// </summary>
		[Description("Исходное (Текущее) направление ветра град. В навигацион-ной системе координат")]
		float in_WindDir;

		/// <summary>
		/// Исходная заправка топлива кгс 1500
		/// </summary>
		[Description("Исходная заправка топлива кгс 1500")]
		float in_Toplivo;

		/// <summary>
		/// Отклонение текущей температуры от стандартного градиента по барометрической высоте Гр. С (При стандартном градиенте=0)
		/// </summary>
		[Description(
			"Отклонение текущей температуры от стандартного градиента по барометрической высоте Гр. С (При стандартном градиенте=0)")]
		float in_dTVozd;

		/// <summary>
		/// Исходный курс вертолёта град Навигационный (+ вправо), по умолчанию =0
		/// </summary>
		[Description("Исходный курс вертолёта град Навигационный (+ вправо), по умолчанию =0")]
		float in_Kurs0;

		/// <summary>
		/// Исходная координаты Хg м По умолчанию =0
		/// </summary>
		[Description("Исходная координаты Хg м По умолчанию =0")]
		float in_Xg0;

		/// <summary>
		/// Исходная координаты Zg м По умолчанию =0
		/// </summary>
		[Description("Исходная координаты Zg м По умолчанию =0")]
		float in_Zg0;

		/// <summary>
		/// [19..22] of single;
		/// </summary>
		[Description("[19..22] of single;")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] in_19_22 = new float[4];

		/// <summary>
		/// Исходная барометрическая высота полёта вертолёта м
		/// </summary>
		[Description("Исходная барометрическая высота полёта вертолёта м")]
		float in_Hbar;

		/// <summary>
		/// Расход продольного управления от автопилота Мм хода штока АП Используются при работе внешнего автопилота, хода штоков АП = +-6.8 мм
		/// </summary>
		[Description(
			"Расход продольного управления от автопилота Мм хода штока АП Используются при работе внешнего автопилота, хода штоков АП = +-6.8 мм")]
		float in_APTang;

		/// <summary>
		/// Расход поперечного управления от автопилота Мм хода штока АП
		/// </summary>
		[Description("Расход поперечного управления от автопилота Мм хода штока АП")]
		float in_APKren;

		/// <summary>
		/// Расход путевого управления от автопилота Мм хода штока АП
		/// </summary>
		[Description("Расход путевого управления от автопилота Мм хода штока АП")]
		float in_APPedal;

		/// <summary>
		/// Расход общего шага от автопилота Мм хода штока АП
		/// </summary>
		[Description("Расход общего шага от автопилота Мм хода штока АП")]
		float in_APShag;

		/// <summary>
		/// Угол поворота пушки в горизонтальной плоскости Град. + влево от оси
		/// </summary>
		[Description("Угол поворота пушки в горизонтальной плоскости Град. + влево от оси")]
		float in_AlfaPushkaHorz;

		/// <summary>
		/// Угол поворота пушки в вертикальной плоскости Град. + вверх от оси
		/// </summary>
		[Description("Угол поворота пушки в вертикальной плоскости Град. + вверх от оси")]
		float in_AlfaPushkaVert;

		/// <summary>
		/// array[30..41] of single
		/// </summary>
		[Description("array[30..41] of single")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		private float[] in_30_41;

		/// <summary>
		/// Вертикальная составляющая силы ветра
		/// </summary>
		[Description("Вертикальная составляющая силы ветра")]
		float in_WindPwrVert;

		/// <summary>
		/// array[43..100] of single
		/// </summary>
		[Description("array[43..100] of single")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 58)]
		private float[] in_43_100;

		// управляющие сигналы
		/// <summary>
		/// Признак переключения на работу внешнего автопилота б/р (1,2) 0-внутренний а.п.,1- внешний
		/// </summary>
		[Description("Признак переключения на работу внешнего автопилота б/р (1,2) 0-внутренний а.п.,1- внешний")]
		int upr_AP_Out;

		/// <summary>
		/// признак полного отключения автопилота б/р 2 (0-вкл. 1 - выкл.)
		/// </summary>
		[Description("признак полного отключения автопилота б/р 2 (0-вкл. 1 - выкл.)")]
		int upr_AP_Off;

		/// <summary>
		/// триммирование углов тангажа, крена, курса б/р 2 Кнопка трим-мера (0 - отжата, 1 - нажата)
		/// </summary>
		[Description("триммирование углов тангажа, крена, курса б/р 2 Кнопка трим-мера (0 - отжата, 1 - нажата)")]
		int upr_TrimAngles;

		/// <summary>
		/// Тумблер включения ЧР двигателя б/р (1,2) 1-вкл. 0-откл.
		/// </summary>
		[Description("Тумблер включения ЧР двигателя б/р (1,2) 1-вкл. 0-откл.")]
		int upr_EngineCritical;

		/// <summary>
		/// признак отключения левого двигателя б/р 2 (0-вкл. 1 - выкл.)
		/// </summary>
		[Description("признак отключения левого двигателя б/р 2 (0-вкл. 1 - выкл.)")]
		int upr_EngineLeftOff;

		/// <summary>
		/// признак отключения правого двигателя б/р 2 (0-вкл. 1 - выкл.)
		/// </summary>
		[Description("признак отключения правого двигателя б/р 2 (0-вкл. 1 - выкл.)")]
		int upr_EngineRightOff;

		/// <summary>
		/// триммирование канала высоты автопилота б/р 2 (0 - отжата,1 - нажата)
		/// </summary>
		[Description("триммирование канала высоты автопилота б/р 2 (0 - отжата,1 - нажата)")]
		int upr_TrimHeight;

		/// <summary>
		/// признак отключения канала тангажа автопилота б/р 2 (0-вкл. 1 - выкл.)
		/// </summary>
		[Description("признак отключения канала тангажа автопилота б/р 2 (0-вкл. 1 - выкл.)")]
		int upr_APTangOff;

		/// <summary>
		/// признак отключения канала крена автопилота б/р 2 (0-вкл. 1 - выкл.)
		/// </summary>
		[Description("признак отключения канала крена автопилота б/р 2 (0-вкл. 1 - выкл.)")]
		int upr_APKrenOff;

		/// <summary>
		/// признак отключения канала курса автопилота б/р 2 (0-вкл. 1 - выкл.)
		/// </summary>
		[Description("признак отключения канала курса автопилота б/р 2 (0-вкл. 1 - выкл.)")]
		int upr_APKursOff;

		/// <summary>
		/// признак отключения канала высоты автопилота б/р 2 (0-вкл. 1 - выкл.) как правило выключен
		/// </summary>
		[Description("признак отключения канала высоты автопилота б/р 2 (0-вкл. 1 - выкл.) как правило выключен")]
		int upr_APHeightOff; // 11 

		/// <summary>
		/// Режим работы СОС-В2 0- штатный 1- СМУ, ночь
		/// </summary>
		[Description("Режим работы СОС-В2 0- штатный 1- СМУ, ночь")]
		int upr_SOS;

		/// <summary>
		/// Скорострельность пушки выст/мин Задается темп стрельбы 600 или 300
		/// </summary>
		[Description("Скорострельность пушки выст/мин Задается темп стрельбы 600 или 300")]
		int upr_PushkaFreq;

		/// <summary>
		/// Боезапас пушки штук
		/// </summary>
		[Description("Боезапас пушки штук")] int upr_PushkaCount;

		/// <summary>
		/// Кол-во снарядов в залпе НУРС штук Задаётся одно из значений 1, 10, 20
		/// </summary>
		[Description("Кол-во снарядов в залпе НУРС штук Задаётся одно из значений 1, 10, 20")]
		int upr_NURSZalpCount;

		/// <summary>
		/// Признак подвески на левый пилон Б/р 0-нет подвески 1-есть подвеска
		/// </summary>
		[Description("Признак подвески на левый пилон Б/р 0-нет подвески 1-есть подвеска")]
		int upr_PodveskaL;

		/// <summary>
		/// Признак подвески на правый пилон Б/р 0-нет подвески 1- подвеска
		/// </summary>
		[Description("Признак подвески на правый пилон Б/р 0-нет подвески 1- подвеска")]
		int upr_PodveskaR;

		/// <summary>
		/// Признак нажатия на гашетку Б/р 0-отжата 1-нажата
		/// </summary>
		[Description("Признак нажатия на гашетку Б/р 0-отжата 1-нажата")]
		int upr_Gashetka;

		/// <summary>
		/// Признак учебной стрельбы Б/р 0-учеб 1-боевой
		/// </summary>
		[Description("Признак учебной стрельбы Б/р 0-учеб 1-боевой")]
		int upr_Train;

		/// <summary>
		/// Выбор пушки Б/р Выбор оружия 0- откл. 1- выбрано
		/// </summary>
		[Description("Выбор пушки Б/р Выбор оружия 0- откл. 1- выбрано")]
		int upr_SelectPushka;

		/// <summary>
		/// Выбор НУРС Б/р
		/// </summary>
		[Description("Выбор НУРС Б/р")] int upr_SelectNURS;

		/// <summary>
		/// Выбор ПТУРС Б/р
		/// </summary>
		[Description("Выбор ПТУРС Б/р")] int upr_SelectPTURS;

		/// <summary>
		/// Тип ПТУРС Б/р 0- "Вихрь" 1- "Атака"
		/// </summary>
		[Description("Тип ПТУРС Б/р 0-Вихрь 1- Атака")]

		int upr_PTURSType;

		// 24-29 Разовые команды срабатывания сигнализации по крену и тангажу, перегрузке и максимально допустимой скорости: 1-срабатывание 0-нет Звуковая и световая сигнализация
		/// <summary>
		/// прав крен
		/// </summary>
		[Description("прав крен")] int upr_SingalKrenR;

		/// <summary>
		/// лев крен
		/// </summary>
		[Description("лев крен")] int upr_SingalKrenL;

		/// <summary>
		/// тан кабр
		/// </summary>
		[Description("тан кабр")] int upr_SignalTangKabr;

		/// <summary>
		/// тан пик
		/// </summary>
		[Description("тан пик")] int upr_SignalTangPikir;

		/// <summary>
		/// по перегрузке
		/// </summary>
		[Description("по перегрузке")] int upr_SignalOverload;

		/// <summary>
		/// по скорости Б\р 2
		/// </summary>
		[Description("по скорости Б/р 2")] int upr_SignalVelocity;

		/// <summary>
		/// Перенастройка оборотов Н.В. б/р 1-кнопка нажата на повышение 0-отжата
		/// </summary>
		[Description("Перенастройка оборотов Н.В. б/р 1-кнопка нажата на повышение 0-отжата")]
		int upr_NVOborotUP;

		/// <summary>
		/// б/р 1- кнопка нажата на понижение 0-отжата
		/// </summary>
		[Description("б/р 1- кнопка нажата на понижение 0-отжата")]
		int upr_NVOborotDOWN;

		/// <summary>
		/// Превышение скорости выхода из пикирования 1-срабатывание сигнализации 0-нет
		/// </summary>
		[Description("Превышение скорости выхода из пикирования 1-срабатывание сигнализации 0-нет")]

		int upr_SignalPikir;

		/// <summary>
		/// array[33..100] of integer
		/// </summary>
		[Description("array[33..100] of integer")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
		private int[] upr_33_100;

		// выходные параметры
		/// <summary>
		/// Текущая воздушная скорость полета км/ч 2
		/// </summary>
		[Description("Текущая воздушная скорость полета км/ч 2")]
		float out_Vx;

		/// <summary>
		/// Текущий тангаж град. 2
		/// </summary>
		[Description("Текущий тангаж град. 2")]
		public float out_Tang;

		/// <summary>
		/// Текущий крен град 2
		/// </summary>
		[Description("Текущий крен град 2")] public float out_Kren;

		/// <summary>
		/// Вертикальная скорость в земной системе координат м/с 2
		/// </summary>
		[Description("Вертикальная скорость в земной системе координат м/с 2")]
		float out_Vy;

		/// <summary>
		/// Вертикальная перегрузка ny в центре масс вертолёта Б/р 2 В связанной системе координат
		/// </summary>
		[Description("Вертикальная перегрузка ny в центре масс вертолёта Б/р 2 В связанной системе координат")]
		float out_ny;

		/// <summary>
		/// Приборная скорость полёта км/ч 2
		/// </summary>
		[Description("Приборная скорость полёта км/ч 2")]
		float out_Vprib;

		/// <summary>
		/// Скольжение град. 2
		/// </summary>
		[Description("Скольжение град. 2")] float out_Skolj;

		/// <summary>
		/// Текущие значения d /dt град./с 2
		/// </summary>
		[Description("Текущие значения d /dt град./с 2")]
		float out_dTeta;

		/// <summary>
		/// Текущие значения d /dt град./с 2
		/// </summary>
		[Description("Текущие значения d /dt град./с 2")]
		float out_dGamma;

		/// <summary>
		/// Текущая относительная высота полёта (относительно исходной точки) м 2 Текущий результат интегрирования Vyg с нулевыми начальными условиями
		/// </summary>
		[Description(
			"Текущая относительная высота полёта (относительно исходной точки) м 2 Текущий результат интегрирования Vyg с нулевыми начальными условиями")]
		public float out_Hotn;

		/// <summary>
		/// Текущие обороты несущего винта % 2
		/// </summary>
		[Description("Текущие обороты несущего винта % 2")]
		float out_Nnv;

		/// <summary>
		/// Xg м 2 Текущие координаты в земной системе
		/// </summary>
		[Description("Xg м 2 Текущие координаты в земной системе")]
		public float out_Xg; // 12 

		/// <summary>
		/// 13 Zg м 2
		/// </summary>
		[Description("13 Zg м 2")] public float out_Zg;

		/// <summary>
		/// Текущий угол курса град. 2 Навигационный (+ вправо)
		/// </summary>
		[Description("Текущий угол курса град. 2 Навигационный (+ вправо)")]
		public float out_Kurs;

		/// <summary>
		/// Исходный балансировочный тангаж град 1
		/// </summary>
		[Description("Исходный балансировочный тангаж град 1")]
		float out_BalTang;

		/// <summary>
		/// Исходный балансировочный крен град. 1
		/// </summary>
		[Description("Исходный балансировочный крен град. 1")]
		float out_BalKren;

		/// <summary>
		/// Текущая температура наружного воздуха Град.С 2
		/// </summary>
		[Description("Текущая температура наружного воздуха Град.С 2")]
		float out_TemperatVozd;

		/// <summary>
		/// 
		float out_18;

		/// <summary>
		/// Текущее значение продольного отклонения равнодействующей z град. 2 + на себя
		/// </summary>
		[Description("Текущее значение продольного отклонения равнодействующей z град. 2 + на себя")]
		float out_19;

		/// <summary>
		/// Текущее значение поперечного отклонения равнодействующей x град. 2 + вправо
		/// </summary>
		[Description("Текущее значение поперечного отклонения равнодействующей x град. 2 + вправо")]
		float out_20;

		/// <summary>
		/// Текущее значение общего шага несущего винта град 2
		/// </summary>
		[Description("Текущее значение общего шага несущего винта град 2")]
		float out_OShag;

		/// <summary>
		/// Балансировочное значение продольного управления мм хода ручки 1 + от себя
		/// </summary>
		[Description("Балансировочное значение продольного управления мм хода ручки 1 + от себя")]
		float out_BalUprTang;

		/// <summary>
		/// Балансировочное значение поперечного управления мм хода ручки 1 + влево
		/// </summary>
		[Description("Балансировочное значение поперечного управления мм хода ручки 1 + влево")]
		float out_BalUprKren;

		/// <summary>
		/// Балансировочное значение путевого управления мм хода педалей 1 + правая педаль вперёд
		/// </summary>
		[Description("Балансировочное значение путевого управления мм хода педалей 1 + правая педаль вперёд")]
		float out_BalUprPedal;

		/// <summary>
		/// Балансировочное значение общего шага несущего винта град. 1
		/// </summary>
		[Description("Балансировочное значение общего шага несущего винта град. 1")]
		float out_BalUprShag;

		/// <summary>
		/// Температура газов левого двигателя град.С 2
		/// </summary>
		[Description("Температура газов левого двигателя град.С 2")]
		float out_TGazL;

		/// <summary>
		/// Температура газов правого двигателя град.С 2
		/// </summary>
		[Description("Температура газов правого двигателя град.С 2")]
		float out_TGazR;

		/// <summary>
		/// Мощность лев. двигателя Л.с 2
		/// </summary>
		[Description("Мощность лев. двигателя Л.с 2")]
		float out_EngPwrL;

		/// <summary>
		/// Мощность прав. двигателя Л.с. 2
		/// </summary>
		[Description("Мощность прав. двигателя Л.с. 2")]
		float out_EngPwrR;

		/// <summary>
		/// Обороты газогенератора левого двигателя % 2
		/// </summary>
		[Description("Обороты газогенератора левого двигателя % 2")]
		float out_NOborotL;

		/// <summary>
		/// Обороты газогенератора правого двигателя % 2
		/// </summary>
		[Description("Обороты газогенератора правого двигателя % 2")]
		float out_NOborotR;

		/// <summary>
		/// Максимально допустимая скорость полёта км/ч 2
		/// </summary>
		[Description("Максимально допустимая скорость полёта км/ч 2")]
		float out_Vmax;

		/// <summary>
		/// Текущий расход топлива лев. двигателя Кгс/ч 2
		/// </summary>
		[Description("Текущий расход топлива лев. двигателя Кгс/ч 2")]
		float out_ToplivoCurL;

		/// <summary>
		/// Текущий расход топлива прав. двигателя Кгс/ч 2
		/// </summary>
		[Description("Текущий расход топлива прав. двигателя Кгс/ч 2")]
		float out_ToplivoCurR;

		/// <summary>
		/// d /dt Гр./с 2
		/// </summary>
		[Description("d /dt Гр./с 2")] float out_dPsi;

		/// <summary>
		/// Vxg М/с 2
		/// </summary>
		[Description("Vxg М/с 2")] float out_36;

		/// <summary>
		/// Vzg М/с 2
		/// </summary>
		[Description("Vzg М/с 2")] float out_37;

		/// <summary>
		/// Боковая перегрузка nz Б/р 2
		/// </summary>
		[Description("Боковая перегрузка nz Б/р 2")]
		float out_nz;

		/// <summary>
		/// Текущая полётный вес кгс 2 см. примечание
		/// </summary>
		[Description("Текущая полётный вес кгс 2 см. примечание")]
		float out_MassaCur;

		/// <summary>
		/// Текущий остаток топлива кгс 2 см. примечание
		/// </summary>
		[Description("Текущий остаток топлива кгс 2 см. примечание")]
		float out_ToplivoCur;

		/// <summary>
		/// x Град./с 2 угловые ско-рости в связан-ной системе к-т (для внешнего автопилота)
		/// </summary>
		[Description("x Град./с 2 угловые ско-рости в связан-ной системе к-т (для внешнего автопилота)")]
		float out_omegax;

		/// <summary>
		/// y Град./с 2
		/// </summary>
		[Description("y Град./с 2")] float out_omegay;

		/// <summary>
		/// z Град./с 2
		/// </summary>
		[Description("z Град./с 2")] float out_omegaz;

		/// <summary>
		/// Максимально допустимая перегрузка ny Ед. 2
		/// </summary>
		[Description("Максимально допустимая перегрузка ny Ед. 2")]
		float out_nyMax;

		/// <summary>
		/// Максимально допустимый крен Град. 2 правый и левый равны по модулю
		/// </summary>
		[Description("Максимально допустимый крен Град. 2 правый и левый равны по модулю")]
		float out_KrenMax;

		/// <summary>
		/// Максимально допустимый тангаж на кабрирование Град. 2
		/// </summary>
		[Description("Максимально допустимый тангаж на кабрирование Град. 2")]
		float out_TangMaxKabr;

		/// <summary>
		/// Максимально допустимый тангаж на пикирование Град. 2
		/// </summary>
		[Description("Максимально допустимый тангаж на пикирование Град. 2")]
		float out_TangMaxPikir;

		/// <summary>
		/// Расход боеприпасов пушки Шт. 2
		/// </summary>
		[Description("Расход боеприпасов пушки Шт. 2")]
		float out_PushkaRashod;

		/// <summary>
		/// Расход НУРС Шт. 2
		/// </summary>
		[Description("Расход НУРС Шт. 2")] float out_NURSRashod;

		/// <summary>
		/// Расход ПТУРС Шт. 2
		/// </summary>
		[Description("Расход ПТУРС Шт. 2")] float out_PTURSRashod;

		/// <summary>
		/// Расход ракет возд.-возд. Шт. 2 Не задействован
		/// </summary>
		[Description("Расход ракет возд.-возд. Шт. 2 Не задействован")]
		float out_51;

		/// <summary>
		/// Признак схода НУРС слева Б/р 2 Для визуализа-ции полёта ракет 1-выстрел 0-нет
		/// </summary>
		[Description("Признак схода НУРС слева Б/р 2 Для визуализа-ции полёта ракет 1-выстрел 0-нет")]
		float out_52;

		/// <summary>
		/// Признак схода НУРС справа Б/р 2
		/// </summary>
		[Description("Признак схода НУРС справа Б/р 2")]
		float out_53;

		/// <summary>
		/// Признак схода ПТУРС слева Б/р 2
		/// </summary>
		[Description("Признак схода ПТУРС слева Б/р 2")]
		float out_54;

		/// <summary>
		/// Признак схода ПТУРС справа Б/р 2
		/// </summary>
		[Description("Признак схода ПТУРС справа Б/р 2")]
		float out_55;

		/// <summary>
		/// Признак схода "возд-возд" слева Б/р 2 Не задействованы
		/// </summary>
		[Description("Признак схода возд - возд слева Б/р 2 Не задействованы")]
		float out_56;

		/// <summary>
		/// Признак схода "возд-возд" справа Б/р 2
		/// </summary>
		[Description("Признак схода возд - возд справа Б/р 2")]
		float out_57;

		/// <summary>
		/// По оси Х м 1,2 Координаты центра масс вертолёта относительно геометрического центра вертолёта
		/// </summary>
		[Description("По оси Х м 1,2 Координаты центра масс вертолёта относительно геометрического центра вертолёта")]
		float out_CenterX;

		/// <summary>
		/// По оси Y м 1,2
		/// </summary>
		[Description("По оси Y м 1,2")] float out_CenterY;

		/// <summary>
		/// По оси Z м 1,2
		/// </summary>
		[Description("По оси Z м 1,2")] float out_CenterZ;

		/// <summary>
		/// Максимально допустимая скорость пологого пикирования Км/ч 1,2
		/// </summary>
		[Description("Максимально допустимая скорость пологого пикирования Км/ч 1,2")]
		float out_VMaxPikir;

		/// <summary>
		/// Приборная скорость Vz Км/ч 1,2
		/// </summary>
		[Description("Приборная скорость Vz Км/ч 1,2")]
		float out_Vzprib;

		/// <summary>
		/// Приборная скорость Vx 1,2 НА ПРИБОР !!!!!!!!!!!!
		/// </summary>
		[Description("Приборная скорость Vx 1,2 НА ПРИБОР !!!!!!!!!!!!")]
		float out_Vxprib;

		/// <summary>
		/// Приборная скорость вывода из пикирования 2
		/// </summary>
		[Description("Приборная скорость вывода из пикирования 2")]
		float out_VpribPikirOut;

		/// <summary>
		/// array[65..89] of single
		/// </summary>
		[Description("array[65..89] of single")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
		private float[] out_65_89;

		/// <summary>
		/// Vy (синие окошки) воздушная
		/// </summary>
		[Description("Vy (синие окошки) воздушная")]
		float out_Vy_SSK;

		/// <summary>
		/// Vz (синие окошки) воздушная
		/// </summary>
		[Description("Vz (синие окошки) воздушная")]
		float out_Vz_SSK;

		/// <summary>
		/// Продольное упр-ние Т
		/// </summary>
		[Description("Продольное упр-ние Т")] float out_92;

		/// <summary>
		/// Поперечное упр-е К
		/// </summary>
		[Description("Поперечное упр-е К")] float out_93;

		/// <summary>
		/// Путевое упр-е Н
		/// </summary>
		[Description("Путевое упр-е Н")] float out_94;

		/// <summary>
		/// По ош В
		/// </summary>
		[Description("По ош В")] float out_95;

		/// <summary>
		/// Vxg ДИСС Путевые скорости (км/ч)
		/// </summary>
		[Description("Vxg ДИСС Путевые скорости (км/ч)")]
		float out_Wxg;

		/// <summary>
		/// Vzg ДИСС Путевые скорости (км/ч)
		/// </summary>
		[Description("Vzg ДИСС Путевые скорости (км/ч)")]
		float out_Wzg;

		/// <summary>
		/// Vz пр (синие окошки) - слева, + справа (дискретность отображения 5 км/ч)
		/// </summary>
		[Description("Vz пр (синие окошки) - слева, + справа (дискретность отображения 5 км/ч)")]
		float out_VzPrib_SSK;

		/// <summary>
		///
		/// </summary>
		[Description("")] float out_99;

		/// <summary>
		///
		/// </summary>
		[Description("")] float out_100;

		#endregion
	}
}
