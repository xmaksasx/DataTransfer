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
	    private double Latitude;

        /// <summary>
        /// долгота [град]
        /// </summary>
        [Description("долгота [град]")]
        private double Longitude;

        /// <summary>
        /// координата X от ЛА [км]
        /// </summary>
        [Description("координата X от ЛА [км]")]
        private double X;

        /// <summary>
        /// координата Z от ЛА [км]
        /// </summary>
        [Description("координата Z от ЛА [км]")]
        private double Z;

        /// <summary>
        /// высота навигационной точки над уровнем моря [м]
        /// </summary>
        [Description("высота навигационной точки над уровнем моря [м]")]
        private double H;


    }
}
