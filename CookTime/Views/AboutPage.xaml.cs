using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread( async () =>
            {
                RestClient client = new RestClient();
                client.Peticion(ChangedLabel); 
                
                    
                
            });
        }
        public void Hola()
        {

                

        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            RestClient client = new RestClient();
            client.Peticion(ChangedLabel);
        }
    }
}