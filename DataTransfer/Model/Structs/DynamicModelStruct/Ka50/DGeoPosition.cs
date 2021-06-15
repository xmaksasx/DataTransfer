using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DGeoPosition
	{
		public double Latitude;
		public double Longitude;
		public double Elevation;
	}
}