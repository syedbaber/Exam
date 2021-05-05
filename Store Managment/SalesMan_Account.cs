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
    public partial class SalesMan_Account : UserControl
    {
        public SalesMan_Account()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            SalesMan_Account_Add a = new SalesMan_Account_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            SalesMan_Account_Edit a = new SalesMan_Account_Edit();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void Customer_Account_Load(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            SalesMan_Account_Add a = new SalesMan_Account_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }
    }
}
