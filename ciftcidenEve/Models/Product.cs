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
        public Image Image { get; set; }
        public float Price { get; set; }
        public string Tag { get; set; }  //ürün kategorisi (meyve sebze vs)
                                         //public Categories Category { get; set; }  //ürün kategorisi (meyve sebze vs)

        public List<string> Categories = new List<string>();
        
       public Product()
        {
            Categories.Add("Sos ve Sirke");
            Categories.Add("Yağ");
            Categories.Add("Kahvaltılık");
            Categories.Add("Sağlıklı İçecek");
            Categories.Add("Kişisel Bakım");
            Categories.Add("Tohum, Fidan, Çiçek");
            Categories.Add("Et ve Balık");
        }

    }
}