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
    /// Interaction logic for SearchToolBar.xaml
    /// </summary>
    public partial class SearchToolBar : UserControl
    {
        public SearchToolBar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// dataBeforeSearching is full list from main
        /// </summary>
        private List<Food> dataBeforeSearching;
        /// <summary>
        /// dataSuggestion is result list from searching
        /// </summary>
        private List<Food> dataSuggestion = new List<Food>();

        public List<Food> GetDataSuggestion()
        {
            return dataSuggestion;
        }

        public void SetDataSuggestion(List<Food> value)
        {
            dataSuggestion = value;
        }

        public List<Food> GetDataBeforeSearching()
        {
            return dataBeforeSearching;
        }

        public void SetDataBeforeSearching(List<Food> value)
        {
            dataBeforeSearching = value;
        }


        /// <summary>
        /// Open suggestion box method
        /// </summary>
        private void openSuggestionBox()
        {
            try
            {
                suggestionList.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Close suggestion box method
        /// </summary>
        private void closeSuggestionBox()
        {
            try
            {
                suggestionList.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Event of changing text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                dataSuggestion.Clear();
                // Verification.  
                if (string.IsNullOrEmpty(this.SearchText.Text))
                {
                    // Disable.  
                    this.closeSuggestionBox();

                    // Info.  
                    return;
                }

                // Enable.  
                this.openSuggestionBox();

                //Text typed by user
                string searching = translateToUnsignedCharacter(SearchText.Text.ToLower());

                // Settings.
                //List string to show on suggestion box
                List<string> nameToShow = new List<string>();

                //Get data from dataBeforeSearching to dataSuggestion
                for (int i = 0; i < dataBeforeSearching.Count(); i++)
                {
                    //Check if that data is similar to our text
                    if (translateToUnsignedCharacter(dataBeforeSearching[i].foodName).ToLower().Contains(searching))
                    {
                        nameToShow.Add(dataBeforeSearching[i].foodName);    //Add to list which will show on suggestion box
                        dataSuggestion.Add(dataBeforeSearching[i]);         //Add that data to dataSuggestion
                    }
                    else
                    {
                        //Do NOTHING
                    }
                }

                suggestionList.ItemsSource = nameToShow;                    //Update suggestion box
            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        /// <summary>
        /// Event when user select result from suggestion box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuggestionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Verification.  
                if (this.suggestionList.SelectedIndex <= -1)
                {
                    // Disable.  
                    this.closeSuggestionBox();

                    // Info.  
                    return;
                }

                // Disable.  
                this.closeSuggestionBox();

                // Settings.  
                this.SearchText.Text = this.suggestionList.SelectedItem.ToString(); //Upcate content of text box with selected choice
                int indexSelected = suggestionList.SelectedIndex;                   //Get index of that choice from suggestion box
                
                Food dataSelected = dataSuggestion[indexSelected];                  //////////////////////////////////////////////
                dataSuggestion.Clear();                                             //////////////////////////////////////////////
                dataSuggestion.Add(dataSelected);                                   ///////////////////GET RESULT ////////////////
                eventReturnFoodResult(dataSuggestion);                              //////////////////////////////////////////////

                this.suggestionList.SelectedIndex = -1;                             //Reset index
            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        /// <summary>
        /// Convert unicode word to ascii word (ex: lâm -> lam)
        /// </summary>
        /// <param name="unicodeString">String need to convert</param>
        /// <returns></returns>
        private string translateToUnsignedCharacter(string unicodeString)
        {
            string result = unicodeString;

            char[] unicodeChar_a = { 'â', 'ă', 'á', 'à', 'ạ', 'ã', 'ả', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ' };
            //char[] unicodeChar_A = { 'Â', 'Ă', 'Á', 'À', 'Ạ', 'Ã', 'Ả', 'Ấ', 'Ầ', 'Ẩ', 'Ẫ', 'Ậ', 'Ắ', 'Ằ', 'Ẳ', 'Ẵ', 'Ặ' };
            char[] unicodeChar_d = { 'đ' };
            //char[] unicodeChar_D = { 'Đ' };
            char[] unicodeChar_e = { 'ê', 'é', 'è', 'ẻ', 'ẽ', 'ẹ', 'ế', 'ề', 'ể', 'ễ', 'ệ' };
            //char[] unicodeChar_E = { 'Ê', 'É', 'È', 'Ẻ', 'Ẽ', 'Ẹ', 'Ế', 'Ề', 'Ể', 'Ễ', 'Ệ' };
            char[] unicodeChar_i = { 'í', 'ì', 'ỉ', 'ĩ', 'ị' };
            //char[] unicodeChar_I = { 'Í', 'Ì', 'Ỉ', 'Ĩ', 'Ị' };
            char[] unicodeChar_o = { 'ô', 'ơ', 'ó', 'ò', 'ỏ', 'õ', 'ọ', 'ố', 'ồ', 'ổ', 'ỗ', 'ộ', 'ớ', 'ờ', 'ở', 'ỡ', 'ợ' };
            //char[] unicodeChar_O = { 'Ô', 'Ơ', 'Ó', 'Ò', 'Ỏ', 'Õ', 'Ọ', 'Ố', 'Ồ', 'Ổ', 'Ỗ', 'Ộ', 'Ớ', 'Ờ', 'Ở', 'Ỡ', 'Ợ' };
            char[] unicodeChar_u = { 'ư', 'ú', 'ù', 'ủ', 'ũ', 'ụ', 'ứ', 'ừ', 'ử', 'ữ', 'ự' };
            //char[] unicodeChar_U = { 'Ư', 'Ú', 'Ù', 'Ủ', 'Ũ', 'Ụ', 'Ứ', 'Ừ', 'Ử', 'Ữ', 'Ự' };
            char[] unicodeChar_y = { 'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ' };
            //char[] unicodeChar_Y = { 'Ý', 'Ỳ', 'Ỷ', 'Ỹ', 'Ỵ' };


            //Replace all unicode character to ascii character
            for (int i = 0; i < unicodeChar_a.Length; i++) { result = result.Replace(unicodeChar_a[i], 'a'); }
            for (int i = 0; i < unicodeChar_d.Length; i++) { result = result.Replace(unicodeChar_d[i], 'd'); }
            for (int i = 0; i < unicodeChar_e.Length; i++) { result = result.Replace(unicodeChar_e[i], 'e'); }
            for (int i = 0; i < unicodeChar_i.Length; i++) { result = result.Replace(unicodeChar_i[i], 'i'); }
            for (int i = 0; i < unicodeChar_o.Length; i++) { result = result.Replace(unicodeChar_o[i], 'o'); }
            for (int i = 0; i < unicodeChar_u.Length; i++) { result = result.Replace(unicodeChar_u[i], 'u'); }
            for (int i = 0; i < unicodeChar_y.Length; i++) { result = result.Replace(unicodeChar_y[i], 'y'); }

            return result;
        }

        public delegate void PassingResultSearchToMain(List<Food> resultSearch);
        /// <summary>
        /// Event passing data to main control
        /// </summary>
        public event PassingResultSearchToMain eventReturnFoodResult;

        /// <summary>
        /// Event when user input a key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (eventReturnFoodResult != null)
                {
                    eventReturnFoodResult(dataSuggestion);
                }
                else
                {
                    //DO NOTHING
                }
            }
            else
            {
                //DO NOTHING
            }
        }

    }
}

