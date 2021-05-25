using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.IncomingData;

namespace DataTransfer.Model.Component.BaseComponent
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Base : Header
	{
	    public virtual void UpdateData(IIncomingData incomingData)
	    {
			Reverse(incomingData);
			Assign(incomingData);
		}





		public virtual void Reverse(IIncomingData incomingData)
		{
		}

		public virtual void Assign(IIncomingData incomingData)
		{
			ConvertHelper.ByteToObject(incomingData.GetByte(), this);

		}
	}
}