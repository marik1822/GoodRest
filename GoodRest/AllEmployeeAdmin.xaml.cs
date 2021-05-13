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
    /// Логика взаимодействия для AllEmployeeAdmin.xaml
    /// </summary>
    public partial class AllEmployeeAdmin : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Employee;
        public AllEmployeeAdmin()
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
            string sql = "SELECT * from  Employee;";
            SqlConnection connection = null;

            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            SqlCommandBuilder myCommandBuilder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.InsertCommand = myCommandBuilder.GetInsertCommand();
            adapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
            adapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();

            Employee = new DataTable();
            adapter.Fill(Employee); //загрузка данных
            AllEMP.ItemsSource = Employee.DefaultView; //привязка к DataGrid
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllEMP.SelectedItem != null)
            {
                string id_Employee = Employee.Rows[AllEMP.SelectedIndex]["Id_Employee"].ToString().Trim();
                string sql2 = "DELETE FROM Employee where Id_Employee='" + id_Employee + "';";
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                adapter.Update(Employee);
                MessageBox.Show("Таблица сотрудников успешно сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString());
            }
        }
    }
}
