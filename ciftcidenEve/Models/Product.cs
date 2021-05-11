using SQLite;
using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ciftcidenEve.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; } 
        public string Description { get; set; }
        public string Satici { get; set; }
        //public Image Image { get; set; }
        public float Price { get; set; }
        public string Tag { get; set; }  //ürün kategorisi (meyve sebze vs)
        public string SubTag { get; set; }  //ürün alt kategorisi (domates elma vs)
        public string City { get; set; }

        public List<string> Categories = new List<string>();
        public Command DeleteCommand { get; }
       public Product()
        {
           
            DeleteCommand = new Command(deleteThis);
        }
        private async void deleteThis(object obj)
        {
            int maxCount = App.products.Count;
            if (this.Id < maxCount)
            {
                for (int i = this.Id; i < maxCount; i++)
                {
                    App.products[i].Id -= 1;
                }
            }
            App.products.RemoveAt(this.Id-1);
           
        }

    }
}