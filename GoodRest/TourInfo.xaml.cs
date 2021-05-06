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
            //DataTable Tour = ExecuteSql(sql);
            /*connection = new SqlConnection(connectionString);
            Tour = new DataTable();
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Name_T.Text = reader[7].ToString();
                Name_H.Text = reader[1].ToString();
                Star.Value = int.Parse(reader[2].ToString());
                typeP.Text = "Тип питания: "+reader[4].ToString();
                DayV.Text = "Дата вылета: "+reader[9].ToString();
                ColN.Text = "Количество ночей: "+reader[10].ToString();
                Cost.Text = reader[8].ToString()+" РУБ";
                Opis.Text = reader[3].ToString();
                // Pat.Source = reader[5];
                Opis.Text = reader[5].ToString();
                return;
            }*/

            /*   int n = int.Parse(CountryTours.v);
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
                       Error.Text = reader[1].ToString();

                       //this.NavigationService.Navigate(new SearchOutputTour());
                       return;
                   }
                   //Error.Text = "По вашему запросу ничего не найдено";

                   reader.Close();
                   connection.Close();
               }else
               if ((Tours.Country == "Турция") && (Tours.cityV == "Санкт-Петербург"))
               {

               }else
               if ((Tours.Country == "ОАЭ") && (Tours.cityV == "Санкт-Петербург"))
               {

               }
               if ((Tours.Country == "Египет") && (Tours.cityV == "Москва"))
               {

               }
               if ((Tours.Country == "Турция") && (Tours.cityV == "Москва"))
               {

               }
               if ((Tours.Country == "Россия") && (Tours.cityV == "Москва"))
               {

               }
               if ((Tours.Country == "ОАЭ") && (Tours.cityV == "Москва"))
               {

               }*/

        }
    }
}
