using ciftcidenEve.Views;
using Xamarin.Forms;
using Plugin.Toast;


namespace ciftcidenEve.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(OnSignUpClicked);
           
        }

        private async void OnLoginClicked(object obj)
        {
            if (App.memberDatabase.MemberLogin(Email,Password))
            {
                App.authorization = true;
               
                CrossToastPopUp.Current.ShowCustomToast("Giriş başarılı", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                CrossToastPopUp.Current.ShowCustomToast("Kullanıcı bulunamadı.\nEmail ve şifrenizi kontrol edin.", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);

            }

        } 
        private async void OnSignUpClicked(object obj)
        {
                     
             // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
             await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
    

    }
}
