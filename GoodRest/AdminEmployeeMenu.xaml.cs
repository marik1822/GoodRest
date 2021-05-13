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
    /// Логика взаимодействия для AdminEmployeeMenu.xaml
    /// </summary>
    public partial class AdminEmployeeMenu : Page
    {
        public AdminEmployeeMenu()
        {
            InitializeComponent();
        }

        private void AllEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllEmployeeAdmin());
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

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
