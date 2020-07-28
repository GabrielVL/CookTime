    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using CookTime.Services;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {

        String id;
        JsonObject perfil;
        JsonObject usuario = new JsonObject();
        public LogIn()
        {
            InitializeComponent();
        }

        public  Boolean Comparar(String correo, String contrasena)
        {
            Boolean answer = true;

            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Verificar=1&Contrasena="+contrasena+"&Correo="+correo;
            //saber si calza la contraseña con el correo

            //recuperar JSON del mae
            //establecer ID
            

            WebClient nombre = new WebClient();

            String x = nombre.DownloadString(url);
            try
            {
                if (x.Equals("false"))
                {
                    DisplayAlert("Error al iniciar sesión", "El usuario no se encuentra en la base de datos", "Reintentar");

                    return false;
                }
                else
                {
                    usuario = (JsonObject)JsonObject.Parse(x);
                    id = usuario["id"];
                    config.setMyId(id);
                    config.setPerfil(usuario);
                    return true;
                }
            }
            catch (Exception e)
            {
                  DisplayAlert("Error al iniciar sesión", "No se ha podido completar la accion", "Reintentar");
                return false;
            }
        }
        async void MainPage(object sender, EventArgs e)
        {
            if (Comparar(Correo.Text.ToString(), Contraseña.Text.ToString()))
            {
                await Navigation.PushModalAsync(new NavigationPage(new MainPageI()));
                Profile perfil = new Profile();
                perfil.name(id);

            }
            else
            {
                await DisplayAlert("Error al iniciar sesión", "El usuario no se encuentra en la base de datos", "Reintentar");
            }
        }
        async void Registrar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Registrar()));

        }

 
    }
    
}
