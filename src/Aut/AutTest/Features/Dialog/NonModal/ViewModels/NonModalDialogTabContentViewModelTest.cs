﻿using Aut.Features.Dialog.NonModal.Views;
using MvvmDialogs;
using NUnit.Framework;
using Moq;

namespace Aut.Features.Dialog.NonModal.ViewModels
{
    [TestFixture]
    public class NonModalDialogTabContentViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private NonModalDialogTabContentViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new NonModalDialogTabContentViewModel(dialogService.Object);
        }

        [Test]
        public void ImplicitShowCurrentTime()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.Show(viewModel, It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // ACT
            viewModel.ImplicitShowCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ExplicitShowCurrentTime()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.Show<CurrentTimeDialog>(It.IsAny<NonModalDialogTabContentViewModel>(), It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // ACT
            viewModel.ExplicitShowCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }
    }
}