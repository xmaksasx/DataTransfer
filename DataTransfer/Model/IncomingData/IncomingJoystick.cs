using System.Collections.Generic;
using SharpDX.DirectInput;

namespace DataTransfer.Model.IncomingData
{
	class IncomingJoystick : IIncomingData
	{
		private JoystickState _data;

		public JoystickState Data
		{
			get { return _data; }
			set { _data = value; }
		}

		
		public byte[] GetByte()
		{
			return new byte[1];
		}
	}
}
