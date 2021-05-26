using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.UITest;
using NUnit.Framework;
using Xamarin.UITest.Queries;

namespace ciftcidenEve.Droid.Tests
{
    [TestFixture(Platform.Android)]
    class UITest
    {
        IApp app;
        Platform platform;

        public UITest(Platform platform)
        {
            this.platform = platform;
        }
        [SetUp]
        public void BefreEachTest()
        {
           
        }
    }
}