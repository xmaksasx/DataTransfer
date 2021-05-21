using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class ChannelThermalEffect : IUpdate
	{
		private ChannelThermalEffectStruct _channelThermalEffect;

		public ChannelThermalEffect()
		{
			_channelThermalEffect = new ChannelThermalEffectStruct();
		}

		public void UpdateData(byte[] dgram)
		{

		}
	}
}
