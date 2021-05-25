using System.Runtime.InteropServices;
using DataTransfer.Model.IncomingData;

namespace DataTransfer.Model.Component.BaseComponent
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Base : Header
	{
		public virtual IIncomingData IncomingData {get; set; }

		public virtual void UpdateData(byte[] dgram)
		{
			var bb = IncomingData.GetByte(dgram);
			Reverse();
			Assign(dgram);
		}

		public virtual void Reverse()
		{
		}

		public virtual void Assign(byte[] dgram)
		{

		}
	}
}