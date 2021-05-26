using System;
using System.Collections.ObjectModel;
using DataTransfer.Services.ControlElements;
using DataTransfer.ViewModels.Base;

namespace DataTransfer.ViewModels
{
	class DeviceWindowViewModel: ViewModel
	{
		#region devices: TYPE - Список устройств
		/// <summary>Список устройств</summary>
		private ObservableCollection<DeviceInstance> _devices;
		/// <summary>Список устройств</summary>
		public ObservableCollection<DeviceInstance> Devices {get =>_devices; set =>Set(ref _devices, value);}
		#endregion

		DeviceControlElement _deviceControl = DeviceControlElement.GetInstance();

		public DeviceWindowViewModel()
		{
			_devices = new ObservableCollection<DeviceInstance>();
			foreach (var deviceInstance in _deviceControl.SearchJoystick())
			{
				_devices.Add(new DeviceInstance(){Guid = deviceInstance.ProductGuid.ToString(), Name = deviceInstance.InstanceName});
			}

		}

	}

	class DeviceInstance
	{
		public String Guid { get; set; }
		public String Name { get; set; }
	}
}
