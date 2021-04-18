using ciftcidenEve.Models;
using ciftcidenEve.Services;
using ciftcidenEve.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve
{
    public partial class App : Application
    {
        public static Boolean authorization = false;
        public static List<Product> products = new List<Product>();
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
