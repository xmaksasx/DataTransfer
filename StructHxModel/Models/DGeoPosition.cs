using System.ComponentModel;
using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct DGeoPosition
	{
		/// <summary>
		/// Широта, град
		/// </summary>
		[Description("Широта, град")]
		public double Latitude;
		/// <summary>
		/// Высота, град
		/// </summary>
		[Description("Долгота, град")]
		public double Longitude;
		/// <summary>
		/// Высота, град
		/// </summary>
		[Description("Высота,  град")]
		public double Elevation;
	}
}
