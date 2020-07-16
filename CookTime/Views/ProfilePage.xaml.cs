using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using System.Net;
namespace CookTime.Views
{
    public partial class ProfilePage : ContentPage
    {
        JsonArray pubCont = new JsonArray();
        public ProfilePage()
        {
            InitializeComponent();
            Peticion();
            //Nombre(String mecago);
            


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

        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() + "/CookTime_Web_exploded/users";


            WebClient nombre = new WebClient();
            pubCont = (JsonArray)JsonArray.Parse(nombre.DownloadString(url));
        }

        public async void Nombre (String id)
        {
            for (int i = 0; i < pubCont.Count; i++)
            {
                try
                {
                    //Result.Text = nombre;
                    if (id.Equals(pubCont[i]["id"]))
                    {
                        username.Text = pubCont[i]["nombre"];
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Error al iniciar sesión", "No se pudo completar la accion", "Reintentar");
                }
            }
        }

    }
    }