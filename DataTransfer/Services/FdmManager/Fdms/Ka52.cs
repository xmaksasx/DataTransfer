using DataTransfer.Model.Structs;
using DataTransfer.Services.FdmManager.Fdms.Base;
using System;

namespace DataTransfer.Services.FdmManager
{
	class Ka52 : IBaseFdm
	{
		StartPosition _startPosition;
		DynamicModel _dynamicModel;
		public byte[] GetBytes()
		{
			throw new NotImplementedException();
		}
		public ResponseFromModel Init()
		{
			_startPosition.InitPosition(0);
			return new ResponseFromModel
			{
				Dgram = _startPosition.GetBytes(),
				IsReady = true
			};
		}
		public ResponseFromModel Start()
		{
			_startPosition.InitPosition(1);
			return new ResponseFromModel
			{
				Dgram = _startPosition.GetBytes(),
				IsReady = true
			};
		}
		public ResponseFromModel Pause()
		{
			_startPosition.InitPosition(2);
			return new ResponseFromModel
			{
				Dgram = _startPosition.GetBytes(),
				IsReady = true
			};
		}
		public ResponseFromModel Stop()
		{
			_startPosition.InitPosition(-1);
			return new ResponseFromModel
			{
				Dgram = _startPosition.GetBytes(),
				IsReady = true
			};
		}
	}
}
