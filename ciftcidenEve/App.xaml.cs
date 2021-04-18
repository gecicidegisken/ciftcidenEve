using ciftcidenEve.Services;
using ciftcidenEve.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve
{
    public partial class App : Application
    {
        public static Boolean authorization = false;
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
