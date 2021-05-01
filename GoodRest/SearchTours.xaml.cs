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
    /// Логика взаимодействия для SearchTours.xaml
    /// </summary>
    public partial class SearchTours : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable City;
        public SearchTours()
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql;
            SqlConnection connection = null;
            City = new DataTable();
            sql = "SELECT Name_City from City;";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            
            adapter.Fill(City);
            for (int i=0; i < City.Rows.Count; i++)
            {
                Country.Items.Add(City.Rows[i]["Name_City"].ToString());
            }
           
            connection.Close();
            

        }
    }
}
