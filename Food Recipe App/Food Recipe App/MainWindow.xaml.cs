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
        List<Food> listOfFood = new List<Food>();

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

                    
                    foreach (DataRow row in foodTable.Rows)
                    {
                        Food tempFood = new Food();
                        tempFood.foodName = row["foodName"].ToString();
                        tempFood.description = row["description"].ToString();
                        tempFood.imagePath = row["imagePath"].ToString();
                        listOfFood.Add(tempFood);
                    }

                    FoodList.ItemsSource = listOfFood;
                }
            }
        }
    }
}
