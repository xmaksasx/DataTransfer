using System;
using System.Windows;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Services.DataManager;
using DataTransfer.View;

namespace DataTransfer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
			Header f = new Header();
			f.GetHeadDouble("dynamicModel");
			DataManager dataManager = DataManager.GetInstance();
			dataManager.Start();
		}

		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			DeviceWindow dw = new DeviceWindow();
			dw.ShowDialog();
		}
	}
}
