using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_App
{
    public class Food : INotifyPropertyChanged
    {
        private int _ID;
        private string _foodName;
        private string _description;
        private string _imagePath;
        List<Step> _recipeSteps;
        private bool _isFavorite;
        private int _rowNumber;
        private string favoriteIconPath;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }
        public string foodName { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
        public List<Step> recipeSteps { get; set; }
        public bool isFavorite
        {
            get { return _isFavorite; }
            set
            {
                _isFavorite = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isFavorite"));

            }
        }
        public int rowNumber { get; set; }


        public string favoriteIcon
        {
            get { return favoriteIconPath; }
            set
            {
                favoriteIconPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("favoriteIcon"));
            }
        }

        public void favoriteIconSource()
        {
            favoriteIcon = "";
            if (isFavorite == true)
            {
                favoriteIcon = "Images/favoritedIcon.png";
            }
            else
            {
                favoriteIcon = "Images/favoriteIcon.png";
            }

            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(favoriteIcon));

        }

        public Food()
        {

        }
    }
}
