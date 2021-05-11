using System;
using System.Collections.Generic;
using System.Diagnostics;
using ciftcidenEve.Models;

namespace ciftcidenEve.Services
{
    public class CategoryService
    {
        public List<string> Categories = new List<string>();
        public List<string> SubCategories = new List<string>();

        public CategoryService()
        {
      
            Categories.Add("Sebze");
            Categories.Add("Meyve");
            Categories.Add("Kahvaltılık");
            Categories.Add("Sağlıklı İçecek");
            Categories.Add("Çiçek, Fidan, Tohum");


        }

        public void ShowSubCategory(string mainCat)
        {
            SubCategories.Clear();

            if (mainCat == "Sebze")
            {
                SubCategories.Add("Biber");
                SubCategories.Add("Domates");
                SubCategories.Add("Domates");
                SubCategories.Add("Havuç");
                SubCategories.Add("Patlıcan");
                SubCategories.Add("Salatalık");

            }
            else if (mainCat == "Meyve")
            {
                SubCategories.Add("Avokado");
                SubCategories.Add("Çilek");
                SubCategories.Add("Elma");
                SubCategories.Add("Mandalina");
                SubCategories.Add("Üzüm");
            }
            else if (mainCat == "Kahvaltılık")
            {
                SubCategories.Add("Bal");
                SubCategories.Add("Reçel");
                SubCategories.Add("Peynir");
                SubCategories.Add("Yumurta");
                SubCategories.Add("Zeytin");
            }
            else if (mainCat == "Sağlıklı İçecek")
            {
                SubCategories.Add("Cay");
                SubCategories.Add("Kahve");
                SubCategories.Add("Meyve Suyu");
                SubCategories.Add("Şalgam Suyu");
                SubCategories.Add("Süt");
            }
            else if (mainCat == "Tohum, Fidan, Çiçek")
            {
                SubCategories.Add("Gübre");
                SubCategories.Add("Meyve Fidanı");
                SubCategories.Add("Meyve Tohumu");
                SubCategories.Add("Sebze Tohumu");
                SubCategories.Add("Sebze Fidanı");
            }
            else
            {
                Debug.WriteLine("else içinde");
            }
        }
    }
}

