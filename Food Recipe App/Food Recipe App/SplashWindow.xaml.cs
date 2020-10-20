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
using System.Xml;
using System.Configuration;

namespace Food_Recipe_App
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        private Random _rng = new Random();

        private string[] listOfTips = new string[]
        {
            "Bỏ muối vào canh sẽ làm canh mặn hơn!",
            "Nếu muốn ngọt hơn thì hãy cho đường vào ^^",
            "Dùng khoai tây để giảm độ mặn của món nước!",
            "Cho thêm muối vào khi luộc rau sẽ giúp rau xanh hơn!",
            "Hãy lau hết dầu khỏi chảo nếu muốn cho nước vào!"
        };
        public SplashWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int index;

            index = _rng.Next(listOfTips.Length);

            Dispatcher.Invoke(() =>
            {
                Tip.Text = listOfTips[index];
            });

            var value = ConfigurationManager.AppSettings["ShowSplashScreen"];
            var showSplash = bool.Parse(value);

            if (showSplash == false)
            {
                var screen = new MainWindow();
                screen.Show();

                this.Close();
            }
            else
            {
                //do nothing
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            screen.Show();

            this.Close();
        }

        private void NeverShowSplashCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ShowSplashScreen"].Value = "false";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void NeverShowSplashCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ShowSplashScreen"].Value = "true";
            config.Save(ConfigurationSaveMode.Minimal);
        }
    }
}
