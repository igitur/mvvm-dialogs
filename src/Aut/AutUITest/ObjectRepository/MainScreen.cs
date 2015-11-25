using AutUITest.ObjectRepository.ModalDialog;
using CUITe.ObjectRepository;

namespace AutUITest.ObjectRepository
{
    public class MainScreen : Screen
    {
        public ModalDialogComponent ModalDialog
        {
            get { return GetComponent<ModalDialogComponent>(); }
        }
    }
}