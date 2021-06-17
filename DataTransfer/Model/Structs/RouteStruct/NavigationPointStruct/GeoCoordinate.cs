using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.RouteStruct.NavigationPointStruct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GeoCoordinate
    {
        /// <summary>
        /// широта [град]
        /// </summary>
        [Description("широта [град]")]
        public double Latitude;

        /// <summary>
        /// долгота [град]
        /// </summary>
        [Description("долгота [град]")]
        public double Longitude;

        /// <summary>
        /// координата X от ЛА [км]
        /// </summary>
        [Description("координата X от ЛА [км]")]
        public double X;

        /// <summary>
        /// координата Z от ЛА [км]
        /// </summary>
        [Description("координата Z от ЛА [км]")]
        public double Z;

        /// <summary>
        /// высота навигационной точки над уровнем моря [м]
        /// </summary>
        [Description("высота навигационной точки над уровнем моря [м]")]
        public double H;


    }
}
