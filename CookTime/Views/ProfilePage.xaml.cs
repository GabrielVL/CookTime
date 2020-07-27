﻿using System;
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
            foreach (string i in MyMenuI)
            {
                String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?ID="+ int.Parse(i);
                readyrecipe.Add((JsonObject)JsonObject.Parse(nombre.DownloadString(url)));
            }
            

        }
        async void CargarMyMenu()
        {
            Peticion();

            for (int i = 0; i < readyrecipe.Count; i++)
            {
                recetas.Add(new Item { Description = readyrecipe[i]["tipo"], Text = readyrecipe[i]["nombre"], foto = readyrecipe[i]["foto"], autor = readyrecipe[i]["autor"], tiempo = readyrecipe[i]["tiempo"], instrucciones = readyrecipe[i]["instrucciones"], precio = readyrecipe[i]["precio"], porciones = readyrecipe[i]["porciones"], dificultad = readyrecipe[i]["dificultad"], dieta = readyrecipe[i]["dieta"], likes = readyrecipe[i]["likes"], dislikes = readyrecipe[i]["dislikes"] });
            }
            BindingContext = this;
        }

        async void About_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
            await Navigation.PushModalAsync(new NavigationPage(new ItemsPage()));
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
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=chef";
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
        async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as Item;
            await Navigation.PushAsync(new ItemDetailPage(mydetails.Text, mydetails.Description, mydetails.foto, mydetails.autor, mydetails.tiempo, mydetails.instrucciones, mydetails.precio, mydetails.porciones, mydetails.dificultad, mydetails.dieta, mydetails.likes, mydetails.dislikes));
        }

    }
}