using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ApplicationOutput1.xaml
    /// </summary>
    /// 
    public partial class ApplicationOutput1 : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Client;
        DataTable Tour;
        public static string Name_Tour { get; set; }
        public static string fio { get; set; }
        public ApplicationOutput1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //Error.Text = "подключено БД";
            }
            catch (SqlException)
            {
                MessageBox.Show("Ошибка подключения БД");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql;
            string f;
            string i;
            string o;
            
            Client = new DataTable();
            Tour = new DataTable();
            Id.Text = SearchApplications.id_Aplic;
            Date.Text = SearchApplications.Date_ap;
            KolPyt.Text = SearchApplications.Number_Of_Trips;
            Status.Text = SearchApplications.Status;
            SqlConnection connection = null;
            sql= "SELECT dbo.Tour.Name_Tour, dbo.Client.Surname, dbo.Client.Name_, dbo.Client.Middle_name, dbo.Application.Id_Tour FROM dbo.Tour INNER JOIN dbo.Application ON dbo.Tour.Id_Tour = dbo.Application.Id_Tour INNER JOIN dbo.Client ON dbo.Application.Id_Client = dbo.Client.Id_Client WHERE (dbo.Application.Id_Tour = '"+SearchApplications.id_Tour+ "')AND (dbo.Application.Id_Application = '"+SearchApplications.id_Aplic+"');";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                f = reader[1].ToString().Trim();
                i = reader[2].ToString().Trim();
                o = reader[3].ToString().Trim();
                fio =f+" "+i+" "+o;
                FIO.Text = fio;
                NameTur.Text = reader[0].ToString();

                return;
            }
            reader.Close();
            connection.Close();
        }
    }
}
