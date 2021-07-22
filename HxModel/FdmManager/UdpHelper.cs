using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

namespace HxModel.FdmManager
{
	class UdpHelper
	{

		private List<UdpClient> UdpReceivers = new List<UdpClient>();
		//private UdpClient _receiveClient;
		private UdpClient _sendClient; 
		IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        public UdpHelper()
        {

            UdpClient cd = new UdpClient(21222);
            cd.JoinMulticastGroup(IPAddress.Parse("239.255.255.255"));
            UdpReceivers.Add(new UdpClient(20030));
            UdpReceivers.Add(new UdpClient(20031));
            UdpReceivers.Add(new UdpClient(20032));
            UdpReceivers.Add(cd);
            _sendClient = new UdpClient();
        }

		public void Stop()
		{
			_sendClient.Close();
			foreach (var udp in UdpReceivers)
				udp.Close();
		}

		public byte[] Receive()
		{
			var id = IsAvailable;
			if (id == -1) return new byte[0];
			IPEndPoint ipendpoint = null;
			return UdpReceivers[id].Receive(ref ipendpoint);
		}



		private int IsAvailable
		{
			get
			{
				int recvId = -1;
				for (int i = 0; i < UdpReceivers.Count; i++)
				{
					if (UdpReceivers[i].Available > 0)

						return i;
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
