using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Extensionista.TestCases
{
    public class EventExample:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            if (!(PropertyChanged == null))
                PropertyChanged(this, new PropertyChangedEventArgs(value));
        }
    }
}
