using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalNotifications : ContentPage
    {
        public LocalNotifications()
        {
            InitializeComponent();
            StartTimer();
        }

        private void Button_Clicked (object sender, EventArgs e)
        {
            Plugin.LocalNotifications.CrossLocalNotifications.Current.Show(txtTitleBadge.Text,txtTextBadge.Text,0,DateTime.Now.AddSeconds(double.Parse(txtTimeBadge.Text)));
        }

        public static void StartTimer()
        {

            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                // do something every 60 seconds

                Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("hola", "hola2", 0, DateTime.Now.AddSeconds(double.Parse("3")));
                Device.BeginInvokeOnMainThread(() =>
                {
                    // interact with UI elements
                });
                return true; // runs again, or false to stop
            });
        }

    }
}