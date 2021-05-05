using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Store_Managment
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from logins where uname='" + t1.Text + "' And pass='" + t2.Text + "'", Main.Con);
                int a = (int)cmd.ExecuteScalar();

                if (a > 0)
                {
                    SqlCommand da = new SqlCommand("select name from logins where uname='" + t1.Text + "'", Main.Con);
                    SqlDataReader reader;
                    reader = da.ExecuteReader();
                    string nm = "";
                    while (reader.Read())
                    {
                        nm = reader["name"].ToString();
                    }
                    reader.Close();
                    Main.Con.Close();
                    HomePage hm = new HomePage(nm);
                    hm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Creditionals");
                }
                Main.Con.Close();

            }
            catch { Main.Con.Close(); }
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void t2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                b1.PerformClick();

            }
        }

        private void t1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                b1.PerformClick();

            }
        }
    }
}
