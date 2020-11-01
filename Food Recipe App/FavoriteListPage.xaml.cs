using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for FavoriteListPage.xaml
    /// </summary>
    public partial class FavoriteListPage : Page
    {
        public List<Food> listOfFavorite = new List<Food>();

        public delegate void PassFoodToMain(Food foodToPass);

        public event PassFoodToMain eventPassFoodToMain;

        public FavoriteListPage()
        {
            InitializeComponent();
            FavoriteList.ItemsSource = listOfFavorite;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }


        //private ListViewItem _currentItem = null;
        private void ListViewItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var item = FavoriteList.ItemContainerGenerator.ItemFromContainer(FavoriteList);

            Debug.WriteLine(item.ToString());
        }

        private void ListViewItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //_currentItem = null;
        }

        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            Food f = (Food)FavoriteList.SelectedItem;

            for(int i = 0; i < listOfFavorite.Count; i++)
            {
                if(f.ID == listOfFavorite[i].ID)
                {
                    eventPassFoodToMain(f);
                    
                    listOfFavorite.RemoveAt(i);
                    break;
                }
            }

            FavoriteList.ItemsSource = listOfFavorite;
            FavoriteList.Items.Refresh();
        }

        private void SelectCurrentItem(object sender, MouseButtonEventArgs e)
        {
            ListViewItem thisItem = (ListViewItem)sender;
            thisItem.IsSelected = true;
        }
    }
}
