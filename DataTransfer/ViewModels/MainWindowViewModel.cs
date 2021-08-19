using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using DataTransfer.Infrastructure.Commands;
using DataTransfer.Model.Component;
using DataTransfer.Model.Structs;
using DataTransfer.Model.Structs.Config.Base;
using DataTransfer.Services.ControlElements;
using DataTransfer.Services.DataManager;
using DataTransfer.ViewModels.Base;
using DataTransfer.Views;
using MaterialDesignThemes.Wpf;

namespace DataTransfer.ViewModels
{
	class MainWindowViewModel : ViewModel
	{
		readonly DataManager _dataManager;
		readonly DeviceControlElement _deviceControlElement;

		#region MessageQueue: SnackbarMessageQueue - Сообщение для пользователя

		/// <summary>Сообщение для пользователя</summary>
		private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue();
		/// <summary>Сообщение для пользователя</summary>
		public SnackbarMessageQueue MessageQueue { get => _messageQueue; set => Set(ref _messageQueue, value); }

		#endregion

		#region ModelState: string - Статус модели

		/// <summary>Статус модели</summary>
		private string _modelState;

		/// <summary>Статус модели</summary>
		public string ModelState { get => _modelState; set => Set(ref _modelState, value); }

		#endregion

		#region PacketState: string - Статус пакетов
		/// <summary>Статус пакетов</summary>
		private string _packetState;
		/// <summary>Статус пакетов</summary>
		public string PacketState { get => _packetState; set => Set(ref _packetState, value); }
		#endregion

		#region DynamicInfos: ObservableCollection<CollectionInfo> - Параметры динамики полета
		/// <summary>Параметры динамики полета</summary>
		private ObservableCollection<CollectionInfo> _dynamicInfos;
		/// <summary>Параметры динамики полета</summary>
		public ObservableCollection<CollectionInfo> DynamicInfos { get => _dynamicInfos; set => Set(ref _dynamicInfos, value); }
		#endregion

		#region controlElementinfos: ObservableCollection<CollectionInfo> - Параметры органов управления
		/// <summary>Параметры органов управления</summary>
		private ObservableCollection<CollectionInfo> _controlElementInfos;
		/// <summary>Параметры органов управления</summary>
		public ObservableCollection<CollectionInfo> ControlElementInfos { get => _controlElementInfos; set => Set(ref _controlElementInfos, value); }
		#endregion

		#region isEnableStart: bool - активность кнопки старт
		/// <summary>активность кнопки старт</summary>
		private bool _isEnableStart = true;
		/// <summary>активность кнопки старт</summary>
		public bool IsEnableStart { get => _isEnableStart; set => Set(ref _isEnableStart, value); }
		#endregion

		#region isEnablePause: bool - активность кнопки пауза
		/// <summary>активность кнопки пауза</summary>
		private bool _isEnablePause;
		/// <summary>активность кнопки пауза</summary>
		public bool IsEnablePause { get => _isEnablePause; set => Set(ref _isEnablePause, value); }
		#endregion

		#region isEnableStop: bool - активность кнопки стоп
		/// <summary>активность кнопки стоп</summary>
		private bool _isEnableStop;
		/// <summary>активность кнопки стоп</summary>
		public bool IsEnableStop { get => _isEnableStop; set => Set(ref _isEnableStop, value); }
		#endregion

		#region ModelSelect: string - Выбранная модель
		/// <summary>Выбранная модель</summary>
		private string _modelSelect;
		/// <summary>Выбранная модель</summary>
		public string ModelSelect { get => _modelSelect;
			set
			{
				Set(ref _modelSelect, value);
				_dataManager.ChangeModel(value);
			}
		}
		#endregion

		#region ControlElementSelect: string - Выбранные органы управления
		/// <summary>Выбранные органы управления</summary>
		private string _controlElementSelect;
		/// <summary>Выбранные органы управления</summary>
		public string ControlElementSelect
		{
			get => _controlElementSelect;
			set
			{
				Set(ref _controlElementSelect, value);
				_dataManager.ChangeControlElement(value);
			}
		}
		#endregion

		#region Координаты

		#region Speed: double - Скорость 

		/// <summary>Тангаж</summary>
		private double _speed = 150;

		/// <summary>Тангаж</summary>
		public double Speed { get => _speed; set => Set(ref _speed, value); } 

		#endregion

		#region Heading: double - Курс 

		/// <summary>Курс</summary>
		private double _heading;

		/// <summary>Курс</summary>
		public double Heading { get => _heading; set => Set(ref _heading, value); }

		#endregion

		#region Elevation: double - Высота 

		/// <summary>Высота</summary>
		private double _elevation=14;

		/// <summary>Высота</summary>
		public double Elevation { get => _elevation; set => Set(ref _elevation, value); }

		#endregion

		#region CoordX: double - Координата Х 

		/// <summary>Координата Х</summary>
		private string _coordX;

		/// <summary>Координата Х</summary>
		public string CoordX {get => _coordX; set => Set(ref _coordX, value);}

		#endregion


		#region CoordZ: double - Координата Z 

		/// <summary>Координата Z</summary>
		private string _coordZ;

		/// <summary>Координата Z</summary>
		public string CoordZ { get => _coordZ; set => Set(ref _coordZ, value); }

		#endregion

		#endregion

		#region Команды

		#region CloseAppCommand
		public ICommand CloseAppCommand { get; set; }

		private bool CanCloseAppCommandExecute(object p) => true;

		private void OnCloseAppCommandExecuted(object p)
		{
			_dataManager?.StopThread();
			Application.Current.Shutdown();
		}
		#endregion

		#region MinimizeAppCommand
		public ICommand MinimizeAppCommand { get; set; }

		private bool CanMinimizeAppCommandExecute(object p) => true;

		private void OnMinimizeAppCommandExecuted(object p)
		{

			Application.Current.MainWindow.WindowState = WindowState.Minimized;
		}
		#endregion

		

		#region StartModeling
		public ICommand StartModelingCommand { get; set; }

		private bool CanStartModelingCommandExecute(object p) => true;

		private void OnStartModelingCommandExecuted(object p)
		{
			IsEnableStart = false;
			IsEnablePause = true;
			IsEnableStop = true;
			_dataManager.Start();
		}
		#endregion

		#region PauseModeling
		public ICommand PauseModelingCommand { get; set; }

		private bool CanPauseModelingCommandExecute(object p) => true;

		private void OnPauseModelingCommandExecuted(object p)
		{
			IsEnableStart = true;
			IsEnablePause = false;
			IsEnableStop = true;
			_dataManager.Pause();
		}
		#endregion

		#region StopModeling
		public ICommand StopModelingCommand { get; set; }

		private bool CanStopModelingCommandExecute(object p) => true;

		private void OnStopModelingCommandExecuted(object p)
		{
			IsEnableStart = true;
			IsEnablePause = false;
			IsEnableStop = false;
			_dataManager.Stop();
		}
		#endregion

		#region Upload config
		public ICommand UploadConfigCommand { get; set; }

		private bool CanUploadConfigCommandExecute(object p) => true;

		private void OnUploadConfigCommandExecuted(object p)
		{
			Config config = null;
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "DataTransfer.Infrastructure.Resource.Config.xml";
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				using (StreamReader reader = new StreamReader(stream))
					config = (Config) serializer.Deserialize(reader);
			}
			using (var writer = new StreamWriter("Config.xml"))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				serializer.Serialize(writer, config);
				writer.Flush();
			}

			OnMessageEvent("Создан файл \"Config.xml\" в корневом каталоге!");
		}

		#endregion

		#region ChangeCollection
		public ICommand ChangeCollectionCommand { get; set; }

		private bool CanChangeCollectionCommandExecute(object p) => true;

		private void OnChangeCollectionCommandExecuted(object p)
		{

			switch (p.ToString())
			{
				case "Dynamic":
					DynamicInfos = _dataManager.DynamicInfos;
					break;
				case "ControlElement":
					DynamicInfos = _dataManager.ControlElementInfos;
					break;
			}
		}
		#endregion

		#region ChangeChannelComtrolElement
		public ICommand ChangeChannelComtrolElementCommand { get; set; }

		private bool CanChangeChannelComtrolElementCommandExecute(object p) => true;

		private void OnChangeChannelComtrolElementCommandExecuted(object p)
		{

			switch (p.ToString())
			{
				case "FirstChannel":
					_dataManager.SetChannelControlElement(1);
					break;
				case "SecondChannel":
					_dataManager.SetChannelControlElement(2);
					break;
			}
		}
		#endregion

		#region OpenDataDescriptionCreator
		public ICommand OpenDataDescriptionCreatorCommand { get; set; }

		private bool CanOpenDataDescriptionCreatorCommandExecute(object p) => true;

		private void OnOpenDataDescriptionCreatorCommandExecuted(object p)
		{
			DataDescriptionCreatorWindow creatorWindow = new DataDescriptionCreatorWindow();
			creatorWindow.ShowDialog();
			OnMessageEvent("Выгрузка \"DataDescription\" закончена!");
		}
		#endregion

		#region SetCoordinate
		public ICommand SetCoordinateCommand { get; set; }

		private bool CanSetCoordinateCommandExecute(object p) => true;

		private void OnSetCoordinateCommandExecuted(object p)
		{

			double valueX;
			double valueZ;
			double.TryParse(CoordX, out valueX);
			double.TryParse(CoordZ, out valueZ);

			StartPosition sp = new StartPosition()
			{
				StartX = valueX,
				StartY = valueZ,
				in_Hgeom = (float)Elevation,
				in_Kurs0 = (float)Heading,
				in_V = (float)Speed
			};
			_dataManager.SetStartPosition(sp);
		}
		#endregion

		#region SetLandingCoordinate
		public ICommand SetLandingCoordinateCommand { get; set; }

		private bool CanSetLandingCoordinateCommandExecute(object p) => true;

		private void OnSetLandingCoordinateCommandExecuted(object p)
		{

			CoordX = "-5103";
			CoordZ = "-10892";
			Elevation = 600;
			Heading = 290;
			Speed = 150;
			double valueX;
			double valueZ;
			double.TryParse(CoordX, out valueX);
			double.TryParse(CoordZ, out valueZ);

			StartPosition sp = new StartPosition()
			{
				StartX = valueX,
				StartY = valueZ,
				in_Hgeom = (float)Elevation,
				in_Kurs0 = (float)Heading,
				in_V = (float)Speed
			};
			_dataManager.SetStartPosition(sp);
		}
		#endregion

		#region ResetCoordinate
		public ICommand ResetCoordinateCommand { get; set; }

		private bool CanResetCoordinateCommandExecute(object p) => true;

		private void OnResetCoordinateCommandExecuted(object p)
		{
			CoordX = "0";
			CoordZ = "0";
			Elevation = 14;
			Heading = 0;
			Speed = 0;

			StartPosition sp = new StartPosition()
			{
				StartX = 0,
				StartY = 0,
				in_Hgeom = (float)14.0,
				in_Kurs0 = (float)0.0,
				in_V = (float)0.0
			};
			_dataManager.SetStartPosition(sp);
		}
		#endregion

		#endregion

		public MainWindowViewModel()
		{
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
			MinimizeAppCommand = new LambdaCommand(OnMinimizeAppCommandExecuted, CanMinimizeAppCommandExecute);
			StartModelingCommand = new LambdaCommand(OnStartModelingCommandExecuted, CanStartModelingCommandExecute);
			PauseModelingCommand = new LambdaCommand(OnPauseModelingCommandExecuted, CanPauseModelingCommandExecute);
			StopModelingCommand = new LambdaCommand(OnStopModelingCommandExecuted, CanStopModelingCommandExecute);
			ChangeCollectionCommand = new LambdaCommand(OnChangeCollectionCommandExecuted, CanChangeCollectionCommandExecute);
            ChangeChannelComtrolElementCommand = new LambdaCommand(OnChangeChannelComtrolElementCommandExecuted, CanChangeChannelComtrolElementCommandExecute);
            OpenDataDescriptionCreatorCommand = new LambdaCommand(OnOpenDataDescriptionCreatorCommandExecuted, CanOpenDataDescriptionCreatorCommandExecute);
			UploadConfigCommand = new LambdaCommand(OnUploadConfigCommandExecuted, CanUploadConfigCommandExecute);

			SetCoordinateCommand = new LambdaCommand(OnSetCoordinateCommandExecuted, CanSetCoordinateCommandExecute);
			SetLandingCoordinateCommand = new LambdaCommand(OnSetLandingCoordinateCommandExecuted, CanSetLandingCoordinateCommandExecute);
			ResetCoordinateCommand = new LambdaCommand(OnResetCoordinateCommandExecuted, CanResetCoordinateCommandExecute);

			
			_dataManager = DataManager.GetInstance();
			_deviceControlElement = DeviceControlElement.GetInstance();
			_dataManager.Init();
			ModelSelect = Config.Instance().Default.DefaultDynamicModel.Value;
			ControlElementSelect = Config.Instance().Default.DefaultControlElement.Value;
			DynamicInfos = _dataManager.DynamicInfos;
			ControlElementInfos = _dataManager.ControlElementInfos;
			_dataManager.StatusModelEvent += OnStatusModelEvent; 
			_dataManager.StatusPacketEvent += OnStatusPacketEvent;
			_dataManager.MessageEvent += OnMessageEvent;
            _dataManager.ChangeBtnEvent += ChangeBtnEvent;

            _deviceControlElement.MessageEvent += OnMessageEvent;
			ChangeChannelComtrolElementCommand.Execute("FirstChannel");
			ChangeBtnEvent("Channel1");

		}

        private void ChangeBtnEvent(string str)
        {
            switch (str)
            {
                case "Start":
                    StartModelingCommand.Execute(null);
                    break;
                case "Pause":
                    PauseModelingCommand.Execute(null);
                    break;
                case "Stop":
                    StopModelingCommand.Execute(null);
                    break;

                case "Channel1":
                    ChangeChannelComtrolElementCommand.Execute("FirstChannel");
                    break;
                case "Channel2":
                    ChangeChannelComtrolElementCommand.Execute("SecondChannel");
                    break;
                default:
                    break;
            }
        }

        private void OnMessageEvent(string str)
		{
			MessageQueue.Enqueue(
			str,
			null,
			null,
			null,
			false,
			true,
			TimeSpan.FromSeconds(2));
		}

		private void OnStatusPacketEvent(string str)
		{
			PacketState = str;
		}

		private void OnStatusModelEvent(string str)
		{
			ModelState = str;
		}
		
	}

	public class ModelSwitchConverter : IValueConverter
	{
	
			public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			{
				return ((string)parameter == (string)value);
			}

			public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			{
				return (bool)value ? parameter : null;
			}
		
	}

}
