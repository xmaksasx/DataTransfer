using DataTransfer.Model.Structs;
using DataTransfer.Services.FdmManager.Fdms.Base;

namespace DataTransfer.Services.FdmManager
{
	class FdmManager
	{
		IBaseFdm _baseFdm;
		bool isInit;
		byte[] bytes;
		ResponseFromModel responseFromModel;

		public FdmManager()
		{
			_baseFdm = new Ka52();
			responseFromModel = new ResponseFromModel();
		}

		void SetModel(string str)
		{
		
		
		}

		ResponseFromModel Init()
		{
			return _baseFdm.Init();
		}

		public 	ResponseFromModel Start() 
		{
			return _baseFdm.Start();
		}

		public ResponseFromModel Pause()
		{
			return _baseFdm.Pause();
		}

		public ResponseFromModel Stop()
		{
			return _baseFdm.Stop();
		}

		byte[] GetBytes()
		{
			if (!isInit) return bytes;
			return bytes;

		}
	}
}

