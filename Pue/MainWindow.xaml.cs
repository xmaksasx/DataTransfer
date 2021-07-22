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
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Data;
using System.Linq;
using System.Globalization;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Collections.Generic;
using Microsoft.Research.DynamicDataDisplay;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

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
		private List<GraphInfo> _lstGraph { get; set; }
		private BaseModel _baseModel;
        private CommandPue _commandPue;
		private readonly DispatcherTimer _timer = new DispatcherTimer();
		private DateTime _dateRec, _timeTitle, _timeChart;
		public MainWindow()
		{
			InitializeComponent();
			_baseModel = new BaseModel();
            _commandPue = new CommandPue();
			_lstGraph = new List<GraphInfo>();

			_baseModel.Update3DEvent += Update3DEvent;

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
			LoadLog();
			LoadFault();
			LoadParam();
			InitPlotter();
			SetTimerInterrupts();

			ListOfData.ItemsSource = _baseModel.DynamicInfos;
			LstParameters.ItemsSource = _baseModel.ParameterInfos;

		}
		#region Инициализация Plotter

		private void InitPlotter()
		{


			Plotter.Children.Remove(Plotter.DefaultContextMenu);
			Plotter.Children.Remove(Plotter.KeyboardNavigation);
			Plotter.Children.Remove(Plotter.MouseNavigation);

			Plotter.Children.Remove(Plotter.VerticalAxisNavigation);
			Plotter.Children.Remove(Plotter.HorizontalAxisNavigation);
			Plotter.MainHorizontalAxisVisibility = Visibility.Hidden;
		}

		#endregion

		private void Update3DEvent(double pitch, double roll, double heading)
        {
            Roll.Angle = roll * -1.0;
            Pitch.Angle = pitch * -1.0;
            Heading.Angle = heading * -1.0;
        }

        private void LoadLog()
		{
			LstDataDesc = new ObservableCollection<NameDataDesc>();
			LstDataDesc.Add(new NameDataDesc() { Description = "Запуск приложения",  Name = "1", Value = DateTime.Now.ToShortTimeString() }); ;
			LstDataDesc.Add(new NameDataDesc() { Description = "Запуск моделирования", Name = "2", Value = DateTime.Now.ToShortTimeString() });
			LstDataDesc.Add(new NameDataDesc() { Description = "Смена времени суток", Name = "3", Value = DateTime.Now.ToShortTimeString() });

			LogList.ItemsSource = LstDataDesc;
		}

		private void LoadFault()
		{
			var lst = new ObservableCollection<FaultInfo>();
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Пожар левого двигателя", IsSelected = false, Code = "A" }); ;
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Пожар првого двигателя", IsSelected = false, Code = "A" });
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Отказ левого двигателя", IsSelected = false, Code = "A" });
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Отказ правого двигателя", IsSelected = false, Code = "A" });

			lst.Add(new FaultInfo() { Description = "Электрика", Name = "Отказ двух генераторов", IsSelected = false, Code = "Э" }); ;
			lst.Add(new FaultInfo() { Description = "Топливо", Name = "Осталось 600 кг.", IsSelected = false, Code = "Т" });
			lst.Add(new FaultInfo() { Description = "Радиовысотомер", Name = "Отказ радиовысотомера", IsSelected = false, Code = "Р" });
			LstFault.ItemsSource = lst;
		}

		private void LoadParam()
		{
			var lst = new ObservableCollection<FaultInfo>();
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Пожар левого двигателя", IsSelected = false, Code = "A" }); ;
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Пожар првого двигателя", IsSelected = false, Code = "A" });
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Отказ левого двигателя", IsSelected = false, Code = "A" });
			lst.Add(new FaultInfo() { Description = "Двигатель", Name = "Отказ правого двигателя", IsSelected = false, Code = "A" });

			lst.Add(new FaultInfo() { Description = "Электрика", Name = "Отказ двух генераторов", IsSelected = false, Code = "Э" }); ;
			lst.Add(new FaultInfo() { Description = "Топливо", Name = "Осталось 600 кг.", IsSelected = false, Code = "Т" });
			lst.Add(new FaultInfo() { Description = "Радиовысотомер", Name = "Отказ радиовысотомера", IsSelected = false, Code = "Р" });
			
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


		private void SetTimerInterrupts()
		{
			_timer.Interval = TimeSpan.FromMilliseconds(20);
			_timer.Tick += OnTimerTick;
			_timer.Start();
			_timeChart = DateTime.Now;
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
            Start.IsEnabled = false;
            Pause.IsEnabled = true;
            Stop.IsEnabled = true;
            _commandPue.sps = 1;
            _baseModel.SetCommand(_commandPue);
        }

		private void Pause_OnClick(object sender, RoutedEventArgs e)
		{
            Start.IsEnabled = true;
            Pause.IsEnabled = false;
            Stop.IsEnabled = true;
            _commandPue.sps = 2;
            _baseModel.SetCommand(_commandPue);
        }

		private void Stop_OnClick(object sender, RoutedEventArgs e)
		{
            Start.IsEnabled = true;
            Pause.IsEnabled = false;
            Stop.IsEnabled = false;
            _commandPue.sps = -1;
            _baseModel.SetCommand(_commandPue);
        }

		#region "Графики" Ввод, Снятие

		private void ChkItemRecord_OnChecked(object sender, RoutedEventArgs e)
		{
			ToggleButton chkSelecttedItem = (ToggleButton)sender;
			if (chkSelecttedItem.Content != null)
			{
				string nameLine = chkSelecttedItem.Tag.ToString();
				var source = new ObservableDataSource<PointsGraph>();
				source.SetXMapping(x => SpanAxis.ConvertToDouble(x.TimeG));
				source.SetYMapping(y => y.PointG);
				var uid =   ((string)chkSelecttedItem.Uid).Split('.').Last();
				_lstGraph.Add(new GraphInfo
				{
				
					LineGraph = Plotter.AddLineGraph(source, 2, nameLine),
					Source = source,
					Uid = uid
				});
				AddToLog("Отображен график: " + nameLine);
			}
		}



		private void ChkItemRecord_OnUnchecked(object sender, RoutedEventArgs e)
		{
			ToggleButton chkSelecttedItem = (ToggleButton)sender;
			if (chkSelecttedItem.Content != null)
			{
				var uid = ((string)chkSelecttedItem.Uid).Split('.').Last();
				GraphInfo lg = null;
				foreach (var item in _lstGraph)
					if (item.Uid == uid)
						lg = item;

				if (lg != null)
				{
					_lstGraph.RemoveAll(a => a.Uid == uid);
					Plotter.Children.Remove(lg.LineGraph);
					AddToLog("Удален график: " + chkSelecttedItem.Content);
				}

			}
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			
			SetChartData();

		}

		private void SetChartData()
		{
			if ((DateTime.Now - _timeChart).Milliseconds > 75)
			{
				_timeChart = DateTime.Now;
				foreach (var t in _lstGraph)
				{
					var tim = DateTime.Now;
					if (t.Source == null || t.Uid == null) continue;
					var p1 = new PointsGraph
					{
						PointG = Math.Round(Convert.ToDouble(_baseModel.GetData(t.Uid)), 3),
						TimeG = new TimeSpan(0, tim.Hour, tim.Minute, tim.Second, tim.Millisecond)
					};
					t.Source.AppendAsync(Dispatcher, p1);
				}

			
			}
		}

		#endregion

		#region Лог событий

		private void AddToLog(string Event)
		{
			NameDataDesc itemLog = new NameDataDesc();
			itemLog.Description = Event;
			itemLog.Value = DateTime.Now.ToShortTimeString();
			//LogList.Items.Add(itemLog);
			//LogList.Items.Refresh();
		}

		#endregion

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

		private void SetLptp_Click(object sender, RoutedEventArgs e)
		{
			var lptp = new Lptp();
		    lptp.scale=Convert.ToInt32(LptpScale.Text); 
		    lptp.posx = Convert.ToInt32(LptpPosX.Text);
			lptp.posy = Convert.ToInt32(LptpPosY.Text);
			lptp.Dtrg = Convert.ToInt32(LptpDistanceToTarget.Text);
			lptp.Htrg = Convert.ToInt32(LptpExcessElevationt.Text);
			lptp.lptp1 = Convert.ToByte(LptpTargetOn.IsChecked);
			lptp.lptp2 = Convert.ToByte(LptpScaleOn.IsChecked);
			lptp.lptp_show = Convert.ToByte(LptpShowOn.IsChecked);
			lptp.lptp_cel_show = Convert.ToByte(LptpMarkOn.IsChecked);
			lptp.lptp_tipgr = Convert.ToByte(LptpTypeCargo.Text);
            _baseModel.SetLpTp(lptp);

		}
		private void PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

	

		private void LptpTypeCargo_TextChanged(object sender, TextChangedEventArgs e)
		{

				int.TryParse(LptpTypeCargo.Text, out int result);
				if (result > 0 && result <= 255)
					return;
				else if (result < 0)
				{
					LptpTypeCargo.Text = "0";
				
				}
				else if (result > 255)
				{
					LptpTypeCargo.Text = "255";
					
				}
			
		}

      
        private void Channel1_Checked(object sender, RoutedEventArgs e)
        {
            if (_baseModel != null)
            {
                _commandPue.channel = 1;
                _baseModel?.SetCommand(_commandPue);
            }
        }
        private void Channel2_Checked(object sender, RoutedEventArgs e)
        {
            if (_baseModel != null)
            {
                _commandPue.channel = 2;
                _baseModel.SetCommand(_commandPue);
            }
        }

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			_baseModel.IsReceive = false;
		}

		private void ScrollViewer_PreviewMouseWheel(object sender,
													MouseWheelEventArgs e)
		{
			ScrollViewer scrollViewer = (ScrollViewer)sender;
			scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
		}
	}

	public class SplitConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((string)value).Split('.').Last();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	class FaultInfo
	{
		public string Code { get; set; }
		public bool IsSelected { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}


	public class PointsGraph
	{
		public TimeSpan TimeG;
		public double PointG;

	}

	public class GraphInfo
	{
		public string Uid;
		public ObservableDataSource<PointsGraph> Source;
		public LineGraph LineGraph = new LineGraph();
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
