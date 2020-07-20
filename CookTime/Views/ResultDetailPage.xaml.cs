using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CookTime.Models;
using CookTime.ViewModels;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ResultDetailPage : ContentPage
    {
        ResultDetail viewModel;

        public ResultDetailPage(ResultDetail viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ResultDetailPage()
        {
            InitializeComponent();

            var item = new ItemBuscado
            {
                nombre = "Item 1",
                Desc = "This is an item description."
            };

            viewModel = new ResultDetail(item);
            BindingContext = viewModel;
        }
    }
}