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

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для AllTourAdmin.xaml
    /// </summary>
    public partial class AllTourAdmin : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Tour;
        public AllTourAdmin()
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
                MessageBox.Show("Ошибка подключения БД");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * from  Tour;";
            SqlConnection connection = null;

            connection = new SqlConnection(connectionString);
            //string table = "brands";
            //string sql = "SELECT * FROM " + table;
            adapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            SqlCommandBuilder myCommandBuilder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.InsertCommand = myCommandBuilder.GetInsertCommand();
            adapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
            adapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();

            Tour = new DataTable();
            adapter.Fill(Tour); //загрузка данных
            AllTour.ItemsSource = Tour.DefaultView; //привязка к DataGrid

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                adapter.Update(Tour);
                MessageBox.Show("Таблица туров успешно сохранена");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: "+ex.ToString());
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllTour.SelectedItem != null)
            {
                string id_Tour = Tour.Rows[AllTour.SelectedIndex]["Id_Tour"].ToString().Trim();
                string sql2 = "DELETE FROM Tour where Id_Tour='" + id_Tour + "';";
                SqlConnection connection = null;

                connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(sql2, connection);
                connection.Open();
                int num = command.ExecuteNonQuery();
                if (num != 0)
                {
                    MessageBox.Show("Строка успешно удалена");
                }
                else MessageBox.Show("Ошибка удаления");
            }
            else MessageBox.Show("Вы не выбрали строку для удаления");

        }
    }
}
