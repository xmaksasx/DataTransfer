using System;
using System.Collections.Generic;
using SharpDX.DirectInput;

namespace DataTransfer.Model.IncomingData
{
	class IncomingJoystick : IIncomingData
	{
		List<int> _list = new List<int>();

		private JoystickState _joystickState;

		public JoystickState JoystickState
		{
			get { return _joystickState; }
			set { _joystickState = value; }
		}

		
		public byte[] GetByte()
		{
			return new byte[1];
		}
	}
}
