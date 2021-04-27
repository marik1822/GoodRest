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
                //Ошибка подключения БД!!
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
                //хранимая процедура
                DataTable Tour = ExecuteSql("SELECT * from AllTourMoscow;");
                LViewTours.ItemsSource = Tour.DefaultView;
            } else
                if (Tours.cityV == "Санкт-Петербург")
            {
               //хранимая процедура
            DataTable Tour = ExecuteSql("SELECT * from AllTourPiter;");
            LViewTours.ItemsSource = Tour.DefaultView;
            }
            
        }
    }
}
