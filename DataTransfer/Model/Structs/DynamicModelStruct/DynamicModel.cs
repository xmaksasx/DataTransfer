using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.Bmpi;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;

namespace DataTransfer.Model.Structs.DynamicModelStruct
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	abstract class DynamicModel : Base
	{
		public virtual byte[] GetPosition(AircraftPosition aircraftPosition)
		{
			return new byte[1];
		}

		public virtual byte[] GetForVaps(DynamicModelToVaps modelToVaps)
		{
			return new byte[1];
		}

		public virtual byte[] GetForBmpi(DynamicModelToBmpi modelToBmpi)
		{
			return new byte[1];
		}
	}
}
