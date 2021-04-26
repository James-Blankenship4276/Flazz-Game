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
   public class Flash
    {
        public OleDbConnection cn;
        public int id;
        public string name;

        public List<Flash> Quiz1 = new List<Flash>();
        public Flash() {

            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
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
               string y = read[1].ToString();
                Quiz1.Add(new Quiz1(id = x, read[1].ToString()));
            }
        }
    }
}
