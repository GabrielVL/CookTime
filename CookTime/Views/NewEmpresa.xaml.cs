using CookTime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using System.Net;
using System.Text;
using System.Net.Http;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEmpresa : ContentPage
    {
        public Company Company { get; set; }
        public NewEmpresa()
        {
            InitializeComponent();
            Company = new Company
            {
                nombre = "nombre de la compañia",
                horario = "Horario",
                contacto = "Medio para consultar",


            };

            BindingContext = this;
        }

        async void enviarFormulario(object e, EventArgs a)
        {

            JsonObject Compañia = new JsonObject();
            Compañia.Add("nombre", Nombre.Text);
            Compañia.Add("horario", Horario.Text);
            Compañia.Add("contacto", Contacto.Text);
            registration(Compañia);
            await Navigation.PopModalAsync();
        }

        public async void registration(JsonObject myJson)
        {
            HttpClient client = new HttpClient();

            MyIp myIps = new MyIp();

            var response = await client.PostAsync("http://" + myIps.returnIP() + "/CookTime_war_exploded/companies", new StringContent(myJson.ToString(), Encoding.UTF8, "application/json"));

        }


    }
}