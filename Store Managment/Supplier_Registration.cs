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
    public partial class Supplier_Registration : UserControl
    {
        public Supplier_Registration()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Supplier_Registeration_Add a = new Supplier_Registeration_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Supplier_Registration_Edit a = new Supplier_Registration_Edit();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void Supplier_Registration_Load(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Supplier_Registeration_Add a = new Supplier_Registeration_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }
    }
}
