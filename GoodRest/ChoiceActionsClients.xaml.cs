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
using GoodRest;
using System.Reflection;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ChoiceActions.xaml
    /// </summary>
    public partial class ChoiceActionsClients : Page
    {
       
        private bool _clickOrNo;
       // public bool clickOrNo { get { return _clickOrNo; } set { _clickOrNo = value; } }

        public ChoiceActionsClients()
        {
            InitializeComponent();
            //this.Opacity = 1;
            //clickOrNo = false;

        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 1;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Tours().Show();
            Helper.CloseWindow(Window.GetWindow(this));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Applications().Show();
            Helper.CloseWindow(Window.GetWindow(this));
        }
    }
}
