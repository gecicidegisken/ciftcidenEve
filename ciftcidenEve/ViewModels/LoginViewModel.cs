using ciftcidenEve.Views;
using Xamarin.Forms;


namespace ciftcidenEve.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command LoginCommandGuess { get; }
        public Command SignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(OnSignUpClicked);
            LoginCommandGuess = new Command(OnLoginGuessClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            //Kullanıcı girişi kontrolü
            App.authorization = true;
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
           
        } 
        private async void OnSignUpClicked(object obj)
        {
             
            
             // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
             await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
        private async void OnLoginGuessClicked(object obj)
        {
            //Misafir girişi kontrolü
            App.authorization = false;
            
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

    }
}
