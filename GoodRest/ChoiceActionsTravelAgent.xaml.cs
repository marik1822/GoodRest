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
    /// Логика взаимодействия для ChoiceActionsTravelAgent.xaml
    /// </summary>
    public partial class ChoiceActionsTravelAgent : Page
    {
        public ChoiceActionsTravelAgent()
        {
            InitializeComponent();
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Application_Click(object sender, RoutedEventArgs e)
        {
            new ApplicationsTravelAgent().Show();
            Helper.CloseWindow(Window.GetWindow(this)); ;
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            new Tours().Show();
            Helper.CloseWindow(Window.GetWindow(this)); ;
        }
    }
}
