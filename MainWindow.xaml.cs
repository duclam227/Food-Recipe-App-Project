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
using System.Diagnostics;

namespace Food_Recipe_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Food> listOfFood = new List<Food>();

        private List<Food> listOfFavorite = new List<Food>();

        SqlConnection connection;

        string connectionString;

        private int currentRow = 0;

        private int currentPage = 1;

        private int noOfRows = 0;

        private DataTable foodTable = new DataTable();

        private int numberOfFoodPerPage = int.Parse(ConfigurationManager.AppSettings["NumberOfFoodPerPage"]);

        public MainWindow()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Food_Recipe_App.Properties.Settings.RecipesDBConnectionString"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foodTable = LoadAllFood();
            PopulateHomeList(foodTable);
            PreviousButton.Visibility = Visibility.Collapsed;
            if (IsLastPage())
            {
                NextButton.Visibility = Visibility.Collapsed;
                PageNumber.Text = "";
            }
        }

        private void PopulateHomeList(DataTable inputDataset)
        {
            int countLoop = 0;

            noOfRows = inputDataset.Rows.Count;

             foreach (DataRow row in inputDataset.Rows)
             {
                 Food tempFood = new Food();
                 tempFood.ID = int.Parse(row["ID"].ToString());
                 tempFood.foodName = row["foodName"].ToString();
                 tempFood.description = row["description"].ToString();
                 tempFood.imagePath = row["imagePath"].ToString();
                 tempFood.isFavorite = row["isFavorite"].ToString();
                 tempFood.rowNumber = currentRow;
                 listOfFood.Add(tempFood);

                currentRow++;
                countLoop++;

                if (countLoop == numberOfFoodPerPage)
                {
                    break;
                }
                else
                {
                    //do nothing
                }
             }
            FoodList.ItemsSource = listOfFood;
        }

        private void GetNextPage()
        {
            listOfFood.Clear();

            for(int i = 0; i < numberOfFoodPerPage; i++)
            {
                if(currentRow >= noOfRows)
                {
                    break;
                }
                else if(currentRow < 0)
                {
                    currentRow++;
                }
                DataRow tempRow = foodTable.Rows[currentRow];

                Food tempFood = new Food();

                tempFood.ID = int.Parse(tempRow["ID"].ToString());
                tempFood.foodName = tempRow["foodName"].ToString();
                tempFood.description = tempRow["description"].ToString();
                tempFood.imagePath = tempRow["imagePath"].ToString();
                tempFood.isFavorite = tempRow["isFavorite"].ToString();
                tempFood.rowNumber = currentRow;
                listOfFood.Add(tempFood);

                currentRow++;
            }

            FoodList.Items.Refresh();
            FoodList.ItemsSource = listOfFood;
        }

        private void GetLastPage()
        {
            listOfFood.Clear();

            for (int i = numberOfFoodPerPage; i > 0; i--)
            {
                if (currentRow < 0)
                {
                    break;
                }
                else if(currentRow == noOfRows)
                {
                    currentRow--;
                }
                DataRow tempRow = foodTable.Rows[currentRow];

                Food tempFood = new Food();

                tempFood.ID = int.Parse(tempRow["ID"].ToString());
                tempFood.foodName = tempRow["foodName"].ToString();
                tempFood.description = tempRow["description"].ToString();
                tempFood.imagePath = tempRow["imagePath"].ToString();
                tempFood.isFavorite = tempRow["isFavorite"].ToString();
                tempFood.rowNumber = currentRow;
                listOfFood.Add(tempFood);

                currentRow--;
            }

            FoodList.Items.Refresh();
            FoodList.ItemsSource = listOfFood;
        }

        private DataTable LoadAllFood()
        {
            DataTable foodTable = new DataTable();

            using (connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Food", connection))
                {
                   
                    adapter.Fill(foodTable);

                    foreach (DataRow row in foodTable.Rows)
                    {
                        Food tempFood = new Food();
                        tempFood.foodName = row["foodName"].ToString();
                        tempFood.description = row["description"].ToString();
                        tempFood.imagePath = row["imagePath"].ToString();
                        tempFood.isFavorite = row["isFavorite"].ToString();
                        //listOfFood.Add(tempFood);
                        if ((tempFood.isFavorite == "1") || (tempFood.isFavorite == "True"))
                        {
                            listOfFavorite.Add(tempFood);
                        }
                    }

                    //FoodList.ItemsSource = listOfFood;
                    FavoriteList.ItemsSource = listOfFavorite;
                }
            }

            return foodTable;
        }

        private bool IsFirstPage()
        {
            bool result = false;

            foreach (Food tempFood in listOfFood)
            {
                if (tempFood.rowNumber == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool IsLastPage()
        {
            bool result = false;

            foreach(Food tempFood in listOfFood)
            {
                if(tempFood.rowNumber >= (noOfRows - 1))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            //lấy n food trước đó
            GetLastPage();

            currentPage--;
            PageNumber.Text = $" {currentPage} ";

            if (IsFirstPage())
            {
                PreviousButton.Visibility = Visibility.Collapsed;
            }

            NextButton.Visibility = Visibility.Visible;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //lấy n food tiếp theo
            GetNextPage();

            currentPage++;
            PageNumber.Text = $" {currentPage} ";

            if (IsLastPage())
            {
                NextButton.Visibility = Visibility.Collapsed;
            }

            PreviousButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Update data for searching (use when list of food has changed)
        /// </summary>
        private void updateSearchingData()
        {
            SearchToolBar.SetDataBeforeSearching(listOfFood);
        }

        /// <summary>
        /// Get list of result from searching
        /// </summary>
        /// <returns></returns>
        private List<Food> GetSearchedResult()
        {
            return SearchToolBar.GetDataSuggestion();
        }

        private void SearchToolBar_eventReturnFoodResult(List<Food> resultSearch)
        {
            //Call populateHomeList here if u want to test what i say :)))
        }
    }
}
