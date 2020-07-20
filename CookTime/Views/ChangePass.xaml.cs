using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CookTime.Services;
namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePass : ContentPage
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        async void cambiar(object sender, EventArgs e) {
            if (Password.Text == Password2.Text)
            {
                MyIp myIps = new MyIp();
                String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=contrasena &Value=" + Password.Text;
                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.GetResponse();
                await Navigation.PopModalAsync();
                DisplayAlert("Información válida", "La información ingresada es válida", "OK");
                await Navigation.PopModalAsync();
            }

            else {
                DisplayAlert("Contraseñas ingresadas no coinciden", "Las contraseñas ingresadas no coinciden, volver a intentar para continuar", "Reintentar");
            }
        
        }

    }
}