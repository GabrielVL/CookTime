using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CookTime.Services;
using CookTime.Views;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;

namespace CookTime
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LogIn();
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
