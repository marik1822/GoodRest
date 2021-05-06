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
                //"Ошибка подключения БД!!!
            }
        }
        static DataTable ExecuteSql(string sql)
        {
            //string sql;
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
    }
}
