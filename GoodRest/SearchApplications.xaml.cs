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

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для SearchApplications.xaml
    /// </summary>
    public partial class SearchApplications : Page
    {
        public SearchApplications()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
             
        }

        private void Search1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameSearch1.Content = new ApplicationOutput1();
            Search1.IsEnabled = false;
            NumberApplications.IsEnabled = false;
        }
    }
}
