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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsTravelAgent.xaml
    /// </summary>
    public partial class ApplicationsTravelAgent : Window
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Tour;
        public static float Sale { get; set; }
        public static string Date { get; set; }
        public static string ID_Aplication { get; set; }
        public static float Cost { get; set; }

        public static int Col_People { get; set; }
        public ApplicationsTravelAgent()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //подключено БД
            }
            catch (SqlException)
            {
                MessageBox.Show("Ошибка подключения БД");
            }
        }
        static DataTable ExecuteSql(string sql)
        {
            Tour = new DataTable();
            SqlConnection connection = null;

            connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    Tour.Load(reader);
                }
            }
            return Tour;
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Greeting().Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Aplic.Content = null;


        }

        private void Akt_apl_Click(object sender, RoutedEventArgs e)
        {
            Aplic.Content = null;
            string sql = "SELECT * from ApplicationEm where Id_Employee='" + MainWindow.id_emp + "'AND (_Status='в обработке');";
            DataTable Tour = ExecuteSql(sql);
            App.ItemsSource = Tour.DefaultView;

        }

        private void Oform_apl_Click(object sender, RoutedEventArgs e)
        {
            Aplic.Content = null;
            string sql = "SELECT * from ApplicationEm where Id_Employee='" + MainWindow.id_emp + "'AND (_Status='оформлен');";
            DataTable Tour = ExecuteSql(sql);
            App.ItemsSource = Tour.DefaultView;

        }

        private void All_apl_Click(object sender, RoutedEventArgs e)
        {
            Aplic.Content = null;
            string sql = "SELECT * from ApplicationEm where Id_Employee='" + MainWindow.id_emp + "';";
            DataTable Tour = ExecuteSql(sql);
            App.ItemsSource = Tour.DefaultView;
        }

        private void Dock_Click(object sender, RoutedEventArgs e)
        {
            Aplic.Content = new Contract();
        }

        private void Oform_Click(object sender, RoutedEventArgs e)
        {
           ID_Aplication = Tour.Rows[App.SelectedIndex]["Id_Application"].ToString().Trim();
           string Status = Tour.Rows[App.SelectedIndex]["_Status"].ToString();
           Cost =float.Parse(Tour.Rows[App.SelectedIndex]["Cost_Adult"].ToString().Trim());
           Col_People = int.Parse( Tour.Rows[App.SelectedIndex]["Number_Of_People"].ToString());
            if (Status == "в обработке")
            {
                
                Date = DateTime.Now.ToString();
                Date = Date.Substring(0, Date.LastIndexOf(' ') + 1);
                Aplic.Content = new ContractOFORM();
               
            }
         
        }
    }
}
