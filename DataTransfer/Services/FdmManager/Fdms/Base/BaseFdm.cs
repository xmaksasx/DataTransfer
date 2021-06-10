using DataTransfer.Model.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Services.FdmManager.Fdms.Base
{
	interface IBaseFdm
	{
		ResponseFromModel Init();
		ResponseFromModel Start();
		ResponseFromModel Pause();
		ResponseFromModel Stop();
		byte[] GetBytes();
	}
}
