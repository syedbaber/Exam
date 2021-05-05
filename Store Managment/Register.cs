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
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Supplier_Registration a = new Supplier_Registration();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Item_Regestration a = new Item_Regestration();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            SalesMan_Registration a = new SalesMan_Registration();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void gunaTileButton4_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Stock_Registraion_Add a = new Stock_Registraion_Add();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }
    }
}
