using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class DynamicModel: BaseComponent
	{
		private DynamicModelStruct _dynamicModelStruct;

		public DynamicModel()
		{
			_dynamicModelStruct = new DynamicModelStruct();
		}
	}
}
