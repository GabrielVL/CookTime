using System;
using System.Collections.Generic;
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

        public void checkChef(string chef, string name, string apellido, string apellido2)
        {
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