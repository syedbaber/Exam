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
    public partial class SalesMan_Registration_Edit : UserControl
    {
        public SalesMan_Registration_Edit()
        {
            InitializeComponent();
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
                    if (t3.Text == "" || t2.Text == "")
                    {
                        MessageBox.Show("Please Fill All * Fields");
                    }
                    else
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlCommand sqlCmd = new SqlCommand("update cust_reg set c_name= @c_name, c_contact= @c_contact, c_cnic = @c_cnic, c_addr= @c_addr where c_id = '" + reg.Text + "'", Main.Con);
                        sqlCmd.Parameters.Add(new SqlParameter("@c_name", t1.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@c_contact", t2.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@c_cnic", t3.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@c_addr", t4.Text));
                        sqlCmd.ExecuteNonQuery();
                        Main.Con.Close();
                        MessageBox.Show("Salesman Updated");
                        t1.Text = string.Empty;
                        t3.Text = string.Empty;
                        t2.Text = string.Empty;
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

        private void Customer_Registration_Edit_Load(object sender, EventArgs e)
        {
            
            all();
        }
        private void all()
        {

            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select c_id as 'ID', C_name as 'Salesman Name', c_contact as 'Phone No', c_cnic as 'CNIC', c_addr as 'Address' from  cust_reg", Main.Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
           
        }


        private void gunaTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
            reg.Text = string.Empty;
            t1.Text = string.Empty;
            t3.Text = string.Empty;
            t2.Text = string.Empty;
            t4.Text = string.Empty;
        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select c_id as 'ID', C_name as 'Salesman Name', c_contact as 'Phone No', c_cnic as 'CNIC', c_addr as 'Address' from  cust_reg where  c_name Like '%" + s1.Text + "%'", Main.Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
           
        }
    }
}
