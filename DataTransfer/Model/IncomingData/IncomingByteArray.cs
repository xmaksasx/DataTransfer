namespace DataTransfer.Model.IncomingData
{
	class IncomingByteArray:IIncomingData
	{
		public byte[] GetByte()
		{
			return new byte[1];
		}
	}
}
