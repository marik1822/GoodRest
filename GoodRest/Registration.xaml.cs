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

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
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


            //Successful.Content = new SuccessfulRegistration();
            if ((Successful.Content = new SuccessfulRegistration())!=null) 
            {
                Button.IsEnabled = false;
                Login.IsEnabled = false;
                Email.IsEnabled = false;
                Password.IsEnabled = false;
                NewPassword.IsEnabled = false;
            }


        }
    }
}
