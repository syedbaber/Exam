using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Managment
{
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Admin_Add a = new Admin_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Admin_Edit a = new Admin_Edit();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Admin_Add a = new Admin_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }
    }
}
