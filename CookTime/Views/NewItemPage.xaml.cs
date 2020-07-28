using System.Net;
using System.Text;
using CookTime.Models;
using System.Net.Http;
using System.ComponentModel;
using Xamarin.Forms;
using System;
using System.Json;
using CookTime.Services;

namespace CookTime.Views
{
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Receta { get; set; }

        public NewItemPage()
        {
            
            InitializeComponent();
            Receta = new Item
            {
                Id = "Id",
                Text = "nombre",
                autor = "Autor",
                Description = "Tipo",
                tiempo = "Tiempo",
                instrucciones = "Instrucciones",
                precio = "Precio",
                porciones = "Porciones",
                dificultad = "Dificultad",
                foto = "Foto",
                likes = "Likes",
                dislikes = "Dislikes",

                
            };

            BindingContext = this;
        }
        
        async void enviarFormulario(object e, EventArgs a)
        {

            /** Añade los parametrós añadidos por el usuario en un JsonObject e invoca a la funciones registration() para añadir la nueva receta en el Json 
            *  @Params: sender Object, e EventArgs
            *  @Author: Yordan Rojas
            *  @Returns nothing
            **/
            
            JsonObject Receta = new JsonObject ();
            Receta.Add("nombre",Nombre.Text);
            Receta.Add("autor", config.getPerfil()["id"]);
            Receta.Add("tipo", Tipo.Text);
            Receta.Add("tiempo",Tiempo.Text);
            Receta.Add("dieta",Dieta.Text);
            Receta.Add("instrucciones",Instrucciones.Text);
            Receta.Add("precio", Precio.Text);
            Receta.Add("porciones", Porciones.Text);
            Receta.Add("dificultad", Dificultad.Text);
            Receta.Add("foto", Foto.Text);
            registration(Receta);

            MessagingCenter.Send(this, "AddItem", Receta);
            await Navigation.PopModalAsync();
        }


        /** Cierra la centana actual
*  @Params: object sender, EventArgs e
*  @Author:Yordan Rojas
*  @Returns nothing
**/

        async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


                /** Realiza la registración de la nueva receta
        *  @Params: object sender, EventArgs e
        *  @Author:Yordan Rojas
        *  @Returns nothing
        **/
        public async void registration(JsonObject myJson)
        {
            HttpClient client = new HttpClient();

            MyIp myIps = new MyIp();
            var response = await client.PostAsync("http://"+myIps.returnIP()+"/CookTime_war_exploded/recipes?Id="+config.getPerfil()["id"], new StringContent(myJson.ToString(), Encoding.UTF8, "application/json"));
            
        } 


    }
}       

