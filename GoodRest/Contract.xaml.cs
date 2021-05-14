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
using Word = Microsoft.Office.Interop.Word;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для Contract.xaml
    /// </summary>
    public partial class Contract : Page
    {
        static string connectionString;
        SqlDataAdapter adapter;
        static DataTable Contracts;
        public Contract()
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
        static DataTable ExecuteSql(string sql)
        {
            Contracts = new DataTable();
            SqlConnection connection = null;

            connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    Contracts.Load(reader);
                }
            }
            return Contracts;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * from ContractAll where Id_Employee='" + MainWindow.id_emp+"' ;";
            DataTable Contracts = ExecuteSql(sql);
            App.ItemsSource = Contracts.DefaultView;
        }

        private void Oform_Click(object sender, RoutedEventArgs e)
        {       
             var application = new Word.Application();
             Word.Document document = application.Documents.Add();
            MessageBox.Show("Договор экспортирован в Word");
            var row = (DataGridRow)App.ItemContainerGenerator.ContainerFromIndex(App.SelectedIndex);
            string FIO = Contracts.Rows[App.SelectedIndex]["Surname"].ToString().Trim()+" "+ Contracts.Rows[App.SelectedIndex]["Name_"].ToString().Trim()+" "+ Contracts.Rows[App.SelectedIndex]["Middle_name"].ToString().Trim();
            string ID_Contract = Contracts.Rows[App.SelectedIndex]["Id_Сontract"].ToString().Trim();
            string FIOEMP = Contracts.Rows[App.SelectedIndex]["SurnameEMP"].ToString().Trim() + " " + Contracts.Rows[App.SelectedIndex]["NameEMP"].ToString().Trim() + " " + Contracts.Rows[App.SelectedIndex]["Middle_nameEMP"].ToString().Trim();
            string DateContract = Contracts.Rows[App.SelectedIndex]["Date_registration"].ToString();
            DateContract = DateContract.Substring(0, DateContract.LastIndexOf(' ') + 1);
            string CityV = Contracts.Rows[App.SelectedIndex]["Departure_City"].ToString().Trim();
            string Seria = Contracts.Rows[App.SelectedIndex]["Series"].ToString().Trim();
            string Number = Contracts.Rows[App.SelectedIndex]["Number_passport"].ToString().Trim();
            string Email = Contracts.Rows[App.SelectedIndex]["Email"].ToString().Trim();
            string EmailEMP = Contracts.Rows[App.SelectedIndex]["EmailEMP"].ToString().Trim();
            string Phone = Contracts.Rows[App.SelectedIndex]["Phone_number"].ToString().Trim();
            string Pol = Contracts.Rows[App.SelectedIndex]["Gender"].ToString().Trim();
            string DayB = Contracts.Rows[App.SelectedIndex]["Date_of_birth"].ToString();
            DayB = DayB.Substring(0, DayB.LastIndexOf(' ') + 1);
            string ColTrip = Contracts.Rows[App.SelectedIndex]["Number_Of_Trips"].ToString().Trim();
            string ColPeople = Contracts.Rows[App.SelectedIndex]["Number_Of_People"].ToString().Trim();
            string ColChild = Contracts.Rows[App.SelectedIndex]["Number_Of_Children"].ToString().Trim();
            string Country = Contracts.Rows[App.SelectedIndex]["Name_Country"].ToString().Trim();
            string City = Contracts.Rows[App.SelectedIndex]["Name_City"].ToString().Trim();
            string DayteP = Contracts.Rows[App.SelectedIndex]["Date_Start_Tour"].ToString();
            DayteP = DayteP.Substring(0, DayteP.LastIndexOf(' ') + 1);
            string DayteV = Contracts.Rows[App.SelectedIndex]["Date_End_Tour"].ToString();
            DayteV = DayteV.Substring(0, DayteV.LastIndexOf(' ') + 1);
            string NameHotel = Contracts.Rows[App.SelectedIndex]["Name_Hotel"].ToString().Trim();
            string Star = Contracts.Rows[App.SelectedIndex]["Hotel_Category"].ToString().Trim();
            string KatEat = Contracts.Rows[App.SelectedIndex]["Type_Of_Food"].ToString().Trim();
            string Price = Contracts.Rows[App.SelectedIndex]["Cost_Adult"].ToString().Trim();
            string Sale = Contracts.Rows[App.SelectedIndex]["Discount"].ToString().Trim();
            string Cost = Contracts.Rows[App.SelectedIndex]["Final_Price"].ToString().Trim();
            var helper = new WordHelper("ContractProb.docx");
            var items = new Dictionary<string, string>
            {
                {"<CityV>", CityV},
                {"<IdContract>", ID_Contract},
                {"<DateContract>", DateContract},
                {"<FIOEMP>", FIOEMP},
                {"<FIOClient>", FIO},
                {"<Seria>", Seria},
                {"<Number>", Number},
                {"<EmailEMP>", EmailEMP},
                {"<EmailClient>", Email},
                {"<Phone>", Phone},
                {"<Pol>", Pol},
                {"<DayB>", DayB },
                {"<Col_Trip>", ColTrip},
                {"<Col_People>", ColPeople},
                {"<Col_Child>",ColChild },
                {"<Country>", Country},
                {"<City>", City},
                {"<DateP>", DayteP},
                {"<DateV>",DayteV },
                {"<NameHotel>",NameHotel },
                {"<Star>", Star},
                {"<KatEat>", KatEat},
                {"<Price>", Price},
                {"<Sale>",Sale },
                {"<Cost>",Cost },
            };

            helper.Process(items);

        }
    }
}
