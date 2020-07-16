using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {

        readonly List<User> users;
        JsonArray pubCont = new JsonArray();
        public LogIn()
        {
            InitializeComponent();
        }
        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            String url = "http://"+myIps.returnIP()+"/CookTime_Web_exploded/users";


            WebClient nombre = new WebClient();
            pubCont = (JsonArray)JsonArray.Parse(nombre.DownloadString(url));
        }
        public Boolean Comparar(String nombre)
        {
            Boolean answer = true;
            for (int i = 0; i < pubCont.Count; i++)
            {
                answer = false;
                try
                {
                    //Result.Text = nombre;
                    if (nombre.Equals(pubCont[i]["nombre"]))
                    {
                        answer = true;
                        return answer;
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Error al iniciar sesión", "No se pudo completar la accion", "Reintentar");
                }
            }
            return answer;
        }
        async void MainPage(object sender, EventArgs e)
        {
            Peticion();
            if (Comparar(Correo.Text.ToString()))
            {
                await Navigation.PushModalAsync(new NavigationPage(new MainPageI()));
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


        async void Bypass(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPageI()));
        }



    }
    
}
