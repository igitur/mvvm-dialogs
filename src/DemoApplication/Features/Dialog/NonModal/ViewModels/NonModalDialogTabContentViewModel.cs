using System;
using System.Windows.Input;
using DemoApplication.Features.Dialog.NonModal.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace DemoApplication.Features.Dialog.NonModal.ViewModels
{
    public class NonModalDialogTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ICommand implicitShowCommand;
        private readonly ICommand explicitShowCommand;

        public NonModalDialogTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            implicitShowCommand = new RelayCommand(ImplicitShow);
            explicitShowCommand = new RelayCommand(ExplicitShow);
        }

        public ICommand ImplicitShowCommand
        {
            get { return implicitShowCommand; }
        }

        public ICommand ExplicitShowCommand
        {
            get { return explicitShowCommand; }
        }

        private void ImplicitShow()
        {
            Show(viewModel => dialogService.Show(this, viewModel));
        }

        private void ExplicitShow()
        {
            Show(viewModel => dialogService.Show<CurrentTimeDialog>(this, viewModel));
        }

        private static void Show(Action<CurrentTimeDialogViewModel> show)
        {
            var dialogViewModel = new CurrentTimeDialogViewModel();
            show(dialogViewModel);
        }
    }
}