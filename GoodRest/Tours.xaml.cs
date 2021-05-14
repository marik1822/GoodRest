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
       // public static Frame ToursFrame { get; set; }
        /// <summary>
        /// Переменная для города вылета
        /// </summary>
        public static string Country { get; set; }
        public static string cityV { get; set; }
        public Tours()
        {
            InitializeComponent();
            cityV = "Санкт-Петербург";
            LoginUser.Text = MainWindow.login_;
            ToursFrame.NavigationService.Navigate(new EditingClient());
        }
        /// <summary>
        /// Кнопка выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
      
        /// <summary>
        /// Появление окна Tours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Кнопка назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             new Greeting().Show();
            this.Close();
        }
        /// <summary>
        /// Кнопка выхода из аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.id_client = null;
            MainWindow.role_ = null;
            new MainWindow().Show();
            Helper.CloseWindow(Window.GetWindow(this));
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToursFrame.Content = null;
            ToursFrame.Content = new UserInfo();
            
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
           ToursFrame.Content = null;
           ToursFrame.Content = new ContactInformation();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            ToursFrame.Content = null;
            ToursFrame.Content = new ToursHome();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            City.Text = "Москва";
            cityV = "Москва";
            ToursFrame.Content = new ToursHome();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            City.Text = "Санкт-Петербург";
            cityV = "Санкт-Петербург";
            ToursFrame.Content = new ToursHome();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ToursFrame.Content = new SearchTours();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ToursFrame.Content = new AllTour();
        }

        private void ARB_Click(object sender, RoutedEventArgs e)
        {
            Country = "ОАЭ";
            ToursFrame.Content = new CountryTours();
        }

        private void RUS_Click(object sender, RoutedEventArgs e)
        {
            Country = "Россия";
            ToursFrame.Content = new CountryTours();
        }

        private void TUR_Click(object sender, RoutedEventArgs e)
        {
            Country = "Турция";
            ToursFrame.Content = new CountryTours();
        }

        private void EGP_Click(object sender, RoutedEventArgs e)
        {
            Country = "Египет";
            ToursFrame.Content = new CountryTours();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            ToursFrame.Content = new AboutUs();
        }
    }
}
