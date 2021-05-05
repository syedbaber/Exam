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
    public partial class Supplier_Registration_Edit : UserControl
    {
        public Supplier_Registration_Edit()
        {
            InitializeComponent();
        }

        private void Supplier_Registration_Edit_Load(object sender, EventArgs e)
        {
            all();
        }
       private void all()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select S_id as 'Supplier ID', s_name as 'Name', s_contact as 'Phone No', s_company as 'Company', s_addr as 'Address' from  sup_reg ", Main.Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

       private void s1_TextChanged(object sender, EventArgs e)
       {
           try
           {
               Main.Con.Close();
               Main.Con.Open();
               SqlCommand cmd = new SqlCommand("select S_id as 'Supplier ID', s_name as 'Name', s_contact as 'Phone No', s_company as 'Company', s_addr as 'Address' from  sup_reg where s_name Like '%" + s1.Text + "%'", Main.Con);
               cmd.CommandType = CommandType.Text;
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               g1.DataSource = dt;
               Main.Con.Close();
           }
           catch
           {
               Main.Con.Close();
               MessageBox.Show("Error Found");
           }
      
       }

       private void g1_MouseDoubleClick(object sender, MouseEventArgs e)
       {

       }

       private void g1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
       {
           try
           {
               DataGridViewRow r = g1.Rows[e.RowIndex];
               int did = Convert.ToInt32(g1.Rows[e.RowIndex].Cells[0].Value);
               g1.Rows[e.RowIndex].Selected = true;
               reg.Text = g1.Rows[e.RowIndex].Cells[0].Value.ToString();
               t1.Text = g1.Rows[e.RowIndex].Cells[1].Value.ToString();
               t2.Text = g1.Rows[e.RowIndex].Cells[2].Value.ToString();
               t3.Text = g1.Rows[e.RowIndex].Cells[3].Value.ToString();
               t4.Text = g1.Rows[e.RowIndex].Cells[4].Value.ToString();
           }
           catch { }
       }

       private void gunaAdvenceButton2_Click(object sender, EventArgs e)
       {
           reg.Text = String.Empty;
           t1.Text = String.Empty;
           t2.Text = String.Empty;
           t3.Text = String.Empty;
           t4.Text = String.Empty;
       }

       private void gunaAdvenceButton1_Click(object sender, EventArgs e)
       {
           try
           {
               if (reg.Text == "")
               {
                   MessageBox.Show("Please Select First To Update");
               }
               else
               {
                   if (t2.Text == "" || t3.Text == "")
                   {
                       MessageBox.Show("Please Fill All * Fields");
                   }
                   else
                   {
                       Main.Con.Close();
                       Main.Con.Open();
                       SqlCommand sqlCmd = new SqlCommand("update sup_reg  set s_name = @s_name, s_contact= @s_contact, s_company= @s_company, s_addr= @s_addr where s_id = '" + reg.Text + "'", Main.Con);
                       sqlCmd.Parameters.Add(new SqlParameter("@s_name", t1.Text));
                       sqlCmd.Parameters.Add(new SqlParameter("@s_contact", t2.Text));
                       sqlCmd.Parameters.Add(new SqlParameter("@s_company", t3.Text));
                       sqlCmd.Parameters.Add(new SqlParameter("@s_addr", t4.Text));
                       sqlCmd.ExecuteNonQuery();
                       Main.Con.Close();
                       MessageBox.Show("Supplier Updated");
                       t1.Text = string.Empty;
                       t2.Text = string.Empty;
                       t3.Text = string.Empty;
                       t4.Text = string.Empty;
                       all();
                   }
               }
           }
           catch
           {
               Main.Con.Close();
           }
       }

       private void gunaAdvenceButton3_Click(object sender, EventArgs e)
       {

       }
       
    }
}
