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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Media.Animation;
using System.Windows.Controls.Primitives;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ToursHome.xaml
    /// </summary>
    public partial class ToursHome : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Resort;
        public ToursHome()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //подключено БД
            }
            catch (SqlException)
            {
                //"Ошибка подключения БД!!!
            }

        }
        private bool IsStartAnimation;
        private int SelectedIndex;
        private void StartAnimation()
        {
            if (Resorts_l.Items.Count == 0)
                return;

            //Resorts_l.IsEnabled = false;
            IsStartAnimation = true;
            SelectedIndex = Resorts_l.SelectedIndex+1;
            Int32Animation animation = new Int32Animation()
            {
                From = 0,
                To = Resorts_l.Items.Count - 1,
                Duration = TimeSpan.FromSeconds(Resorts_l.Items.Count * 2),
                RepeatBehavior = RepeatBehavior.Forever
               
            };
            Resorts_l.BeginAnimation(Selector.SelectedIndexProperty, animation);
            //buttAnimation.Content = "Остановить анимацию";

        }
       
        static DataTable ExecuteSql(string sql)
        {
            //string sql;
            Resort = new DataTable();
            SqlConnection connection = null;

            connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    Resort.Load(reader);
                }
            }
            return Resort;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * from Resort;";
            DataTable Resort = ExecuteSql(sql);
           Resorts_l.ItemsSource = Resort.DefaultView;
          //  StartAnimation();
        
        }

        private void Resorts_l_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Info = Resort.Rows[Resorts_l.SelectedIndex]["Description"].ToString();
            DescripResort.Text = Info;
        }
    }
}
