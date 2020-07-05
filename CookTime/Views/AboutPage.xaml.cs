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
                var root = await client.Get<Profile>("https://my-json-server.typicode.com/typicode/demo/profile");
                if (root != null)
                {
                    ChangedLabel.Text = root.name;
                }
            });
        }

    }
}