using ciftcidenEve.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ciftcidenEve.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        Product product = new Product();
        string Text { get; set; }
        string Tag { get; set; }
        float Price { get; set; }

        public ProductDetailViewModel(string text, string tag, float price)
        {
            product.Text = text;
            product.Tag = tag;
            product.Price = price;
 
        }

    }
}
