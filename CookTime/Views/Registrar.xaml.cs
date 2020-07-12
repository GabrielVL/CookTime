using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using System.Net;
using System.Text;
using CookTime.Models;
using System.Net.Http;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Registrar : ContentPage
    {
        public User User { get; set; }

        public Registrar()
        {
            
            InitializeComponent();
            User = new User
            {
                nombre = "Nombre del usuario",
                apellido1 = "Primer apellido",
                apellido2 = "Segundo apellido",
                correo = "Corrreo Electrónico",
                edad = "Edad",
                contrasena = "Contraseña",
                perfil = "Perfil del usuario",
                
                
            };

            BindingContext = this;
        }
        
        async void enviarFormulario(object e, EventArgs a)
        {
            
            JsonObject Usuario = new JsonObject ();
            Usuario.Add("nombre", Nombre.Text);
            Usuario.Add("apellido1",PrimerApellido.Text);
            Usuario.Add("apellido2", SegundoApellido.Text);
            Usuario.Add("edad", Edad.Text);
            Usuario.Add("contrasena",Contrasena.Text);
            Usuario.Add("correo",Correo.Text);
            prueba.Text = Nombre.Text + PrimerApellido.Text;
            registration(Usuario);
        }


        async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void registration(JsonObject myJson)
        {
            HttpClient client = new HttpClient();

            MyIp myIps = new MyIp();

            var response = await client.PostAsync("http://"+myIps.returnIP()+":8080/CookTime_Web_exploded/users", new StringContent(myJson.ToString(), Encoding.UTF8, "application/json"));
            
        } 


    }
}