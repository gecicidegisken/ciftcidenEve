using ciftcidenEve.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public string Tag="";
        public CategoryPage(string tag)
        {
            InitializeComponent();
            this.BindingContext = new CategoryViewModel(tag);
            this.Tag = tag;
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            return true;
        }
        async void mRefreshViewCategoryPage_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            mRefreshViewCategoryPage.IsRefreshing = false;

        }

        protected override void OnAppearing()
        {
            ShowSubCategories(Tag);
            mRefreshViewCategoryPage.IsRefreshing = true;
            base.OnAppearing();
            
        }

        protected void ShowSubCategories(string Tag)
        {
            Debug.WriteLine(this.Tag);
            
            if (Tag== "Sebze")
            {
                
                ImageButton1.Source = "sebze_biber_icon.png";
                ImageButton1.CommandParameter = "Biber";

                ImageButton2.Source = "sebze_domates_icon.png";
                ImageButton2.CommandParameter = "Domates";

                ImageButton3.Source = "sebze_havuc_icon.png";
                ImageButton3.CommandParameter = "Havuç";

                ImageButton4.Source = "sebze_patlican_icon.png";
                ImageButton4.CommandParameter = "Patlıcan";

                ImageButton5.Source = "sebze_salatalik_icon.png";
                ImageButton5.CommandParameter = "Salatalık";
            }
            else if (Tag == "Kahvaltılık")
            {
                ImageButton1.Source = "kahvaltilik_bal_icon.png";
                ImageButton1.CommandParameter = "Bal";

                ImageButton2.Source = "kahvaltilik_peynir_icon.png";
                ImageButton2.CommandParameter = "Peynir";

                ImageButton3.Source = "kahvaltilik_recel_icon.png";
                ImageButton3.CommandParameter = "Reçel";

                ImageButton4.Source = "kahvaltilik_yumurta_icon.png";
                ImageButton4.CommandParameter = "Yumurta";

                ImageButton5.Source = "kahvaltilik_zeytin_icon.png";
                ImageButton5.CommandParameter = "Zeytin";
            }
            else if (Tag == "Meyve")
            {
                ImageButton1.Source = "meyve_avokado_icon.png";
                ImageButton1.CommandParameter = "Avokado";

                ImageButton2.Source = "meyve_cilek_icon.png";
                ImageButton2.CommandParameter = "Çilek";

                ImageButton3.Source = "meyve_elma_icon.png";
                ImageButton3.CommandParameter = "Elma";

                ImageButton4.Source = "meyve_mandalina_icon.png";
                ImageButton4.CommandParameter = "Mandalina";

                ImageButton5.Source = "meyve_uzum_icon.png";
                ImageButton5.CommandParameter = "Üzüm";
            }
            else if (Tag == "Çiçek, Fidan, Tohum")
            {
                ImageButton1.Source = "tohum_meyveFidani_icon.png";
                ImageButton1.CommandParameter = "Meyve Fidanı";

                ImageButton2.Source = "tohum_meyveTohumu_icon.png";
                ImageButton2.CommandParameter = "Meyve Tohumu";

                ImageButton3.Source = "tohum_gubre_icon.png";
                ImageButton3.CommandParameter = "Gübre";

                ImageButton4.Source = "tohum_sebzeFidani_icon.png";
                ImageButton4.CommandParameter = "Sebze Fidanı";

                ImageButton5.Source = "tohum_sebzeTohumu_icon.png";
                ImageButton5.CommandParameter = "Sebze Tohumu";
            }
            else if (Tag == "Sağlıklı İçecek")
            {
                ImageButton1.Source = "icecek_cay_icon.png";
                ImageButton1.CommandParameter = "Çay";

                ImageButton2.Source = "icecek_kahve_icon.png";
                ImageButton2.CommandParameter = "Kahve";

                ImageButton3.Source = "icecek_meyveSuyu_icon.png";
                ImageButton3.CommandParameter = "Meyve Suyu";

                ImageButton4.Source = "icecek_salgam_icon.png";
                ImageButton4.CommandParameter = "Şalgam";

                ImageButton5.Source = "icecek_sut_icon.png";
                ImageButton5.CommandParameter = "Süt";
            }
        }
    }
}