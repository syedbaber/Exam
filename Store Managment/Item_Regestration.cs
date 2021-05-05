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
    public partial class Item_Regestration : UserControl
    {
        public Item_Regestration()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Item_Registration_Add a = new Item_Registration_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Iterm_Registration_Edit a = new Iterm_Registration_Edit();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void Item_Regestration_Load(object sender, EventArgs e)
        {
            cont.Controls.Clear();
            Item_Registration_Add a = new Item_Registration_Add();
            cont.Dock = DockStyle.Fill;
            cont.BringToFront();
            cont.Focus();
            cont.Controls.Add(a);
        }

        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cont_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
