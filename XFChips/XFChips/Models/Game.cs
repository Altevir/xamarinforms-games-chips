using XFChips.ViewModel;

namespace XFChips.Models
{
    public class Game : BaseViewModel
    {
        public int gameId { get; set; }
        public string name { get; set; }

        private string _colorBackground = "#FFFFFF";
        public string colorBackground
        {
            get { return _colorBackground; }
            set { SetProperty(ref _colorBackground, value); }
        }

        private string _colorText = "#000000";
        public string colorText
        {
            get { return _colorText; }
            set { SetProperty(ref _colorText, value); }
        }

        private bool _selected;
        public bool selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public string image { get; set; }
    }
}
