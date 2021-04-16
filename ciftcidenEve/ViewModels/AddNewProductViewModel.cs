using ciftcidenEve.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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


        public AddNewProductViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private bool ValidateSave()
        { //isim ve açıklama boş bırakılamaz
          //diğer alanların da boş bırakılmamasını garantiye al
            return !String.IsNullOrWhiteSpace(Text)
                && !String.IsNullOrWhiteSpace(Description);
               
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
