using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

namespace Ka50Model.FdmManager
{
	class UdpHelper
	{

		private List<UdpClient> UdpReceivers = new List<UdpClient>();
		//private UdpClient _receiveClient;
		private UdpClient _sendClient;
		IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
		public UdpHelper()
		{
			UdpReceivers.Add(new UdpClient(20030));
			UdpReceivers.Add(new UdpClient(20031));
			UdpReceivers.Add(new UdpClient(21222));
			_sendClient = new UdpClient();
		}

		public byte[] Receive()
		{
			var id = IsAvailable;
			if (id == -1) return new byte[0];
			IPEndPoint ipendpoint = null;
			return UdpReceivers[id].Receive(ref RemoteIpEndPoint);
		}



		private int IsAvailable
		{
			get
			{
				int recvId = -1;
				for (int i = 0; i < UdpReceivers.Count; i++)
				{
					if (UdpReceivers[i].Available > 0)
			
						return  i;
				}

				return recvId;
			}
		}

		public void Send(byte[] dgram, string hostname, int port)
		{
			try
			{
				_sendClient?.Send(dgram, dgram.Length, hostname, port);
			}
			catch (Exception expSend)
			{
				Console.WriteLine(expSend.ToString());
			}
		}


    }

	
}
