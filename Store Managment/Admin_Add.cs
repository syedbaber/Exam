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
    public partial class Admin_Add : UserControl
    {
        public Admin_Add()
        {
            InitializeComponent();
            
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (t1.Text == "" || t2.Text == "" || t3.Text == "")
                {
                    MessageBox.Show("Please Fill All * Fields");
                }
                else
                {
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand Cmd1 = new SqlCommand("select count(uname) from Logins where uname = '" + t1.Text + "' ", Main.Con);
                    int diff = (int)Cmd1.ExecuteScalar();
                    SqlCommand Cmd2 = new SqlCommand("select count(name) from Logins where name = '" + t3.Text + "' ", Main.Con);
                    int diff1 = (int)Cmd2.ExecuteScalar();

                    if (diff > 0)
                    {
                        MessageBox.Show("Username Already Exist, Please Change");
                    }
                    else if(diff1 > 0)
                    {
                         MessageBox.Show("User Already Exist");
                    }
                    else
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlCommand sqlCmd = new SqlCommand("INSERT INTO Logins (name,uname, pass) values(@name,@uname, @pass)", Main.Con);
                        sqlCmd.Parameters.Add(new SqlParameter("@name", t3.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@uname", t1.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@pass", t2.Text));
                        sqlCmd.ExecuteNonQuery();
                        Main.Con.Close();
                        MessageBox.Show("User Saved");
                        t1.Text = String.Empty;
                        t2.Text = String.Empty;
                        t3.Text = String.Empty;

                    }
                }
            }
            catch { Main.Con.Close(); }
             
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
