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
           // string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame1.accdb";
            //cn = new OleDbConnection(connectionstring);
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
           
            Quiz quiz = new Quiz();
            quiz.Show();      
            this.Visibility = Visibility.Hidden;
            this.Close();
            Flash flash = new Flash();
            //flash.load_quiz();
            Bridges bridges = new Bridges();

            bridges.Load_Bridges();
           
            bridges.Questions(0);
            bridges.Load(0);




            Answers answers = new Answers();
            //quiz.Question.Text = flash.quiz1[3].name;
            //Questions questions1 = new Questions();
            //questions1.Load_Questions(0);



          
            
                quiz.Question.Text = Convert.ToString(bridges.questions[0]);
                //quiz.Answer.Content = Convert.ToString(answers.answers1[0].isAnwser);
            
            
            

        }
            
            //answers.load_anwsers();
            // Quiz quiz1 = new Quiz();


        //}

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Visibility = Visibility.Hidden;//https://stackoverflow.com/questions/33823326/this-close-doesnt-work-in-window-wpf/33823397
            this.Close();
            Flash flash = new Flash();
            //flash.load_quiz();
        }

    }
    public class Flash
    {
        public OleDbConnection cn;
        public int id;
        public string name;


        public List<Flash> quiz1 = new List<Flash>();//List that  holds quiz information 
        public Flash()
        {
        
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
            cn = new OleDbConnection(connectionstring);
            string query = "select * from Quiz";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            //string data = "";
            while (read.Read())// Reads the quiz information into the list
            {
                int x = Convert.ToInt32(read[0].ToString());
                //string y = read[1].ToString();
                quiz1.Add(new Flash(id = x, name = read[1].ToString()));
            }
            
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
            
            while (read.Read())
            {
                int x = Convert.ToInt32(read[0].ToString());
                
                quiz1.Add(new Flash(id = x, name = read[1].ToString()));
            }
        }
    }
    public class Bridges
    {

        public int QuizID1;
        public int QuestionID1;
        public OleDbConnection cn;
        public List<Bridges> cross = new List<Bridges>();//Holds the information to find the questions and answers
        public List<string> questions = new List<string>();// Holds question strings



        public Bridges()
        {
            QuizID1 = 0;
            QuestionID1 = 0;

            


        }
        public Bridges(int id, int questionid)
        {
            QuizID1 = id;
            QuestionID1 = questionid;
           
            
        }

        // string connectionstring = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
        // cn = new OleDbConnection(connectionstring);


        public void Load_Bridges()
        {
            
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
            cn = new OleDbConnection(connectionstring);
            Flash flash = new Flash();
            string query = "select * from QuizBridge where QuizID=" + flash.quiz1[1].id;//Take the quiz ID as a conditinal to find 
            OleDbCommand cmd = new OleDbCommand(query, cn);


            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
           
            while (read.Read())
            {
                int x = Convert.ToInt32(read[1].ToString());//QuizID from Database 
                int y = Convert.ToInt32(read[2].ToString());//QuestionID
                cross.Add(new Bridges(QuizID1 = x, QuestionID1 = y));//Reads into cross List 


            }


        }
        public void Load(int index) {

            Answers answers = new Answers();
            answers.load_anwsers(cross[0]);
        
        
        
        
        }
        public void Questions(int index)
        {
          

            Bridges current = cross[index];
            string query = "select Question from Questions where ID=" + current.QuestionID1;//Reads in  the Question field from the Questions table
            OleDbCommand cmd = new OleDbCommand(query, cn);
         
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                questions.Add(read[0].ToString());//Reads in question text 
                
            }
           


        }
        public int getIndex( int index) {
            return index + 1;
        
        
        
        
        }
       

    }
    public class Answers
    {
        public List<Answers> answers1 = new List<Answers>();//List that holds anwsers
        public string isAnwser;
        public bool iscorrect;
        public OleDbConnection cn;
  


        public Answers()
        {

            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
            cn = new OleDbConnection(connectionstring);
        }
        public Answers(string Anwser, bool correct)
        {


            isAnwser = Anwser;
            iscorrect = correct;
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\blank\Documents\FlazzGame1.accdb";
            cn = new OleDbConnection(connectionstring);
        
    }





        public void load_anwsers(Bridges current)
        {

            Bridges bridges = new Bridges();
            bridges.Load_Bridges();
           
          
            string query = "Select * from Anwsers where QuestionID=" + current.QuestionID1;
            OleDbCommand cmd = new OleDbCommand(query, cn);


            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
      
            while (read.Read())
            {
                bool val = Convert.ToBoolean(read[2].ToString());
                answers1.Add(new Answers(read[1].ToString(), val));

            }
            cn.Close();

        }
    }
   
}
