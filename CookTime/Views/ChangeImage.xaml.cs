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
    public partial class ChangeImage : ContentPage
    {
        public ChangeImage()
        {
            InitializeComponent();
            preview();
           
        }


        /** Cambio de nombre
        *  @Params: object sender, EventArgs e
        *  @Author:Yordan Rojas
        *  @Returns nothing
        **/

        async void cambiar(object sender, EventArgs e)
        {
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Id=" + ((int)config.getPerfil()["id"]) + "&Target=Foto&Value=" + nuevaImagen.Text;
            WebRequest request = WebRequest.Create(url);
            request.Method = "PUT";
            request.GetResponse();

            DisplayAlert("Información válida", "El cambio se ha realizado con éxito", "OK");

            await Navigation.PopModalAsync();
        }
        
        public async void preview()
        {
        //Foto.Source = new UriImageSource { CachingEnabled = false, Uri = new Uri(nuevaImagen.Text) };
        }

    }
}