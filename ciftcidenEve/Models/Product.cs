﻿using SQLite;
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

        //public List<string> Categories = new List<string>();

        public Uri Path { get; set; }
        public Product()
        {

            Path = new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/590x300.jpg?alt=media&token=aaca9b5e-039e-43cc-9677-6b6424cec65a");
        }

        public Product(string text, string description, string satici, float price, string tag, string subTag, string city, Uri path)
        {
            Text = text;
            Description = description;
            Satici = satici;
            Price = price;
            Tag = tag;
            SubTag = subTag;
            City = city;
            Path = path;
        }
    }
}