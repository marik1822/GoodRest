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
    /// Логика взаимодействия для SearchApplications.xaml
    /// </summary>
    public partial class SearchApplications : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Application;
        public static string id_Aplic {get;set;}
        public static string id_Client { get; set; }
        public static string id_Tour { get; set; }
        public static string Date_ap { get; set; }

        public static string Number_Of_Trips { get; set; }

        public static string Status { get; set; }
        public SearchApplications()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                Error.Text = "Ошибка подключения БД!!!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
             
        }

        private void Search1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string sql;
            Application = new DataTable();
            id_Aplic =NumberApplications.Text.Trim();
            SqlConnection connection = null;
            Error.Text = "";
            if (NumberApplications.Text == "")
            {
                Error.Text = "Вы ничего не ввели";
            }

            else

                if (NumberApplications.Text != "")
            {
                sql = "Select Id_Application,Id_Tour,Id_Client,Number_Of_Trips,_Status,convert(varchar,Submission_Date,106) from Application where Id_Application='"+id_Aplic+"';";
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id_Client = reader[2].ToString();
                    id_Tour = reader[1].ToString();
                    Number_Of_Trips = reader[3].ToString();
                    Status = reader[4].ToString();
                    Date_ap = reader[5].ToString();
                    if (MainWindow.id_client==id_Client)
                    {


                        FrameSearch1.Content = new ApplicationOutput1();
                        Search1.IsEnabled = false;
                        NumberApplications.IsEnabled = false;
                    }
                    return;
                }
                reader.Close();
                connection.Close();
                Error.Text = "Заявка не найдена";
                NumberApplications.Text = "";
            }
        }
    }
}
