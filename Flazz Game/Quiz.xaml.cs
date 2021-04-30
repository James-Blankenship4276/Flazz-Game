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
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
    

        public Quiz()
        {
            InitializeComponent();
        }

     

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer.Background = Brushes.Green;

            Wrong_1.Click -= Wrong_1_Click;//https://stackoverflow.com/questions/34284232/disable-click-button-event-c-sharp
            Wrong_2.Click -= Wrong_2_Click;//https://stackoverflow.com/questions/34284232/disable-click-button-event-c-sharp
            Wrong_3.Click -= Wrong_3_Click;//https://stackoverflow.com/questions/34284232/disable-click-button-event-c-sharp
        }

        private void Wrong_1_Click(object sender, RoutedEventArgs e)
        {
            Wrong_1.Background = Brushes.Red;
            Answer.Background = Brushes.Green;

            Answer.Click -= Button_Click;
            Wrong_2.Click -= Wrong_2_Click;
            Wrong_3.Click -= Wrong_3_Click;
        }

        private void Wrong_2_Click(object sender, RoutedEventArgs e)
        {
            Wrong_2.Background = Brushes.Red;
            Answer.Background = Brushes.Green;

            Answer.Click -= Button_Click;
            Wrong_1.Click -= Wrong_1_Click;
            Wrong_3.Click -= Wrong_3_Click;
        }

        private void Wrong_3_Click(object sender, RoutedEventArgs e)
        {
            Wrong_3.Background = Brushes.Red;
            Answer.Background = Brushes.Green;

            Answer.Click -= Button_Click;//https://stackoverflow.com/questions/34284232/disable-click-button-event-c-sharp
            Wrong_1.Click -= Wrong_1_Click;
            Wrong_2.Click -= Wrong_2_Click;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
             i = i + 1;
            Bridges bridges = new Bridges();           
            bridges.Questions(i);            
        }
    }
}
