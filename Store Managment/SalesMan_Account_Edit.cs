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
    public partial class SalesMan_Account_Edit : UserControl
    {
        public SalesMan_Account_Edit()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Account_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                dtdd.Value = System.DateTime.Now;
                rd3.Checked = true;
                all();
                cb_load();
                sum();
                var today = DateTime.Today;
                var lastmonth = new DateTime(today.Year, today.Month, 1);
                d2.Value = lastmonth;
                d3.Value = System.DateTime.Now;
                d1.Value = System.DateTime.Now;
            }
            catch { Main.Con.Close(); }
        }
        private void sum()
        {
            try
            {
                double paid;
                double tot_dues;

                if (t3.Text == "")
                {
                    paid = 0;
                }
                else { paid = int.Parse(t3.Text); }

                if (t4.Text == "")
                {
                    tot_dues = 0;
                }
                else { tot_dues = int.Parse(t4.Text); }


                double totals = double.Parse(t2.Text) - paid;
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
        public void all()
        {
            try
            {
                if (rd3.Checked)
                {
                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', c_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  Paid as 'Paid Payment', due_tot as 'Due After Transaction', rec_by as 'Recieved By' from  cust_ac ca, cust_reg cg where cg.c_id=ca.c_id and t_date = '" + dtdd.Text + "' order by trans_id asc", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g1.DataSource = dt;
                    Main.Con.Close();
                }
                if (rd4.Checked)
                {
                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', c_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  Paid as 'Paid Payment', due_tot as 'Due After Transaction', rec_by as 'Recieved By' from  cust_ac ca, cust_reg cg where cg.c_id=ca.c_id and t_date between '" + d2.Text + "' and '" + d3.Text + "' order by trans_id asc", Main.Con);
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

        private void gunaTextBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (rd3.Checked)
                {
                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', c_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  Paid as 'Paid Payment', due_tot as 'Due After Transaction', rec_by as 'Recieved By' from  cust_ac ca, cust_reg cg where cg.c_id=ca.c_id and t_date = '" + dtdd.Text + "' and  cg.c_name Like '%" + s1.Text + "%' order by trans_id asc ", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g1.DataSource = dt;
                    Main.Con.Close();
                }
                if (rd4.Checked)
                {
                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select trans_id as 'ID', c_name as 'Name', inv_desc as 'Description', t_date as 'Date', due as 'Recent Due',  Paid as 'Paid Payment', due_tot as 'Due After Transaction', rec_by as 'Recieved By' from  cust_ac ca, cust_reg cg where cg.c_id=ca.c_id and t_date between '" + d2.Text + "' and '" + d3.Text + "' and cg.c_name Like '%" + s1.Text + "%' order by trans_id asc ", Main.Con);
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

        private void d2_ValueChanged(object sender, EventArgs e)
        {
            all();
        }

        private void d3_ValueChanged(object sender, EventArgs e)
        {
            all();
        }

        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
            all();
        }

        private void rd4_CheckedChanged(object sender, EventArgs e)
        {
            all();
            cb_load();
        }

        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        
        int x;
        int y;
        double z=0;
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
                x = Convert.ToInt32(g1.Rows[e.RowIndex].Cells[6].Value.ToString());

                z = double.Parse(g1.Rows[e.RowIndex].Cells[5].Value.ToString());

                int sid = (int)cb1.SelectedValue;
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select  c_due from cust_reg where c_id = '" + sid + "'", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                while (reader.Read())
                {
                    duu.Text = reader["c_due"].ToString();
                    y = Convert.ToInt32(duu.Text);
                    // 1000 - 500 +600
                }
                reader.Close();
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }
        public void sum4()
        {
            
            duu.Text = (y - x + Convert.ToInt32(t4.Text)).ToString();
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
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
                    SqlCommand sqlCmd = new SqlCommand("update cust_ac  set c_id = @c_name, inv_desc= @inv_desc, t_date= @t_date, paid = @paid, due_tot=@due_tot, rec_by=@rec_by where trans_id = '" + reg.Text + "'", Main.Con);
                    sqlCmd.Parameters.Add(new SqlParameter("@c_name", cb1.SelectedValue));
                    sqlCmd.Parameters.Add(new SqlParameter("@inv_desc", t1.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@t_date", d1.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@due", t2.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@paid", t3.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@due_tot", t4.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@rec_by", t5.Text));
                    sqlCmd.ExecuteNonQuery();

                    SqlCommand sqlCmd1 = new SqlCommand("update cust_reg  set c_due = @c_due  where c_id = '" + cb1.SelectedValue + "'", Main.Con);
                    sqlCmd1.Parameters.Add(new SqlParameter("@c_due", duu.Text));
                    sqlCmd1.ExecuteNonQuery();
                    Main.Con.Close();
                    MessageBox.Show("Trasaction Updated");
                    reg.Text = string.Empty;
                    t1.Text = string.Empty;
                    t3.Text = string.Empty;
                    t5.Text = string.Empty;
                    all();

                }
            }
            catch { Main.Con.Close(); }
        }

        private void t4_TextChanged(object sender, EventArgs e)
        {
            sum4();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try
            {

                if (reg.Text == "")
                {
                    MessageBox.Show("Please Select First To Delete");
                }
                else
                {
                    Main.Con.Open();
                    double temp = 0;
                    SqlCommand sq = new SqlCommand("select c_due from cust_reg where c_id ='" + cb1.SelectedValue + "'", Main.Con);
                    temp = (double)sq.ExecuteScalar();

                    double a = temp + z;

                    SqlCommand sqlCmd2 = new SqlCommand("update cust_reg set c_due=@c_due where  c_id = '" + cb1.SelectedValue + "'", Main.Con);
                    sqlCmd2.Parameters.Add(new SqlParameter("@c_due", a));
                    sqlCmd2.ExecuteNonQuery();


                    SqlCommand Cmd = new SqlCommand("delete from cust_ac where trans_id = '" + reg.Text + "'", Main.Con);
                    Cmd.ExecuteNonQuery();

                    Main.Con.Close();
                    MessageBox.Show("Transaction Deleted Succeccfully");
                    all();
                    reg.Text = string.Empty;
                    t1.Text = string.Empty;
                    t3.Text = string.Empty;
                    t5.Text = string.Empty;
                    z = 0;
                }
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {

        }

        private void duu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }

        }
    }
}
