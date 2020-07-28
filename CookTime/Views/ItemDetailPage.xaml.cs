using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Json;
using CookTime.Models;
using CookTime.ViewModels;
using System.Collections.Generic;
using System.Net;

namespace CookTime.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        string[] auxForList;
        int id1=0;
        int likes1=0;
        int dislikes1=0;
        int auxPuntuacion = 1;
        public ItemDetailPage(ItemDetailViewModel viewModel, List<string> pepe)
        {
            InitializeComponent();

            auxForList = pepe.ToArray();

            ListaEjemplo.ItemsSource = auxForList;
            id1= int.Parse(viewModel.Item.Id);
            likes1 = int.Parse(viewModel.Item.likes);
            dislikes1 = int.Parse(viewModel.Item.dislikes);
            BindingContext = this.viewModel = viewModel;

        }
        public ItemDetailPage(string nombre, string desc,
            string foto, string tipo, string tiempo, string instrucciones,
            string precio, string porciones, string dificultad, string dieta,
            string likes, string dislikes, string id)
        {
            id1 = int.Parse(id);
            likes1 = int.Parse(likes);
            dislikes1 = int.Parse(dislikes);
            Console.WriteLine("Simulacro" + id);
            InitializeComponent();
           
            Item pedrito = new Item();
            pedrito.Id = id;
            pedrito.Text = nombre;
            pedrito.autor = desc;
            pedrito.dieta = dieta;
            pedrito.foto = foto;
            pedrito.tiempo = tiempo;
            pedrito.instrucciones = instrucciones;
            pedrito.precio = precio;
            pedrito.porciones = porciones;
            pedrito.dificultad = dificultad;
            pedrito.likes = likes;
            pedrito.dislikes = dislikes;

            JsonArray autorReceta = new JsonArray();
            MyIp myIps = new MyIp();
            WebClient x = new WebClient();

            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?ID=" + pedrito.autor;
            autorReceta.Add((JsonObject)JsonObject.Parse(x.DownloadString(url)));


            BindingContext = this.viewModel = new ItemDetailViewModel(pedrito);
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }



        /**  Llama al servlet Recipes y le pide un put a una receta en específico
         *  @Params: sender Object, e EventArgs
         *  @Author: Andrés Quiros
         *  @Returns nothing
         **/


        async void Like(object sender, EventArgs e)
        {
            
            try
            {
                if (auxPuntuacion == 1) {
                    MyIp myIps = new MyIp();
                    String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?Target=opinion&DATA=1&Id=" + id1;
                   
                    WebRequest request = WebRequest.Create(url);
                    request.Method = "PUT";
                    request.GetResponse();
                    likesLabel.Text = (likes1 + 1).ToString();
                    auxPuntuacion--;
                }
            }
            catch
            {

            }

            

        }
        /**  Llama al servlet Recipes y le pide un put a una receta en específico
            *  @Params: sender Object, e EventArgs
            *  @Author: Andrés Quiros
            *  @Returns nothing
            **/
        async void Dislike(object sender, EventArgs e)
        {
            try
            {
                if (auxPuntuacion == 1)
                {
                    dislikesLabel.Text = dislikes1.ToString();
                    MyIp myIps = new MyIp();
                    String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?Target=opinion&DATA=-1&Id=" + id1;
                    WebRequest request = WebRequest.Create(url);
                    request.Method = "PUT";
                    request.GetResponse();
                    dislikesLabel.Text = (dislikes1 + 1).ToString();
                    auxPuntuacion--;
                }
            }
            catch { }
        }
    /**  Llama al servlet Recipes y le pide un delete a una receta en específico
         *  @Params: sender Object, e EventArgs
         *  @Author: Andrés Quiros
         *  @Returns nothing
         **/
        async void Borrar(object sender, EventArgs e)
        {


        }

            /**  Llama al servlet Recipes y le pide un put a una receta en específico en sus comentarios
         *  @Params: sender Object, e EventArgs
         *  @Author: Andrés Quiros
         *  @Returns nothing
         **/
        async void Publicarcomentario(object sender, EventArgs e)
        {
            if (NuevoComentario.Text != null) {
                if (NuevoComentario.Text.Length != 0) {
                    Console.WriteLine("AAA" + NuevoComentario.Text + "BBB");
                    List<string> auxiliardepepe = new List<string>();

                    foreach (string i in auxForList)
                    {
                        auxiliardepepe.Add(i);
                    }
                    auxiliardepepe.Add(NuevoComentario.Text);

                    auxForList = auxiliardepepe.ToArray();
                    ListaEjemplo.ItemsSource = auxForList;
                }
                NuevoComentario.Text = "";
            }
        }
        } }