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
using System.Windows.Shapes;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security;
using System.ComponentModel;

namespace Food_Recipe_App
{
    public enum BrowserEmulationVersion
    {
        Default = 0,
        Version7 = 7000,
        Version8 = 8000,
        Version8Standards = 8888,
        Version9 = 9000,
        Version9Standards = 9999,
        Version10 = 10000,
        Version10Standards = 10001,
        Version11 = 11000,
        Version11Edge = 11001
    }
    /// <summary>
    /// Interaction logic for AddRecipeMediaWindow.xaml
    /// </summary>
    public partial class AddRecipeMediaWindow : Window
    {
        
        public EventHandler<AddMediaEventArgs> AddedMedia;
        public AddRecipeMediaWindow()
        {
            InitializeComponent();

            //Set IE browser version
            if (!InternetExplorerBrowserEmulation.IsBrowserEmulationSet())
            {
                InternetExplorerBrowserEmulation.SetBrowserEmulationVersion();
            }

            //Stop media from playing after closing
            this.Closing += new CancelEventHandler(
                (object sender, CancelEventArgs e) =>
                {
                    YoutubeElement.Dispose();
                });

        }

        private void Button_AddMedia_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "Select a video";
            openFileDialog.Filter = "Media file (*.mp4;*.wmv;*.mkv;*.avi,*.mpg,*.mpeg)|*.mp4;*.wmv;*.mkv;*.avi,*.mpg,*.mpeg";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PlayerControlBarElement.Visibility = Visibility.Visible;
                YoutubeElement.Visibility = Visibility.Hidden;
                TextBox_YoutubeURL.Text = String.Empty;
                TextBox_YoutubeURL.IsReadOnly = true;
                LocalVideoElement.Source = new Uri(openFileDialog.FileName, UriKind.Absolute);
                LocalVideoElement.Play();
            }
        }

        private void Button_CancelMedia_Click(object sender, RoutedEventArgs e)
        {
            LocalVideoElement.Stop();
            PlayerControlBarElement.Visibility = Visibility.Collapsed;
            LocalVideoElement.Visibility = Visibility.Hidden;
            TextBox_YoutubeURL.IsReadOnly = false;
            LocalVideoElement.Source = null;
        }

        private void Button_AddMediaComplete_Click(object sender, RoutedEventArgs e)
        {
            if (AddedMedia != null)
            {
                if (TextBox_YoutubeURL.Text != "")
                {
                    AddedMedia(this, new AddMediaEventArgs(new KeyValuePair<bool, string>(true, TextBox_YoutubeURL.Text)));
                }
                else if (LocalVideoElement.Source != null)
                {
                    AddedMedia(this, new AddMediaEventArgs(new KeyValuePair<bool, string>(true, LocalVideoElement.Source.ToString())));
                }
                else
                {
                    AddedMedia(this, new AddMediaEventArgs(new KeyValuePair<bool, string>(false, "")));
                }
            }
            this.Close();
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            PlayerControlBarElement.Visibility = Visibility.Collapsed;
            YoutubeElement.Visibility = Visibility.Visible;
            string youtubeURL = TextBox_YoutubeURL.Text;
            if (youtubeURL != "")
            {
                if (!youtubeURL.Contains("embed"))
                {
                    string ID = youtubeURL.Substring(youtubeURL.IndexOf('=') + 1);
                    youtubeURL = String.Format("https://www.youtube.com/embed/{0}", ID);
                }
                Button_AddMedia.IsEnabled = false;
                string html = "<html><title></title>";
                html += "<iframe width='560' height='315' " +
                    $"src='{youtubeURL}' " +
                    "frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture'></iframe>";
                html += "</html>";

                YoutubeElement.NavigateToString(html);
            }
            else
                Button_AddMedia.IsEnabled = true;
        }

        // Play the media.
        void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs args)
        {

            // The Play method will begin the media if it is not currently active or
            // resume media if it is paused. This has no effect if the media is
            // already running.
            LocalVideoElement.Play();
        }

        // Pause the media.
        void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs args)
        {

            // The Pause method pauses the media if it is currently running.
            // The Play method can be used to resume.
            LocalVideoElement.Pause();
        }

        // When the media opens, initialize the "Seek To" slider maximum value
        // to the total number of miliseconds in the length of the media clip.
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            timelineSlider.Maximum = LocalVideoElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        // When the media playback is finished. Stop() the media to seek to media start.
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            LocalVideoElement.Stop();
        }

        // Jump to different parts of the media (seek to).
        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;

            // Overloaded constructor takes the arguments days, hours, minutes, seconds, milliseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            LocalVideoElement.Position = ts;
        }

        
    }

    /// <summary>
    /// Class for handling WPF IE Browser
    /// </summary>
    public class InternetExplorerBrowserEmulation
    {
        private const string InternetExplorerRootKey = @"Software\Microsoft\Internet Explorer";
        private const string BrowserEmulationKey = InternetExplorerRootKey + @"\Main\FeatureControl\FEATURE_BROWSER_EMULATION";

        public static int GetInternetExplorerMajorVersion()
        {
            int result;

            result = 0;

            try
            {
                RegistryKey key;

                key = Registry.LocalMachine.OpenSubKey(InternetExplorerRootKey);

                if (key != null)
                {
                    object value;

                    value = key.GetValue("svcVersion", null) ?? key.GetValue("Version", null);

                    if (value != null)
                    {
                        string version;
                        int separator;

                        version = value.ToString();
                        separator = version.IndexOf('.');
                        if (separator != -1)
                        {
                            int.TryParse(version.Substring(0, separator), out result);
                        }
                    }
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
            }

            return result;
        }

        public static bool SetBrowserEmulationVersion(BrowserEmulationVersion browserEmulationVersion)
        {
            bool result;

            result = false;

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);

                if (key != null)
                {
                    string programName;

                    programName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                    if (browserEmulationVersion != BrowserEmulationVersion.Default)
                    {
                        // if it's a valid value, update or create the value
                        key.SetValue(programName, (int)browserEmulationVersion, RegistryValueKind.DWord);
                    }
                    else
                    {
                        // otherwise, remove the existing value
                        key.DeleteValue(programName, false);
                    }

                    result = true;
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
            }

            return result;
        }

        public static bool SetBrowserEmulationVersion()
        {
            int ieVersion;
            BrowserEmulationVersion emulationCode;

            ieVersion = GetInternetExplorerMajorVersion();

            if (ieVersion >= 11)
            {
                emulationCode = BrowserEmulationVersion.Version11;
            }
            else
            {
                switch (ieVersion)
                {
                    case 10:
                        emulationCode = BrowserEmulationVersion.Version10;
                        break;
                    case 9:
                        emulationCode = BrowserEmulationVersion.Version9;
                        break;
                    case 8:
                        emulationCode = BrowserEmulationVersion.Version8;
                        break;
                    default:
                        emulationCode = BrowserEmulationVersion.Version7;
                        break;
                }
            }

            return SetBrowserEmulationVersion(emulationCode);
        }

        public static BrowserEmulationVersion GetBrowserEmulationVersion()
        {
            BrowserEmulationVersion result;

            result = BrowserEmulationVersion.Default;

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);
                if (key != null)
                {
                    string programName;
                    object value;

                    programName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);
                    value = key.GetValue(programName, null);

                    if (value != null)
                    {
                        result = (BrowserEmulationVersion)Convert.ToInt32(value);
                    }
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
            }

            return result;
        }


        public static bool IsBrowserEmulationSet()
        {
            return GetBrowserEmulationVersion() != BrowserEmulationVersion.Default;
        }
    }

    public class AddMediaEventArgs : EventArgs
    {
        public KeyValuePair<bool, string> Media;
        public AddMediaEventArgs(KeyValuePair<bool,string> media)
        {
            this.Media = media;
        }
    }
}
