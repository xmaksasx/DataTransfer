using System.Windows;

namespace DataTransfer.Views
{
	/// <summary>
	/// Interaction logic for DataDesctiptionCreatorWindow.xaml
	/// </summary>
	public partial class DataDescriptionCreatorWindow : Window
	{
		public DataDescriptionCreatorWindow()
		{
			InitializeComponent();
		}

		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DragMove();
		}

		
	}
}
