using System.ComponentModel;
using Xamarin.Forms;
using XFChips.ViewModels;

namespace XFChips
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            //if (Device.RuntimePlatform == Device.Android)
            //    this.BackgroundImageSource = ImageSource.FromFile("the_last_of_us_background.jpg");
        }
    }
}
