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
using System.Windows.Media.Animation;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для TourInfo.xaml
    /// </summary>
    public partial class TourInfo : Page
    {
       static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Tour;
      //  public static string id_t { get; set; }
        public TourInfo()
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
            //string photo;
            string sql;

            SqlConnection connection = null;
            sql = "EXEC TourInfo @ID='"+CountryTours.id_t+"';";
            DataTable Tour = ExecuteSql(sql);
            List.ItemsSource = Tour.DefaultView;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.role_ == "1")
            {
                this.NavigationService.Navigate(new TourOform());
            }
            else  MessageBox.Show("Вы не являетесь клиентом");
        }
    }
}
