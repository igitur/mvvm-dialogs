using System.ComponentModel;

namespace Aut.Features.OpenFileDialog.ViewModels
{
    public class OpenFileTabItemViewModel : TabItemViewModel
    {
        private readonly OpenFileTabContentViewModel content;

        public OpenFileTabItemViewModel(OpenFileTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Open File"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }

        public override int Priority
        {
            get { return 4; }
        }
    }
}