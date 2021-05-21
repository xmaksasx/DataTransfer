using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class StartPosition : BaseComponent
	{
		private StartPositionStruct _startPosition;

		public StartPosition()
		{
			_startPosition = new StartPositionStruct();
		}
	}
}
