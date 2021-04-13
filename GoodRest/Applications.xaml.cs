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
    /// Логика взаимодействия для Applications.xaml
    /// </summary>
    public partial class Applications : Window
    {
       
        public Applications()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationsFrame.Content = new SearchApplications();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Greeting().Show();
            Helper.CloseWindow(Window.GetWindow(this));
        }
    }
}
