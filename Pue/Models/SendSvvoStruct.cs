using System.Runtime.InteropServices;

namespace Pue.Models
{
    class SendSvvoStruct
    {

        public tpacket_meteo _tpacketMeteo;

        public SendSvvoStruct()
        {
            _tpacketMeteo.preamble.wSync = 0xCDEF;
            _tpacketMeteo.preamble.ProtVers = 0x04;
            _tpacketMeteo.preamble.wLength = (ushort)Marshal.SizeOf(_tpacketMeteo);
            _tpacketMeteo.header._type = 1;
            _tpacketMeteo.header.Number = 0;
            _tpacketMeteo.id = 1;
            _tpacketMeteo.size = (ushort)(Marshal.SizeOf(_tpacketMeteo.data) + 4);
            _tpacketMeteo.data.visibility = (float)50 * 1000; // Дальняя граница тумана  [м]
            _tpacketMeteo.data.visibility_loc = (float)50 * 10; //Локальная дальность видимости [м]
            _tpacketMeteo.data.hour = (byte)9;
        }
        // Atm_Vis ExtPack Tra_Mod Nvy_Vis NVG_PAR Air_Vis Mod_Bot VPP_Vis Mod_Vis Exp_Vis TRG_ARG Obj_Vis Grn_Vis

        public byte[] GetBytesFog(double intensity)
        {
            _tpacketMeteo.data.visibility = (float)intensity*1000; // Дальняя граница тумана  [м]
            _tpacketMeteo.data.visibility_loc = (float)intensity*10; //Локальная дальность видимости [м]
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }

        public byte[] GetBytesDefault()
        {
	        _tpacketMeteo.data.visibility += 10000;
	        _tpacketMeteo.data.visibility_loc += 10;
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }

        public byte[] GetBytesTime(int hour)
        {
            _tpacketMeteo.data.hour = (byte)hour;
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }

        public byte[] GetBytesRain(float rain)
        {
	        _tpacketMeteo.data.parm = 9;
               _tpacketMeteo.data.snow = 0;
            _tpacketMeteo.data.season = rain == 0.9F ? 3 : 0;
            _tpacketMeteo.data.rain = rain;
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }

        public byte[] GetBytesSnow(float snow)
        {
	        _tpacketMeteo.data.rain = 0;
            _tpacketMeteo.data.season = snow == 0.9F ? 2 : 0;
            _tpacketMeteo.data.snow = snow;
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }

        public byte[] GetBytesMist(byte mist)
        {
            _tpacketMeteo.data.mist = mist; //Дымка			[0,1]
            _tpacketMeteo.data.hmist = mist*200; //Высота дымки  [м]
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }

        //public byte[] GetBytesCloud(CloudInfo  cloud)
        //{
        //    _tpacketMeteo.data.Cloud = new Cloud[3];
        //    _tpacketMeteo.data.cloud_num = 1; // Количество слоев облачности
        //    _tpacketMeteo.data.Cloud[0].cl_type = 0; // Тип облачности
        //    _tpacketMeteo.data.Cloud[0].cl_grade = (float)cloud.IntensityCloud; // балл, 0-10
        //    _tpacketMeteo.data.Cloud[0].cl_height = (float)cloud.DownLimit; // Нижняя граница слоя облачности
        //    _tpacketMeteo.data.Cloud[0].cl_depth = (float)cloud.UpLimit; // Толщина  границы слоя облачности
        //    return ConvertHelper.ObjectToByte(_tpacketMeteo);
        //}

        public byte[] GetBytes()
        {
           
            //_tpacketMeteo.data.year = 0; // 2005
            //_tpacketMeteo.data.mon = 0; // 1-12
            //_tpacketMeteo.data.day = 0; // 1-31
            //_tpacketMeteo.data.hour = 16; // 0 - 23
            //_tpacketMeteo.data.min = 0; // 0 - 59
            //_tpacketMeteo.data.time = 0; // Время суток 0, 1-Рассвет, 2-Утро, 3-Полдень, 4-День, 5-Вечер, 6-Закат, 7-Полночь, 8-Ночь
            //_tpacketMeteo.data.parm = 0; // Дополнительные параметры
            //_tpacketMeteo.data.visibility = 10000; // Дальняя граница тумана  [м]
            //_tpacketMeteo.data.visibility_loc = 1000; //Локальная дальность видимости [м]
           
            _tpacketMeteo.data.cloud_num = 0; // Количество слоев облачности
            _tpacketMeteo.data.Cloud[0].cl_type = 0; // Тип облачности
            _tpacketMeteo.data.Cloud[0].cl_grade = 0; // балл, 0-10
            _tpacketMeteo.data.Cloud[0].cl_height = 0; // Нижняя граница слоя облачности
            _tpacketMeteo.data.Cloud[0].cl_depth = 0; // Толщина  границы слоя облачности

            _tpacketMeteo.data.Cloud[1].cl_type = 0; // Тип облачности
            _tpacketMeteo.data.Cloud[1].cl_grade = 0; // балл, 0-10
            _tpacketMeteo.data.Cloud[1].cl_height = 0; // Нижняя граница слоя облачности
            _tpacketMeteo.data.Cloud[1].cl_depth = 0; // Толщина  границы слоя облачности

            _tpacketMeteo.data.Cloud[2].cl_type = 0; // Тип облачности
            _tpacketMeteo.data.Cloud[2].cl_grade = 0; // балл, 0-10
            _tpacketMeteo.data.Cloud[2].cl_height = 0; // Нижняя граница слоя облачности
            _tpacketMeteo.data.Cloud[2].cl_depth = 0; // Толщина  границы слоя облачности






            _tpacketMeteo.data.season = 0; //время года: SEASON_SUMMER=0, SEASON_AUTUMN=1, SEASON_WINTER=2, SEASON_SPRING=3
            //_tpacketMeteo.data.rain = 0; //Дождь		    [0,1]
            //_tpacketMeteo.data.snow = 0; //Снег			[0,1]
            //_tpacketMeteo.data.mist = 0; //Дымка			[0,1]
            //_tpacketMeteo.data.hmist = 0; //Высота дымки  [м]
            //_tpacketMeteo.data.starbright = 0; //Яркость звезд [0,1]
            //_tpacketMeteo.data._type = 0;
            //_tpacketMeteo.data.num_meteo = 0; // Количество точек с метеопараметрами
            return ConvertHelper.ObjectToByte(_tpacketMeteo);
        }
    }




    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct tpacket_meteo
    {
        public preamble preamble;
        public header header;
        public ushort id;
        public ushort size;
        public TMeteo data;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct preamble
    {
        public ushort wSync;
        public byte ProtVers;
        public ushort wLength;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct header
    {
        public ushort _type;
        public int Number;
        public int Flag;
        public int Res;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TMeteo
    {
        public ushort year; // 2005
        public byte mon; // 1-12
        public byte day; // 1-31
        public byte hour; // 0 - 23
        public byte min; // 0 - 59
        public int time; // Время суток 0, 1-Рассвет, 2-Утро, 3-Полдень, 4-День, 5-Вечер, 6-Закат, 7-Полночь, 8-Ночь
        public ushort parm; // Дополнительные параметры
        public float visibility; // Дальняя граница тумана  [м]
        public float visibility_loc; //Локальная дальность видимости [м]
        public int cloud_num; // Количество слоев облачности

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Cloud[] Cloud; // Массив слоев облачности

        public int season; //время года: SEASON_SUMMER=0, SEASON_AUTUMN=1, SEASON_WINTER=2, SEASON_SPRING=3
        public float rain; //Дождь		    [0,1]
        public float snow; //Снег			[0,1]
        public float mist; //Дымка			[0,1]
        public float hmist; //Высота дымки  [м]
        public float starbright; //Яркость звезд [0,1]
        public byte _type;
        public int num_meteo; // Количество точек с метеопараметрами

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public MeteoPoint[] MeteoPoint; // Метеоточки
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Cloud
    {
        // Массив слоев облачности
        public uint cl_type; // Тип облачности
        public float cl_grade; // балл, 0-10
        public float cl_height; // Нижняя граница слоя облачности
        public float cl_depth; // Толщина  границы слоя облачности
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MeteoPoint
    {
        // Метеоточки
        ushort _type; // тип точки привязки: 0- непривязан, 1- аэродром, 2- ППМ
        ushort num_point; // номер точки привязки
        double lat; // Текущая географическая долгота   [рад]
        double lon; // Текущая географическая широта    [рад]
        float h; // Текущая высота					[м]
        float temperature; // Температура в данной точке		[град С]
        float pressure; // Давление в данной точке			[мм рт.ст.]
        float wind_x; // Скорость ветра в ЗСК				[м/сек]
        float wind_y; // Скорость ветра в ЗСК				[м/сек]
        float wind_z; // Скорость ветра в ЗСК				[м/сек]
        float windturb_x; // Скорость ветра в ЗСК				[м/сек]
        float windturb_y; // Скорость ветра в ЗСК				[м/сек]
        float windturb_z; // Скорость ветра в ЗСК				[м/сек]
    }
}