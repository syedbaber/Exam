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
    public partial class Supplier_Registeration_Add : UserControl
    {
        public Supplier_Registeration_Add()
        {
            InitializeComponent();
        }

        private void Supplier_Registeration_Add_Load(object sender, EventArgs e)
        {
            sup_id();
        }
        private void sup_id()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(s_id) from sup_reg", Main.Con);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    reg.Text = "1";
                }
                else
                {
                    SqlCommand da1 = new SqlCommand("select max(s_id) from sup_reg", Main.Con);
                    int regno = (int)da1.ExecuteScalar();
                    regno = regno + 1;
                    reg.Text = regno.ToString();
                }
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (t1.Text == "")
                {
                    MessageBox.Show("Please Enter Name");
                }
                else
                {
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO sup_reg (s_id, s_name, s_contact, s_company, s_addr, due_tot) values(@s_id, @s_name, @s_contact, @s_company, @s_addr, '"+ 0 +"')", Main.Con); //
                    sqlCmd.Parameters.Add(new SqlParameter("@s_id", reg.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@s_name", t1.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@s_contact", t2.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@s_company", t3.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@s_addr", t4.Text));
                    sqlCmd.ExecuteNonQuery();
                    Main.Con.Close();
                    MessageBox.Show("Suplier Saved");
                    t1.Text = String.Empty;
                    t2.Text = String.Empty;
                    t3.Text = String.Empty;
                    t4.Text = String.Empty;
                    sup_id();
         
                }

            }

            catch
            {
                Main.Con.Close();
            }
        }
    }
}
