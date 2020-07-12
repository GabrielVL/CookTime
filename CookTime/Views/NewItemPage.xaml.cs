﻿using System.Net;
using System.Text;
using CookTime.Models;
using System.Net.Http;
using System.ComponentModel;
using Xamarin.Forms;
using System;
using System.Json;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Receta { get; set; }

        public NewItemPage()
        {
            
            InitializeComponent();
            Receta = new Item
            {
                Id = "Id",
                Text = "Nombre",
                autor = "Autor",
                Description = "Tipo",
                tiempo = "Tiempo",
                instrucciones = "Instrucciones",
                precio = "Precio",
                porciones = "Porciones",
                dificultad = "Dificultad",
                foto = "Foto"
                
            };

            BindingContext = this;
        }
        
        async void enviarFormulario(object e, EventArgs a)
        {
            
            JsonObject Receta = new JsonObject ();
            Receta.Add("id", Id.Text);
            Receta.Add("nombre",Nombre.Text);
            Receta.Add("autor", Autor.Text);
            Receta.Add("tipo", Tipo.Text);
            Receta.Add("tiempo",Tiempo.Text);
            Receta.Add("dieta",Dieta.Text);
            Receta.Add("instrucciones",Instrucciones.Text);
            Receta.Add("precio", Precio.Text);
            Receta.Add("porciones", Porciones.Text);
            Receta.Add("dificultad", Dificultad.Text);
            Receta.Add("foto", Foto.Text);
            registration(Receta);
        }


        async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void registration(JsonObject myJson)
        {
            HttpClient client = new HttpClient();

            MyIp myIps = new MyIp();

            var response = await client.PostAsync("http://"+myIps.returnIP()+":8080/CookTime_Web_exploded/recipes", new StringContent(myJson.ToString(), Encoding.UTF8, "application/json"));
            
        } 


    }
}