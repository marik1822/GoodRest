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
    /// Логика взаимодействия для TourOform.xaml
    /// </summary>
    public partial class TourOform : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Employee;
        static DataTable Application;
        public static string id_EMP { get; set; }
        public static string col_ch { get; set; }
        public static string  col_p{ get; set; }

        public TourOform()
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
            string id_app = value1.ToString() + value2.ToString() + value3.ToString() + value4.ToString() + value5.ToString() + value6.ToString() + value7.ToString() + value8.ToString() + value9.ToString() + value10.ToString();
            return id_app;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((id_EMP != "")&&(col_ch!="")&&(col_p!="")) {
                string sql;
                string sql2;
                string id_app = null;
                Application = new DataTable();
                SqlConnection connection = null;
                connection = new SqlConnection(connectionString);
                connection.Open(); ;
                bool id = true;
                while (id)
                {
                    id_app = Random_();
                    sql = "Select * from Client where Id_Client='" + id_app + "';";
                    SqlCommand command3 = new SqlCommand(sql, connection);
                    SqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        id = true;
                        return;
                    }
                    id = false;
                    reader3.Close();
                }
                //CountryTours.id_t;
                 col_ch = ChildCol.SelectedItem.ToString();
                 col_p = PeopleCol.SelectedItem.ToString();
                int col_ch1 = int.Parse(col_ch);
                int col_p1 = int.Parse(col_p);
                int col_t1 = col_ch1 + col_p1;
                string col_t = col_t1.ToString();
                string DateN = DateTime.Now.ToString();
                DateN = DateN.Substring(0, DateN.LastIndexOf(' ') + 1);


                if ((MainWindow.name_ != "") && (MainWindow.surname_ != "") && (MainWindow.midleN != "") && (MainWindow.phone != "") && (MainWindow.seria != "") && (MainWindow.number != "") && (MainWindow.dayB != ""))
                {
                    sql2 = "INSERT INTO Application(Id_Application,Id_Employee,Id_Tour,Id_Client,Number_Of_Trips,Number_Of_People,_Status,Submission_Date,Number_Of_Children) VALUES('" + id_app + "','"+id_EMP+"','" + CountryTours.id_t + "','" + MainWindow.id_client + "'," + col_t + "," + col_p + ",'в обработке','"+DateN+"'," + col_ch + ");";
                    SqlCommand command2 = new SqlCommand(sql2, connection);
                    int num = command2.ExecuteNonQuery();
                    if (num != 0)
                    {
                        MessageBox.Show("Заявка №" + id_app + " оформлена. Пожалуйста запишите или запомните номер заявки для дальнейшего просмотра статуса заявки.");
                    }
                    else MessageBox.Show("Ошибка оформления");
                } else MessageBox.Show("Вы не ввели контактную информацию в личном кабинете");
            } else MessageBox.Show("Вы не ввели одно или несколько полей");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql;
            SqlConnection connection = null;
            Employee = new DataTable();
            sql = "SELECT * from Employee where (Status='Активен') AND (Post='Турагент                      ');";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            connection.Open();

            adapter.Fill(Employee);
            for (int i = 0; i < Employee.Rows.Count; i++)
            {
                Employer.Items.Add(Employee.Rows[i]["Surname"].ToString());
            }

            connection.Close();
            int s = 0;
            for (int i = -1; i <= 8; i++)
            {
                int n = i + 1;
                string str = n.ToString();
                ChildCol.Items.Add(str);
            }
            for (int i = 0; i <= 8; i++)
            {
                int n = i + 1;
                string str = n.ToString();
                PeopleCol.Items.Add(str);
            }
            

        }

        private void Employer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string  SurnameEMP = Employer.SelectedItem.ToString();
            string sql4 = "SELECT * from Employee where Surname='"+ SurnameEMP + "';";
            SqlConnection connection = null;
            connection = new SqlConnection(connectionString);
            Employee = new DataTable();
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql4, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_EMP = reader[0].ToString();
                return;
            }
            

            reader.Close();
            connection.Close();

        }

        private void PeopleCol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            col_p= PeopleCol.SelectedItem.ToString();
        }

        private void ChildCol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            col_ch = ChildCol.SelectedItem.ToString();
        }
    }
}
