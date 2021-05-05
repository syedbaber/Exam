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
    public partial class Admin_Edit : UserControl
    {
        public Admin_Edit()
        {
            InitializeComponent();
        }

        private void Admin_Edit_Load(object sender, EventArgs e)
        {
            refreshgv();
        }
        private void refreshgv()
        {
            try
            {
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select name as 'Name', uname as 'Username', pass as 'Password' from Logins where uname != 'Master'", Main.Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Open();
                SqlCommand cd = new SqlCommand("Select count(uname) from Logins where uname='" + t1.Text + "';", Main.Con);
                int a = (int)cd.ExecuteScalar();
                Main.Con.Close();
                if (a == 0)
                {
                    MessageBox.Show("Invalid Username Name To Delete");
                }
                else
                {
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand cd1 = new SqlCommand("Select uname from Logins where uname='" + t1.Text + "';", Main.Con);
                    string b = (string)cd1.ExecuteScalar();
                    Main.Con.Close();
                    if (b == "Master")
                    {
                        MessageBox.Show("You Can Not Delete Master User");
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Really Want To Delete User?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Main.Con.Close();
                            Main.Con.Open();
                            SqlCommand cmd = new SqlCommand("delete from Logins where uname = '" + t1.Text + "'", Main.Con);
                            cmd.ExecuteNonQuery();
                            Main.Con.Close();
                            MessageBox.Show("User Updated Successfully");
                            t1.Text = String.Empty;
                            t2.Text = String.Empty;
                            t3.Text = String.Empty;
                            refreshgv();
                        }
                    }
                }
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Open();
                SqlCommand cd = new SqlCommand("Select count(uname) from Logins where uname='" + t1.Text + "';", Main.Con);
                int a = (int)cd.ExecuteScalar();
                Main.Con.Close();
                if (a == 0)
                {
                    MessageBox.Show("Invalid Username Name To Update");
                }
                else if (t2.Text == "" || t1.Text == "")
                {
                    MessageBox.Show("Please Enter Name & Password");
                }
                else
                {
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand cd1 = new SqlCommand("Select uname from Logins where uname='" + t1.Text + "';", Main.Con);
                    string b = (string)cd1.ExecuteScalar();
                    Main.Con.Close();
                    if (b == "Master")
                    {
                        if (MessageBox.Show("Do You Really Want To Update Master User?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Main.Con.Open();
                            SqlCommand cmd = new SqlCommand("update Logins set pass ='" + t2.Text + "' where uname = '" + t1.Text + "'", Main.Con);
                            cmd.ExecuteNonQuery();
                            Main.Con.Close();
                            MessageBox.Show("Password for Master User Updated Successfully");
                            t1.Text = String.Empty;
                            t2.Text = String.Empty;
                            t3.Text = String.Empty;
                            refreshgv();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Really Want To Update User?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Main.Con.Open();
                            SqlCommand cmd = new SqlCommand("update Logins set pass ='" + t2.Text + "', name ='" + t3.Text + "' where uname = '" + t1.Text + "'", Main.Con);
                            cmd.ExecuteNonQuery();
                            Main.Con.Close();
                            MessageBox.Show("User Updated Successfully");
                            t1.Text = String.Empty;
                            t2.Text = String.Empty;
                            t3.Text = String.Empty;
                            refreshgv();
                        }
                    }
                }
            }
            catch { Main.Con.Close(); }
        }

        private void g1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow r = g1.Rows[e.RowIndex];
                g1.Rows[e.RowIndex].Selected = true;
                t3.Text = g1.Rows[e.RowIndex].Cells[0].Value.ToString();
                t1.Text = g1.Rows[e.RowIndex].Cells[1].Value.ToString();
                t2.Text = g1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { Main.Con.Close(); }
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
