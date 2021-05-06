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
    /// Логика взаимодействия для SearchOutputTour.xaml
    /// </summary>
    public partial class SearchOutputTour : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Tour;
        public SearchOutputTour()
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

            string sql2;
            //SqlConnection connection = null;
            sql2 = "EXECUTE SearchTour @col=" + SearchTours.col_pyt + ",@city='" + SearchTours.country + "',@cityV='" + Tours.cityV + "',@date='" + SearchTours.day + "';";
            DataTable Tour = ExecuteSql(sql2);
            LViewTours.ItemsSource = Tour.DefaultView;



        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            Cursor = Cursors.Wait;
        }

        private void LViewTours_Unloaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
        }

        private void LViewTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string v = LViewTours.SelectedIndex.ToString();
            int n = int.Parse(v);
            n++;
            string sql2;
            SqlConnection connection = null;
            sql2 = "SELECT Photo, Name_Tour, Cost_Adult, Number_Of_Trips, Date_Start_Tour, Id_Tour,row_number() over(ORDER BY SearchToursV.Id_Tour)  num from SearchToursV where((SearchToursV.Number_Of_Trips-" + SearchTours.col_pyt + ")>= 0 ) AND(Departure_City = '" + Tours.cityV + "') AND(Name_City = '" + SearchTours.country + "') AND(Date_Start_Tour = '" + SearchTours.day + "') AND (num="+n+") ;";
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
                //this.NavigationService.Navigate(new SearchOutputTour());
                return;
            }
            //Error.Text = "По вашему запросу ничего не найдено";

            reader.Close();
            connection.Close();


        }
    }
}
