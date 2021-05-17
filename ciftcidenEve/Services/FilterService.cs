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
        public  List<string> Prices = new List<string>();


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

            
        }


    }
}
