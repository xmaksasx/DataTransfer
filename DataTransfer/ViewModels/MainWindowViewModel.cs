using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DataTransfer.Infrastructure.Commands;
using DataTransfer.Model.Component;
using DataTransfer.Services.DataManager;
using DataTransfer.ViewModels.Base;

namespace DataTransfer.ViewModels
{
	class MainWindowViewModel:ViewModel
	{
		readonly DataManager _dataManager;

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

		#endregion

		public MainWindowViewModel()
		{
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
			StartModelingCommand = new LambdaCommand(OnStartModelingCommandExecuted, CanStartModelingCommandExecute);
			PauseModelingCommand = new LambdaCommand(OnPauseModelingCommandExecuted, CanPauseModelingCommandExecute);
			StopModelingCommand = new LambdaCommand(OnStopModelingCommandExecuted, CanStopModelingCommandExecute);
			_dataManager = DataManager.GetInstance();
			DynamicInfos = _dataManager.DynamicInfos;
			ControlElementInfos = _dataManager.ControlElementInfos;
		}
	}
}
