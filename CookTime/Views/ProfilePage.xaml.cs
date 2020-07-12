using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;

namespace CookTime.Views
{
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage()
        {
            InitializeComponent();

        }
        async void MyMenu(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyMenu()));
        }

        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
        }
    }
}