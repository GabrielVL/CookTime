﻿using System;
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
        public IList<ItemBuscado> Resultadousuarios { get; private set; }
        public IList<ItemBuscado> Resultadorecetas { get; private set; }
        JsonArray pubCont = new JsonArray();
        JsonArray pubCont2 = new JsonArray();
        public Search()
        {
            InitializeComponent();
            Resultadousuarios = new List<ItemBuscado>();
            Resultadorecetas = new List<ItemBuscado>();
        }
        async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as ItemBuscado;
            await Navigation.PushAsync(new ItemDetailPage(mydetails.nombre, mydetails.Desc, mydetails.Foto, mydetails.tipo, mydetails.tiempo, mydetails.instrucciones, mydetails.precio, mydetails.porciones, mydetails.dificultad, mydetails.dieta, mydetails.likes, mydetails.dislikes));
        }
        async void OnItemSelected2(object sender, ItemTappedEventArgs e)
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
        }
        async void Busqueda(object sender, EventArgs e)
        {
            Peticion();
                for (int i = 0; i < 5; i++)
                {
                try
                {
                    Resultadousuarios.Add(new ItemBuscado 
                    { 
                        Desc = pubCont[i]["apellido1"].ToString(), 
                        nombre = pubCont[i]["nombre"].ToString(), 
                        Foto = pubCont[i]["perfil"]["Foto"] 
                    });

                    Resultadorecetas.Add(new ItemBuscado
                    {
                        Desc = pubCont2[i]["autor"].ToString(),
                        nombre = pubCont2[i]["nombre"].ToString(),

                        Foto = pubCont2[i]["foto"],
                        dieta = pubCont2[i]["dieta"],
                        dificultad = pubCont2[i]["dificultad"],
                        dislikes = pubCont2[i]["dislikes"],

                        instrucciones = pubCont2[i]["instrucciones"],
                        likes = pubCont2[i]["likes"],
                        porciones = pubCont2[i]["porciones"],
                        precio = pubCont2[i]["precio"],

                        tiempo = pubCont2[i]["tiempo"],
                        tipo = pubCont2[i]["tipo"]
                    });
                }
                catch { }
                }


            BindingContext = this;
        }
    }
}