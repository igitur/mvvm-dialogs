using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    public class AddTextDialogViewModel : ObservableObject, IModalDialogViewModel
    {
        private readonly ICommand okCommand;

        private string text;
        private bool? dialogResult;

        public AddTextDialogViewModel()
        {
            okCommand = new RelayCommand(Ok);
        }

        public string Text
        {
            get { return text; }
            set { Set(ref text, value); }
        }

        public ICommand OkCommand
        {
            get { return okCommand; }
        }

        public bool? DialogResult
        {
            get { return dialogResult; }
            private set { Set(ref dialogResult, value); }
        }

        private void Ok()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                DialogResult = true;
            }
        }
    }
}