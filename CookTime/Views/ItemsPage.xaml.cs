using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CookTime.Models;
using CookTime.Views;
using CookTime.ViewModels;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item), item.comentarios));
        }
        /** Abre nueva ventana para añadir nueva receta
*  @Params: object sender, EventArgs e
*  @Author:Yordan Rojas
*  @Returns nothing
**/
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }


        /** Abre nueva ventana para registrar nuevo usuario
*  @Params: object sender, EventArgs e
*  @Author:Andrés Quirós
*  @Returns nothing
**/
        async void AddUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Registrar()));
        }

        /** Abre nueva ventana para buscar usuarios y recetas
*  @Params: object sender, EventArgs e
*  @Author:Yordan Rojas
*  @Returns nothing
**/
        async void Buscar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Search()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}