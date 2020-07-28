using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Json;
using System.Net;
using CookTime.Services;
using CookTime.Models;
namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemBuscadoViewDetail : ContentPage
    {
        private JsonArray MyMenuI = new JsonArray();
        private JsonArray readyrecipe = new JsonArray();
        private JsonObject Usuario = new JsonObject();

        public IList<Item> recetasPerfil { get; private set; }
        private string Id2;
        private JsonObject perfilUsuario;
        private JsonArray MyMenuUsuario;
        public ItemBuscadoViewDetail(string Name, string Apellido, string source, string Apellido2, string Correo, string Edad, string Chef, string Id)
        {
            InitializeComponent();
            checkChef(Chef, Name, Apellido, Apellido2);
            recetasPerfil = new List<Item>();
            

            Id2 = Id;
            Console.WriteLine("PRUEBA" + Id2);
            correo.Text = Correo;
            edad.Text = "Edad:  " + Edad;  

            CargarMyMenu();
            Foto.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
        public ItemBuscadoViewDetail(string Name, string Horario, string source, string Puntuacion, string Contacto, JsonArray MyMenu)
        {
            InitializeComponent();

            ItemName.Text = Name;
            
            correo.Text = Horario;
            edad.Text = Contacto;


            Foto.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }

        public async void Peticion()
        {
            WebClient nombre = new WebClient();
            MyIp myIps = new MyIp();

            string url2 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?ID="+Id2;

            Usuario = (JsonObject)JsonObject.Parse(nombre.DownloadString(url2));

            perfilUsuario = (JsonObject)Usuario["perfil"];
            MyMenuUsuario = (JsonArray)perfilUsuario["MyMenu"];

            foreach (string i in MyMenuUsuario)
            {
                String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?ID=" + int.Parse(i.ToString());
                readyrecipe.Add((JsonObject)JsonObject.Parse(nombre.DownloadString(url)));

            }

        }
        async void CargarMyMenu()
        {
            Peticion();

            for (int i = 0; i < readyrecipe.Count; i++)
            {
                recetasPerfil.Add(new Item { Description = readyrecipe[i]["tipo"], Text = readyrecipe[i]["nombre"], foto = readyrecipe[i]["foto"], autor = readyrecipe[i]["autor"], tiempo = readyrecipe[i]["tiempo"], instrucciones = readyrecipe[i]["instrucciones"], precio = readyrecipe[i]["precio"], porciones = readyrecipe[i]["porciones"], dificultad = readyrecipe[i]["dificultad"], dieta = readyrecipe[i]["dieta"], likes = readyrecipe[i]["likes"], dislikes = readyrecipe[i]["dislikes"], Id = readyrecipe[i]["id"] });
            }

            BindingContext = this;

        }

        async void OnItemSelected(object sender, ItemTappedEventArgs e)

        {

            var mydetails = e.Item as Item;

            await Navigation.PushAsync(new ItemDetailPage(mydetails.Text, mydetails.Description, mydetails.foto, mydetails.autor, mydetails.tiempo, mydetails.instrucciones, mydetails.precio, mydetails.porciones, mydetails.dificultad, mydetails.dieta, mydetails.likes, mydetails.dislikes, mydetails.Id));
        }


        async void SeguirUsuario(object sender, EventArgs e)
        {
           
                MyIp myIps = new MyIp();
                String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?Target=Following&Value="+Id2+"&Id="+config.getMyId().ToString();
                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.GetResponse();


                //TargetIdiom = following DATA = id ID config.getid 
            
        }




        /**  Verifica si el usuario es chef, sí lo es visualiza un label con la palabre chef, si no lo es no la muestra
    *  @Params: chef string, name string, apellido string, apellido2 string
    *  @Author: Andrés Quiros
    *  @Returns nothing
    **/
        public void checkChef(string chef, string name, string apellido, string apellido2)
        {
            Console.WriteLine("MEDIDOR" + chef + name + apellido);
            if (chef.Equals("2"))
            {
                chef1.Text = "CHEF:";
                ItemName.Text = name + "   " + apellido + "   " + apellido2;
                chef1.BackgroundColor = Color.FromHex("FFD700");
            }
            else
            {
                chef1.Text = "";
                ItemName.Text = name + "   " + apellido + "   " + apellido2;
            }

        }
    }
}