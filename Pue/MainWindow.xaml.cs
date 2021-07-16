using HelixToolkit.Wpf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
//using Microsoft.Research.DynamicDataDisplay;
//using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace Pue
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public ObservableCollection<NameDataDesc> LstDataDesc { get; set; }
		public MainWindow()
		{
			InitializeComponent();

			Prepare3DModel();
			//// Prepare data in arrays
			//const int N = 1000;
			//double[] x = new double[N];
			//double[] y = new double[N];

			//for (int i = 0; i < N; i++)
			//{
			//	x[i] = i * 0.1;
			//	y[i] = Math.Sin(x[i]);
			//}

			//// Create data sources:
			//var xDataSource = x.AsXDataSource();
			//var yDataSource = y.AsYDataSource();

			//CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
			//// adding graph to plotter
			//plotter.AddLineGraph(compositeDataSource, Color.FromArgb(255,196,32,222),
			//	3,
			//	"Sine");

			//// Force evertyhing plotted to be visible
			//plotter.FitToView();

			//LstDataDesc = new ObservableCollection<NameDataDesc>();
			//LstDataDesc.Add(new NameDataDesc(){Description = "Тангаж", Name = "Taetta", Value = "54"});
			//LstDataDesc.Add(new NameDataDesc() { Description = "Крен", Name = "Gamma", Value = "21" });
			//LstDataDesc.Add(new NameDataDesc() { Description = "Курс", Name = "PSI", Value = "128" });

			//ListOfData.ItemsSource = LstDataDesc;


		}

		private void Prepare3DModel()
		{
			ObjReader helixObjReader = new ObjReader();
			string path = @"path-to-image.png";
			Material material = MaterialHelper.CreateImageMaterial(path, 1);
			var modelAircraft3D = helixObjReader.Read(@"mi24.obj");
			model.Content = modelAircraft3D;


			model.Children.Add(new DefaultLights());

			myView.Camera.UpDirection = new Vector3D(0, 1, 0);
			myView.Camera.LookDirection = new Vector3D(0, 0, -100);
			myView.Camera.Position = new Point3D(0, 0, 100);
		}


		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void CloseApp_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MinimizedApp_OnClick(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void Start_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void Pause_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void Stop_OnClick(object sender, RoutedEventArgs e)
		{
	
		}
	}

	[Serializable]
	public class NameDataDesc : INotifyPropertyChanged
	{
		private string _name = String.Empty;
		private string _value = String.Empty;
		private string _description = String.Empty;

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public string Name
		{
			get { return this._name; }

			set
			{
				if (value != this._name)
				{
					this._name = value;
					NotifyPropertyChanged();
				}
			}
		}

		public string Value
		{
			get { return this._value; }

			set
			{
				if (value != this._value)
				{
					this._value = value;
					NotifyPropertyChanged();
				}
			}
		}

		public string Description
		{
			get { return this._description; }

			set
			{
				if (value != this._description)
				{
					this._description = value;
					NotifyPropertyChanged();
				}
			}
		}
	}
}
