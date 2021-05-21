using System;
using DataTransfer.Model.Component;

namespace DataTransfer.Services.DataManager
{
	class DataManager: IDataManager
	{

		private DynamicModel _dynamicModel;


		public DataManager(DynamicModel dynamicModel)
		{
			this._dynamicModel = dynamicModel;
			this._dynamicModel.SetDataManager(this);
			
		}


		public void Notify(string header, byte[] dgram)
		{
			if (true)
			{
				Console.WriteLine("Mediator reacts on A and triggers folowing operations:");

			}
			if (true)
			{
				Console.WriteLine("Mediator reacts on D and triggers following operations:");
			}
		}
	}
}
