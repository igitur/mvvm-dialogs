using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace DemoApplication
{
    public abstract class TabItemViewModel : ObservableObject
    {
        public abstract string Title { get; }

        public abstract INotifyPropertyChanged Content { get; }

        public abstract int Priority { get; }
    }
}