using System.Configuration;
using System.Windows;

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public delegate void DeathHandler();
        public event DeathHandler Dying;
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var value = ConfigurationManager.AppSettings["ShowSplashScreen"];
            bool showSplash = bool.Parse(value);
            if (!showSplash)
            {
                isVisibleSplashScreen.IsChecked = false;
            }
            else
            {
                isVisibleSplashScreen.IsChecked = true;
            }
        }

        private void isVisibleSplashScreen_Checked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            config.AppSettings.Settings["ShowSplashScreen"].Value = "true";
            config.Save(ConfigurationSaveMode.Full, true);
        }

        private void isVisibleSplashScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            config.AppSettings.Settings["ShowSplashScreen"].Value = "false";
            config.Save(ConfigurationSaveMode.Full, true);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Dying?.Invoke();
        }
    }
}
