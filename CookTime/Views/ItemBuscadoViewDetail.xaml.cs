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
        public ItemBuscadoViewDetail(string Name, string Desc, string source)
        {
            InitializeComponent();


            ItemName.Text = Name;
            Description.Text = Desc;
            Foto.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
    }
}