using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using System.Net;
using CookTime.Services;
using CookTime.Models;

namespace CookTime.Views
{
    public partial class ProfilePage : ContentPage
    {
        JsonArray MyMenuI = new JsonArray();
        JsonArray readyrecipe = new JsonArray();
        public IList<Item> recetas { get; private set; }
        public ProfilePage()
        {
            InitializeComponent();
            UserInfo();

            recetas = new List<Item>();         
            CargarMyMenu();
            
        }
        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            
            WebClient nombre = new WebClient();

            MyMenuI = (JsonArray)config.getPerfilOficial()["MyMenu"];
            foreach (object i in MyMenuI)
            {
                String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?ID="+i.ToString();
                readyrecipe.Add((JsonObject)JsonObject.Parse(nombre.DownloadString(url)));
            }
            

        }
        async void CargarMyMenu()
        {
            Peticion();

            for (int i = 0; i < readyrecipe.Count; i++)
            {
                recetas.Add(new Item { Description = readyrecipe[i]["tipo"].ToString(), Text = readyrecipe[i]["nombre"].ToString(), foto = readyrecipe[i]["foto"] });
            }
            BindingContext = this;
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
            int x = config.getPerfil()["nombre"];
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=nombre";
            WebRequest request = WebRequest.Create(url);
            request.Method = "PUT";
            request.GetResponse();
        
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