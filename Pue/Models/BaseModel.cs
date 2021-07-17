using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Pue.Models
{
	class BaseModel
	{
		public UdpClient SendUdp { get; set; }
		private SendSvvoStruct _sendSvvo;
		private string _ipSvvo = "127.0.0.1";

		public BaseModel()
		{
			_sendSvvo = new SendSvvoStruct();
			SendUdp = new UdpClient();
		}

		public void SetDayTime(int hour)
		{
			Send(_sendSvvo.GetBytesTime(hour), _ipSvvo, 6100);
		}

		public void SetFog(double value)
		{
			Send(_sendSvvo.GetBytesFog(value), _ipSvvo, 6100);
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
				SendUdp?.Send(dgram, dgram.Length, hostname, port);
			}
			catch (Exception expSend)
			{
				MessageBox.Show(expSend.ToString());
			}
		}

		#endregion
    }
}
