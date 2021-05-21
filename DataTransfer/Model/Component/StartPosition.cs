using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class StartPosition : IUpdate
	{
		private StartPositionStruct _startPosition;

		public StartPosition()
		{
			_startPosition = new StartPositionStruct();
		}
		public void UpdateData(byte[] dgram)
		{

		}
	}
}
