using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DataTransfer.Infrastructure.Commands;
using DataTransfer.Services.ControlElements;
using DataTransfer.ViewModels.Base;

namespace DataTransfer.ViewModels
{
	class DeviceWindowViewModel: ViewModel
	{
		#region Devices: ObservableCollection<DeviceInstance> - Список устройств
		/// <summary>Список устройств</summary>
		private ObservableCollection<DeviceInstance> _devices;
		/// <summary>Список устройств</summary>
		public ObservableCollection<DeviceInstance> Devices {get =>_devices; set =>Set(ref _devices, value);}
		#endregion

		DeviceControlElement _deviceControl = DeviceControlElement.GetInstance();

		#region Команды

		#region CloseAppCommand
		public ICommand CloseAppCommand { get; set; }

		private bool CanCloseAppCommandExecute(object p) => true;

		private void OnCloseAppCommandExecuted(object p)
		{
			foreach (Window window in Application.Current.Windows)
				if (window.DataContext == this)
					window.Close();
		}
		#endregion

		#endregion

		public DeviceWindowViewModel()
		{
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);

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
