using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DataTransfer.Infrastructure.Commands;
using DataTransfer.Services.DataDescriptionCreator;
using DataTransfer.ViewModels.Base;

namespace DataTransfer.ViewModels
{
	class DataDescriptionCreatorViewModel:ViewModel
	{
		#region ObjectInfos: ObservableCollection<ObjectInfo> - Список объектов
		/// <summary>Список объектов</summary>
		private ObservableCollection<ObjectInfo> _objectInfos;
		/// <summary>Список объектов</summary>
		public ObservableCollection<ObjectInfo> ObjectInfos { get =>_objectInfos; set =>Set(ref _objectInfos, value);}
		#endregion		

		readonly DataDescriptionCreator _dataDescriptionCreator = DataDescriptionCreator.GetInstance();

		#region Команды

		#region CloseAppCommand
		public ICommand CloseAppCommand { get; set; }

		private bool CanCloseAppCommandExecute(object p) => true;

		private void OnCloseAppCommandExecuted(object p)
		{
			foreach (Window window in Application.Current.Windows)
				if (window.DataContext == this)
					window.Close();
		}

		public ICommand UploadDataDescriptionCommand { get; set; }

		private bool CanUploadDataDescriptionCommandExecute(object p) => true;

		private void OnUploadDataDescriptionCommandExecuted(object p)
		{
			foreach (var objectInfo in _objectInfos)
				if (objectInfo.IsSelected)
					_dataDescriptionCreator.CreateDataDescription(objectInfo.ObjectType);
		}



		#endregion

		#endregion

		public DataDescriptionCreatorViewModel()
		{
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
			UploadDataDescriptionCommand = new LambdaCommand(OnUploadDataDescriptionCommandExecuted, CanUploadDataDescriptionCommandExecute);

	
			_objectInfos = new ObservableCollection<ObjectInfo>();
			foreach (var objectInfo in _dataDescriptionCreator.SearchTypes())
			{
				_objectInfos.Add(new ObjectInfo() { Guid = objectInfo.AssemblyQualifiedName, Name = objectInfo.Name, ObjectType = objectInfo });
			}
		}

	}
	class ObjectInfo
	{
		public string Guid { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }
		public Type ObjectType { get; set; }
	}

}

