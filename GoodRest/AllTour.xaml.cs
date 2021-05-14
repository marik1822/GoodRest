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
    /// Логика взаимодействия для AllTour.xaml
    /// </summary>
    public partial class AllTour : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Tour;
        public AllTour()
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Tours.cityV == "Москва")
            {
               
                DataTable Tour = ExecuteSql("SELECT * from AllTourMoscow;");
                LViewTours.ItemsSource = Tour.DefaultView;
            } else
                if (Tours.cityV == "Санкт-Петербург")
            {
               
            DataTable Tour = ExecuteSql("SELECT * from AllTourPiter;");
            LViewTours.ItemsSource = Tour.DefaultView;
            }
            
        }

        private void LViewTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           string  v = LViewTours.SelectedIndex.ToString();
            int n = int.Parse(v);
            n++;
            if (Tours.cityV == "Москва") {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from AllTourMoscow where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    CountryTours.id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    return;
                }

                reader.Close();
                connection.Close();
            }else 
            if (Tours.cityV == "Санкт-Петербург")
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from AllTourPiter where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    CountryTours.id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    return;
                }

                reader.Close();
                connection.Close();

            }

        }
    }
}
