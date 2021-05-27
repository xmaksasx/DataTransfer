using System.Windows;
using System.Windows.Input;
using DataTransfer.Infrastructure.Commands;
using DataTransfer.Services.DataManager;

namespace DataTransfer.ViewModels
{
	class MainWindowViewModel
	{
		DataManager _dataManager;

		#region Команды

		#region CloseAppCommand
		public ICommand CloseAppCommand { get; set; }

		private bool CanCloseAppCommandExecute(object p) => true;

		private void OnCloseAppCommandExecuted(object p)
		{
			_dataManager.StopThread();
			Application.Current.Shutdown();
		}
		#endregion

		#region StartModeling
		public ICommand StartModelingCommand { get; set; }

		private bool CanStartModelingCommandExecute(object p) => true;

		private void OnStartModelingCommandExecuted(object p)
		{
			_dataManager.Start();
		}
		#endregion


		#endregion

		public MainWindowViewModel()
		{
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
			StartModelingCommand = new LambdaCommand(OnStartModelingCommandExecuted, CanStartModelingCommandExecute);
			_dataManager = DataManager.GetInstance();
		}
	}
}
