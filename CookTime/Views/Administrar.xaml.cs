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
    public partial class Administrar : ContentPage
    {
        public Administrar()
        {
            InitializeComponent();
        }
        async void ChangeName(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangeName()));
        }
        async void ChangePass(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangePass()));
        }
        async void ChangeImage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangeImage()));
        }
        async void NewEmpresa(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewEmpresa()));
        }
    }
}