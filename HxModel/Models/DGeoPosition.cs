using System.Runtime.InteropServices;

namespace HxModel.Models
{
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct DGeoPosition
	{
		public double Latitude;
		public double Longitude;
		public double Elevation;
	}
}
