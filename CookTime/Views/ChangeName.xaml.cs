using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using CookTime.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeName : ContentPage
    {
        public ChangeName()
        {
            InitializeComponent();
        }
    async void cambiar(object sender, EventArgs e)
    {
            //hacer la llamada a /Users 
            //mandar mi ID
            //especificar qué quiero cambiar Target
            //especificar con qué lo quiero cambiar
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=nombre &Value="+Nombre.Text;
            String url2 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=apellido1 &Value="+Apellido1.Text;
            String url3 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=apellido2 &Value="+Apellido2.Text;
            WebRequest request = WebRequest.Create(url);
            WebRequest request2 = WebRequest.Create(url2);
            WebRequest request3 = WebRequest.Create(url3);

            request.Method = "PUT";
            request2.Method = "PUT";
            request3.Method = "PUT";

            request.GetResponse();
            request2.GetResponse();
            request3.GetResponse();


            DisplayAlert("Información válida", "El cambio se ha realizado con éxito", "OK");

            await Navigation.PopModalAsync();
        }


    }

}