using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX.DirectInput;

namespace JoystickExample
{
	class Program
	{
		static void Main(string[] args)
		{


			// Initialize DirectInput
			var directInput = new DirectInput();
			var devices = SearchDevice(directInput);
			var joystickState = new JoystickState();

			// Find a Joystick Guid
			var joystickGuid = Guid.Empty;
			var joystickName = "";

			foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad,
				DeviceEnumerationFlags.AllDevices))
			{
				joystickGuid = deviceInstance.InstanceGuid;
				joystickName = deviceInstance.ProductName;
			}

			// If Gamepad not found, look for a Joystick
			if (joystickGuid == Guid.Empty)
				foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick,
					DeviceEnumerationFlags.AllDevices))
				{
					joystickGuid = deviceInstance.InstanceGuid;
					joystickName = deviceInstance.InstanceName;
					Console.WriteLine(deviceInstance.ProductGuid);
				}

			// If Joystick not found, throws an error
			if (joystickGuid == Guid.Empty)
			{
				Console.WriteLine("No joystick/Gamepad found.");
				Console.ReadKey();
				Environment.Exit(1);
			}

			// Instantiate the joystick
			var joystick = new Joystick(directInput, joystickGuid);
			joystick.Properties.BufferSize = 128;
			joystick.Acquire();

			while (true)
			{
				//joystick.Poll();
			var t=	joystick.GetCurrentState();
			var t2 = joystick.Information;
			var t1 = joystick;
			//var datas = joystick.GetBufferedData();
			//foreach (var state in datas)
			//	Console.WriteLine(state);
			}
        }

		private static void Init(string guidRus, string guidRud)
		{
			//return directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices).ToList();
		}
		private static List<DeviceInstance> SearchDevice(DirectInput directInput)
		{
			return directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices).ToList();
		}
	}

}
