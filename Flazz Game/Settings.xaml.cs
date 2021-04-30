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

namespace Flazz_Game
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Settings settings = new Settings();
            this.Visibility = Visibility.Hidden;//https://stackoverflow.com/questions/33823326/this-close-doesnt-work-in-window-wpf/33823397
            settings.Close();
        }

        private void Music_on_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
            Music_on.Visibility = Visibility.Visible;
            Music_off.Visibility = Visibility.Visible;
        }

        private void Music_off_Click(object sender, RoutedEventArgs e)
        {
            Sound.MuteBackgroundMusic();
            Music_on.Visibility = Visibility.Visible;
            Music_off.Visibility = Visibility.Visible;
        }
    }
}
