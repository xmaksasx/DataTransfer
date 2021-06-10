using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct DGeoPosition
	{
		public double Latitude;
		public double Longitude;
		public double Elevation;
	}
}