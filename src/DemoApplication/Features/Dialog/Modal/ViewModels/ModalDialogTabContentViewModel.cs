using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DemoApplication.Features.Dialog.Modal.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    public class ModalDialogTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ObservableCollection<string> texts;
        private readonly ICommand implicitShowDialogCommand;
        private readonly ICommand explicitShowDialogCommand;

        public ModalDialogTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            texts = new ObservableCollection<string>();

            implicitShowDialogCommand = new RelayCommand(ImplicitShowDialog);
            explicitShowDialogCommand = new RelayCommand(ExplicitShowDialog);
        }

        public ObservableCollection<string> Texts
        {
            get { return texts; }
        }

        public ICommand ImplicitShowDialogCommand
        {
            get { return implicitShowDialogCommand; }
        }

        public ICommand ExplicitShowDialogCommand
        {
            get { return explicitShowDialogCommand; }
        }

        private void ImplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog(this, viewModel));
        }

        private void ExplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog<AddTextDialog>(this, viewModel));
        }

        private void ShowDialog(Func<AddTextDialogViewModel, bool?> showDialog)
        {
            var dialogViewModel = new AddTextDialogViewModel();

            bool? success = showDialog(dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }
    }
}