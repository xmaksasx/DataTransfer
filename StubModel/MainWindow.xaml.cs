
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using StubModel.Models;


namespace StubModel
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Thread th;
		private ModelKa52 _ka52;
		private bool _send;
		private UdpClient _sendClient;
		private Svvo _svvo;

		public MainWindow()
		{
			InitializeComponent();
			this.Closed += (sender, args) => _send = false;
			_sendClient = new UdpClient();
			_send = true;
			_svvo = new Svvo();
			_ka52 = new ModelKa52();
			th = new Thread(Send);
			th.Start();
		}

		private void Send()
		{
			while (_send)
			{
				var bytes = _ka52.GetBytes();
				var bytesSvvo = GetByte();
				_sendClient?.Send(bytes, bytes.Length, "127.0.0.1", 20020);
				_sendClient?.Send(bytesSvvo, bytesSvvo.Length, "127.0.0.1", 6100);
				Thread.Sleep(20);
			}
		}

		public byte[] GetByte()
		{
			_svvo.Preamble.wSync = 0xCDEF;
			_svvo.Preamble.ProtVers = 0x04;
			_svvo.Preamble.wLength = (ushort)Marshal.SizeOf(_svvo);
			_svvo.Header._type = 3;
			_svvo.Header.Number = 0;

			_svvo.Id = 2;
			_svvo.Size = (ushort)(Marshal.SizeOf(_svvo.Packetcam) + 4);
			_svvo.Packetcam.x = _ka52.out_Xg;
			_svvo.Packetcam.z = _ka52.out_Zg;
			_svvo.Packetcam.ht = _ka52.out_Hotn;
			_svvo.Packetcam.tet = (float)(_ka52.out_Tang * Math.PI / 180D);
			_svvo.Packetcam.gam = (float)(_ka52.out_Kren * Math.PI / 180D);
			_svvo.Packetcam.psi = (float)(_ka52.out_Kurs * Math.PI / 180D);
			_svvo.Packetcam.flag = 1;

			return ConvertHelper.ObjectToByte(_svvo);
		}

		private void SliderX_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_ka52.out_Xg = (float)SliderX.Value;
		}

		private void SliderZ_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_ka52.out_Zg = (float)SliderZ.Value;
		}

		private void SliderH_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_ka52.out_Hotn = (float)SliderH.Value;
		}

		private void SliderRoll_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_ka52.out_Kren = (float)SliderRoll.Value;
		}

		private void SliderPitch_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_ka52.out_Tang = (float)SliderPitch.Value;
		}

		private void SliderHead_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_ka52.out_Kurs = (float)SliderHead.Value;
		}
	}
}
