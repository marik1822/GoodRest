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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для CountryTours.xaml
    /// </summary>
    public partial class CountryTours : Page
    {
        public static string id_t { get; set; }
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Tour;
        public static string v { get; set; }
        public CountryTours()
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql1 = "SELECT * from EGP_Tour_Moscow;";
            string sql2 = "SELECT * from TUR_Tour_Moscow;";
            string sql3 = "SELECT * from RUS_Tour_Moscow;";
            string sql4 = "SELECT * from ARB_Tour_Moscow;";
            string sql5 = "SELECT * from EGP_Tour_Piter;";
            string sql6 = "SELECT * from TUR_Tour_Piter;";
            string sql7 = "SELECT * from ARB_Tour_Piter;";
            if ((Tours.Country=="Египет") && (Tours.cityV== "Санкт-Петербург"))
            {
                DataTable Tour = ExecuteSql(sql5);
                LViewTours.ItemsSource = Tour.DefaultView;
            }
            if ((Tours.Country == "Турция") && (Tours.cityV == "Санкт-Петербург"))
            {
                DataTable Tour = ExecuteSql(sql6);
                LViewTours.ItemsSource = Tour.DefaultView;
            }
            if ((Tours.Country == "ОАЭ") && (Tours.cityV == "Санкт-Петербург"))
            {
                DataTable Tour = ExecuteSql(sql7);
                LViewTours.ItemsSource = Tour.DefaultView;
            }
            if ((Tours.Country == "Египет") &&(Tours.cityV=="Москва"))
            {
                DataTable Tour = ExecuteSql(sql1);
                LViewTours.ItemsSource = Tour.DefaultView;
            }
            else
            if ((Tours.Country == "Турция") && (Tours.cityV == "Москва"))
            {
                DataTable Tour = ExecuteSql(sql2);
                LViewTours.ItemsSource = Tour.DefaultView;
            }
            else
            if ((Tours.Country == "Россия") && (Tours.cityV == "Москва"))
            {
                DataTable Tour = ExecuteSql(sql3);
                LViewTours.ItemsSource = Tour.DefaultView;

            }
            else
            if ((Tours.Country == "ОАЭ") && (Tours.cityV == "Москва"))
            {
                DataTable Tour = ExecuteSql(sql4);
                LViewTours.ItemsSource = Tour.DefaultView;
            }

        }

        private void LViewTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            v = LViewTours.SelectedIndex.ToString();
            int n = int.Parse(CountryTours.v);
            n++;
            if ((Tours.Country == "Египет") && (Tours.cityV == "Санкт-Петербург"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from EGP_Tour_Piter where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();
            }
            else
            if ((Tours.Country == "Турция") && (Tours.cityV == "Санкт-Петербург"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from TUR_Tour_Piter where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();
            }
            else
            if ((Tours.Country == "ОАЭ") && (Tours.cityV == "Санкт-Петербург"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from ARB_Tour_Piter where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();
            }
            if ((Tours.Country == "Египет") && (Tours.cityV == "Москва"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from EGP_Tour_Moscow where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();


            }
            if ((Tours.Country == "Турция") && (Tours.cityV == "Москва"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from TUR_Tour_Moscow where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();
            }
            if ((Tours.Country == "Россия") && (Tours.cityV == "Москва"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from RUS_Tour_Moscow where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();
            }
            if ((Tours.Country == "ОАЭ") && (Tours.cityV == "Москва"))
            {
                string sql2;
                SqlConnection connection = null;
                sql2 = "SELECT * from ARB_Tour_Moscow where num=" + n + ";";
                connection = new SqlConnection(connectionString);
                Tour = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    id_t = reader[5].ToString();
                    this.NavigationService.Navigate(new TourInfo());
                    //this.NavigationService.Navigate(new SearchOutputTour());
                    return;
                }
                //Error.Text = "По вашему запросу ничего не найдено";

                reader.Close();
                connection.Close();

            }
         //   this.NavigationService.Navigate(new TourInfo());

        }
    }
}
