﻿using ciftcidenEve.Models;
using ciftcidenEve.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ciftcidenEve
{
    public partial class App : Application
    {
        public static Boolean authorization = false;
        public static Person currentUser;
        public static List<Product> products = new List<Product>();
        public static ProductService mDatabase = new ProductService();
        public static PersonService memberDatabase = new PersonService();
        public static CardService shoppingCard = new CardService();
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            mDatabase.AddDefaultProducts();
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
