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
                nombre = "nombre del usuario",
                apellido1 = "Primer apellido",
                apellido2 = "Segundo apellido",
                correo = "Corrreo Electrónico",
                edad = "Edad",
                contrasena = "Contraseña",
                perfil = "Perfil del usuario",
                
                
            };

            BindingContext = this;
        }


        /** Envia solicitud para registro de usuarios
*  @Params: object sender, EventArgs e
*  @Author:Andrés Quirós
*  @Returns nothing
**/
        async void enviarFormulario(object e, EventArgs a)
        {
            
            JsonObject Usuario = new JsonObject ();
            Usuario.Add("nombre", Nombre.Text);
            Usuario.Add("Desc",PrimerApellido.Text);
            Usuario.Add("Foto", SegundoApellido.Text);
            Usuario.Add("edad", Edad.Text);
            Usuario.Add("contrasena",Contrasena.Text);
            Usuario.Add("correo",Correo.Text);
            
            
            registration(Usuario);
            await Navigation.PopModalAsync();
        }


        /** Cierra la ventana
*  @Params: object sender, EventArgs e
*  @Author:Yordan Rojas
*  @Returns nothing
**/

        async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /** Registra al usuario
*  @Params: myJson JsonObject
*  @Author:Yordan Rojas
*  @Returns nothing
**/
        public async void registration(JsonObject myJson)
        {
            HttpClient client = new HttpClient();

            MyIp myIps = new MyIp();

            var response = await client.PostAsync("http://"+myIps.returnIP()+"/CookTime_war_exploded/users", new StringContent(myJson.ToString(), Encoding.UTF8, "application/json"));
            
        } 


    }
}