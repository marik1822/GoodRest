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
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Client;
        public UserInfo()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //Error.Text = "подключено БД";
            }
            catch (SqlException)
            {
               // Error.Text = "Ошибка подключения БД!!!";
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Surname.Text = "Информация отсутствует";
            Name.Text = "Информация отсутствует";
            MidleName.Text = "Информация отсутствует";
            Phone.Text = "Информация отсутствует";
            Ser.Text = "Информация отсутствует";
            Number.Text = "Информация отсутствует";
            Sex.Text = "Информация отсутствует";
            DayOfB.Text = "Информация отсутствует";
            string sql;
            Client = new DataTable();
            SqlConnection connection = null;
            sql = "SELECT Surname,Name_,Middle_name,Phone_number,Series,Number_passport,Gender,CONVERT(varchar,Date_of_birth,106) as Date_of_birth from Client where Id_Client='"+MainWindow.id_client+"';";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Surname.Text = reader[0].ToString();
                Name.Text = reader[1].ToString();
                MidleName.Text = reader[2].ToString();
                Phone.Text = reader[3].ToString();
                Ser.Text = reader[4].ToString();
                Number.Text = reader[5].ToString();
                Sex.Text = reader[6].ToString();
                DayOfB.Text = reader[7].ToString();
                // Error.Text = role_;
                return;
            }
            reader.Close();
        }

        private void ReadakInf_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditingClient());

        }
    }
}
