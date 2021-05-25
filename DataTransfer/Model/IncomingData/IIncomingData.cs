using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Model.IncomingData
{
	public interface IIncomingData
	{
		byte[] GetByte<T>(T data);
	}
}
