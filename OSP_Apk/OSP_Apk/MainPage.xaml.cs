using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace OSP_Apk
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // called every 1 second
                // do stuff here
                time1.Text = DateTime.Now.ToString("t");
                return true; // return true to repeat counting, false to stop timer
            });

        }
        private void Button_Clicked(object sender, EventArgs e) //dodaj zgłoszenie
        {   
            recBtn2.BackgroundColor = Color.FromHex("FF6100");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn3.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn4.BackgroundColor = Color.FromHex("2E2E2D");
            App.Current.MainPage = new addNew();
        }

        private void Button_Clicked_1(object sender, EventArgs e) //homepage
        {
            recBtn1.BackgroundColor = Color.FromHex("FF6100");
            recBtn2.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn3.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn4.BackgroundColor = Color.FromHex("2E2E2D");
        }

        private void Button_Clicked_2(object sender, EventArgs e) //pending
        {
            recBtn3.BackgroundColor = Color.FromHex("FF6100");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn2.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn4.BackgroundColor = Color.FromHex("2E2E2D");
            App.Current.MainPage = new pending();
        }

        private void Button_Clicked_3(object sender, EventArgs e) //pracownicy
        {
            recBtn4.BackgroundColor = Color.FromHex("FF6100");
            recBtn2.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn3.BackgroundColor = Color.FromHex("2E2E2D");
            App.Current.MainPage = new workers();
        }
    }
}
