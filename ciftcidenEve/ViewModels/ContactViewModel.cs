using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System;

namespace ciftcidenEve.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public Command EmailCommand { get; }
        public Command SocialMediaCommand { get; }

        public ContactViewModel()
        {
            Title = "Bize Ulaşın";
            EmailCommand = new Command(emailClicked);
            SocialMediaCommand = new Command(OnSocialMediaClicked);
        }

        public void emailClicked()
        {
          //  var address = "info@ciftcideneve.com";
          // Device.OpenUri(new Uri($"mailto:{address}"));
           
        }
        public async void OnSocialMediaClicked(object url)
        {
            await Browser.OpenAsync(url.ToString());
        }
    }
}
