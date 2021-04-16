using ciftcidenEve.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ciftcidenEve.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public string Text { get; set; }
       public string Description { get; set; }
       public string Tag { get; set; }
       public float Price { get; set; }

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
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
            Product newItem = new Product()
            {
                Id = Convert.ToInt32(Guid.NewGuid()),
                Text = Text,
                Description = Description,
                Price = Price,
                Tag = Tag
            };

           // await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
