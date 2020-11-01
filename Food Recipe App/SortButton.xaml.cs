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

namespace Food_Recipe_App
{
    /// <summary>
    /// Interaction logic for SortButton.xaml
    /// </summary>
    public partial class SortButton : UserControl
    {
        public delegate void PassStringToMain(string value);

        public event PassStringToMain eventPassStringToMain;

        private string[] listOfSortOptions = { 
            "Theo tên A-Z",
            "Theo tên Z-A",
            "Theo ngày A-Z",
            "Theo ngày Z-A"
        };

        public SortButton()
        {
            InitializeComponent();
            SortOptionsList.ItemsSource = listOfSortOptions.ToList();
        }

        private void SortOptionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = SortOptionsList.SelectedItem.ToString();
            SortOptionsList.Visibility = Visibility.Collapsed;
            eventPassStringToMain(text);
        }

        private void SortButtonIcon_Click(object sender, RoutedEventArgs e)
        {
            if(SortOptionsList.Visibility == Visibility.Collapsed)
            {
                SortOptionsList.Visibility = Visibility.Visible;
            }
            else
            {
                SortOptionsList.Visibility = Visibility.Collapsed;
            }
        }
    }
}
