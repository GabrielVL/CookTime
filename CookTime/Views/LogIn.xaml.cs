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
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
        }

        async void MainPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPageI()));
        }
        async void Registrar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Registrar()));
        }
    }
    
}
