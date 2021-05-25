using System.Windows;
using DataTransfer.Services.DataManager;

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
			DataManager dataManager = new DataManager();
		}
	}
}
