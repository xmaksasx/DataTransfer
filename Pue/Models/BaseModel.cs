﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
namespace Pue.Models
{
	class BaseModel
	{
		public UdpClient _sendUdp { get; set; }
		public UdpClient _receiveUdp { get; set; }
		private SendSvvoStruct _sendSvvo;
		private string _ipSvvo = "127.0.0.1";
		bool _isReceive;
		Thread _receiveThread;
		DynamicModel _dynamicModel;


		public BaseModel()
		{
			_dynamicModel = new DynamicModel();
			_sendSvvo = new SendSvvoStruct();
			_sendUdp = new UdpClient();
			_receiveUdp = new UdpClient(20100);
			_receiveThread = new Thread(Receive);
			_receiveThread.Start();
		}

		public void SetDayTime(int hour)
		{
			Send(_sendSvvo.GetBytesTime(hour), _ipSvvo, 6100);
		}

		public void SetFog(double value)
		{
			Send(_sendSvvo.GetBytesFog(value), _ipSvvo, 6100);
		}

		public void SetLpTp(Lptp value)
		{
			var bytes = ConvertHelper.ObjectToByte(value);
			Send(bytes, "127.0.0.1", 20090);
		}

		public void SetPrecipitation(float rain, float snow)
		{

			Send(_sendSvvo.GetBytesRain(rain), _ipSvvo, 6100);
			Send(_sendSvvo.GetBytesSnow(snow), _ipSvvo, 6100);
			Thread.Sleep(200);
			
			Send(_sendSvvo.GetBytesDefault(), _ipSvvo, 6100);

		}


		#region Отправляю на модель

		public void Send(byte[] dgram, string hostname, int port)
		{
			try
			{
				_sendUdp?.Send(dgram, dgram.Length, hostname, port);
			}
			catch (Exception expSend)
			{
				MessageBox.Show(expSend.ToString());
			}
		}

        #endregion

        #region Принимаю данные 

        void Receive()
        {
            while (_isReceive)
            {
                if (IsAvailable) continue;
                IPEndPoint ipendpoint = null;
                byte[] modelBytes = _receiveUdp.Receive(ref ipendpoint);
                string header = System.Text.Encoding.UTF8.GetString(modelBytes, 0, 30).Trim('\0');
                ProcessingPackage(header, modelBytes);
            }
        }

		private bool IsAvailable
		{
			get
			{
				if (_receiveUdp.Available == 0)
				{
					Thread.Sleep(10);
					return true;
				}

				return false;
			}
		}

		private void ProcessingPackage(string header, byte[] modelBytes)
        {
           
                switch (header)
                {
                    case "MODELSTRUCT":
                        ConvertHelper.ByteToObject(modelBytes, _dynamicModel);
                        break;

                  

                    case "DynamicModelToVaps":
                        for (int i = 68; i < modelBytes.Length; i = i + 8)
                            Array.Reverse(modelBytes, i, 8);
                        ConvertHelper.ByteToObject(modelBytes, _dynamicModel);
                        break;

                    default:
                        break;
                }
            
        
        }
    
        #endregion
    }
}
