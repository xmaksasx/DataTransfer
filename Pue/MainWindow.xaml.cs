using HelixToolkit.Wpf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using Pue.Models;

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
		private BaseModel _baseModel;
		public MainWindow()
		{
			InitializeComponent();
			_baseModel = new BaseModel();
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
			string path = @"texture.png";
			var point = helixObjReader.Read(@"mi24.obj");

			//var importer = new HelixToolkit.Wpf.ModelImporter();
			//var point = importer.Load("mi24.obj");

			//GeometryModel3D model = point.Children[0] as GeometryModel3D;

	
			//Material material = MaterialHelper.CreateImageMaterial(path, 1);

			ImageBrush colors_brush = new ImageBrush();
			colors_brush.ImageSource =
				new BitmapImage(new Uri("texture.png", UriKind.Relative));
			DiffuseMaterial colors_material =
				new DiffuseMaterial(colors_brush);
			GeometryModel3D model;

			DiffuseMaterial diffuseMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Black));

			SpecularMaterial specularMaterial = new SpecularMaterial(new SolidColorBrush(Colors.Chocolate), 2.55);
			foreach (var pointChild in point.Children)
			{
				 model = pointChild as GeometryModel3D;
			
				 model.Material = specularMaterial;
				// model.Material = diffuseMaterial;
			}

			//DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(Colors.Black));

			//SpecularMaterial specularMaterial = new SpecularMaterial(new SolidColorBrush(Colors.Chocolate), 2.55);
			
			//model.Material = material;
			//model.Material = specularMaterial;

			modelVisual3D.Content = point;




			//model.Content = modelAircraft3D;
			//model.Children.Add(new DefaultLights());
			//GeometryModel3D model1 = modelAircraft3D.Children[0] as GeometryModel3D;
			//DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(Colors.Black));
			//model1.Material = material;
			//modelAircraft3D.Children[0] = model1;
			//model.Content = modelAircraft3D;
			modelVisual3D.Children.Add(new DefaultLights());
			myView.Camera.UpDirection = new Vector3D(0, 1, 0);
			myView.Camera.LookDirection = new Vector3D(0, 0, 100);
			myView.Camera.Position = new Point3D(0, 0, -25);
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
			var t = myView.Camera;
			myView.Camera.Position = new Point3D(0,16, 25);
		}

		private void Pause_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void Stop_OnClick(object sender, RoutedEventArgs e)
		{
	
		}

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

			xxx.Angle = e.NewValue*3;

		}

		private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			yyy.Angle = e.NewValue * 3;
		}

		private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			zzz.Angle = e.NewValue * 3;
		}

		private void SetTime_OnChecked(object sender, RoutedEventArgs e)
		{
			var cb = (RadioButton) sender;
			_baseModel?.SetDayTime(Convert.ToInt32(cb?.Tag));
		}
		private void IntensityFog_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_baseModel?.SetFog(100 - e.NewValue);
		}

		private void Precipitation_OnChecked(object sender, RoutedEventArgs e)
		{
			var cb = (RadioButton)sender;
			switch (cb?.Tag?.ToString())
			{
				case "Good":
					_baseModel?.SetPrecipitation(0.001F, 0.001F);
				break;
				case "Rain":
					_baseModel?.SetPrecipitation(0.9F, 0.001F);
					break;
				case "Snow":
					_baseModel?.SetPrecipitation(0.001F, 0.9F);
					break;
			}
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
