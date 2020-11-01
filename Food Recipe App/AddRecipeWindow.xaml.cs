using System;
using System.IO;
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
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//using Microsoft.Win32;

namespace Food_Recipe_App
{

    public partial class AddRecipeWindow : Window
    {
        private Food _newFood = new Food();

        string connectionString;

        public AddRecipeWindow(int ID)
        {
            InitializeComponent();

            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            _newFood.ID = ID;
            connectionString = ConfigurationManager.ConnectionStrings["Food_Recipe_App.Properties.Settings.RecipesDBConnectionString"].ConnectionString;
        }

        private void Button_AddHeaderImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
          "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
          "Portable Network Graphic (*.png)|*.png";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _newFood.ImagePath = openFileDialog.FileName;
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                HeaderImage.Source = new BitmapImage(uri);
            }
        }

        private void Button_AddStep_Click(object sender, RoutedEventArgs e)
        {
            AddStepWindow _stepWindow = new AddStepWindow();
            _stepWindow.Owner = this;
            _stepWindow.AddedStep += (s, args) =>
            {
                args.AddedStep.FoodID = _newFood.ID;
                args.AddedStep.Number = _newFood.StepCount()+1;
                _newFood.AddStep(args.AddedStep);
                ListView_Steps.Items.Add(args.AddedStep);
            };
            _stepWindow.ShowDialog();

        }

        /// <summary>
        /// Add food into database here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Complete_Click(object sender, RoutedEventArgs e)
        {
            //create new folder for new recipe
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += $"Images\\{_newFood.ID}\\";
            System.IO.Directory.CreateDirectory(path);

            //copy header image
            if (_newFood.ImagePath != null)
            {
                _newFood.ImagePath = Utilities.CopyFile(_newFood.ImagePath, path);
            }
            else
            {
                System.Windows.MessageBox.Show("Bạn chưa thêm hình ảnh chính!");
                return;
            }

            _newFood.FoodName = TextBox_RecipeName.Text;
            _newFood.Description = TextBox_Description.Text;
            _newFood.isFavorite = false;
            _newFood.ImagePath = System.IO.Path.GetFileName(_newFood.ImagePath);
            _newFood.favoriteIconSource();

            AddFoodToDB(_newFood);

            //copy Steps images and change database
            foreach (Step step in _newFood.RecipeSteps)
            {
                if (step.ImagesPath.Count() != 0)
                {
                    string stepPath = System.IO.Path.Combine(path, step.Number.ToString());
                    System.IO.Directory.CreateDirectory(stepPath);

                    int i = 0;
                    for (i = 0; i < step.ImagesPath.Count;)
                    {
                        var imagePath = step.ImagesPath[i];
                        string tempPath = Utilities.CopyFile(imagePath, stepPath);
                        step.ImagesPath[i] = tempPath;
                        i++;
                    }
                }
                AddStepToDB(step);
            }

            this.Close();
        }

        private void Button_AddVideo_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeMediaWindow mediaWindow = new AddRecipeMediaWindow();
            mediaWindow.Owner = this;
            mediaWindow.AddedMedia += (s, args) =>
            {
                if (args.Media.Key == true)
                {
                    _newFood.MediaPath = args.Media.Value;
                }
            };
            mediaWindow.ShowDialog();

        }

        private void AddStepToDB(Step newStep)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string addNewStep = $"insert into Steps(FoodID, Number, Content) values ({newStep.FoodID}, {newStep.Number}, N'{newStep.Content}')";

            connection.Open();

            SqlCommand cmd = new SqlCommand(addNewStep, connection);
            cmd.ExecuteNonQuery();

            connection.Close();

            AddStepImagesToDB(newStep);
        }

        private void AddStepImagesToDB(Step newStep)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            List<string> imagesPath = new List<string>();

            //copy list images path từ step qua list mới
            imagesPath.AddRange(newStep.ImagesPath);

            connection.Open();

            int tempID = 1;

            foreach (string path in imagesPath)
            {
                //thêm vào db
                string imageName = System.IO.Path.GetFileName(path);
                string addNewStepImage = $"insert into StepImages(FoodID, StepNumber, ImagePath, StepImageID) values ({newStep.FoodID}, {newStep.Number}, '{imageName}', {tempID})";

                tempID++;
                SqlCommand cmd = new SqlCommand(addNewStepImage, connection);
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        private void AddFoodToDB(Food newFood)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string addNewFood = $"insert into dbo.Food(FoodID, FoodName, FoodDescription, FoodImagePath, IsFavorite, DateAdded) values ({newFood.ID}, N'{newFood.FoodName}', N'{newFood.Description}', '{newFood.ImagePath}', 0, CURRENT_TIMESTAMP)";

            SqlCommand cmd = new SqlCommand(addNewFood, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

      
    }
}
