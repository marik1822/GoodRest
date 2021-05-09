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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ContractOFORM.xaml
    /// </summary>
    public partial class ContractOFORM : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Contract;
        public ContractOFORM()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //Error.Text = "подключено БД";
            }
            catch (SqlException)
            {
                Error.Text = "Ошибка подключения БД!!!";
            }
        }
        public string Random_()
        {
            Random rnd = new Random();
            int value1 = rnd.Next(0, 9);
            int value2 = rnd.Next(0, 9);
            int value3 = rnd.Next(0, 9);
            int value4 = rnd.Next(0, 9);
            int value5 = rnd.Next(0, 9);
            int value6 = rnd.Next(0, 9);
            int value7 = rnd.Next(0, 9);
            int value8 = rnd.Next(0, 9);
            int value9 = rnd.Next(0, 9);
            int value10 = rnd.Next(0, 9);
            string id_contract = value1.ToString() + value2.ToString() + value3.ToString() + value4.ToString() + value5.ToString() + value6.ToString() + value7.ToString() + value8.ToString() + value9.ToString() + value10.ToString();
            return id_contract;
        }
        private void Dock_Click(object sender, RoutedEventArgs e)
        {
            if (Sale.Text != "")
            {
                ApplicationsTravelAgent.Sale =float.Parse(Sale.Text.Trim());
                if (ApplicationsTravelAgent.Sale < (ApplicationsTravelAgent.Col_People * ApplicationsTravelAgent.Cost))
                {
                    // int finall_cost = (ApplicationsTravelAgent.Col_People * ApplicationsTravelAgent.Cost) - ApplicationsTravelAgent.Sale;
                    string finall_cost = ((ApplicationsTravelAgent.Col_People * ApplicationsTravelAgent.Cost) - ApplicationsTravelAgent.Sale).ToString();
                    string id_contract = null;
                    string sql;
                    Contract = new DataTable();
                    SqlConnection connection = null;
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    bool id = true;
                    while (id)
                    {
                        id_contract = Random_();
                        sql = "SELECT * from Contract where Id_Сontract='" + id_contract + "';";
                        SqlCommand command = new SqlCommand(sql, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            id = true;
                            return;
                        }
                        id = false;
                        reader.Close();
                    }
                    string sql2 = "INSERT INTO Contract (Id_Сontract,Id_Application,Discount,Final_Price,Date_registration) VALUES('" + id_contract + "','" + ApplicationsTravelAgent.ID_Aplication + "'," + ApplicationsTravelAgent.Sale.ToString() + "," + finall_cost + ",'" + ApplicationsTravelAgent.Date + "');";
                    SqlCommand command2 = new SqlCommand(sql2, connection);
                    int num = command2.ExecuteNonQuery();
                    string sql3 = "UPDATE Application SET _Status='оформлен' where Id_Application='"+ ApplicationsTravelAgent.ID_Aplication + "';";
                    SqlCommand command3 = new SqlCommand(sql3, connection);
                    int num2 = command3.ExecuteNonQuery();

                    connection.Close();

                    if ((num != 0)&&(num2!=0))
                    {
                        MessageBox.Show("Договор успешно оформлен");
                        this.NavigationService.Navigate(null);
                    }
                    else Error.Text = "Ошибка оформления договора";
                }
                else Error.Text = "Слишком большая скидка";
            } else
            {
                Error.Text = "Вы ничего не ввели";
            }


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(null);
        }

        private void Sale_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
