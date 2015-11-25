using AutUITest.ObjectRepository;
using AutUITest.ObjectRepository.ModalDialog;
using CUITe.ObjectRepository;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutUITest
{
    [CodedUITest]
#if DEBUG
    [DeploymentItem(@"..\..\..\Aut\bin\Debug\Aut.exe")]
#else
    [DeploymentItem(@"..\..\..\Aut\bin\Release\Aut.exe")]
#endif
    public class ModalDialogTests
    {
        private MainScreen mainScreen;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            mainScreen = Screen.Launch<MainScreen>("Aut.exe");
        }

        [TestMethod]
        public void AddTextUsingDialogTypeLocator()
        {
            // ARRANGE
            AddTextScreen addTextScreen = mainScreen.ModalDialog.ClickAddTextUsingDialogTypeLocator();

            // ACT
            addTextScreen.Text = "Added text";
            addTextScreen.ClickOK();

            // ASSERT
            CollectionAssert.AreEqual(new[] { "Added text" }, mainScreen.ModalDialog.Texts);
        }

        [TestMethod]
        public void AddTextBySpecifyingDialogType()
        {
            // ARRANGE
            AddTextScreen addTextScreen = mainScreen.ModalDialog.ClickAddTextBySpecifyingDialogType();

            // ACT
            addTextScreen.Text = "Added text";
            addTextScreen.ClickOK();

            // ASSERT
            CollectionAssert.AreEqual(new[] { "Added text" }, mainScreen.ModalDialog.Texts);
        }

        [TestMethod]
        public void CancelAddingTextUsingDialogTypeLocator()
        {
            // ARRANGE
            AddTextScreen addTextScreen = mainScreen.ModalDialog.ClickAddTextUsingDialogTypeLocator();

            // ACT
            addTextScreen.Text = "Added text";
            addTextScreen.ClickCancel();

            // ASSERT
            CollectionAssert.AreEqual(new string[0], mainScreen.ModalDialog.Texts);
        }

        [TestMethod]
        public void CancelAddingTextBySpecifyingDialogType()
        {
            // ARRANGE
            AddTextScreen addTextScreen = mainScreen.ModalDialog.ClickAddTextBySpecifyingDialogType();

            // ACT
            addTextScreen.Text = "Added text";
            addTextScreen.ClickCancel();

            // ASSERT
            CollectionAssert.AreEqual(new string[0], mainScreen.ModalDialog.Texts);
        }
    }
}