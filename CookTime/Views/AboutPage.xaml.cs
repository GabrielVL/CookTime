using System;
using System.ComponentModel;
using Xamarin.Forms;

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

        public void DisplayJSON(object sender, System.EventArgs e)
        {
            if (entry.Text == "users")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    RestClient client = new RestClient();
                    client.Peticion(ChangedLabel);
                });
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            RestClient client = new RestClient();
            client.Peticion(ChangedLabel);
        }
    }
}