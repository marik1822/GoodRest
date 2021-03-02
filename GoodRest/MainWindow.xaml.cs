using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Drawing;
using System.Windows.Media.Animation;



namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page Registration;
        private Greeting_GoodRest _greeting_GoodRest;

        private Page _currentPage;
        public Page CurrentPage { get { return _currentPage; } set { _currentPage = value;   }  }

        private double _frameOpacity;
        public double FrameOpacity { get { return _frameOpacity; } set { _frameOpacity = value; } }
        public MainWindow()
        {
            InitializeComponent();
           // MainFrame.Content = new Greeting_GoodRest();
            FrameOpacity = 1;
            CurrentPage = null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Greeting().Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            new Registration().Show();
            this.Close();
        }
       
    private async void SlowOpacity(Page page)
        { 
           await Task.Factory.StartNew(()=>
               {
                for (double i = 1.0; i > 0.0; i -= 0.1) 
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Exit_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
