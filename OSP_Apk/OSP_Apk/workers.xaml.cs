using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OSP_Apk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class wrk
    {
        public int id;
        public string name, surname;

    }
    public partial class workers : ContentPage
    {
        List<wrk> workersList = new List<wrk>();
        string query;
        public workers()
        {
            InitializeComponent();
            query = "SELECT * FROM `pracownicy`";
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
            App.Current.MainPage = new pending();
        }

        private void Button_Clicked_3(object sender, EventArgs e) //pracownicy
        {
            recBtn4.BackgroundColor = Color.FromHex("FF6100");
            recBtn2.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn1.BackgroundColor = Color.FromHex("2E2E2D");
            recBtn3.BackgroundColor = Color.FromHex("2E2E2D");
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            App.Current.MainPage = new addWorker();
        }
        void readWorkersData()
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

                    int j = 1;
                    while (result.Read())
                    {
                        workersList.Add(new wrk { id = j, name = result[0].ToString(), surname = result[1].ToString() });
                        j++;
                    }
                    for (int i = 0; i < workersList.Count; i++)
                    {
                        listView2.Children.Add(new Label { Text = workersList[i].id + "           " + workersList[i].name + " " + workersList[i].surname, FontSize = 25, FontAttributes = FontAttributes.Bold, Margin = new Thickness(30, 20, 0, 0) });
                    }

                }
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}

