using System;
using System.Collections.Generic;
using System.Text;
using ciftcidenEve.Models;

namespace ciftcidenEve.Services
{
  public class FilterService
    {
        public  List<string> Cities = new List<string>();
        public static List<string> Sellers = new List<string>();
        public  List<float> Prices = new List<float>();

        PersonService ps = new PersonService();


       public Dictionary<string, string> pricesdic = new Dictionary<string, string>
        {
            { "0-10 TL arası", "0" },
            { "10-20 TL arası", "10" },
            { "20-30 TL arası", "20" },
            { "30-40 TL arası", "30" },
            { "40-50 TL arası", "40" },
            { "50-60 TL arası", "50" },

        };


        public FilterService()
        {      

            Cities.Clear();
            Cities.Add("İstanbul");
            Cities.Add("Bursa");
            Cities.Add("Kocaeli");
            Cities.Add("Yalova");
            Cities.Add("Sakarya");
            Cities.Add("Tekirdağ");
            Cities.Add("Adana");

            Prices.Add(0);
            Prices.Add(10);
            Prices.Add(20);
            Prices.Add(30);
            Prices.Add(40);
            Prices.Add(50);
            
        }


        public List<string> GetSellers()
        {

           var members= ps.GetMembers();
            foreach (var item in members)
            {
                Sellers.Add(item.Name);
            }
            return Sellers;
        }

        //public List<string> GetPrices()
        //{ var prices = new List<string>();

        //    foreach (var item in this.Prices)
        //    {
        //        var x = item + 10;
        //        prices.Add(item + " - " + x +" TL arası");
        //    }
        //    return prices;
        //}


        public List<string> GetPrices()
        {

            var prices = new List<string>();
           


            foreach (var item in pricesdic.Keys)
            {
                prices.Add(item);
            }
            return prices;
        }

    }
}
