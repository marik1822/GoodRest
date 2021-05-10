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
    /// Логика взаимодействия для EditingClient.xaml
    /// </summary>
    public partial class EditingClient : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Client;
        public EditingClient()
        {
            InitializeComponent();
            //Phone.PreviewTextInput += new TextCompositionEventHandler(Phone_TextInput);
            Seria.PreviewTextInput += new TextCompositionEventHandler(Seria_TextInput);
            Number.PreviewTextInput += new TextCompositionEventHandler(Number_TextInput);
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

        private void ReadakInf_Click(object sender, RoutedEventArgs e)
        {
            Error.Text = "";
            string sql;
            string phone_ =  Phone.Text ;
            if ((Surname.Text.Trim() == "") && (Name.Text.Trim() == "") && (MiddleName.Text.Trim() == "") && (Phone.Text.Trim() == "") && (Seria.Text.Trim() == "") && (Number.Text.Trim() == "") && (Date.Text.Trim() == "") && ((M.IsChecked == false) || (F.IsChecked == false)))
            {
                Error.Text = "Вы ничего не ввели";
            }
            else
            if (Surname.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели фамилию";
            }
            else
            if (Name.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели имя";
            }
            else
            if (MiddleName.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели отчество";
            }
            else
            if (Phone.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели номер телефона";
            }
            else
            if (Seria.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели серию паспорта";
            }
            else
            if (Number.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели номер паспорта";
            }
            else
            if (Date.Text.Trim() == "")
            {
                Error.Text = "Вы не ввели дату рождения";
            }
            else
            if ((M.IsChecked == false) && (F.IsChecked == false))
            {
                Error.Text = "Вы не выбрали пол";
            } else
            if (phone_[0] != '+')
            {
                Error.Text = "Неправильно введён номер телефона, пример ввода номера: +79850503288";
            } else
                if ((phone_[0] == '+') && (Surname.Text.Trim() != "") && (Name.Text.Trim() != "") && (MiddleName.Text.Trim() != "") && (Phone.Text.Trim() != "") && (Seria.Text.Trim() != "") && (Number.Text.Trim() != "") && (Date.Text.Trim() != "") && ((M.IsChecked == true) || (F.IsChecked==true))) 
            {
                // string phone_plus = "+" + Phone.Text.Trim();
                // string sql;
                Client = new DataTable();
                SqlConnection connection = null;
                sql = "UPDATE Client SET Series='" + Seria.Text.Trim() + "',Number_passport='" + Number.Text.Trim() + "',Surname='" + Surname.Text.Trim() + "',Name_='" + Name.Text.Trim() + "',Middle_name='" + MiddleName.Text.Trim() + "',Date_of_birth='" + Date.Text.Trim() + "',Phone_number='" + Phone.Text.Trim() + "',Gender='" + MainWindow.sex + "' WHERE Id_Client='" + MainWindow.id_client.Trim() + "';";
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                int num = command.ExecuteNonQuery();
                if (M.IsChecked == true)
                {
                    MainWindow.sex = "м";
                }
                else
                if (F.IsChecked == true)
                {
                    MainWindow.sex = "ж";
                }
                MainWindow.seria = Seria.Text.Trim();
                MainWindow.number = Number.Text.Trim();
                MainWindow.name_ = Name.Text.Trim();
                MainWindow.midleN = MiddleName.Text.Trim();
                MainWindow.dayB = Date.Text.Trim();
                MainWindow.phone = Phone.Text.Trim();
                this.NavigationService.Navigate(new UserInfo());
                connection.Close();
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
                if (MainWindow.surname_ != "")
                {
                    Surname.Text = MainWindow.surname_;
                }
                if (MainWindow.name_ != "")
                {
                    Name.Text = MainWindow.name_;
                }
                if (MainWindow.midleN != "")
                {
                    MiddleName.Text = MainWindow.midleN;
                }
                if (MainWindow.phone != "")
                {

                    Phone.Text = MainWindow.phone;
                }
                if (MainWindow.seria != "")
                {
                    Seria.Text = MainWindow.seria;
                }
                if (MainWindow.number != "")
                {
                    Number.Text = MainWindow.number;
                }

                if (MainWindow.dayB != "")
                {

                    Date.SelectedDate = DateTime.Parse(MainWindow.dayB);
                }
                if (MainWindow.sex.Trim().ToLower() == "ж")
                {
                    F.IsChecked = true;
                    M.IsChecked = false;
                }
                else
                     if (MainWindow.sex.Trim().ToLower() == "м")
                {
                    F.IsChecked = false;
                    M.IsChecked = true;
                }
            
        }

        private void M_Checked(object sender, RoutedEventArgs e)
        {
            F.IsChecked = false;
            MainWindow.sex = "м";

        }

        private void F_Checked(object sender, RoutedEventArgs e)
        {
            M.IsChecked = false;
            MainWindow.sex = "ж";
        }

        private void Phone_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        private void Seria_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Number_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
