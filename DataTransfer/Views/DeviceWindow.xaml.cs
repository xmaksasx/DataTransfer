using System.Windows;

namespace DataTransfer.Views
{
	public partial class DeviceWindow : Window
	{
		public DeviceWindow()
		{
			InitializeComponent();
		}

		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}
