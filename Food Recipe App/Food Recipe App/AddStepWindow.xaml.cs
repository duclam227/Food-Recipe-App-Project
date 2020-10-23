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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

namespace Food_Recipe_App
{
    /// <summary>
    /// Interaction logic for AddStepWindow.xaml
    /// </summary>
    public partial class AddStepWindow : Window
    {
        private Step NewStep { get; set; }

        public event EventHandler<AddStepEventArgs> AddedStep;
        public AddStepWindow()
        {
            InitializeComponent();
            TextBox_StepDescription.Focus();
            NewStep = new Step();
        }

        private void Button_AddStep_Click(object sender, RoutedEventArgs e)
        {

            if (!TextBox_StepDescription.Text.Equals(""))
            {
                NewStep.Content = TextBox_StepDescription.Text;
                if (this.AddedStep != null)
                {
                    this.AddedStep(this, new AddStepEventArgs(NewStep));
                }

                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Empty description!");
            }
        }

        private void Button_AddStepImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
          "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
          "Portable Network Graphic (*.png)|*.png";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NewStep.AddImage(openFileDialog.FileName);
                ListView_AddStepPictures.ItemsSource = NewStep.ImagesPath;
            }
        }
    }

    public class AddStepEventArgs : EventArgs
    {
        public Step AddedStep { get; private set; }

        public AddStepEventArgs(Step data)
        {

            this.AddedStep = data;
        }
    }


}
