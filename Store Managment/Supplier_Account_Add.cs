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
    public partial class Supplier_Account_Add : UserControl
    {
        public Supplier_Account_Add()
        {
            InitializeComponent();
        }

        private void Supplier_Account_Add_Load(object sender, EventArgs e)
        {
            try
            {
                cb_load();
                trans_id();
                sum();
                d1.Value = System.DateTime.Now;
            }
            catch { Main.Con.Close(); }
        }

        private void sum()
        {
            try
            {
                float inv;
                float paid;
                float tot_dues;

                if (t3.Text == "")
                {
                    inv = 0;

                }
                else { inv = float.Parse(t3.Text); }

                if (t4.Text == "")
                {
                    paid = 0;

                }
                else { paid = float.Parse(t4.Text); }

                if (t5.Text == "")
                {
                    tot_dues = 0;

                }
                else { tot_dues = float.Parse(t5.Text); }


                float totals = inv - paid + float.Parse(t2.Text);
                t5.Text = totals.ToString();
            }
            catch { }
            
        }
        private void cb_load()
        {
            try
            {
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select s_id, s_name from sup_reg", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("s_name", typeof(string));
                dt.Load(reader);
                cb1.DisplayMember = "s_name";
                cb1.ValueMember = "s_id";
                cb1.DataSource = dt;
                Main.Con.Close();
                cb1.SelectedIndex = 0;
            }
            catch { Main.Con.Close(); }

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sid = (int)cb1.SelectedValue;
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select  due_tot from sup_reg where s_id = '" + sid + "'", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                while (reader.Read())
                {
                    t2.Text = reader["due_tot"].ToString();
                }
                reader.Close();
                Main.Con.Close();
                sum();
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO sup_ac (trans_id, s_id, inv_desc,inv_amount, t_date, paid_amount, due, tot_due) values(@trans_id, @s_id, @inv_desc,@inv_amount, @t_date, @paid_amount, @due, @tot_due)", Main.Con); //
                sqlCmd.Parameters.Add(new SqlParameter("@trans_id", reg.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@s_id", (int)cb1.SelectedValue));
                sqlCmd.Parameters.Add(new SqlParameter("@inv_desc", t1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@t_date", d1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@inv_amount", t3.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@paid_amount", t4.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due", t2.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@tot_due", t5.Text));
                sqlCmd.ExecuteNonQuery();
                SqlCommand sqlCmd1 = new SqlCommand("Update sup_reg set due_tot = '" + t5.Text + "' where s_id = '" + cb1.SelectedValue + "' ", Main.Con);
                sqlCmd1.ExecuteNonQuery();
                Main.Con.Close();
                MessageBox.Show("Transaction Saved");
                t1.Text = String.Empty;
                t3.Text = String.Empty;
                t4.Text = String.Empty;
                cb1.SelectedIndex = 0;
                trans_id();
            }
            catch { Main.Con.Close(); }
        }
        private void trans_id()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(trans_id) from sup_ac", Main.Con);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    reg.Text = "1";
                }
                else
                {
                    SqlCommand da1 = new SqlCommand("select max(trans_id) from sup_ac", Main.Con);
                    int regno = (int)da1.ExecuteScalar();
                    regno = regno + 1;
                    reg.Text = regno.ToString();
                }
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

        private void t2_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void t4_TextChanged(object sender, EventArgs e)
        {
            sum();
        }
    }
}
