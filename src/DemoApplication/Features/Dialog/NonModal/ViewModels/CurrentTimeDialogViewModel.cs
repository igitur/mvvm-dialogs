using System;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DemoApplication.Features.Dialog.NonModal.ViewModels
{
    public class CurrentTimeDialogViewModel : ObservableObject
    {
        private readonly ICommand startClockCommand;
        
// ReSharper disable once NotAccessedField.Local
        private DispatcherTimer timer;

        public CurrentTimeDialogViewModel()
        {
            startClockCommand = new RelayCommand(StartClock);
        }

        public ICommand StartClockCommand
        {
            get { return startClockCommand; }
        }

        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private void StartClock()
        {
            timer = new DispatcherTimer(
                TimeSpan.FromSeconds(1),
                DispatcherPriority.Normal,
                OnTick,
                Dispatcher.CurrentDispatcher);
        }

        private void OnTick(object sender, EventArgs e)
        {
// ReSharper disable once ExplicitCallerInfoArgument
            RaisePropertyChanged("CurrentTime");
        }
    }
}