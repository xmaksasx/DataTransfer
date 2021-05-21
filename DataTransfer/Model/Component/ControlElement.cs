using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ControlElement : BaseComponent
	{
		private ControlElementStruct _controlElement;

		public ControlElement()
		{
			_controlElement = new ControlElementStruct();
		}
	}
}
