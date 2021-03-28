using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ciftcidenEve.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel()
        {
            Title = "Ana Sayfa";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}