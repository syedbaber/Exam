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
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Rept_SalesMan a = new Rept_SalesMan();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Rept_SalesmanDet a = new Rept_SalesmanDet();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Rept_Income a = new Rept_Income();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void gunaTileButton4_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Rept_Supplier a = new Rept_Supplier();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }

        private void gunaTileButton5_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Rept_Salesman_Due a = new Rept_Salesman_Due();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            panel.Focus();
            panel.Controls.Add(a);
        }
    }
}
