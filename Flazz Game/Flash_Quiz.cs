//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.OleDb;
//using System;
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
    public class Flash_Quiz
    {
        public OleDbConnection cn;
       
            List<Flash_Quiz> flash = new Flash_Quiz();
        public Flash_Quiz() {
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\FlazzGame.accdb";
            cn = new OleDbConnection(connectionstring);
            InitializeComponent();
        }

        public load_quiz() {
            string query = "select * from Quiz";
        
            cn.open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read()) {
                int x = Convert.ToInt32(read[0].ToString);
                flash.Add(new Flash_Quiz(x, read[1].Tostring));                                   
            }
            




        }

    }
}
