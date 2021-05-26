using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX.DirectInput;

namespace DataTransfer.Services.ControlElements
{
	class DeviceControlElement
	{
		private DirectInput _directInput = new DirectInput();
		private List<Joystick> _joysticks = new List<Joystick>();
		private List<DeviceInstance> _deviceInstances;

		private static DeviceControlElement _instance;
		public static DeviceControlElement GetInstance()
		{
			if (_instance == null)
			{
				_instance = new DeviceControlElement();
			}
			return _instance;
		}
		private DeviceControlElement()
		{
			_deviceInstances = SearchJoystick();
		}
		private Joystick SetDevice(Guid guidJoystick)
		{
			var joystick = new Joystick(_directInput, guidJoystick);
			joystick.Properties.BufferSize = 128;
			joystick.Acquire();
			return joystick;
		}

		public List<DeviceInstance> SearchJoystick()
		{
			return  _directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices).ToList();
		}

		public JoystickState ReadData(string guid)
		{
			foreach (var joystick in _joysticks)
				if (guid == joystick.Information.ProductGuid.ToString())
					return joystick.GetCurrentState();

			return new JoystickState();
		}

		public void AddJoystick(string guid)
		{
			Guid guidDevice = new Guid(guid);
			foreach (var deviceInstance in _deviceInstances)
				if (guidDevice == deviceInstance.ProductGuid)
					_joysticks.Add(SetDevice(guidDevice));
		}
	}
}
