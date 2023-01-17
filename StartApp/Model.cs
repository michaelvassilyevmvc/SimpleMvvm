using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace StartApp
{
    public class Model: INotifyPropertyChanged
    {
        string mCurrentName;
        public string CurrentName {
            get
            {
                return mCurrentName;
            }
            set
            {
                if (value == mCurrentName) return;
                mCurrentName = value;
                OnPropertyChanged();
            } 
        }

        public ObservableCollection<string> AddedNames { get; } = new ObservableCollection<string>();

        public ICommand AddCommand { get; private set; }

        public Model()
        {
            AddCommand = new AddNameCommand(this);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
