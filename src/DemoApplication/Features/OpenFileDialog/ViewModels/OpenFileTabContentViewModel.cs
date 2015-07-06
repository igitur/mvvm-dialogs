using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    public class OpenFileTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ICommand openFileCommand;

        private string path;

        public OpenFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            
            openFileCommand = new RelayCommand(OpenFile);
        }

        public string Path
        {
            get { return path; }
            set { Set(ref path, value); }
        }

        public ICommand OpenFileCommand
        {
            get { return openFileCommand; }
        }

        private void OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "This Is The Title",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            bool? success = dialogService.ShowOpenFileDialog(this, settings);
            if (success == true)
            {
                Path = settings.FileName;
            }
        }
    }
}