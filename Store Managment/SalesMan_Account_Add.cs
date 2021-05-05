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
    public partial class SalesMan_Account_Add : UserControl
    {
        public SalesMan_Account_Add()
        {
            InitializeComponent();
           // t5.Text = a;

        }

        private void Customer_Account_Add_Load(object sender, EventArgs e)
        {
            try
            {
                trans_id();
                cb_load();
                d1.Value = System.DateTime.Now;
                sum();
            }
            catch { Main.Con.Close(); }
        }

        private void trans_id()
        {
            try
            {
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(trans_id) from cust_ac", Main.Con);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    reg.Text = "1";
                }
                else
                {
                    SqlCommand da1 = new SqlCommand("select max(trans_id) from cust_ac", Main.Con);
                    int regno = (int)da1.ExecuteScalar();
                    regno = regno + 1;
                    reg.Text = regno.ToString();
                }
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }

        private void sum()
        {
            try {
                float paid;
                float tot_dues;

                if (t3.Text == "")
                {
                    paid = 0;
                }
                else { paid = float.Parse(t3.Text); }

                if (t4.Text == "")
                {
                    tot_dues = 0;
                }
                else { tot_dues = float.Parse(t4.Text); }


                float totals = float.Parse(t2.Text) - paid;
                t4.Text = totals.ToString();
            }
            catch { }
        }

        private void cb_load()
        {

            try
            {
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select c_id, c_name from cust_reg", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("c_name", typeof(string));
                dt.Load(reader);
                cb1.DisplayMember = "c_name";
                cb1.ValueMember = "c_id";
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
                SqlCommand da = new SqlCommand("select c_due from cust_reg where c_id = '" + sid + "'", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                while (reader.Read())
                {
                    t2.Text = reader["c_due"].ToString();
                }
                reader.Close();
                Main.Con.Close();
                sum();
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (t3.Text == "") 
                {
                    MessageBox.Show("Please Add Some Amount");
                }
                else{
                     
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO cust_ac (trans_id, c_id, inv_desc, t_date, due, paid, due_tot, rec_by) values(@trans_id, @c_id, @inv_desc, @t_date, @due, @paid, @due_tot, @rec_by)", Main.Con); //
                sqlCmd.Parameters.Add(new SqlParameter("@trans_id", reg.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@c_id", (int)cb1.SelectedValue));
                sqlCmd.Parameters.Add(new SqlParameter("@inv_desc", t1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@t_date", d1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due", t2.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@paid", t3.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due_tot", t4.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@rec_by", t5.Text));
                sqlCmd.ExecuteNonQuery();

                SqlCommand sqlCmd1 = new SqlCommand("Update cust_reg set c_due = '" + t4.Text + "' where c_id = '" + cb1.SelectedValue + "' ", Main.Con);
                sqlCmd1.ExecuteNonQuery();
                Main.Con.Close();
                MessageBox.Show("Transaction Saved");
                t1.Text = String.Empty;
                t3.Text = String.Empty;
                t4.Text = String.Empty;
                t5.Text = String.Empty;
                cb1.SelectedIndex = 0;
                trans_id();
                }

                
            }
            catch { Main.Con.Close(); }
        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO cust_ac (trans_id, c_id, inv_desc, t_date, due, paid, due_tot, rec_by) values(@trans_id, @c_id, @inv_desc, @t_date, @due, @paid, @due_tot, @rec_by)", Main.Con); //
                sqlCmd.Parameters.Add(new SqlParameter("@trans_id", reg.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@c_id", (int)cb1.SelectedValue));
                sqlCmd.Parameters.Add(new SqlParameter("@inv_desc", t1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@t_date", d1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due", t2.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@paid", t3.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due_tot", t4.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@rec_by", t5.Text));

                sqlCmd.ExecuteNonQuery();

                SqlCommand sqlCmd1 = new SqlCommand("Update cust_reg set c_due = '" + t4.Text + "' where c_id = '" + cb1.SelectedValue + "' ", Main.Con);
                sqlCmd1.ExecuteNonQuery();
                Main.Con.Close();
                MessageBox.Show("Transaction Saved");

                SqlDataAdapter da = new SqlDataAdapter("select trans_id, cg.c_name, ca.inv_desc, ca.t_date, ca.due, ca.paid, ca.rec_by from cust_ac ca, cust_reg cg where ca.c_id = cg.c_id and  trans_id = '" + reg.Text + "'", Main.Con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Reciept cr = new Reciept();
                cr.SetDataSource(dt);
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rdoc = cr;
                    rdoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
                    rdoc.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage);
                }
                t1.Text = String.Empty;
                t3.Text = String.Empty;
                t4.Text = String.Empty;
                t5.Text = String.Empty;
                cb1.SelectedIndex = 0;
                trans_id();
            }
            catch { Main.Con.Close(); }
        }

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            t1.Text = String.Empty;
            t5.Text = String.Empty;
            t3.Text = String.Empty;
        }

        private void t5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
