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
using DataTransfer.Model.Structs.Config.Base;
using DataTransfer.Services.ControlElements;
using DataTransfer.Services.DataManager;
using DataTransfer.ViewModels.Base;
using DataTransfer.Views;
using MaterialDesignThemes.Wpf;

namespace DataTransfer.ViewModels
{
	class MainWindowViewModel:ViewModel
	{
		readonly DataManager _dataManager;
		readonly DeviceControlElement _deviceControlElement;

		#region MessageQueue: SnackbarMessageQueue - Сообщение для пользователя
		
		/// <summary>Сообщение для пользователя</summary>
		private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue();
		/// <summary>Сообщение для пользователя</summary>
		public SnackbarMessageQueue MessageQueue {get =>_messageQueue; set =>Set(ref _messageQueue, value);}
	
		#endregion		

		#region ModelState: string - Статус модели

		/// <summary>Статус модели</summary>
		private string _modelState;

		/// <summary>Статус модели</summary>
		public string ModelState {get => _modelState; set =>Set(ref _modelState, value);}

		#endregion	

		#region PacketState: string - Статус пакетов
		/// <summary>Статус пакетов</summary>
		private string _packetState;
		/// <summary>Статус пакетов</summary>
		public string PacketState {get =>_packetState; set =>Set(ref _packetState, value);}
		#endregion		
		
		#region DynamicInfos: ObservableCollection<CollectionInfo> - Параметры динамики полета
		/// <summary>Параметры динамики полета</summary>
		private ObservableCollection<CollectionInfo> _dynamicInfos;
		/// <summary>Параметры динамики полета</summary>
		public ObservableCollection<CollectionInfo> DynamicInfos { get =>_dynamicInfos; set =>Set(ref _dynamicInfos, value);}
		#endregion		

		#region controlElementinfos: ObservableCollection<CollectionInfo> - Параметры органов управления
		/// <summary>Параметры органов управления</summary>
		private ObservableCollection<CollectionInfo> _controlElementInfos;
		/// <summary>Параметры органов управления</summary>
		public ObservableCollection<CollectionInfo> ControlElementInfos {get =>_controlElementInfos; set =>Set(ref _controlElementInfos, value);}
		#endregion		

		#region isEnableStart: bool - активность кнопки старт
		/// <summary>активность кнопки старт</summary>
		private bool _isEnableStart= true;
		/// <summary>активность кнопки старт</summary>
		public bool IsEnableStart {get =>_isEnableStart; set =>Set(ref _isEnableStart, value);}
		#endregion		

		#region isEnablePause: bool - активность кнопки пауза
		/// <summary>активность кнопки пауза</summary>
		private bool _isEnablePause;
		/// <summary>активность кнопки пауза</summary>
		public bool IsEnablePause {get =>_isEnablePause; set =>Set(ref _isEnablePause, value);}
		#endregion		

		#region isEnableStop: bool - активность кнопки стоп
		/// <summary>активность кнопки стоп</summary>
		private bool _isEnableStop;
		/// <summary>активность кнопки стоп</summary>
		public bool IsEnableStop {get =>_isEnableStop; set =>Set(ref _isEnableStop, value);}
		#endregion		

		#region ModelSelect: string - Выбранная модель
		/// <summary>Выбранная модель</summary>
		private string _modelSelect;
		/// <summary>Выбранная модель</summary>
		public string ModelSelect { get =>_modelSelect;
			set
			{
				Set(ref _modelSelect, value);
				_dataManager.ChangeModel(value);
			}
		}
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

		#endregion

		public MainWindowViewModel()
		{
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
			MinimizeAppCommand = new LambdaCommand(OnMinimizeAppCommandExecuted, CanMinimizeAppCommandExecute);
			StartModelingCommand = new LambdaCommand(OnStartModelingCommandExecuted, CanStartModelingCommandExecute);
			PauseModelingCommand = new LambdaCommand(OnPauseModelingCommandExecuted, CanPauseModelingCommandExecute);
			StopModelingCommand = new LambdaCommand(OnStopModelingCommandExecuted, CanStopModelingCommandExecute);
			ChangeCollectionCommand = new LambdaCommand(OnChangeCollectionCommandExecuted, CanChangeCollectionCommandExecute);
			OpenDataDescriptionCreatorCommand = new LambdaCommand(OnOpenDataDescriptionCreatorCommandExecuted, CanOpenDataDescriptionCreatorCommandExecute);
			UploadConfigCommand = new LambdaCommand(OnUploadConfigCommandExecuted, CanUploadConfigCommandExecute);
			_dataManager = DataManager.GetInstance();
			_deviceControlElement = DeviceControlElement.GetInstance();
			_dataManager.Init();
			ModelSelect = Config.Instance().Default.DefaultDynamicModel.Value;
			DynamicInfos = _dataManager.DynamicInfos;
			ControlElementInfos = _dataManager.ControlElementInfos;
			_dataManager.StatusModelEvent += OnStatusModelEvent; 
			_dataManager.StatusPacketEvent += OnStatusPacketEvent;
			_dataManager.MessageEvent += OnMessageEvent;
			_deviceControlElement.MessageEvent += OnMessageEvent;




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
