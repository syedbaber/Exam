using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Managment
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(string nm )
        {
            InitializeComponent();
            l0.Text = nm;
        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Register a = new Register();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Supplier_Account a = new Supplier_Account();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void gunaTileButton4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Bill a = new Bill(l0.Text);
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage a = new HomePage();
            a.Show();
            
        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            SalesMan_Account a = new SalesMan_Account();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void m4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Supplier_Account a = new Supplier_Account();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void m2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            SalesMan_Account a = new SalesMan_Account();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);

        }

        private void m3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Register a = new Register();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void m1_Click(object sender, EventArgs e)
        {
            string nm = l0.Text;
            this.Hide();
            HomePage a = new HomePage(nm);
            a.Show();
        }

        private void m5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Bill a = new Bill(l0.Text);
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void gunaTileButton5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Backup a = new Backup();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void gunaTileButton6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Reports a = new Reports();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void m6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Reports a = new Reports();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }
        private void m7_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Admin a = new Admin();
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
            panel3.Focus();
            panel3.Controls.Add(a);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
