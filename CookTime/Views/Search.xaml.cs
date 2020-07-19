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
        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() +"/CookTime_war_exploded/users?nombre="+Nombre.Text;
            String url2 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?nombre=" + Nombre.Text;

            WebClient nombre = new WebClient();
            pubCont = (JsonArray)JsonArray.Parse(nombre.DownloadString(url));
            pubCont2 = (JsonArray)JsonArray.Parse(nombre.DownloadString(url2));
        }
        async void Busqueda(object sender, EventArgs e)
        {
            Peticion();
                for (int i = 0; i < 5; i++)
                {
                        Resultado.Add(new ItemBuscado { Desc = pubCont[i]["apellido1"].ToString(), nombre = pubCont[i]["nombre"].ToString(), Foto = pubCont[i]["perfil"]["Foto"]});
                }
                for (int i=0; i<5; i++)
                {
                Resultado.Add(new ItemBuscado { Desc = pubCont2[i]["autor"].ToString(), nombre = pubCont2[i]["nombre"].ToString(), Foto = pubCont2[i]["foto"]});
                }


            BindingContext = this;
        }
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ItemBuscado selectedItem = e.SelectedItem as ItemBuscado;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            ItemBuscado tappedItem = e.Item as ItemBuscado;
        }
    }
}