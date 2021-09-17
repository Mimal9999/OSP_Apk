using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/*
 * 
select z.data, z.km, .... p.imie, p.nazwisko
from `zgloszenie_pracownicy` z
JOIN pracownicy p
ON z.id_kierowcy = p.id
*/


namespace OSP_Apk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addNew : ContentPage
    {
        List<string> workersString = new List<string>();
        string query;
        public addNew()
        {
            InitializeComponent();
            query = "SELECT * FROM `pracownicy`";
            readData();
            dowodca.ItemsSource = workersString;
            kierowca.ItemsSource = workersString;
        }
        private void Button_Clicked(object sender, EventArgs e) //dodaj zgłoszenie
        {
            recBtn2.BackgroundColor = Color.FromHex("FF6100");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn3.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn4.BackgroundColor = Color.FromHex("2E2E2D");

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
        void readData()
        {
            // List<workers> =  dataAccess.GetAllWorkers();
            // worker somebody = = dataAccess.GetWorkerById(1);
            
            string connectionString = "server=192.168.0.52;database=test1;uid=test1;pwd=;";
            query = "SELECT * FROM `pracownicy`";
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
                        workersString.Add(result[0] + " " + result[1]);
                    }
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            //query dodajace do bazy
            query = "INSERT INTO `zgloszenie_pracownicy`(`data`, `dowodca`, `kierowca`, `cel`, `skad`, `dokad`, `godzina_wyjazd`, `licznik_wyjazd`, `godzina_przyjazd`, `licznik_przyjazd`, `km`, `postoj`, `autopompa`) VALUES ('"+ data.Date.Date.ToString("d") + "','" + dowodca.SelectedItem.ToString() + "','" + kierowca.SelectedItem.ToString() + "','" + cel.Text + "','" + skad.Text + "','" + dokad.Text + "','" + godzina_wyjazdu.Time.ToString() + "','" + licznik_wyjazd.Text + "','" + godzina_przyjazdu.Time.ToString() + "','" + licznik_przyjazd.Text + "','" + przejechano.Text + "','" + postoj.Text + "','" + autopompa.Text + "')";
            sendData();
   
        }

        private void licznik_przyjazd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(licznik_wyjazd.Text != null && licznik_przyjazd.Text != null)
            {
                int wynik = int.Parse(licznik_przyjazd.Text) - int.Parse(licznik_wyjazd.Text);
                przejechano.Text = wynik.ToString();
            }
        }

        private void licznik_wyjazd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (licznik_wyjazd.Text != null && licznik_przyjazd.Text != null)
            {
                int wynik = int.Parse(licznik_przyjazd.Text) - int.Parse(licznik_wyjazd.Text);
                przejechano.Text = wynik.ToString();
            }
        }
        void sendData()
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

                }
            }
            catch (Exception exception)
            {
                cel.Text = exception.ToString();
            }
        }
    }
}