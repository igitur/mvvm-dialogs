﻿using System;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using ReactiveUI;

namespace Aut.Features.SaveFileDialog.ViewModels
{
    public class SaveFileTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> saveFileCommand;

        private string path;

        public SaveFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            saveFileCommand = ReactiveCommand.Create();
            saveFileCommand.Subscribe(_ => SaveFile());
        }

        public string Path
        {
            get { return path; }
            set { this.RaiseAndSetIfChanged(ref path, value); }
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