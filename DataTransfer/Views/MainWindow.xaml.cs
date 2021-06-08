using System.ComponentModel;
using System.Reflection;
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
