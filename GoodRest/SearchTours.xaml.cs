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
        public static string country { get; set; }
        public static int col_pyt { get; set; }
        public static string day { get; set; }

        string connectionString;
        SqlDataAdapter adapter;
        DataTable City;
        DataTable Tour;
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
                MessageBox.Show("Ошибка подклюючения БД");
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
            int s = 0;
            for (int i=0; i <= 8; i++)
            {
                int n = i + 1;
                string str = n.ToString();
                Col.Items.Add(str);
            }
            

        }

        private void Serch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Wait;
            country = Country.SelectedItem.ToString();
             string  colP = Col.SelectedItem.ToString();
             col_pyt = int.Parse(colP);
             day = Date.Text;
            string sql2;
            SqlConnection connection = null;
            sql2 = "EXEC SearchTour @col="+col_pyt+",@city='"+country+"',@cityV='"+Tours.cityV+"',@date='"+day+"';";
            connection = new SqlConnection(connectionString);
            Tour = new DataTable();
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql2, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.NavigationService.Navigate(new SearchOutputTour());
                return;
            }
            MessageBox.Show("По вашему запросу ничего не найдено");

            reader.Close();
            connection.Close();
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Serch_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}


