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


namespace Flazz_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Start menu
        {
            Start_Menu start = new Start_Menu();
            start.Show();
            this.Visibility = Visibility.Hidden;//https://stackoverflow.com/questions/33823326/this-close-doesnt-work-in-window-wpf/33823397
            this.Close();
           
        }

        private void Make_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Visibility = Visibility.Hidden;//https://stackoverflow.com/questions/33823326/this-close-doesnt-work-in-window-wpf/33823397
            this.Close();
            settings.Show();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Close();
            Application.Current.Shutdown();
          
        }
    }
}
