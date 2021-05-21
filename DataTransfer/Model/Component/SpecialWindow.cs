using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class SpecialWindow : IUpdate
	{
		private SpecialWindowStruct _specialWindow;

		public SpecialWindow()
		{
			_specialWindow = new SpecialWindowStruct();
		}
		public void UpdateData(byte[] dgram)
		{

		}
	}
}
