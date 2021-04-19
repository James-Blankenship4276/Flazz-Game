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

        private void Button_Click(object sender, RoutedEventArgs e)//Mute
        {

        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Start_Menu start = new Start_Menu();
            Settings settings = new Settings();
            main.Background = Brushes.Black;
            start.Background = Brushes.Black;
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Settings settings = new Settings();
            this.Visibility = Visibility.Hidden;//https://stackoverflow.com/questions/33823326/this-close-doesnt-work-in-window-wpf/33823397
            settings.Close();
        }
    }
}
