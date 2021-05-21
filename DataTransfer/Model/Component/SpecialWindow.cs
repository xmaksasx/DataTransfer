using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class SpecialWindow : BaseComponent
	{
		private SpecialWindowStruct _specialWindow;

		public SpecialWindow()
		{
			_specialWindow = new SpecialWindowStruct();
		}
	}
}
