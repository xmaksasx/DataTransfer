using System.Windows;
using DataTransfer.Model.Component.BaseComponent;
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
			
			Header f = new Header();
			f.GetHeadDouble("dynamicModel");
			DataManager dataManager = DataManager.GetInstance();
			dataManager.StartThread();
		}

		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			DeviceWindow dw = new DeviceWindow();
			dw.ShowDialog();
		}
	}
}
