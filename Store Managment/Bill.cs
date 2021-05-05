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
    public partial class Bill : UserControl
    {
        public string b;
        public Bill()
        {
            InitializeComponent();
        }

        public Bill(string a)
        {
            InitializeComponent();
            b = a;
        }


        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Bill_Add a = new Bill_Add(b);
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Bill_Edit a = new Bill_Edit();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Bill_Add a = new Bill_Add(b);
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }
    }
}
