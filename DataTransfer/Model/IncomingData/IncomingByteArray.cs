namespace DataTransfer.Model.IncomingData
{
	class IncomingByteArray:IIncomingData
	{
		private byte[] _data;

		public byte[] Data
		{
			get { return _data;}
			set { _data = value; }
		}

		public byte[] GetByte()
		{
			return new byte[1];
		}
	}
}
