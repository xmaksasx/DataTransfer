using System;
using System.Collections.Generic;
using DataTransfer.Model.Component;
using DataTransfer.Model.Component.Base;

namespace DataTransfer.Services.DataManager
{
	class DataManager: IDataManager
	{

		private DynamicModel _dynamicModel;
		private ChannelRadar _channelRadar;

		List<IUpdate> _updates = new List<IUpdate>();

		public DataManager()
		{
			_updates.Add(_dynamicModel);
			_updates.Add(_channelRadar);
		}
		public DataManager(DynamicModel dynamicModel)
		{
			this._dynamicModel = dynamicModel;
			this._dynamicModel.SetDataManager(this);
			
		}



		public void UpdateData(string header, byte[] dgram)
		{
				_dynamicModel.UpdateData(new byte[4]);
		}

		public void Notify(string header, byte[] dgram)
		{
			if (true)
			{
				_dynamicModel.UpdateData(new byte[4]);

			}
			if (true)
			{
				Console.WriteLine("Mediator reacts on D and triggers following operations:");
			}
		}
	}
}
