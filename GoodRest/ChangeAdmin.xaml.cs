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

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ChangeAdmin.xaml
    /// </summary>
    public partial class ChangeAdmin : Window
    {
        public ChangeAdmin()
        {
            InitializeComponent();
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Greeting().Show();
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tour_Click(object sender, RoutedEventArgs e)
        {
           MainFrame.Content = new AdminTourMenu();
        }

        private void empl_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdminEmployeeMenu();
        }

        private void resort_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdminClientMenu();
        }

        private void Hotel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdminHotel();
        }

        

        private void client_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdminClientMenu();
        }
    }
}
