using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;

namespace DemoApplication.Features.FolderBrowserDialog.ViewModels
{
    public class FolderBrowserTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ICommand browseFolderCommand;

        private string path;

        public FolderBrowserTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            
            browseFolderCommand = new RelayCommand(BrowseFolder);
        }

        public string Path
        {
            get { return path; }
            set { Set(ref path, value); }
        }

        public ICommand BrowseFolderCommand
        {
            get { return browseFolderCommand; }
        }

        private void BrowseFolder()
        {
            var settings = new FolderBrowserDialogSettings
            {
                Description = "This is a description"
            };

            bool? success = dialogService.ShowFolderBrowserDialog(this, settings);
            if (success == true)
            {
                Path = settings.SelectedPath;
            }
        }
    }
}