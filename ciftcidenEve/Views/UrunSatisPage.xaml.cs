using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrunSatisPage : ContentPage
    {
        public Product Product { get; set; }
       
        public UrunSatisPage()
        {
            InitializeComponent();
            BindingContext = new AddNewProductViewModel();
        }
    }
}