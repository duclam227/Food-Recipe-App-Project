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
//using Microsoft.Win32;

namespace Food_Recipe_App
{
    
    public partial class AddRecipeWindow : Window
    {
        private int _stepsNumber;
        private int _foodID;
        public AddRecipeWindow()
        {
            InitializeComponent();

            _stepsNumber = 0;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
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
                _stepsNumber++;
                args.AddedStep.FoodID = _foodID;
                args.AddedStep.Number = _stepsNumber;
                ListView_Steps.Items.Add(args.AddedStep);
            };
            _stepWindow.ShowDialog();

        }

        private void Button_Complete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_AddVideo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
