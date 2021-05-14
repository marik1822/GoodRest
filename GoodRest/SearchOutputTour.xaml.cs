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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            string sql2;
            sql2 = "EXECUTE SearchTour @col=" + SearchTours.col_pyt + ",@city='" + SearchTours.country + "',@cityV='" + Tours.cityV + "',@date='" + SearchTours.day + "';";
            DataTable Tour = ExecuteSql(sql2);
            LViewTours.ItemsSource = Tour.DefaultView;



        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void LViewTours_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void LViewTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CountryTours.id_t= Tour.Rows[LViewTours.SelectedIndex]["Id_Tour"].ToString().Trim();
            this.NavigationService.Navigate(new TourInfo());
        }
    }
}
