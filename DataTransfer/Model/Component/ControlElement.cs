using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ControlElement : IUpdate
	{
		private ControlElementStruct _controlElement;

		public ControlElement()
		{
			_controlElement = new ControlElementStruct();
		}

		public void UpdateData(byte[] dgram)
		{

		}
	}
}
