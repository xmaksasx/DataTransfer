using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using DataTransfer.Model.Component;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs;
using DataTransfer.Services.DataDescriptionCreator;
using DataTransfer.Services.DataManager;

namespace DataTransfer.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

		    Route _routeToIup = new Route();
			int s = Marshal.SizeOf(_routeToIup);
			_routeToIup.DepartureAerodrome.Name = new char[40];

			var name = "АААААААААААААААААААААААААААААААААААААААП".ToCharArray();
			name.CopyTo(_routeToIup.DepartureAerodrome.Name, 0);
	        ToBigEndian(_routeToIup.DepartureAerodrome.Name);
	        ToLittleEndian(_routeToIup.DepartureAerodrome.Name);


		}

		private char[] ToBigEndian(char[] str)
		{
			Array.Copy(Encoding.BigEndianUnicode.GetBytes(str), str, str.Length);
			for (int i = 0; i < str.Length; i = i + 8)
				Array.Reverse(str, i, 8);
			return str;
		}

		private void ToLittleEndian(char[] str)
		{
			for (int i = 0; i < str.Length; i = i + 8)
				Array.Reverse(str, i, 8);
			var bytes = Encoding.UTF8.GetBytes(str);
			string st = Encoding.BigEndianUnicode.GetString(bytes);
			str = new char[str.Length];
		Array.Copy(st.ToCharArray(), str, st.Length);
			
		}

		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			DeviceWindow dw = new DeviceWindow();
			dw.ShowDialog();
		}

		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}
