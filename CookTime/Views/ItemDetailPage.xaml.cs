using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Json;
using CookTime.Models;
using CookTime.ViewModels;
using System.Threading.Tasks;
using CookTime.Services;
using System.Collections.Generic;
using System.Linq;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        string[] auxForList;
        public ItemDetailPage(ItemDetailViewModel viewModel, List<string> pepe)
        {
            InitializeComponent();



            auxForList= pepe.ToArray();            

            ListaEjemplo.ItemsSource = auxForList; 
                    
            BindingContext = this.viewModel = viewModel;            
        }
        public ItemDetailPage(string nombre, string desc, 
            string foto, string tipo, string tiempo, string instrucciones, 
            string precio, string porciones, string dificultad, string dieta, 
            string likes, string dislikes)
        {
            InitializeComponent();
            Item pedrito = new Item();
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

        async void Like(object sender, EventArgs e) {


        }

        async void Dislike(object sender, EventArgs e)
        {

        }

        async void Borrar(object sender, EventArgs e)
        {
            

        }
        async void Publicarcomentario(object sender, EventArgs e)
        {
            List<string> auxiliardepepe = new List<string>();
            foreach (string i in auxForList) {
                auxiliardepepe.Add(i);
            }
            auxiliardepepe.Add(NuevoComentario.Text);

            auxForList = auxiliardepepe.ToArray();
             ListaEjemplo.ItemsSource = auxForList;

        }


    }
}