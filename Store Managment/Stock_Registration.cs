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
    public partial class Stock_Registration : UserControl
    {
        public Stock_Registration()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Stock_Registraion_Add a = new Stock_Registraion_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Stock_Registration_Edit a = new Stock_Registration_Edit();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void Stock_Registration_Load(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Stock_Registraion_Add a = new Stock_Registraion_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }
    }
}
