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
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
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
                data += read[1] + "\n";
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
            Flash flash = new Flash();
            flash.load_quiz();
        }

    }
    public class Flash
    {
        public OleDbConnection cn;
        public int id;
        public string name;


        public List<Flash> quiz1 = new List<Flash>();
        public Flash()
        {
            id = 0;
            name = null;
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
            cn = new OleDbConnection(connectionstring);
        }
        public Flash(int ID, string Name)
        {
            id = ID;
            name = Name;
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
            cn = new OleDbConnection(connectionstring);
        }
        public void load_quiz()
        {
            string query = "select * from Quiz";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            //string data = "";
            while (read.Read())
            {
                int x = Convert.ToInt32(read[0].ToString());
                //string y = read[1].ToString();
                quiz1.Add(new Flash(id = x, name = read[1].ToString()));
            }
        }
    }
    public class Bridges
    {

        public int QuizID;
        public int QuestionID;
        public OleDbConnection cn;
        public List<Bridges> cross = new List<Bridges>();
       
       
      
        public Bridges()
        {
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
            cn = new OleDbConnection(connectionstring);


        }
        public Bridges(int id, int questionid)
        {
            QuizID = id;
            QuestionID = questionid;


        }

        // string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
        // cn = new OleDbConnection(connectionstring);


        public void Load_Bridges()
        {

            Flash flash = new Flash();
            string query = "select * from Quiz_Bridge where QuizID=" + flash.quiz1[0].id;
            OleDbCommand cmd = new OleDbCommand(query, cn);


            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                int x = Convert.ToInt32(read[1].ToString());
                int y = Convert.ToInt32(read[2].ToString());
                cross.Add(new Bridges(x, y));
            }
        }
        public void Questions()
        {
            int i = 0;

            Bridges current = cross[i];
            string query = "select Question from Questions where ID=" + current.QuestionID;
            OleDbCommand cmd = new OleDbCommand(query, cn);
            string data = "";
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                data = read[0].ToString();
            }


        }
    }
    public class Answers : Bridges
    {
        string isAnwser;
        bool iscorrect;
        public OleDbConnection cn;
        Bridges bridges = new Bridges();


        public Answers()
        {

            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
            cn = new OleDbConnection(connectionstring);
        }

        public void load_anwsers() 
        {
            int i = 0;
            Bridges current = cross[i];
            List<Answers> answers = new List<Answers>();

            string query = "Select Answer,correct from Anwsers where QuestionID=" + current.QuestionID;
            OleDbCommand cmd = new OleDbCommand(query, cn);


            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {


            }




        }


    }
}
