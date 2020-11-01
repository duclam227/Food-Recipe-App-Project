using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Food_Recipe_App
{
    public class Step
    {
        private int _foodID;
        private int _number;
        private string _content;
        List<string> _imagesPath;

        public Step(string description)
        {
            _imagesPath = new List<string>();
            _content = description;
        }

        public Step()
        {
            _imagesPath = new List<string>();
        }

        public int FoodID { get => _foodID; set => _foodID = value; }
        public int Number { get => _number; set => _number = value; }
        public string Content { get => _content; set => _content = value; }
        public List<BitmapImage> ImagesLoader
        {
            get
            {
                List<BitmapImage> bitmapImgList = new List<BitmapImage>();

                foreach (var path in _imagesPath)
                {
                    bitmapImgList.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                }


                return bitmapImgList;
            }
        }

        public List<String> ImagesPath
        {
            get
            {
                return _imagesPath;
            }
            set
            {
                _imagesPath = value;
            }
        }

        public void AddImage(string path)
        {
            _imagesPath.Add(path);
        }
    }
}