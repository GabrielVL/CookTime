using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Json;
using System.Net;
using System.Linq.Expressions;
using CookTime.ViewModels;
using CookTime.Models;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        public IList<ItemBuscado> Resultado { get; private set; }
        JsonArray pubCont = new JsonArray();
        JsonArray pubCont2 = new JsonArray();
        public Search()
        {
            InitializeComponent();
            Resultado = new List<ItemBuscado>();
        }
        async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as ItemBuscado;
            await Navigation.PushAsync(new ItemBuscadoViewDetail(mydetails.nombre, mydetails.Desc, mydetails.Foto));
        }
        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() +"/CookTime_war_exploded/users?Nombre="+Nombre.Text;
            String url2 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?Nombre=" +Nombre.Text;

            WebClient nombre = new WebClient();
            pubCont = (JsonArray)JsonArray.Parse(nombre.DownloadString(url));
            pubCont2 = (JsonArray)JsonArray.Parse(nombre.DownloadString(url2));
            Console.WriteLine(pubCont.ToString());
            Console.WriteLine(pubCont2.ToString());
        }
        async void Busqueda(object sender, EventArgs e)
        {
            Peticion();
                for (int i = 0; i < 5; i++)
                {
                try
                {
                    Resultado.Add(new ItemBuscado { Desc = pubCont[i]["apellido1"].ToString(), nombre = pubCont[i]["nombre"].ToString(), Foto = pubCont[i]["perfil"]["Foto"] });
                }
                catch { }
                }
                for (int i=0; i<5; i++)
                {
                    try
                    {
                        Resultado.Add(new ItemBuscado { Desc = pubCont2[i]["autor"].ToString(), nombre = pubCont2[i]["nombre"].ToString(), Foto = pubCont2[i]["foto"] });
                    }
                    catch { }
                }


            BindingContext = this;
        }
    }
}