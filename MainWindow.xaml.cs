//Created by: Jordan Hurst
//Date: October 14, 2020
//Program takes in input from textboxes  when the Subumit button is clicked and saves them to an SQL database
//Program displays the SQL database file on the screen when the Print button is clicked.
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using DataController;

namespace PersonInfoSQL
{    
    public partial class MainWindow : Window
    {        
        DataControl data = new DataControl();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            data.ToDatabase(firstName, lastName);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            const string READ_CMD = "SELECT * FROM NABA.dbo.Person";
            SqlConnection connectionString = new SqlConnection(@"Data Source = DESKTOP-GQR2API;Initial Catalog = NABA;Trusted_Connection = true");
            using SqlCommand read = new SqlCommand(READ_CMD, connectionString);
            SqlDataAdapter sda = new SqlDataAdapter(read);
            DataTable dt = new DataTable("Person Info");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            data.DeleteData();
        }
    }
}
