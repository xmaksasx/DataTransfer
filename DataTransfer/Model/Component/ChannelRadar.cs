using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ChannelRadar : BaseComponent
	{
		private ChannelRadarStruct _channelRadar;

		public ChannelRadar()
		{
			_channelRadar = new ChannelRadarStruct();
		}
	}
}