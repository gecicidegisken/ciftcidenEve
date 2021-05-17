using ciftcidenEve.Models;
using ciftcidenEve.Services;
using Xamarin.Forms;
using System.Windows.Input;
using Plugin.Toast;
using Xamarin.Essentials;
using System;


namespace ciftcidenEve.ViewModels
{
  public  class SignUpViewModel : BaseViewModel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string PasswordCheck { get; set; }


        public ICommand TapCommand => new Command(OnSignUpClicked);
        //public ICommand LoginCommand;
        public ICommand LoginCommand => new Command(OnLoginClicked);
        public SignUpViewModel()
        {
            Title = "Uye ol";
            //TapCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
            //LoginCommand = new Command(OnLoginClicked);
           



        }


        private async void OnSignUpClicked()
        {
            Person newMember = new Person()
            {
                Name = this.Name,
                Email = this.Email,
                City = this.City,
                Password =this.Password,             
            };

            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(City) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(PasswordCheck))

            {
                CrossToastPopUp.Current.ShowCustomToast("Bütün boş alanlar doldurulmalıdır.", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);

            }
            else if (App.memberDatabase.IsEmailUsed(this.Email))
            {
                CrossToastPopUp.Current.ShowCustomToast("Bu email adresiyle üye kayıtlı.", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
            }
            else if (Password != PasswordCheck)
            {
                CrossToastPopUp.Current.ShowCustomToast("Parolalar uyuşmuyor", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
            }
            

            else
            {
                //Add new member to our local SQLite database.
                App.memberDatabase.Add(newMember);
                FilterService.Sellers.Add(newMember.Name);
                CrossToastPopUp.Current.ShowCustomToast("Üyelik işlemi tamamlandı.\nGiriş yapabilirsiniz.", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
                await Shell.Current.GoToAsync("//LoginPage");
            }

           
        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}
