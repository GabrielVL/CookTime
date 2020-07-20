using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            UpdateMap();
        }
        private async void UpdateMap()
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(9.860192, -83.917166), Distance.FromKilometers(20)));
        } 
    }
}