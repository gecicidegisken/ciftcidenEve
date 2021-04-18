using SQLite;
using System;
using Xamarin.Forms;

namespace ciftcidenEve.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Satici { get; set; }
        public Image Image { get; set; }
        public float Price { get; set; }
        public string Tag { get; set; }  //ürün kategorisi (meyve sebze vs)
    }
}