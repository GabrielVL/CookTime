using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemBuscadoViewDetail : ContentPage
    {
        public ItemBuscadoViewDetail(string Name, string Apellido, string source, string Apellido2, string Correo, string Edad, string Chef)
        {
            InitializeComponent();
            checkChef(Chef, Name, Apellido, Apellido2);


            correo.Text = Correo;
            edad.Text = "Edad:  " + Edad;  


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