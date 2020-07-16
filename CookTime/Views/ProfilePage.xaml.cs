﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using System.Net;
using CookTime.Services;
namespace CookTime.Views
{
    public partial class ProfilePage : ContentPage
    {
        JsonArray pubCont = new JsonArray();
        public ProfilePage()
        {
            InitializeComponent();
            UserInfo();
            
            


        }
        async void MyMenu(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyMenu()));
        }
        async void Seguidores(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Seguidores()));
            
        }

        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
        }

        public void GetProfile(String id)
        {

        }

        public async void UserInfo()
        {
            username.Text = config.getPerfilOficial()["nombre"];

            Foto.Source = new UriImageSource { CachingEnabled = false, Uri = new Uri(config.getPerfilOficial()["Foto"]) };

            correo.Text = config.getPerfilOficial()["correo"];


        }
        
    }
    }