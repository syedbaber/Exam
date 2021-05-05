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
    public partial class Supplier_Account_Edit : UserControl
    {
        public Supplier_Account_Edit()
        {
            InitializeComponent();
        }

        private void Supplier_Account_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                cb_load();
                dtdd.Value = System.DateTime.Now;
                rd1.Checked = true;
                all();
                sum();
                var today = DateTime.Today;
                var lastmonth = new DateTime(today.Year, today.Month, 1);
                d2.Value = lastmonth;
                d3.Value = System.DateTime.Now;
            }
            catch { Main.Con.Close(); }
        }

        private void sum()
        {
            try
            {
                int inv;
                int paid;
                int tot_dues;
                int pre_dues;

                if (t3.Text == "")
                {
                    inv = 0;
                }
                else { inv = int.Parse(t3.Text); }

                if (t4.Text == "")
                {
                    paid = 0;
                }
                else { paid = int.Parse(t4.Text); }

                if (t5.Text == "")
                {
                    tot_dues = 0;
                }
                else { tot_dues = int.Parse(t5.Text); }

                if (t2.Text == "")
                {
                    pre_dues = 0;
                }
                else { pre_dues = int.Parse(t2.Text); }


                int totals = inv - paid + pre_dues;
                t5.Text = totals.ToString();
            }
            catch { Main.Con.Close(); }
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
            catch { }
        }

        private void all()
        {
            try
            {
                if (rd1.Checked)
                {
                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', s_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  inv_amount as 'Invoice Payment',  paid_amount as 'paid amount', tot_due as 'Latest Due' from  sup_ac sa, sup_reg sg where sg.s_id=sa.s_id and t_date = '" + dtdd.Text + "'", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g1.DataSource = dt;
                    Main.Con.Close();
                }

                if (rd2.Checked)
                {
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', s_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  inv_amount as 'Invoice Payment',  paid_amount as 'paid amount', tot_due as 'Latest Due' from  sup_ac sa, sup_reg sg where sg.s_id=sa.s_id and t_date between '" + d2.Text + "' and '" + d3.Text + "'", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g1.DataSource = dt;
                    Main.Con.Close();
                }
            }
            catch { Main.Con.Close(); }
        }


        private void searchs()
        {
            try
            {
                if (rd1.Checked)
                {
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', s_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  inv_amount as 'Invoice Payment',  paid_amount as 'paid amount', tot_due as 'Latest Due' from  sup_ac sa, sup_reg sg where sg.s_id=sa.s_id and t_date = '" + dtdd.Text + "' and sg.s_name Like '%" + s1.Text + "%'", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g1.DataSource = dt;
                    Main.Con.Close();
                }

                if (rd2.Checked)
                {
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', s_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  inv_amount as 'Invoice Payment',  paid_amount as 'paid amount', tot_due as 'Latest Due' from  sup_ac sa, sup_reg sg where sg.s_id=sa.s_id and sg.s_name Like '%" + s1.Text + "%' and t_date between '" + d2.Text + "' and '" + d3.Text + "'", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g1.DataSource = dt;
                    Main.Con.Close();
                }
            }
            catch { Main.Con.Close(); }
        }



        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {
            searchs();
        }

        private void g1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow r = g1.Rows[e.RowIndex];
                int did = Convert.ToInt32(g1.Rows[e.RowIndex].Cells[0].Value);
                g1.Rows[e.RowIndex].Selected = true;
                reg.Text = g1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cb1.Text = g1.Rows[e.RowIndex].Cells[1].Value.ToString();
                t1.Text = g1.Rows[e.RowIndex].Cells[2].Value.ToString();
                d1.Value = Convert.ToDateTime(g1.Rows[e.RowIndex].Cells[3].Value.ToString());
                t2.Text = g1.Rows[e.RowIndex].Cells[4].Value.ToString();
                t3.Text = g1.Rows[e.RowIndex].Cells[5].Value.ToString();
                t4.Text = g1.Rows[e.RowIndex].Cells[6].Value.ToString();
                t5.Text = g1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { Main.Con.Close(); }
        }

        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
            l1.Visible = false;
            d2.Visible = false;
            d3.Visible = false;
            all();
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
            l1.Visible = true;
            d2.Visible = true;
            d3.Visible = true;
            all();
            all();
        }

        private void t2_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void t4_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (reg.Text == "")
                {
                    MessageBox.Show("Please Select First To Update");
                }
                else
                {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlCommand sqlCmd = new SqlCommand("update sup_ac  set s_id = @s_name, inv_desc= @inv_desc, t_date= @t_date, inv_amount= @inv_amount, paid_amount = @paid_amount, due=@due, tot_due=@tot_due where trans_id = '" + reg.Text + "'", Main.Con);
                        sqlCmd.Parameters.Add(new SqlParameter("@s_name", cb1.SelectedValue));
                        sqlCmd.Parameters.Add(new SqlParameter("@inv_desc", t1.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@t_date", d1.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@inv_amount", t3.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@paid_amount", t4.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@due", t2.Text));
                        sqlCmd.Parameters.Add(new SqlParameter("@tot_due", t5.Text));
                        sqlCmd.ExecuteNonQuery();

                        SqlCommand sqlCmd1 = new SqlCommand("update sup_reg  set due_tot = @due_tot  where s_id = '" + cb1.SelectedValue + "'", Main.Con);
                        sqlCmd1.Parameters.Add(new SqlParameter("@due_tot", t5.Text));
                        sqlCmd1.ExecuteNonQuery();
                        Main.Con.Close();
                        MessageBox.Show("Trasaction Updated");

                        reg.Text = string.Empty; 
                        t1.Text = string.Empty;
                        t3.Text = string.Empty;
                        t2.Text = string.Empty;
                        t4.Text = string.Empty;
                        all();
                    
                }
            }
            catch
            {
                MessageBox.Show("Please Fill All Values");
                Main.Con.Close();
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (reg.Text == "")
                {
                    MessageBox.Show("Please Select First To Delete");
                }
                else
                {
                    double invo = double.Parse(t3.Text);
                    double pds = double.Parse(t4.Text);
                    double tda = double.Parse(t5.Text);
                    double n = tda - invo + pds;
                    Main.Con.Close();
                    Main.Con.Open();

                    SqlCommand sqlCmd1 = new SqlCommand("update sup_reg set due_tot = @due_tot  where s_id = '" + cb1.SelectedValue + "'", Main.Con);
                    sqlCmd1.Parameters.Add(new SqlParameter("@due_tot", n));
                    sqlCmd1.ExecuteNonQuery();


                    SqlCommand sqlCmd = new SqlCommand("delete from sup_ac where trans_id = '" + reg.Text + "'", Main.Con);
                    sqlCmd.ExecuteNonQuery();

                    Main.Con.Close();
                    MessageBox.Show("Trasaction Updated");
                    t1.Text = string.Empty;
                    t3.Text = string.Empty;
                    t2.Text = string.Empty;
                    t4.Text = string.Empty;
                    all();
                }
            }
            catch { Main.Con.Close(); }
        }

        private void d2_ValueChanged(object sender, EventArgs e)
        {
            all();
        }

        private void d3_ValueChanged(object sender, EventArgs e)
        {
            all();
        }
    }
}
