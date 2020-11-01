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
using FluidKit.Controls;

namespace Food_Recipe_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FoodDetailWindow : Window
    {

        private List<Step> _listOfSteps = new List<Step>();

        private Food _food = new Food();

        private string connectionString;

        public FoodDetailWindow(Food food)
        {
            InitializeComponent();
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;

            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            connectionString = ConfigurationManager.ConnectionStrings["Food_Recipe_App.Properties.Settings.RecipesDBConnectionString"].ConnectionString;
            this.Title = food.FoodName;

            _food = food;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FoodTitleTextBlock.Text = _food.FoodName;
            FoodDescTextBlock.Text = _food.Description;

            try
            {
                HeaderImage.Source = new BitmapImage(new Uri(_food.ImagePath, UriKind.Absolute));
            }
            catch
            {
                MessageBox.Show("Không có hình ảnh của món ăn này!");
                this.Close();
            }

            GetListOfStepsFromDB(_food.ID);

            ListView_Steps.ItemsSource = _listOfSteps;
        }

        private List<Step> GetListOfStepsFromDB(int foodID)
        {
            List<Step> result = new List<Step>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string getSteps = $"select * from Steps where FoodID = {foodID}";

            SqlCommand cmd = new SqlCommand(getSteps, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable stepTable = new DataTable();

            try
            {
                adapter.Fill(stepTable);
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu!");
            }
            
            connection.Close();

            foreach(DataRow row in stepTable.Rows)
            {
                Step tempStep = new Step();
                tempStep.FoodID = foodID;
                tempStep.Number = int.Parse(row["Number"].ToString());
                tempStep.Content = row["Content"].ToString();

                tempStep.ImagesPath = GetListOfStepImages(tempStep);

                _listOfSteps.Add(tempStep);
            }


            return result;
        }
       
        private List<string> GetListOfStepImages(Step inputStep)
        {
            List<string> result = new List<string>();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string getStepImagesQuery = $"select * from dbo.StepImages where FoodID = {inputStep.FoodID} and StepNumber = {inputStep.Number}";

            SqlCommand cmd = new SqlCommand(getStepImagesQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable stepImagesTable = new DataTable();

            try
            {
                adapter.Fill(stepImagesTable);
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu!");
            }

            connection.Close();

            foreach (DataRow row in stepImagesTable.Rows)
            {
                string tempString;
                tempString = row["ImagePath"].ToString();

                string path = basePath;
                path += $"Images\\{inputStep.FoodID}\\{inputStep.Number}\\{tempString}";

                result.Add(path);
            }

            return result;
        }

       
    }
}
