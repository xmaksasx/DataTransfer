using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;

namespace DataTransfer.Model.Component.BaseComponent
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Base : Header
	{
	    public virtual void UpdateData(byte[] dgram)
	    {
			Reverse(ref dgram);
			Assign(dgram);
		}


	    public virtual void Reverse(ref byte[] dgram)
		{
		}

		public virtual void Assign(byte[] dgram)
		{
			ConvertHelper.ByteToObject(dgram,this);
		}

		public virtual byte[] GetBytes()
		{
			return ConvertHelper.ObjectToByte(this);
		}
	}
}