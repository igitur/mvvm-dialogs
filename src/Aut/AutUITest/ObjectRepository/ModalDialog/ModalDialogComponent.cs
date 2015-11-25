using System.Linq;
using CUITe.Controls.WpfControls;
using CUITe.ObjectRepository;
using CUITe.SearchConfigurations;

namespace AutUITest.ObjectRepository.ModalDialog
{
    public class ModalDialogComponent : ScreenComponent<WpfTabPage>
    {
        public ModalDialogComponent()
            : base(By.AutomationId("Modal Dialog"))
        {
        }

        public string[] Texts
        {
            get
            {
                return Find<WpfList>(By.AutomationId("Vfkrmkr640yWmoMTKUWIbQ"))
                    .Items
                    .Select(item => item.DisplayText)
                    .ToArray();
            }
        }

        public AddTextScreen ClickAddTextUsingDialogTypeLocator()
        {
            Find<WpfButton>(By.AutomationId("FHE_oyWqBEq_9TPaU1yPTQ")).Click();
            return NavigateTo<AddTextScreen>();
        }

        public AddTextScreen ClickAddTextBySpecifyingDialogType()
        {
            Find<WpfButton>(By.AutomationId("Dq9ZjnVdFESxu8StkQ8jMw")).Click();
            return NavigateTo<AddTextScreen>();
        }
    }
}