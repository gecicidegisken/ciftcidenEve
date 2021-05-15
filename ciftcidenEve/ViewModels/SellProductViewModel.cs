using ciftcidenEve.Models;
using Xamarin.Forms;
using Plugin.Toast;


namespace ciftcidenEve.ViewModels
{
    public class SellProductViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string SubTag { get; set; }

        public float Price { get; set; }
        public Image Image{get; set;}


        public SellProductViewModel()
        {
            
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
               (_, __) => SaveCommand.ChangeCanExecute();

           
        }
        private void darari()
        {
            
        }

        //private bool ValidateSave()
        //{ //isim ve açıklama boş bırakılamaz
        //  //diğer alanların da boş bırakılmamasını garantiye al
        //    return !String.IsNullOrWhiteSpace(Text)
        //        && !String.IsNullOrWhiteSpace(Description);

        //}

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }

        private async void OnSave()
        {
            Product newItem = new Product()
            {
                Text = this.Text,
                Description = this.Description,
                Price = this.Price,
                Tag = this.Tag,
                SubTag = this.SubTag,
                 Satici = App.currentUser.Name,
                City = App.currentUser.City,
              //  Image = this.Image
            };

            //Add item to our local SQLite database.
            App.mDatabase.Add(newItem);
            CrossToastPopUp.Current.ShowCustomToast("Ürün satışa çıkarıldı.", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
            await Shell.Current.GoToAsync("//HomePage");
          
        }
    }
}