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
    /// Логика взаимодействия для PhotoHotelAdd.xaml
    /// </summary>
    public partial class PhotoHotelAdd : Page
    {
       static string connectionString;
        SqlDataAdapter adapter;
        DataTable Photo;
       static DataTable Hotel;
        public PhotoHotelAdd()
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
        public string Random_()
        {
            Random rnd = new Random();
            int value1 = rnd.Next(0, 9);
            int value2 = rnd.Next(0, 9);
            int value3 = rnd.Next(0, 9);
            int value4 = rnd.Next(0, 9);
            int value5 = rnd.Next(0, 9);
            int value6 = rnd.Next(0, 9);
            int value7 = rnd.Next(0, 9);
            int value8 = rnd.Next(0, 9);
            int value9 = rnd.Next(0, 9);
            int value10 = rnd.Next(0, 9);
            string id_photo = value1.ToString() + value2.ToString() + value3.ToString() + value4.ToString() + value5.ToString() + value6.ToString() + value7.ToString() + value8.ToString() + value9.ToString() + value10.ToString();
            return id_photo;
        }
        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((ID_H.SelectedItem != null) && (Role.SelectedItem != null)&&(PathP.Text!=""))
            {
                string id_photo = null;
                string sql;
                string sql2;
                string sql3;
                Photo = new DataTable();
                SqlConnection connection = null;
                bool id = true;
                connection = new SqlConnection(connectionString);
                connection.Open();
                while (id)
                {
                    id_photo = Random_();
                    sql = "Select * from Photo where Id_Photo='" + id_photo + "';";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = true;
                        return;
                    }
                    id = false;
                    reader.Close();
                }
                sql2 = "INSERT INTO Photo(Id_Photo,Id_Hotel,Role) VALUES ('" + id_photo + "','" + ID_H.SelectedItem.ToString().Trim() + "'," + Role.SelectedItem.ToString().Trim() + ");";
                SqlCommand command2 = new SqlCommand(sql2, connection);
                int num = command2.ExecuteNonQuery();
                if (num != 0)
                {
                    sql3 = "UPDATE Photo SET Photo =(SELECT * FROM OPENROWSET(BULK N'"+PathP.Text+"', SINGLE_BLOB) AS image) WHERE Id_Photo = "+id_photo+";";
                    SqlCommand command3 = new SqlCommand(sql3, connection);
                    int num2 = command3.ExecuteNonQuery();
                    if (num2 != 0)
                    {
                        MessageBox.Show("Фотография успешно загружена");
                    }
                    else MessageBox.Show("Ошибка: Неправильно указан путь");
                }
                else MessageBox.Show("Ошибка добавления фотографии");
            }
            else MessageBox.Show("Вы ничего не ввели");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            string sql;
            SqlConnection connection = null;
            Hotel = new DataTable();
            sql = "SELECT Id_Hotel from Hotel;";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            connection.Open();

            adapter.Fill(Hotel);
            for (int i = 0; i < Hotel.Rows.Count; i++)
            {
                ID_H.Items.Add(Hotel.Rows[i]["Id_Hotel"].ToString());
            }

            connection.Close();
            int s = 0;
            for (int i = 0; i <= 4; i++)
            {
                int n = i + 1;
                string str = n.ToString();
                Role.Items.Add(str);
            }

        }
    }
}
