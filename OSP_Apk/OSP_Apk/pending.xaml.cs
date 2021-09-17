using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OSP_Apk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pending : ContentPage
    {
        string query;
        public pending()
        {
            InitializeComponent();
            query = "SELECT * FROM `zgloszenie_pracownicy`";
            readData();
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
            App.Current.MainPage = new MainPage();
        }

        private void Button_Clicked_2(object sender, EventArgs e) //pending
        {
            recBtn3.BackgroundColor = Color.FromHex("FF6100");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn2.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn4.BackgroundColor = Color.FromHex("2E2E2D");
        }

        private void Button_Clicked_3(object sender, EventArgs e) //pracownicy
        {
            recBtn4.BackgroundColor = Color.FromHex("FF6100");
            recBtn2.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn3.BackgroundColor = Color.FromHex("2E2E2D");
            App.Current.MainPage = new workers();

        }
        void readData()
        {
            string connectionString = "server=192.168.0.52;database=test1;uid=test1;pwd=;";
            string selectQuery = query;
            try
            {
                using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
                {
                    //open connection
                    connection.Open();

                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(selectQuery, connection);

                    command.Connection = connection;
                    command.CommandText = selectQuery;
                    var result = command.ExecuteReader();
                    //check if account exists
                    var exists = result.HasRows;

                    while (result.Read())
                    {
                        output.Text = result[0].ToString() + result[1] + result[2] + result[3] + result[4] + result[5] + result[6] + result[7] + result[8] + result[9] + result[10] + result[11] + result[12];
                    }

                }
            }
            catch (Exception exception)
            {

            }
        }
    }
}