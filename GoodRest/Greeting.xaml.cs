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
using System.Windows.Media.Animation;


namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для Greeting.xaml
    /// </summary>
    public partial class Greeting : Window
    {
        private MediaPlayer _mpBgr;
        public Greeting()
        {
            InitializeComponent();
            _mpBgr = new MediaPlayer();
        }

       

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Cloud3_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da1 = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();

            da1.To = -30;
            da2.To = -5;
           
            da1.Duration = new Duration(TimeSpan.FromSeconds(30));
            da1.RepeatBehavior = RepeatBehavior.Forever;
            da2.Duration = new Duration(TimeSpan.FromSeconds(30));
            da2.RepeatBehavior = RepeatBehavior.Forever;
            SkewTransform rt = new SkewTransform();
            Cloud3.RenderTransform = rt;
            rt.BeginAnimation(SkewTransform.AngleXProperty, da1);
            rt.BeginAnimation(SkewTransform.AngleYProperty, da2);
        }

        private void Cloud2_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da2 = new DoubleAnimation();
            DoubleAnimation da1 = new DoubleAnimation();

            da1.To = -30;
            da2.To = -1;

            da1.Duration = new Duration(TimeSpan.FromSeconds(30));
            da1.RepeatBehavior = RepeatBehavior.Forever;
            da2.Duration = new Duration(TimeSpan.FromSeconds(30));
            da2.RepeatBehavior = RepeatBehavior.Forever;
            SkewTransform rt = new SkewTransform();
            Cloud2.RenderTransform = rt;
            rt.BeginAnimation(SkewTransform.AngleXProperty, da1);
            rt.BeginAnimation(SkewTransform.AngleYProperty, da2);
        }

        private void Cloud4_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da2 = new DoubleAnimation();
            DoubleAnimation da1 = new DoubleAnimation();

            da1.To = -25;
            da2.To = -2;

            da1.Duration = new Duration(TimeSpan.FromSeconds(30));
            da1.RepeatBehavior = RepeatBehavior.Forever;
            da2.Duration = new Duration(TimeSpan.FromSeconds(30));
            da2.RepeatBehavior = RepeatBehavior.Forever;
            SkewTransform rt = new SkewTransform();
            Cloud4.RenderTransform = rt;
            rt.BeginAnimation(SkewTransform.AngleXProperty, da1);
            rt.BeginAnimation(SkewTransform.AngleYProperty, da2);
        }

        private void Cloud1_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da2 = new DoubleAnimation();
            DoubleAnimation da1 = new DoubleAnimation();

            da1.To = -35;
            da2.To = -5;

            da1.Duration = new Duration(TimeSpan.FromSeconds(30));
            da1.RepeatBehavior = RepeatBehavior.Forever;
            da2.Duration = new Duration(TimeSpan.FromSeconds(30));
            da2.RepeatBehavior = RepeatBehavior.Forever;
            SkewTransform rt = new SkewTransform();
            Cloud1.RenderTransform = rt;
            rt.BeginAnimation(SkewTransform.AngleXProperty, da1);
            rt.BeginAnimation(SkewTransform.AngleYProperty, da2);

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Next.IsEnabled = true;
            MainFraime.Content = new GreetingPage();
            _mpBgr.Open(new Uri(@"C:/Users/orvis/source/repos/GoodRest/GoodRest/Звуки природы Star — Музыкотерапия.mp3", UriKind.Absolute));
            _mpBgr.Play();
            _mpBgr.Position = TimeSpan.FromMinutes(0.10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFraime.Content = new ChoiceActionsClients();
            
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Next.IsEnabled = false;
            Next.Opacity = 0.0;
            MainFraime.Content = null;
            MainFraime.Content = new ChoiceActionsClients();
        }
        public void Close_window() 
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void Greeting1_Unloaded(object sender, RoutedEventArgs e)
        {
            _mpBgr.Pause();
        }
    }
}
