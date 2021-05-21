using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ChannelRadar : IUpdate
	{
		private ChannelRadarStruct _channelRadar;

		public ChannelRadar()
		{
			_channelRadar = new ChannelRadarStruct();
		}

		public void UpdateData(byte[] dgram)
		{

		}
	}
}