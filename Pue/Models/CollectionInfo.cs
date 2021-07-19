using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Pue.Models
{
    public class CollectionInfo : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _value = string.Empty;
        private string _description = string.Empty;
        private string _guidName = string.Empty;

     

        public string Name
        {
            get { return _name; }

            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Value
        {
            get { return _value; }

            set
            {
                if (value != _value)
                {
                    _value = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Description
        {
            get { return _description; }

            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string GuidName
        {
            get { return _guidName; }

            set
            {
                if (value != _guidName)
                {
                    _guidName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
