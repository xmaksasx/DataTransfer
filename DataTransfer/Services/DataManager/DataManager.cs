using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.IncomingData;
using DataTransfer.Model.Structs;
using DataTransfer.Services.ControlElements;

namespace DataTransfer.Services.DataManager
{
	class DataManager
	{
		IncomingByteArray _incomingByteArray = new IncomingByteArray();
		IncomingJoystick _incomingJoystick = new IncomingJoystick();
		private Base _channelRadar;
		private Base _channelThermalEffect;
		private Base _channelTvHeadEffect;
		private Base _controlElement;
		private Base _dynamicModel;
		private Base _simulationManagement;
		private Base _specialWindow;
		private Base _startPosition;

		private DeviceControlElement _deviceControlElement;

		private UdpHelper _udpHelper;

		private Thread _receiveThread;



		public DataManager()
		{
			_udpHelper = new UdpHelper();
			_deviceControlElement = new DeviceControlElement();
			var t = _deviceControlElement.SearchJoystick();
			_deviceControlElement.AddJoystick("0402044f-0000-0000-0000-504944564944");
			var te = _deviceControlElement.ReadData("0402044f-0000-0000-0000-504944564944");


			_channelRadar = new ChannelRadarStruct();
			_channelThermalEffect = new ChannelThermalEffectStruct();
			_channelTvHeadEffect = new ChannelTvHeadEffectStruct();
			_controlElement = new ControlElementStruct();
			_dynamicModel = new DynamicModelStruct();
			_simulationManagement = new SimulationManagementStruct();
			_specialWindow = new SpecialWindowStruct();
			_startPosition = new StartPositionStruct();

			_receiveThread = new Thread(Receive);

		}

		private void Receive()
		{
			while (true)
			{
				 var receivedBytes = _udpHelper.Receive();
				if (receivedBytes.Length == 0) continue;
				string header = Encoding.UTF8.GetString(receivedBytes, 0, 30).Trim('\0');
				ProcessingPackage(header, receivedBytes);
			}
		}

		private void ProcessingPackage(string header, byte[] receivedBytes)
		{
			switch (header)
			{
				case "ChannelRadar":
					_channelRadar.UpdateData(receivedBytes);
					break;

				case "ChannelThermalEffect":
					_channelThermalEffect.UpdateData(receivedBytes);
					break;

				case "ChannelTvHeadEffect":
					_channelTvHeadEffect.UpdateData(receivedBytes);
					break;

				case "DynamicModel":
					_dynamicModel.UpdateData(receivedBytes);
					break;

				case "SpecialWindow":
					_specialWindow.UpdateData(receivedBytes);
					break;


				default:
					break;
			}
		}

		}
}
