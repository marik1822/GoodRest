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
using System.Threading;


namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для GreetingPage.xaml
    /// </summary>
    public partial class GreetingPage : Page
    {
        public GreetingPage()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 1;
            for (int i = 10; i < 0; i--)
            {
                Thread.Sleep(60);
                this.Opacity -= 0.1;
            }
            NewFrame.Content = new ChoiceActionsClients();
            
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
