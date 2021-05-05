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
    public partial class SalesMan_Registeration_Add : UserControl
    {
        public SalesMan_Registeration_Add()
        {
            InitializeComponent();
        }

        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Registeration_Add_Load(object sender, EventArgs e)
        {
            cust_id();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (t1.Text == "" )
                {
                    MessageBox.Show("Please Enter Salesman Name !!!");
                }
                else
                {

                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO cust_reg (c_id, c_name, c_contact, c_cnic, c_addr, c_due) values(@c_id, @c_name, @c_contact, @c_cnic, @c_addr, @c_due)", Main.Con);
                    sqlCmd.Parameters.Add(new SqlParameter("@c_id", reg.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@c_name", t1.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@c_contact", t2.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@c_cnic", t3.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@c_addr", t4.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@c_due", "0"));
                    sqlCmd.ExecuteNonQuery();
                    Main.Con.Close();
                    MessageBox.Show("Salesman Saved");
                    t1.Text = String.Empty;
                    t2.Text = String.Empty;
                    t3.Text = String.Empty;
                    t4.Text = String.Empty;
                    cust_id();
                }
            }
            catch { Main.Con.Close(); }
        }
        private void cust_id()
        {
            try
            {
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(c_id) from cust_reg", Main.Con);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    reg.Text = "1";
                }
                else
                {
                    SqlCommand da1 = new SqlCommand("select max(c_id) from cust_reg", Main.Con);
                    int regno = (int)da1.ExecuteScalar();
                    regno = regno + 1;
                    reg.Text = regno.ToString();
                }
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try
            {
                t1.Text = String.Empty;
                t2.Text = String.Empty;
                t3.Text = String.Empty;
                t4.Text = String.Empty;
                cust_id();
            }
            catch { Main.Con.Close(); }
        }
    }
}
