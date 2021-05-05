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
    public partial class Stock_Registraion_Add : UserControl
    {
        public Stock_Registraion_Add()
        {
            InitializeComponent();
        }

        private void Stock_Registraion_Add_Load(object sender, EventArgs e)
        {
            cb1_load();
            g1_load();
        }
        public void cb1_load()
        {
            try
            {
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select i_id, i_name from item", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("i_name", typeof(string));
                dt.Load(reader);
                cb1.DisplayMember = "i_name";
                cb1.ValueMember = "i_id";
                cb1.DataSource = dt;
                Main.Con.Close();
                cb1.SelectedIndex = 0;
            }
            catch { Main.Con.Close(); }
        }
        public void g1_load()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select i_name as 'Item Name', stock as 'Available Stock' from Item ", Main.Con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb1_changed();
        }

        public void cb1_changed()
        {
            try
            {
                int sid = (int)cb1.SelectedValue;
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select stock from item where i_id = '" + sid + "'", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                while (reader.Read())
                {
                    t2.Text = reader["stock"].ToString();
                }
                reader.Close();
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                float st = float.Parse((t2.Text)) + float.Parse((t3.Text));
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand sda = new SqlCommand("update item set stock = '" + st + "' where i_id= '" + cb1.SelectedValue + "' ", Main.Con);
                sda.ExecuteNonQuery();
                Main.Con.Close();
                cb1_changed();
                g1_load();
                MessageBox.Show("Stock Added Successfully");
                t3.Text = String.Empty;
            }
            catch { Main.Con.Close(); }

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try
            {
                float st = float.Parse((t2.Text)) - float.Parse((t3.Text));
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand sda = new SqlCommand("update item set stock = '" + st + "' where i_id= '" + cb1.SelectedValue + "' ", Main.Con);
                sda.ExecuteNonQuery();
                Main.Con.Close();
                cb1_changed();
                g1_load();
                MessageBox.Show("Stock Removed Successfully");
                t3.Text = String.Empty;
            }
            catch { Main.Con.Close(); }
        }

        private void g1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow r = g1.Rows[e.RowIndex];
                g1.Rows[e.RowIndex].Selected = true;
                cb1.Text = g1.Rows[e.RowIndex].Cells[0].Value.ToString();
                t2.Text = g1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { Main.Con.Close(); }
        }

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }

        }
    }
}
