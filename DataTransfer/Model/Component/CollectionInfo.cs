using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataTransfer.Model.Component
{
	public class CollectionInfo
	{//: INotifyPropertyChanged
		private string _name = String.Empty;
		private string _value = String.Empty;
		private string _description = String.Empty;


		public string Name
		{
			get { return this._name; }

			set
			{
				if (value != this._name)
				{
					this._name = value;
					//NotifyPropertyChanged();
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
					//NotifyPropertyChanged();
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
					//NotifyPropertyChanged();
				}
			}
		}

		//public event PropertyChangedEventHandler PropertyChanged;

		//private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		//{
		//	if (PropertyChanged != null)
		//		PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}
	}
}
