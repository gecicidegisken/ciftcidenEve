using ciftcidenEve.Models;
using System;
using Xamarin.Forms;

namespace ciftcidenEve.ViewModels
{
  public class AddNewProductViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public float Price { get; set; }
        public Image Image { get; set; }


        public AddNewProductViewModel()
        {
            
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            //this.PropertyChanged +=
            //    (_, __) => SaveCommand.ChangeCanExecute();
        }


        //private bool ValidateSave()
        //{ //isim ve açıklama boş bırakılamaz
        //  //diğer alanların da boş bırakılmamasını garantiye al
        //    return !String.IsNullOrWhiteSpace(Text)
        //        && !String.IsNullOrWhiteSpace(Description);
               
        //}

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//HomePage");
        }

        private async void OnSave()
        {
            Product newItem = new Product()
            {
                //Id = Convert.ToInt32(Guid.NewGuid()),
                Text = this.Text,
                Description = this.Description,
                Price = this.Price,
                Tag = this.Tag
            };

            await DataStore.AddItemAsync(newItem);
            await Shell.Current.GoToAsync("//HomePage");
        }


       

    }
}
