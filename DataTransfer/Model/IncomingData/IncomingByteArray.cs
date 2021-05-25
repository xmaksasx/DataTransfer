namespace DataTransfer.Model.IncomingData
{
	class IncomingByteArray:IIncomingData
	{
		public byte[] GetByte<T>(T data)
		{
			return data;
		}
	}
}
