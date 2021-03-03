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
    /// Логика взаимодействия для Tours.xaml
    /// </summary>
    public partial class Tours : Window
    {
        public Tours()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VisualBrush vb = new VisualBrush();
            MediaElement me = new MediaElement();
            // me.Source = new Uri("C:/Users/orvis/source/repos/GoodRest/GoodRest/Palm - 44399.mp4");
            me.Source = new Uri("C:/Users/orvis/source/repos/GoodRest/GoodRest/Waves - 61950.mp4");
            vb.Visual = me;
            this.Background = vb;
            ToursFrame.Content = new ToursHome();
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Greeting().Show();
            this.Close();
        }
    }
}
