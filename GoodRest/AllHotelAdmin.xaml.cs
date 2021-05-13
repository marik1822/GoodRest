﻿using System;
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
    /// Логика взаимодействия для AllHotelAdmin.xaml
    /// </summary>
    public partial class AllHotelAdmin : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Hotel;
        public AllHotelAdmin()
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllHotel.SelectedItem != null)
            {
                string id_Hotel = Hotel.Rows[AllHotel.SelectedIndex]["Id_Hotel"].ToString().Trim();
                string sql2 = "DELETE FROM Hotel where Id_Hotel='" + id_Hotel + "';";
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
                adapter.Update(Hotel);
                MessageBox.Show("Таблица отелей успешно сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString());
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * from  Hotel;";
            SqlConnection connection = null;

            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            SqlCommandBuilder myCommandBuilder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.InsertCommand = myCommandBuilder.GetInsertCommand();
            adapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
            adapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();

            Hotel = new DataTable();
            adapter.Fill(Hotel); //загрузка данных
            AllHotel.ItemsSource = Hotel.DefaultView; //привязка к DataGrid

        }
    }
}
