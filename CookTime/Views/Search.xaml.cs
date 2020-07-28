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
        public IList<ItemBuscado> Resultadousuarios { get; private set; }
        public IList<ItemBuscado> Resultadorestaurantes { get; private set; }
        public IList<ItemBuscado> Resultadorecetas { get; private set; }
        JsonArray pubCont = new JsonArray();
        JsonArray pubCont2 = new JsonArray();
        JsonArray pubCont3 = new JsonArray();

        Boolean mostrarUsers = true;
        Boolean mostrarRecipes = true;
        Boolean mostrarCompanies = true;
        public Search()
        {
            InitializeComponent();
            Resultadousuarios = new List<ItemBuscado>();
            Resultadorecetas = new List<ItemBuscado>();
            Resultadorestaurantes = new List<ItemBuscado>();

            
        }
        async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as ItemBuscado;
            await Navigation.PushAsync(new ItemDetailPage(mydetails.nombre, mydetails.Desc, mydetails.Foto, mydetails.tipo, mydetails.tiempo, mydetails.instrucciones, mydetails.precio, mydetails.porciones, mydetails.dificultad, mydetails.dieta, mydetails.likes, mydetails.dislikes, mydetails.Id));
        }
        async void OnItemSelected2(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as ItemBuscado;
            await Navigation.PushAsync(new ItemBuscadoViewDetail(mydetails.nombre, mydetails.apellido, mydetails.Foto, mydetails.apellido2, mydetails.correo, mydetails.edad, mydetails.chef, mydetails.Id));
        }
        async void OnItemSelected3(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as ItemBuscado;
            await Navigation.PushAsync(new ItemBuscadoViewDetail(mydetails.nombre, mydetails.horario, mydetails.Foto, mydetails.puntuacion, mydetails.contacto, mydetails.MyMenu));
        }
        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            String url = "http://" + myIps.returnIP() +"/CookTime_war_exploded/users?Nombre="+Nombre.Text;
            String url2 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?Nombre=" +Nombre.Text;
            String url3 = "http://" + myIps.returnIP() + "/CookTime_war_exploded/companies?Nombre=" + Nombre.Text;
            WebClient nombre = new WebClient();
            if (mostrarUsers)
            {
                pubCont = (JsonArray)JsonArray.Parse(nombre.DownloadString(url));
            }
            if (mostrarRecipes) {
                pubCont2 = (JsonArray)JsonArray.Parse(nombre.DownloadString(url2));
            }
            pubCont3 = (JsonArray)JsonArray.Parse(nombre.DownloadString(url3));
        }
        async void Busqueda(object sender, EventArgs e)
        { 
            
            Peticion();
                for (int i = 0; i < 5; i++)
                {
                
                try
                {

                    //USUARIOS-----------------------------------------------------------------------------
                    if (mostrarUsers)
                        {
                                string condicionChefsiana="";
                            if(((String)pubCont[i]["chef"]).Equals("2"))
                                {
                                    condicionChefsiana=" * CHEF *";
                                }

                                Resultadousuarios.Add(new ItemBuscado
                                    {
                                        apellido = pubCont[i]["apellido1"],
                                        nombre = pubCont[i]["nombre"],
                                        Foto = pubCont[i]["perfil"]["Foto"],
                                        apellido2 = pubCont[i]["apellido2"],
                                        correo = pubCont[i]["perfil"]["correo"],
                                        edad = pubCont[i]["perfil"]["edad"],
                                        
                                        chef = pubCont[i]["chef"],
                                        chefLabel = condicionChefsiana
                                    });
                        }
                    else{
                        
                    }


                    if (mostrarRecipes)
                        {
                            Resultadorecetas.Add(new ItemBuscado
                                {
                                    Desc = pubCont2[i]["autor"],
                                    nombre = pubCont2[i]["nombre"],

                                    Foto = pubCont2[i]["foto"],
                                    dieta = pubCont2[i]["dieta"],
                                    dificultad = pubCont2[i]["dificultad"],


                                    instrucciones = pubCont2[i]["instrucciones"],
                                    likes = pubCont2[i]["likes"],
                                    dislikes = pubCont2[i]["dislikes"],
                                    porciones = pubCont2[i]["porciones"],
                                    precio = pubCont2[i]["precio"],

                                    tiempo = pubCont2[i]["tiempo"],
                                    tipo = pubCont2[i]["tipo"]
                                });
                        }
                    //COMPANIES-----------------------------------------------------------------------------
                    if (mostrarCompanies)
                    {
                        Resultadorestaurantes.Add(new ItemBuscado
                        {

                            horario = pubCont3[i]["horario"],
                            nombre = pubCont3[i]["nombre"],
                            Foto = pubCont3[i]["Foto"],
                            puntuacion = pubCont3[i]["puntuacion"],
                            MyMenu = (JsonArray)pubCont3[i]["MyMenu"],
                            contacto = pubCont3[i]["contacto"]



                        });
                    }
                   
                }
                catch { }
                }


            BindingContext = this;
        }
        async void NoMostrarUsers (object sender, CheckedChangedEventArgs e)
        {
            mostrarUsers = !mostrarUsers;

        }
        async void NoMostrarRecipes(object sender, CheckedChangedEventArgs e)
        {
            mostrarRecipes = !mostrarRecipes;

        }
        async void NoMostrarCompanies(object sender, CheckedChangedEventArgs e)
        {
            mostrarCompanies = !mostrarCompanies;

        }
    }
}