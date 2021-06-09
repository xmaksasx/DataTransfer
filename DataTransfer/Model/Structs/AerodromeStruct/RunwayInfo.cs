using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Structs.NavigationPointStruct;

namespace DataTransfer.Model.Structs.AerodromeStruct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RunwayInfo
    {
        /// <summary>
        /// Курс ВПП
        /// </summary>
        [Description("Курс ВПП")]
        public double Heading;

        /// <summary>
        /// Длина ВПП
        /// </summary>
        [Description("Длина ВПП")]
        public double Length;

        /// <summary>
        /// Ширина ВПП
        /// </summary>
        [Description("Ширина ВПП")]
        public double Width;

        /// <summary>
        /// Торец ВПП
        /// </summary>
        [Description("Торец ВПП")]
        public GeoCoordinate Threshold;

        /// <summary>
        /// Глиссадный маяк
        /// </summary>
        [Description("Глиссадный маяк")]
        public GeoCoordinate GlideSlope;

        /// <summary>
        /// Курсовой маяк
        /// </summary>
        [Description("Курсовой маяк")]
        public GeoCoordinate Localizer;

        /// <summary>
        /// БПРМ
        /// </summary>
        [Description("БПРМ")]
        public GeoCoordinate LocatorMiddle;

        /// <summary>
        /// ДПРМ
        /// </summary>
        [Description("ДПРМ")]
        public GeoCoordinate LocatorOuter;

    }
}
