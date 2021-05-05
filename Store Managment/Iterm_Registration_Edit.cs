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
    public partial class Iterm_Registration_Edit : UserControl
    {
        public Iterm_Registration_Edit()
        {
            InitializeComponent();
        }

        private void Iterm_Registration_Edit_Load(object sender, EventArgs e)
        {
            all();
        }
        private void all()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select i_id as 'Item ID', i_name as 'Item Name', i_desc as 'Description', u_price as 'Unit Process', w_price as 'Purchase Price' from  item ", Main.Con);
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
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select i_id as 'Item ID', i_name as 'Item Name', i_desc as 'Description', u_price as 'Selling Process', w_price as 'Retail Price' from  item where i_name Like '%" + s1.Text + "%'", Main.Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
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
                        SqlCommand sqlCmd = new SqlCommand("update item set i_name = @i_name, i_desc= @i_decs, u_price= @u_price, w_price= @w_price where i_id = '" + reg.Text + "'", Main.Con);
                        sqlCmd.Parameters.Add(new SqlParameter("@i_name", t1.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@i_decs", t2.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@u_price", t3.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@w_price", t4.Text));
                        sqlCmd.ExecuteNonQuery();
                        Main.Con.Close();
                        MessageBox.Show("Item Updated");
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

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
