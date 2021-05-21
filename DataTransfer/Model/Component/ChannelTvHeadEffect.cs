using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ChannelTvHeadEffect : IUpdate
	{
		private ChannelTvHeadEffectStruct _channelTvHeadEffect;

		public ChannelTvHeadEffect()
		{
			_channelTvHeadEffect = new ChannelTvHeadEffectStruct();
		}

		public void UpdateData(byte[] dgram)
		{

		}
	}
}
