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
using System.Windows.Shapes;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Client;
        public Registration()
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
                MessageBox.Show("Ошибка подключения БД");
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
            string id_client = value1.ToString() + value2.ToString() + value3.ToString() + value4.ToString() + value5.ToString() + value6.ToString() + value7.ToString() + value8.ToString() + value9.ToString() + value10.ToString();
            return id_client;
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql;
            string sql2;
            string sql3;
            string sql4;
            Client = new DataTable();
            SqlConnection connection = null;
            string idClient = null;
            //проверка на не пустоту поля
            Error.Text = "";
            if ((Email.Text == "") && (Login.Text == "") && (Password.Text == "") && (NewPassword.Text == ""))
            {
                Error.Text = "Вы ничего не ввели";


            }
            else
                if (Email.Text == "")
            {
                Error.Text = "Вы не ввели почту";
            }
            else
                if (Login.Text == "")
            {
                Error.Text = "Вы не ввели логин";
            }
            else
                if (Password.Text == "")
            {
                Error.Text = "Вы не ввели пароль";
            }
            else
            if (NewPassword.Text == "")
            {
                Error.Text = "Вы не ввели пароль повторно";
            }
            else
             if (!string.IsNullOrEmpty(Email.Text.Trim()))
            {
                const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                var email = Email.Text.Trim().ToLowerInvariant();

                if (Regex.Match(email, pattern).Success)
                {

                    MainWindow.login_ = Login.Text.Trim();
                    MainWindow.email = Email.Text.Trim();
                    MainWindow.password_ = Password.Text.Trim();
                    sql2 = "Select * from Client where Email='" + MainWindow.email + "';";
                    sql = "Select * from Client where Login='" + MainWindow.login_ + "';";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    bool id = true;
                    while (id)
                    {
                        idClient = Random_();
                        sql3 = "Select * from Client where Id_Client='" + idClient + "';";
                        SqlCommand command3 = new SqlCommand(sql3, connection);
                        SqlDataReader reader3 = command3.ExecuteReader();
                        while (reader3.Read())
                        {
                            id = true;
                            return;
                        }
                        id = false;
                        reader3.Close();
                    }
                    sql4 = "EXECUTE Registrarion @id='"+ idClient + "',@email='"+ MainWindow.email + "',@login='"+ MainWindow.login_ + "',@password='"+ MainWindow.password_ + "';";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Error.Text = "Такой логин уже существует";

                        return;
                    }
                    reader.Close();
                    SqlCommand command2 = new SqlCommand(sql2, connection);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Error.Text = "Эта почта уже использована другим пользователем";
                        return;
                    }
                    reader2.Close();
                    Successful.Content = new SuccessfulRegistration();
                    if ((Successful.Content = new SuccessfulRegistration()) != null)
                    {
                        SqlCommand command3 = new SqlCommand(sql4, connection);
                        int num = command3.ExecuteNonQuery();
                        Button.IsEnabled = false;
                        Login.IsEnabled = false;
                        Email.IsEnabled = false;
                        Password.IsEnabled = false;
                        NewPassword.IsEnabled = false;
                        MainWindow.login_ = Login.Text.Trim();
                        MainWindow.password_ = Password.Text.Trim();
                        MainWindow.id_client = idClient;
                        MainWindow.role_ = "";
                        MainWindow.name_ = "";
                        MainWindow.surname_ = "";
                        MainWindow.id_client = "";
                        MainWindow.seria = "";
                        MainWindow.number ="";
                        MainWindow.dayB = "";
                        MainWindow.midleN = "";
                        MainWindow.sex = "";
                        MainWindow.phone ="";
                        connection.Close();
                    }
                }

                else
                    Error.Text = "Неверно введена почта. Пример ввода почты: Ivanov@mail.ru";
            }
            
        }
    }
}
