using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;

namespace DemoApplication.Features.SaveFileDialog.ViewModels
{
    public class SaveFileTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ICommand saveFileCommand;

        private string path;

        public SaveFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            saveFileCommand = new RelayCommand(SaveFile);
        }

        public string Path
        {
            get { return path; }
            set { Set(ref path, value); }
        }

        public ICommand SaveFileCommand
        {
            get { return saveFileCommand; }
        }

        private void SaveFile()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "This Is The Title",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*",
                CheckFileExists = false
            };

            bool? success = dialogService.ShowSaveFileDialog(this, settings);
            if (success == true)
            {
                Path = settings.FileName;
            }
        }
    }
}