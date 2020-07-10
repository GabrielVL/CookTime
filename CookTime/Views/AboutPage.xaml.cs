using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net;
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
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("ID", "1");
            webClient.QueryString.Add("DATA", "correo");

            string result = webClient.DownloadString("http://192.168.100.2:8080/CookTime_Web_exploded/users");
            ChangedLabel.Text = result;
        }
    }
    }


