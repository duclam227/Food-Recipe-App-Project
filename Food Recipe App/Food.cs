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
        private string _mediaPath;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get => _ID; set => _ID = value; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get => _imagePath; set => _imagePath = value; }

        public List<Step> RecipeSteps { get => _recipeSteps; set => _recipeSteps = value; }
        public string MediaPath { get => _mediaPath; set => _mediaPath = value; }


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

        public void AddStep(Step newStep)
        {
            _recipeSteps.Add(newStep);
        }

        public int StepCount()
        {
            return _recipeSteps.Count();
        }

        public Food()
        {
            _recipeSteps = new List<Step>();
        }
    }
}
