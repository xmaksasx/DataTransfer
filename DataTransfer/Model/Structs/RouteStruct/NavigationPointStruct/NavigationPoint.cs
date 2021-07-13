using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.RouteStruct.NavigationPointStruct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NavigationPoint
    {
        /// <summary>
        /// Имя навигационной точки
        /// </summary>
        [Description("Имя навигационной точки")]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] Name;

        /// <summary>
        /// 1-АЭР, 2-ППМ
        /// </summary>
        [Description("1-АЭР, 2-ППМ")]
        public double Type;

        /// <summary>
        /// признак исполняемой НТ 0-нет, 1-да
        /// </summary>
        [Description("признак исполняемой НТ 0-нет, 1-да")]
        public double Executable;
    

        /// <summary>
        /// признак прохода
        /// </summary>
        [Description("признак прохода")]
        public double PrPro;
      
        /// <summary>
        /// Геодезические координаты
        /// </summary>
        [Description("Геодезические координаты")]
        public GeoCoordinate GeoCoordinate;
        
        /// <summary>
        /// Расчетные параметры 
        /// </summary>
        [Description("Расчетные параметры")]
        public Measure Measure;

    }
}
