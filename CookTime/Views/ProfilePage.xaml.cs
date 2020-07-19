using System;
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

        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
        }
        async void NewMap(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Page1()));
        }
        async void Administrar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Administrar()));
        }

        async void Chef(object sender, EventArgs e)
        {
            int x = config.getPerfil()["chef"];
            if (x != 2)
            {
                MyIp myIps = new MyIp();
                String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=chef";
                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.GetResponse();
            }

            else { chef.Text = "Ya eres Chef!"; }
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