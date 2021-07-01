using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using DataTransfer.Model.Structs.ControlElements;
using MaterialDesignThemes.Wpf;


namespace DataTransfer.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			SplashScreen splash = new SplashScreen("/Infrastructure/resource/Splash.png");
			
			splash.Show(false);
			splash.Close(TimeSpan.FromMilliseconds(2));
			InitializeComponent();

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
