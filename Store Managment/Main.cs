using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Store_Managment
{
    class Main
    {

        public static String return_string()
        {
            using (StreamReader sr = new StreamReader("Settings.txt"))
            {
                String line = sr.ReadToEnd();

                return line;
            }
        }

        public static SqlConnection Con = new SqlConnection(return_string());


    }
}
