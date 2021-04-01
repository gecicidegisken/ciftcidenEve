using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ciftcidenEve.ViewModels
{
   public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
            Title = "Üye ol";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }
        public ICommand OpenWebCommand { get; }
    }
}
