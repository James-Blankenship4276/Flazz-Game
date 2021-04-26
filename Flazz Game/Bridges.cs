//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
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
   public class Bridges 
    {
       
        int QuizID;
        int QuestionID;
        public OleDbConnection cn;
        public Bridges()
        {
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
            cn = new OleDbConnection(connectionstring);


        }
        public void Load_Bridges()
        {

           
            string query = "select * from Quiz_Bridge where QuizID=" ;
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
