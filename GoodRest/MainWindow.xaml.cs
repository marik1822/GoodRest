using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Drawing;
using System.Configuration.Assemblies;
using System.Windows.Media.Animation;



namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Client;
        DataTable Employee;


        private Page Registration;
        private Greeting_GoodRest _greeting_GoodRest;

        private Page _currentPage;
        public Page CurrentPage { get { return _currentPage; } set { _currentPage = value;   }  }

        private double _frameOpacity;
        public double FrameOpacity { get { return _frameOpacity; } set { _frameOpacity = value; } }
        public static string role_{ get; set; }
        public static string login_ { get; set ; }
        public static string password_ { get; set;  }
        public static string name_ { get; set; }
        public static string surname_ { get; set; }
        public static string id_client { get; set; }
        public static string email { get; set; }
        public static string seria { get; set; }
        public static string number { get; set; }
        public static string dayB { get; set; }
        public static string midleN { get; set; }
        public static string sex { get; set; }
        public static string phone { get; set; }


        public MainWindow()
        {
            InitializeComponent();
           // MainFrame.Content = new Greeting_GoodRest();
            FrameOpacity = 1;
            CurrentPage = null;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //Error.Text = "подключено БД";
            }
            catch (SqlException) 
            {
                Error.Text = "Ошибка подключения БД!!!";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql;
            string sql2;
            Client= new DataTable();
            Employee = new DataTable();
            password_ = Password.Text.Trim();
            login_ = Login.Text.Trim();
            SqlConnection connection = null;
            Error.Text = "";
            if ((Login.Text == "") && (Password.Text == ""))
            {
                Error.Text = "Вы ничего не ввели";
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
                if (NoRobot.IsChecked == true)
            {
                //string role;
               sql = "SELECT Id_Client, Series,Number_passport,Surname,Name_,Middle_name,Phone_number,Gender,Role,convert(varchar,Date_of_birth,106) from Client where (Login='"+login_+"')and(Password='"+password_+"');";
               sql2 = "SELECT login,password, Role from Employee where ((Login='" + login_ + "') and (Password='" + password_ + "'))";
               // sql = "SELECT login,password, Role from Client where ((Login='marik') and (Password='marik'))";
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                //command.Parameters.AddWithValue("@login",log);
                //command.Parameters.AddWithValue("@password",pass);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    role_ = reader[8].ToString();
                    name_ = reader[4].ToString();
                    surname_ = reader[3].ToString();
                    id_client = reader[0].ToString();
                    seria= reader[1].ToString();
                    number= reader[2].ToString();
                    dayB=reader[9].ToString();
                    midleN= reader[5].ToString();
                    sex= reader[7].ToString();
                    phone= reader[6].ToString();



                    new Greeting().Show();
                    this.Close();
                   // Error.Text = role_;
                    return;
                }
                reader.Close();
                //connection.Close();
                //connection= new SqlConnection(connectionString);
                SqlCommand command2 = new SqlCommand(sql2, connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    role_ = reader2[2].ToString();
                    new Greeting().Show();
                    this.Close();
                    Error.Text = role_;
                    return;
                }
                reader2.Close();
                
                Error.Text = "Неверный логин или пароль";
                Login.Text = "";
                Password.Text = "";
                NoRobot.IsChecked = false;
                
                connection.Close();

                // new Greeting().Show();
            }
            else
                Error.Text = "Поставьте галочку в поле я не робот";
            //Helper.CloseWindow(Window.GetWindow(this));
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            new Registration().Show();
            this.Close();
        }
       
    private async void SlowOpacity(Page page)
        { 
           await Task.Factory.StartNew(()=>
               {
                for (double i = 1.0; i > 0.0; i -= 0.1) 
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Exit_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
           

        }
    }
}
