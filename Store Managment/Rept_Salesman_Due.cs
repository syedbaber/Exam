using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store_Managment
{
    public partial class Rept_Salesman_Due : UserControl
    {
        public Rept_Salesman_Due()
        {
            InitializeComponent();
        }

        private void Rept_Salesman_Due_Load(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Close();
                Main.Con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from cust_reg", Main.Con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Rpt_Salesman_Due cr = new Rpt_Salesman_Due();
                cr.SetDataSource(dt);
                crv.ReportSource = cr;
                cr.Refresh();
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }
    }
}
