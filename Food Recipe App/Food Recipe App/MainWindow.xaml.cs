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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Food_Recipe_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection connection;

        string connectionString;

        public MainWindow()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Food_Recipe_App.Properties.Settings.RecipesDBConnectionString"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Food", connection))
                {
                    DataTable foodTable = new DataTable();
                    adapter.Fill(foodTable);

                    string fname;
                    //fname = foodTable.Rows[0][1].ToString();
                    //FoodList.Items.Add(fname);
                    FoodList.DisplayMemberPath = "Name";
                    FoodList.SelectedValuePath = "ID";
                    FoodList.ItemsSource = foodTable.DefaultView.ToString();
                }
            }
        }
    }
}
