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
using System.Collections.ObjectModel;
using System.CodeDom;

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

        private int noOfPages = 0;

        private DataTable foodTable = new DataTable();

        private int numberOfFoodPerPage = int.Parse(ConfigurationManager.AppSettings["NumberOfFoodPerPage"]);

        List<Food> foodPage = new List<Food>();

        public MainWindow()
        {
            InitializeComponent();
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            connectionString = ConfigurationManager.ConnectionStrings["Food_Recipe_App.Properties.Settings.RecipesDBConnectionString"].ConnectionString;
            LoadFoodIntoTable("");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResetHomeScreen();
            FavoriteList.ItemsSource = listOfFavorite;
        }

        private void LoadFoodIntoTable(string order)
        {
            if (order == "Theo tên A-Z")
            {
                foodTable = LoadAllFoodByNameAsc();
            }
            else if (order == "Theo tên Z-A")
            {
                foodTable = LoadAllFoodByNameDesc();
            }
            else if (order == "Theo ngày A-Z")
            {
                foodTable = LoadAllFoodByDateAsc();
            }
            else if (order == "Theo ngày Z-A")
            {
                foodTable = LoadAllFoodByDateDesc();
            }
            else
            {
                foodTable = LoadAllFoodByID();
            }
        }

        private void ResetHomeScreen()
        {
            listOfFood.Clear();
            listOfFavorite.Clear();
            PopulateListOfFood(foodTable);
            PopulateListOfFavorite(foodTable);
            updateSearchingData();
            

            //lấy tổng số trang
            noOfPages = (noOfRows / numberOfFoodPerPage) + ((noOfRows % numberOfFoodPerPage) == 0 ? 0 : 1);
            GetPage(currentPage);
        }

        /// <summary>
        /// Load tất cả đồ ăn từ database vào DataTable foodTable
        /// </summary>
        /// <returns></returns>
        private DataTable LoadAllFoodByID()
        {
            foodTable.Clear();

            connection = new SqlConnection(connectionString);

            connection.Open();

            string getAll = "select * from Food";
            SqlCommand command = new SqlCommand(getAll, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(foodTable);

            connection.Close();

            return foodTable;
        }

        private DataTable LoadAllFoodByNameAsc()
        {
            foodTable.Clear();

            connection = new SqlConnection(connectionString);

            connection.Open();

            string getAll = "select * from Food order by FoodName ASC";
            SqlCommand command = new SqlCommand(getAll, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(foodTable);

            connection.Close();

            return foodTable;
        }

        private DataTable LoadAllFoodByNameDesc()
        {
            foodTable.Clear();

            connection = new SqlConnection(connectionString);

            connection.Open();

            string getAll = "select * from Food order by FoodName DESC";
            SqlCommand command = new SqlCommand(getAll, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(foodTable);

            connection.Close();

            return foodTable;
        }

        private DataTable LoadAllFoodByDateAsc()
        {
            foodTable = new DataTable();

            connection = new SqlConnection(connectionString);

            connection.Open();

            string getAll = "select * from Food order by DateAdded ASC";
            SqlCommand command = new SqlCommand(getAll, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(foodTable);

            connection.Close();

            return foodTable;
        }

        private DataTable LoadAllFoodByDateDesc()
        {
            foodTable = new DataTable();

            connection = new SqlConnection(connectionString);

            connection.Open();

            string getAll = "select * from Food order by DateAdded DESC";
            SqlCommand command = new SqlCommand(getAll, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(foodTable);

            connection.Close();

            return foodTable;
        }

        /// <summary>
        /// Load đồ ăn vào món ăn yêu thích
        /// </summary>
        /// <param name="inputDataset"></param>
        private void PopulateListOfFavorite(DataTable inputDataset)
        {
            foreach (DataRow row in inputDataset.Rows)
            {
                Food tempFood = new Food();
                tempFood.ID = int.Parse(row["FoodID"].ToString());
                tempFood.FoodName = row["FoodName"].ToString();
                tempFood.Description = row["FoodDescription"].ToString();
                string imageName = row["FoodImagePath"].ToString();

                string path = AppDomain.CurrentDomain.BaseDirectory;
                path += $"Images\\{tempFood.ID}\\{imageName}";

                tempFood.ImagePath = path;
                var tmpVar = row["IsFavorite"].ToString();
                if (tmpVar == "True")
                {
                    tempFood.isFavorite = true;
                }
                else
                {
                    tempFood.isFavorite = false;
                }
                //listOfFood.Add(tempFood);
                if (tempFood.isFavorite == true)
                {
                    tempFood.favoriteIconSource();
                    listOfFavorite.Add(tempFood);
                }
            }

            //FoodList.ItemsSource = listOfFood;
            //FavoriteList.ItemsSource = listOfFavorite;
        }

        /// <summary>
        /// Load toàn bộ đồ ăn vào listOfFood
        /// </summary>
        /// <param name="inputDataset"></param>
        private void PopulateListOfFood(DataTable inputDataset)
        {
            noOfRows = inputDataset.Rows.Count;

            foreach (DataRow row in inputDataset.Rows)
            {
                Food tempFood = new Food();
                tempFood.ID = int.Parse(row["FoodID"].ToString());
                tempFood.FoodName = row["FoodName"].ToString();
                tempFood.Description = row["FoodDescription"].ToString();


                string imageName = row["FoodImagePath"].ToString();

                string path = AppDomain.CurrentDomain.BaseDirectory;
                path += $"Images\\{tempFood.ID}\\{imageName}";

                tempFood.ImagePath = path;

                var tmpVar = row["IsFavorite"].ToString();
                if (tmpVar == "True")
                {
                    tempFood.isFavorite = true;
                }
                else
                {
                    tempFood.isFavorite = false;
                }
                tempFood.rowNumber = currentRow;
                tempFood.favoriteIconSource();
                listOfFood.Add(tempFood);

                currentRow++;
            }
            //FoodList.ItemsSource = listOfFood;
        }

        /// <summary>
        /// Lấy trang thứ pageNumber
        /// </summary>
        private void GetPage(int pageNumber)
        {
            pageNumber--;
            var enumerableFoodList = from food in listOfFood select food;
            foodPage = enumerableFoodList.Skip(pageNumber * numberOfFoodPerPage).Take(numberOfFoodPerPage).ToList();
            FoodList.ItemsSource = foodPage;

            CheckPageNavigation();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {

            currentPage--;
            PageNumber.Text = $"  {currentPage}  ";

            //lấy trang trước đó
            GetPage(currentPage);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            PageNumber.Text = $"  {currentPage}  ";

            GetPage(currentPage);
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
            Dispatcher.Invoke(() =>
            {
                FoodList.Items.Refresh();
                FoodList.ItemsSource = resultSearch;
            });

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ResetHomeScreen();
        }

        private void FavoriteListButton_Click(object sender, RoutedEventArgs e)
        {
            var favPage = new FavoriteListPage();

            favPage.listOfFavorite.AddRange(listOfFavorite);
            MainFrame.Navigate(favPage);

            favPage.eventPassFoodToMain += FavPage_eventPassFoodToMain;
        }

        private void FavPage_eventPassFoodToMain(Food foodToPass)
        {
            //xóa food này khỏi list of favorite
            for (int i = 0; i < listOfFavorite.Count; i++)
            {
                if (foodToPass.ID == listOfFavorite[i].ID)
                {
                    listOfFavorite.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < listOfFood.Count; i++)
            {
                if (foodToPass.ID == listOfFood[i].ID)
                {
                    listOfFood[i].isFavorite = false;
                    listOfFood[i].favoriteIconSource();
                    break;
                }
            }

            UpdateFavoriteToDB(foodToPass.ID, 0);
            FoodList.Items.Refresh();
            FavoriteList.Items.Refresh();
        }

        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
       
            Food f = (Food)FoodList.SelectedItem;

            if (f.isFavorite == true)
            {
                for (int i = 0; i < listOfFood.Count; i++)
                {
                    if (listOfFood[i].ID == f.ID)
                    {
                        listOfFood[i].isFavorite = false;
                        listOfFood[i].favoriteIconSource();

                        for (int j = 0; j < listOfFavorite.Count; j++)
                        {
                            if (listOfFavorite[j].ID == f.ID)
                            {
                                listOfFavorite.RemoveAt(j);
                                UpdateFavoriteToDB(f.ID, 0);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < listOfFood.Count; i++)
                {
                    if (listOfFood[i].ID == f.ID)
                    {
                        listOfFood[i].isFavorite = true;
                        listOfFood[i].favoriteIconSource();

                        listOfFavorite.Add(f);
                        UpdateFavoriteToDB(f.ID, 1);
                    }
                }
            }

            FavoriteList.Items.Refresh();
            FoodList.UnselectAll();
        }

        private void SelectCurrentItem(object sender, MouseButtonEventArgs e)
        {
            ListViewItem thisItem = (ListViewItem)sender;
            thisItem.IsSelected = true;
        }

        public void UpdateFavoriteToDB(int ID, int value)
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            string updateFavorite = $"update dbo.Food set isFavorite = {value} where FoodID = {ID}";

            SqlCommand cmd = new SqlCommand(updateFavorite, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            Food newFood = new Food();
            AddRecipeWindow addNewFood = new AddRecipeWindow(listOfFood.Count() + 1);
            addNewFood.Owner = this;
            addNewFood.ShowDialog();


            LoadFoodIntoTable("");
            ResetHomeScreen();
        }


        private void UpdateNumberOfFoodPerPageTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
         {
            if(e.Key == Key.Enter)
            {
                var fromTextBox = UpdateNumberOfFoodPerPageTextBox.Text;
                //Debug.WriteLine(fromTextBox);
                int inputNumber = 0;
                try
                {
                    inputNumber = int.Parse(fromTextBox);
                    if (inputNumber <= 0)
                    {
                        MessageBox.Show("Hãy nhập một số nguyên > 0!");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Hãy nhập một số nguyên > 0!");
                    return;
                }

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["NumberOfFoodPerPage"].Value = inputNumber.ToString();
                config.Save(ConfigurationSaveMode.Minimal);


                numberOfFoodPerPage = inputNumber;
                noOfPages = (noOfRows / numberOfFoodPerPage) + ((noOfRows % numberOfFoodPerPage) == 0 ? 0 : 1);
                currentPage = 1;

                GetPage(currentPage);
            }
        }

        private void CheckPageNavigation()
        {
            //nếu trang hiện tại = 1
            if(currentPage == 1)
            {
                //nếu trang đầu tiên không phải trang duy nhất
                if(noOfRows > FoodList.Items.Count)
                {
                    NextButton.Opacity = 1;
                    NextButton.IsEnabled = true;

                    PreviousButton.Opacity = 0;
                    PreviousButton.IsEnabled = false;

                    PageNumber.Opacity = 1;
                    PageNumber.Text = "  1  ";
                }
                //nếu trang đầu tiên là trang duy nhất
                else if (noOfRows == FoodList.Items.Count)
                {
                    NextButton.Opacity = 0;
                    NextButton.IsEnabled = false;

                    PreviousButton.Opacity = 0;
                    PreviousButton.IsEnabled = false;

                    PageNumber.Opacity = 0;
                }
                else
                {
                    //Do nothing: TH không bao giờ xảy ra
                }
            }
            //nếu trang hiện tại là trang cuối
            else if(currentPage == noOfPages)
            {
                NextButton.Opacity = 0;
                NextButton.IsEnabled = false;

                PreviousButton.Opacity = 1;
                PreviousButton.IsEnabled = true;

                PageNumber.Opacity = 1;
                PageNumber.Text = $"  {currentPage}  ";
            }
            //các trang nằm giữa
            else
            {
                NextButton.Opacity = 1;
                NextButton.IsEnabled = true;

                PreviousButton.Opacity = 1;
                PreviousButton.IsEnabled = true;

                PageNumber.Opacity = 1;
                PageNumber.Text = $"  {currentPage}  ";
            }
        }

        private void SortButton_eventPassStringToMain(string value)
        {
            foodTable.Clear();
            listOfFavorite.Clear();
            listOfFood.Clear();
            LoadFoodIntoTable(value);
            ResetHomeScreen();
        }

        private void ShowFoodDetail(object sender, MouseEventArgs e)
        {
            
            Food f = (Food)FoodList.SelectedItem;
            if (f == null)
            {
                return;
            }

            try
            {
                FoodDetailWindow foodDetail = new FoodDetailWindow(f);
                foodDetail.Owner = this;
                foodDetail.ShowDialog();
            }
            catch
            {

            }
            
        }

    }
}
