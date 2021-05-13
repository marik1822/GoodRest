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
    /// Логика взаимодействия для AdminTourMenu.xaml
    /// </summary>
    public partial class AdminTourMenu : Page
    {
        public AdminTourMenu()
        {
            InitializeComponent();
           
        }

        private void AllTours_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllTourAdmin());
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            Vivod.Opacity = 100;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Vivod.Opacity = 0;
        }
    }
}
