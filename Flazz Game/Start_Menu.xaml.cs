using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Interaction logic for Start_Menu.xaml
    /// </summary>
    public partial class Start_Menu : Window
    {
        public OleDbConnection cn;
        public Start_Menu()
        {
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
            cn = new OleDbConnection(connectionstring);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Categories
        {
        

        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //Difficulty
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Show();
            this.Visibility = Visibility.Hidden;
            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
         
            int i = 0;
            string query = "select * from Quiz";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";

            while (read.Read())
            {
                data += read[1]+ "\n";
            }
            





            Quiz quiz = new Quiz();
            quiz.Show();
            quiz.Question.Text = data;
            this.Visibility = Visibility.Hidden;
            this.Close();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Visibility = Visibility.Hidden;//https://stackoverflow.com/questions/33823326/this-close-doesnt-work-in-window-wpf/33823397
            this.Close();
        }
      
    }
}
