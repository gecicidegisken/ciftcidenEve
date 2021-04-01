
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace ciftcidenEve.ViewModels
{
  public  class SignUpViewModel : BaseViewModel
    {
        public ICommand TapCommand;
        public SignUpViewModel()
        {
            Title = "Uye ol";
            TapCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
          

        }
  
    }
}
