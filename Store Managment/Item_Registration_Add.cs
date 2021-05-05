using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store_Managment
{
    public partial class Item_Registration_Add : UserControl
    {
        public Item_Registration_Add()
        {
            InitializeComponent();
        }
        private void item_id()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(i_id) from item", Main.Con);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    reg.Text = "1";
                }
                else
                {
                    SqlCommand da1 = new SqlCommand("select max(i_id) from item", Main.Con);
                    int regno = (int)da1.ExecuteScalar();
                    regno = regno + 1;
                    reg.Text = regno.ToString();
                }
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (t1.Text == "" || t3.Text == "" || t4.Text == "")
                {
                    MessageBox.Show("Please Fill All Fields");
                }
                else
                {
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO item (i_id, i_name, i_desc, u_price, w_price, stock) values(@i_id, @i_name, @i_desc, @u_price, @w_price, @stock)", Main.Con); //
                    sqlCmd.Parameters.Add(new SqlParameter("@i_id", reg.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@i_name", t1.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@i_desc", t2.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@u_price", t3.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@w_price", t4.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@stock", t5.Text));
                    sqlCmd.ExecuteNonQuery();
                    Main.Con.Close();
                    MessageBox.Show("Item Saved");
                    t1.Text = String.Empty;
                    t2.Text = String.Empty;
                    t3.Text = String.Empty;
                    t4.Text = String.Empty;
                    t5.Text = String.Empty;
                    item_id();
                }
            }
            catch { Main.Con.Close(); }
        }

        private void Item_Registration_Add_Load(object sender, EventArgs e)
        {
            item_id();
        }

        private void Item_Registration_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            t1.Text = String.Empty;
            t2.Text = String.Empty;
            t3.Text = String.Empty;
            t4.Text = String.Empty;
        }

    }
}
