using CUITe.Controls.WpfControls;
using CUITe.ObjectRepository;
using CUITe.SearchConfigurations;

namespace AutUITest.ObjectRepository.ModalDialog
{
    public class AddTextScreen : Screen
    {
        public string Text
        {
            set { Find<WpfEdit>(By.AutomationId("Csl8dP93gUGQLj7rVZxDAg")).Text = value; }
        }

        public void ClickOK()
        {
            Find<WpfButton>(By.AutomationId("eyRW_87u20qR7QTCypm2RQ")).Click();
        }

        public void ClickCancel()
        {
            Find<WpfButton>(By.AutomationId("I91auHr_EECzhSZyIfvvzQ")).Click();
        }
    }
}