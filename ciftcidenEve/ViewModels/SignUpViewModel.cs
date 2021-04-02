
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace ciftcidenEve.ViewModels
{
  public  class SignUpViewModel : BaseViewModel
    {
        public ICommand TapCommand;
        //public ICommand LoginCommand;
        public ICommand LoginCommand => new Command(OnLoginClicked);
        public SignUpViewModel()
        {
            Title = "Uye ol";
            TapCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
            //LoginCommand = new Command(OnLoginClicked);



        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}
