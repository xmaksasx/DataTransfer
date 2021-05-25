using System.Runtime.InteropServices;
using DataTransfer.Model.IncomingData;

namespace DataTransfer.Model.Component.BaseComponent
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Base : Header
	{
	    public virtual void UpdateData(IIncomingData incomingData)
	    {

		    var bytes = GetByte(incomingData);
			Reverse(bytes);
			Assign(bytes);
		}


	    public virtual byte[] GetByte(IIncomingData incomingData)
	    {
		    return incomingData.GetByte();
	    }


		public virtual void Reverse(byte[] dgram)
		{
		}

		public virtual void Assign(byte[] dgram)
		{

		}
	}
}