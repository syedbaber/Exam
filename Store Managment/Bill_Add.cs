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
    public partial class Bill_Add : UserControl
    {
        public Bill_Add()
        {
            InitializeComponent();
        }

        public Bill_Add(string a)
        {
            InitializeComponent();
            l99.Text = a;
        }


        private void Bill_Add_Load(object sender, EventArgs e)
        {
            cb1_lod();
            b_id();
            d1.Value = System.DateTime.Now;
            cb2_lod();
            sum();
            g1.ReadOnly = false;
            g1.Columns[0].ReadOnly = true;
            g1.Columns[1].ReadOnly = true;
            g1.Columns[2].ReadOnly = true;
            g1.Columns[5].ReadOnly = true;
            g1.Columns[6].ReadOnly = true;

            
        }

        private void b_id()
        {
            try
            {
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand cmd = new SqlCommand("select count(b_id) from bill", Main.Con);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    reg.Text = "1";
                }
                else
                {
                    SqlCommand da1 = new SqlCommand("select max(b_id) from  bill", Main.Con);
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
            try
            {
                float pr;
                float qn;

                if (t1.Text == "")
                {
                    pr = 0;
                }
                else { pr = float.Parse(t1.Text); }

                if (t2.Text == "")
                {
                    qn = 0;
                }
                else { qn = float.Parse(t2.Text); }
                float totals = pr * qn;
                t3.Text = totals.ToString();
            }
            catch { }
        }
        private void sum1()
        {
            try
            {
                float pr;
                float tot;

                if (t1.Text == "")
                {
                    pr = 0;
                }
                else { pr = float.Parse(t1.Text); }

                if (t3.Text == "")
                {
                    tot = 0;
                }
                else { tot = float.Parse(t3.Text); }
                float totals =  tot/pr;
                t2.Text = totals.ToString();
            }
            catch { }
        }
        public void cb2_lod()
        {
            try
            {
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select i_id, i_name from item order by i_name asc", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("i_name", typeof(string));
                dt.Load(reader);
                cb2.DisplayMember = "i_name";
                cb2.ValueMember = "i_id";
                cb2.DataSource = dt;
                Main.Con.Close();
                cb2.SelectedIndex = 0;
            }
            catch { Main.Con.Close(); }
        }

        public void cb1_lod()
        {
            try
            {
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select c_id, c_name from cust_reg order by c_name asc", Main.Con);
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

        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sid = (int)cb2.SelectedValue;
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select  u_price from item where i_id = '" + sid + "'", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                while (reader.Read())
                {
                    t1.Text = reader["u_price"].ToString();
                }
                reader.Close();
                Main.Con.Close();

                Main.Con.Open();
                SqlCommand sda = new SqlCommand("select stock from item where i_id = '" + sid + "'", Main.Con);
                SqlDataReader sreader;
                sreader = sda.ExecuteReader();
                while (sreader.Read())
                {
                    t99.Text = sreader["stock"].ToString();
                }
                sreader.Close();
                Main.Con.Close();

                Double a = Convert.ToDouble(t99.Text);
                if (a < 10)
                {
                    t99.BaseColor = Color.Red;
                }
                else
                {
                    t99.BaseColor = Color.LightGray;
                }
            }
            catch { Main.Con.Close(); }
 
        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void t2_TextChanged(object sender, EventArgs e)
        {
            sum();
            t2.Select(t2.Text.Length, 0);
        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            sum1();
            t3.Select(t3.Text.Length, 0);
        }

        private void t3_MouseClick(object sender, MouseEventArgs e)
        {
            t3.SelectAll();
            t3.Focus();
        }

        private void t2_Click(object sender, EventArgs e)
        {
            t2.SelectAll();
            t2.Focus();
        }
        int count = 0;
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(t99.Text);
                double b = Convert.ToDouble(t2.Text);
                if (b > a)
                {
                    MessageBox.Show("Not Enough Stock Available");
                }
                else if (b == 0)
                {
                    MessageBox.Show("Please Select Quantity");
                }
                else
                {
                    double prevTotal = double.Parse(txtSum.Text);
                    double currTotal = prevTotal + double.Parse(t3.Text);
                    txtSum.Text = currTotal.ToString();
                    g1.Rows.Add();
                    g1.Rows[count].Cells[0].Value = reg.Text;
                    g1.Rows[count].Cells[1].Value = cb2.SelectedValue;
                    g1.Rows[count].Cells[2].Value = cb2.Text;
                    g1.Rows[count].Cells[3].Value = double.Parse(t2.Text);
                    g1.Rows[count].Cells[4].Value = double.Parse(t1.Text);
                    g1.Rows[count].Cells[5].Value = double.Parse(t3.Text);
                    g1.Rows[count].Cells[6].Value = "Delete";
                    count += 1;
                    t2.Text = "0";
                    t3.Text = "0";

                }
            }
            catch { Main.Con.Close();}
        }

        private void g1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int priceDelete = 0;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow r = g1.Rows[e.RowIndex];
                    if (g1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                    {
                        priceDelete = int.Parse(g1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        g1.Rows.RemoveAt(e.RowIndex);
                        count--;
                        txtSum.Text = (int.Parse((txtSum.Text)) - priceDelete).ToString();

                    }
                }
            }
            catch { Main.Con.Close(); }
        }
        double temp;
        int itemId;
        public void update_quan(string name, double quant)
        {
            try
            {
                Main.Con.Open();
                //get item id
                SqlCommand sq0 = new SqlCommand("select i_id from item where i_name ='" + name + "'", Main.Con);
                SqlDataReader r0;
                r0 = sq0.ExecuteReader();
                while (r0.Read())
                {
                    itemId = Convert.ToInt32(r0["i_id"].ToString());

                }
                r0.Close();

                //update item quantity
                SqlCommand sq = new SqlCommand("select stock from item where i_id ='" + itemId + "'", Main.Con);
                SqlDataReader r;
                r = sq.ExecuteReader();
                while (r.Read())
                {
                    temp = Convert.ToDouble(r["stock"].ToString()) - quant;

                }
                r.Close();


                //update item quantity
                SqlCommand sq1 = new SqlCommand("UPDATE item set stock ='" + temp + "' where i_id = '" + itemId + "' ", Main.Con);
                sq1.ExecuteNonQuery();
                Main.Con.Close();
            }
            catch { Main.Con.Close(); }
        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Open();
                SqlCommand sqlCmd = new SqlCommand("insert into bill (b_id, c_id, c_name, tot, paid, due, b_date, bill_by ) values (@b_id, @c_id, @c_name, @tot, @paid, @due, @b_date, @bill_by)", Main.Con);
                sqlCmd.Parameters.Add(new SqlParameter("@b_id", reg.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@c_id", cb1.SelectedValue));
                sqlCmd.Parameters.Add(new SqlParameter("@c_name", cb1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@tot", txtSum.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@paid", pt.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due", dts.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@b_date", d1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@Bill_By", l99.Text));
                sqlCmd.ExecuteNonQuery();
                Main.Con.Close();


                Main.Con.Open();
                SqlCommand sqlCmd1 = new SqlCommand("select cast(c_due as float) from cust_reg where c_id = '" + cb1.SelectedValue + "'", Main.Con);
                float rdu = float.Parse(sqlCmd1.ExecuteScalar().ToString());
                float ndu = float.Parse(dts.Text) + rdu;
                SqlCommand sqlCmd2 = new SqlCommand("update cust_reg set c_due=@c_due where  c_id = '" + cb1.SelectedValue + "'", Main.Con);
                sqlCmd2.Parameters.Add(new SqlParameter("@c_due", ndu));
                sqlCmd2.ExecuteNonQuery();
                Main.Con.Close();

                for (int i = 0; i < g1.Rows.Count; i++)
                {
                    Main.Con.Open();
                    string name = g1.Rows[i].Cells[2].Value.ToString();
                    double quan = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                    SqlCommand cmd1 = new SqlCommand("select w_price from item where i_name = '" + name + "'", Main.Con);
                    double wp = (double)cmd1.ExecuteScalar();


                    SqlCommand cmd = new SqlCommand("insert into bill_det (bd_id, i_id, i_name, quantity, u_price, s_tot, dlt,w_price) values ('" + g1.Rows[i].Cells[0].Value + "', '" + g1.Rows[i].Cells[1].Value + "', '" + g1.Rows[i].Cells[2].Value + "', '" + g1.Rows[i].Cells[3].Value + "', '" + g1.Rows[i].Cells[4].Value + "', '" + g1.Rows[i].Cells[5].Value + "', '" + g1.Rows[i].Cells[6].Value + "', '" + wp + "' )", Main.Con);
                    cmd.ExecuteNonQuery();
                    Main.Con.Close();
                    update_quan(name, quan);

                }

                MessageBox.Show("Bill generated Sucessfully");
                Main.Con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from cust_bill where  b_id= '" + reg.Text + "'", Main.Con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Rpt_Bill cr = new Rpt_Bill();
                cr.SetDataSource(dt);
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rdoc = cr;
                    rdoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
                    rdoc.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage);
                }
               
                b_id();
                g1.Rows.Clear();

                g1.Refresh();
                Main.Con.Close();
                count = 0;
                cb2_lod();
                txtSum.Text = "0";
                dts.Text = "0";
                pt.Text = "0";

            }
            catch { 
                Main.Con.Close();
                MessageBox.Show("Invalid Entries.");
            }
        }

        private void rdc_CheckedChanged(object sender, EventArgs e)
        {
           
            cb1.Visible = false;
        }

        private void txtSum_TextChanged(object sender, EventArgs e)
        {
            sum3();
            txtSum.Select(txtSum.Text.Length, 0);
        }



        private void sum3()
        {
            try
            {
                float pr;
                float qn;

                if (txtSum.Text == "")
                {
                    pr = 0;
                }
                else { pr = float.Parse(txtSum.Text); }

                if (pt.Text == "")
                {
                    qn = 0;
                }
                else { qn = float.Parse(pt.Text); }
                float totals = pr - qn;
                dts.Text = totals.ToString();
            }
            catch { }
        }

        private void pt_TextChanged(object sender, EventArgs e)
        {
            //Baber's Addition
            float paidAmount=0;
            float totalAmount=0;

            if (pt.Text == "") {
                paidAmount = 0;
            }
            else { paidAmount = float.Parse(pt.Text); }
            
             
             totalAmount = float.Parse(txtSum.Text);
            

            if (paidAmount > totalAmount)
            {
                MessageBox.Show("Amount Exeeded");
                dts.Text = "0";
                pt.Text = "0";
            }
            else
            {

                sum3();
                pt.Select(pt.Text.Length, 0);
            }
        }

        private void dts_TextChanged(object sender, EventArgs e)
        {
          
            if (float.Parse(dts.Text)!= 0)
            {
                sum3();
                dts.Select(dts.Text.Length, 0);
            }
            
      
        }

        private void txtSum_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Open();
                SqlCommand sqlCmd = new SqlCommand("insert into bill (b_id, c_id, c_name, tot, paid, due, b_date, bill_by ) values (@b_id, @c_id, @c_name, @tot, @paid, @due, @b_date, @bill_by)", Main.Con);
                sqlCmd.Parameters.Add(new SqlParameter("@b_id", reg.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@c_id", cb1.SelectedValue));
                sqlCmd.Parameters.Add(new SqlParameter("@c_name", cb1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@tot", txtSum.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@paid", pt.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@due", dts.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@b_date", d1.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@Bill_By", l99.Text));
                sqlCmd.ExecuteNonQuery();
                Main.Con.Close();

                Main.Con.Open();
                SqlCommand sqlCmd1 = new SqlCommand("select cast(c_due as float) from cust_reg where c_id = '" + cb1.SelectedValue + "'", Main.Con);
                double rdu = double.Parse(sqlCmd1.ExecuteScalar().ToString());
                double ndu = double.Parse(dts.Text) + rdu;
                SqlCommand sqlCmd2 = new SqlCommand("update cust_reg set c_due=@c_due where  c_id = '" + cb1.SelectedValue + "'", Main.Con);
                sqlCmd2.Parameters.Add(new SqlParameter("@c_due", ndu));
                sqlCmd2.ExecuteNonQuery();
                Main.Con.Close();

                for (int i = 0; i < g1.Rows.Count; i++)
                {
                    Main.Con.Open();
                    string name = g1.Rows[i].Cells[2].Value.ToString();
                    double quan = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                    SqlCommand cmd1 = new SqlCommand("select w_price from item where i_name = '" + name + "'", Main.Con);
                    double wp = (double)cmd1.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("insert into bill_det (bd_id, i_id, i_name, quantity, u_price, s_tot, dlt, w_price) values ('" + g1.Rows[i].Cells[0].Value + "', '" + g1.Rows[i].Cells[1].Value + "', '" + g1.Rows[i].Cells[2].Value + "', '" + g1.Rows[i].Cells[3].Value + "', '" + g1.Rows[i].Cells[4].Value + "', '" + g1.Rows[i].Cells[5].Value + "', '" + g1.Rows[i].Cells[6].Value + "' , '" + wp + "'  )", Main.Con);
                    cmd.ExecuteNonQuery();
                    Main.Con.Close();
                    update_quan(name, quan);
                }
                b_id();
                g1.Rows.Clear();
                g1.Refresh();
                Main.Con.Close();
                count = 0;
                MessageBox.Show("Bill Generated Successfully");
                txtSum.Text = "0";
                dts.Text = "0";
                pt.Text = "0";
                cb2_lod();
            }
            catch { 
                Main.Con.Close();
                MessageBox.Show("Invalid Entries.");
            }
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
        }

        private void g1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < g1.Rows.Count; i++)
                {

                    double a = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                    double b = Convert.ToDouble(g1.Rows[i].Cells[4].Value);
                    this.g1.Rows[i].Cells[5].Value = (a * b).ToString();

                }

                double sum = 0;
                for (int i = 0; i < g1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(g1.Rows[i].Cells[5].Value);
                }
                txtSum.Text = sum.ToString();

            }
            catch
            {
                MessageBox.Show("Invalid Entries! Please Enter Numbers Only");
            }
        }

        private void l99_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
