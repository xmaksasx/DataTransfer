using DataTransfer.Services.DataManager;

namespace DataTransfer.Model.Component.Base
{
	class BaseComponent
	{
		protected IDataManager _dataManager;

		public BaseComponent(IDataManager dataManager = null)
		{
			this._dataManager = dataManager;
		}

		public void SetDataManager(IDataManager dataManager)
		{
			this._dataManager = dataManager;
		}
    }
}
