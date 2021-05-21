using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ChannelTvHeadEffect : BaseComponent
	{
		private ChannelTvHeadEffectStruct _channelTvHeadEffect;

		public ChannelTvHeadEffect()
		{
			_channelTvHeadEffect = new ChannelTvHeadEffectStruct();
		}
	}
}
