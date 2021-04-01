using ciftcidenEve.Views;
using Xamarin.Forms;


namespace ciftcidenEve.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(OnSignUpClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        } 
        private async void OnSignUpClicked(object obj)
        {
            
             // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
             await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
    }
}
