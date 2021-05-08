using ciftcidenEve.Models;
using ciftcidenEve.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ciftcidenEve
{
    public partial class App : Application
    {
        public static Boolean authorization = false;
        public static List<Product> products = new List<Product>();
        public static ProductService mDatabase = new ProductService();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
