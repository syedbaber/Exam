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
    public partial class Bill_Edit : UserControl
    {
        double due_up = 0;
        double tot_up = 0;
        double paid_up = 0;


        public Bill_Edit()
        {
            InitializeComponent();
        }

        private void Bill_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                d1.Value = System.DateTime.Now;
                d3.Value = System.DateTime.Now;
                var today = DateTime.Today;
                var lastmonth = new DateTime(today.Year, today.Month, 1);
                d2.Value = lastmonth;
                dtdd.Value = System.DateTime.Now;
                cb2_lod();
                sum();
                cb1_lod();
                rd3.Checked = true;
                all();

                g1.ReadOnly = false;
                g1.Columns[0].ReadOnly = true;
                g1.Columns[1].ReadOnly = true;
                g1.Columns[2].ReadOnly = true;
                g1.Columns[5].ReadOnly = true;
                g1.Columns[6].ReadOnly = true;
         
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
                float totals = tot / pr;
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
            }
            catch { Main.Con.Close(); }
        }
        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
            cb1_lod();
           
            cb1.Visible = true;
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            cb1_lod();
           
            cb1.Visible = true;
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
                else
                {

                    double prevTotal = double.Parse(txtSum.Text);
                    double currTotal = prevTotal + double.Parse(t3.Text);
                    txtSum.Text = currTotal.ToString();
                    String item = cb2.Text;
                    double unitPrice = double.Parse(t1.Text);
                    double quantity = double.Parse(t2.Text);
                    double subTotal = double.Parse(t3.Text);
                    DataTable dt = g1.DataSource as DataTable;
                    DataRow row = dt.NewRow();
                    row[0] = reg.Text;
                    row[1] = cb2.SelectedValue;
                    row[2] = item;
                    row[3] = quantity;
                    row[4] = unitPrice;
                    row[5] = subTotal;
                    row[6] = "Delete";
                    dt.Rows.Add(row);
                    //count += 1;
                    t2.Text = "0";
                    t3.Text = "0";
                }
            }
            catch { }
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

                double a = Convert.ToDouble(t99.Text);
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
        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            sum1();
        }
        public void all()
        {
            try
            {
                if (rd3.Checked)
                {

                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select b_id as 'Bill ID', c.c_name as 'Name', tot as 'Total Bill', paid as 'Paid', due as 'Due', b_date as 'Date', bill_by as 'Bill By' from bill b, cust_reg c where  b.c_id=c.c_id and  b_date = '" + dtdd.Text + "' order by b_id asc", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g2.DataSource = dt;
                    Main.Con.Close();

                }
                if (rd4.Checked)
                {

                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select b_id as 'Bill ID', c.c_name as 'Name', tot as 'Total Bill', paid as 'Paid', due as 'Due', b_date as 'Date', bill_by as 'Bill By' from bill b, cust_reg c where  b.c_id=c.c_id  and b_date between '" + d2.Text + "' and '" + d3.Text + "' order by b_id asc", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g2.DataSource = dt;
                    Main.Con.Close();

                }
            }
            catch { Main.Con.Close(); }
        }
        private void s1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd3.Checked)
                {

                    dtdd.Value = System.DateTime.Now;
                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select b_id as 'Bill ID', c.c_name as 'Name', tot as 'Total Bill', paid as 'Paid', due as 'Due', b_date as 'Date', bill_by as 'Bill By' from bill b, cust_reg c where  b.c_id=c.c_id and  b_date = '" + dtdd.Text + "' and c.c_name Like '%" + s1.Text + "%' order by b_id asc", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g2.DataSource = dt;
                    Main.Con.Close();

                }
                if (rd4.Checked)
                {

                    Main.Con.Open();
                    SqlCommand cmd = new SqlCommand("select b_id as 'Bill ID', c.c_name as 'Name', tot as 'Total Bill', paid as 'Paid', due as 'Due', b_date as 'Date', bill_by as 'Bill By' from bill b, cust_reg c where  b.c_id=c.c_id  and b_date between '" + d2.Text + "' and '" + d3.Text + "' and c.c_name Like '%" + s1.Text + "%' order by b_id asc", Main.Con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    g2.DataSource = dt;
                    Main.Con.Close();

                }
            }
            catch { Main.Con.Close(); }
        }

        private void rrd1_CheckedChanged(object sender, EventArgs e)
        {
            all();
        }

        private void rrd2_CheckedChanged(object sender, EventArgs e)
        {
            all();
        }

        private void rrd3_CheckedChanged(object sender, EventArgs e)
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
        }

        private void d2_ValueChanged(object sender, EventArgs e)
        {
            all();
        }

        private void d3_ValueChanged(object sender, EventArgs e)
        {
            all();
        }

     
        private void g2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow r = g2.Rows[e.RowIndex];
                int did = Convert.ToInt32(g2.Rows[e.RowIndex].Cells[0].Value);
                reg.Text = did.ToString();
                txtSum.Text = g2.Rows[e.RowIndex].Cells[2].Value.ToString();
                cb1.Text = g2.Rows[e.RowIndex].Cells[1].Value.ToString();
                pt.Text = g2.Rows[e.RowIndex].Cells[3].Value.ToString();
                dts.Text = g2.Rows[e.RowIndex].Cells[4].Value.ToString();
                d1.Value = Convert.ToDateTime(g2.Rows[e.RowIndex].Cells[5].Value.ToString());
                l99.Text = g2.Rows[e.RowIndex].Cells[6].Value.ToString();
                Main.Con.Open();
                SqlCommand sqlcmd = new SqlCommand("Select bd_id, i_id, i_name,quantity,u_price,s_tot,dlt from bill_det where bd_id = '" + reg.Text + "' ", Main.Con);
                sqlcmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                g1.DataSource = dt;
                Main.Con.Close();
                due_up = double.Parse(dts.Text);
                paid_up = double.Parse(pt.Text);
                tot_up = double.Parse(txtSum.Text);
                gr1.Visible = false;
            }
            catch { Main.Con.Close(); }

        }

        private void rdc_CheckedChanged(object sender, EventArgs e)
        {
            cb1.Visible = false;
        }

        private void g1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Double priceDelete = 0;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow r = g1.Rows[e.RowIndex];
                    if (g1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                    {
                        priceDelete = Double.Parse(g1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        g1.Rows.RemoveAt(e.RowIndex);
                        count--;
                        txtSum.Text = (Double.Parse((txtSum.Text)) - priceDelete).ToString();

                    }
                }
            }
            catch { Main.Con.Close(); }
        }
     
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
             {
                if (reg.Text == "")
                {
                    MessageBox.Show("Please Click Back And Select Order To Update");
                }
                else if (double.Parse(txtSum.Text) < double.Parse(pt.Text))
                {
                    MessageBox.Show("Please recheck the Paid Amount.");
                }
                else
                {
                    var oldList = new List<bill_det>();
                    //<--- This Postion For Subtraction All Previous Stock Data for Order --->

                    List<bill_det> model = new List<bill_det>();
                    Main.Con.Open();
                    SqlCommand sqlcmd = new SqlCommand("select bd_id, i_id,i_name, CAST(quantity AS varchar) from bill_det where bd_id = '" + reg.Text + "' ", Main.Con);
                    sqlcmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = sqlcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new bill_det()
                            {
                                bd_id = reader.GetInt32(0),
                                i_id = reader.GetInt64(1),
                                i_name = reader.GetString(2),
                                quantity = reader.GetString(3)

                            }); //Specify column index 
                        }
                    }
                    Main.Con.Close();
                    oldList = model;
                    foreach (var item in oldList)
                    {
                        Main.Con.Open();
                        double temp = 0;
                        SqlCommand sq = new SqlCommand("select stock from item where i_id ='" + item.i_id + "'", Main.Con);
                        SqlDataReader r;
                        r = sq.ExecuteReader();
                        while (r.Read())
                        {
                            temp = Convert.ToDouble(r["stock"].ToString());
                        }
                        r.Close();
                        Main.Con.Close();
                        item.quantity = Convert.ToString(Double.Parse(item.quantity.ToString()) + temp);
                        ////add old item count to table
                        Main.Con.Open();
                        SqlCommand sq1 = new SqlCommand("UPDATE item set stock ='" + item.quantity + "' where i_id = '" + item.i_id + "' ", Main.Con);
                        sq1.ExecuteNonQuery();
                        Main.Con.Close();
                    }

                    //<--- This Postion For Updating Data in Bill Table --->
                    Main.Con.Open();
                    SqlCommand sqlCmd1 = new SqlCommand("update bill set tot=@tot, paid=@paid, due=@due, b_date=@b_date, bill_by= @bill_by where b_id = '" + reg.Text + "'  ", Main.Con);
                    sqlCmd1.Parameters.Add(new SqlParameter("@tot", txtSum.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@paid", pt.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@due", dts.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@b_date", d1.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@Bill_By", l99.Text));
                    sqlCmd1.ExecuteNonQuery();
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand sqlCmd = new SqlCommand("select cast(c_due as float) from cust_reg where c_id = '" + cb1.SelectedValue + "'", Main.Con);
                    double rdu = double.Parse(sqlCmd.ExecuteScalar().ToString());
                    double ndu = double.Parse(dts.Text) + rdu - due_up;
                    SqlCommand sqlCmd2 = new SqlCommand("update cust_reg set c_due=@c_due where  c_id = '" + cb1.SelectedValue + "'", Main.Con);
                    sqlCmd2.Parameters.Add(new SqlParameter("@c_due", ndu));
                    sqlCmd2.ExecuteNonQuery();
                    Main.Con.Close();

                    //<--- This Postion For Deleting All Previous Data in Bill_Dt Table For selected Order--->
                    Main.Con.Open();
                    SqlCommand Cmd = new SqlCommand("delete from bill_det where bd_id = '" + reg.Text + "'", Main.Con);
                    Cmd.ExecuteNonQuery();
                    Main.Con.Close();

                    //<--- This Postion For Adding Updated Data in Bill_Dt Table For selected Order--->
                    //for (int i = 0; i < g1.Rows.Count; i++)
                    //{
                    //    Main.Con.Open();
                    //    string name = g1.Rows[i].Cells[2].Value.ToString();
                    //    double quan = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                    //    SqlCommand cmd1 = new SqlCommand("select w_price from item where i_name = '" + name + "'", Main.Con);
                    //    double wp = (double)cmd1.ExecuteScalar();
                    //    SqlCommand cmd = new SqlCommand("insert into bill_det (bd_id, i_id, i_name, quantity, u_price, s_tot, dlt, w_price) values ('" + g1.Rows[i].Cells[0].Value + "', '" + g1.Rows[i].Cells[1].Value + "', '" + g1.Rows[i].Cells[2].Value + "', '" + g1.Rows[i].Cells[3].Value + "', '" + g1.Rows[i].Cells[4].Value + "', '" + g1.Rows[i].Cells[5].Value + "', '" + g1.Rows[i].Cells[6].Value + "' , '" + wp + "'  )", Main.Con);
                    //    cmd.ExecuteNonQuery();
                    //    Main.Con.Close();
                    //    update_quan(name, quan);
                    //}
                    //new code starts
                    for (int i = 0; i < g1.Rows.Count; i++)
                    {
                        Main.Con.Open();
                        int ids = int.Parse(g1.Rows[i].Cells[1].Value.ToString());


                        double quan = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                        SqlCommand cmd1 = new SqlCommand("select w_price from item where i_id = '" + ids + "'", Main.Con);
                        double wp = (double)cmd1.ExecuteScalar();
                        SqlCommand cmd = new SqlCommand("insert into bill_det (bd_id, i_id, i_name, quantity, u_price, s_tot, dlt, w_price) values ('" + g1.Rows[i].Cells[0].Value + "', '" + g1.Rows[i].Cells[1].Value + "', '" + g1.Rows[i].Cells[2].Value + "', '" + g1.Rows[i].Cells[3].Value + "', '" + g1.Rows[i].Cells[4].Value + "', '" + g1.Rows[i].Cells[5].Value + "', '" + g1.Rows[i].Cells[6].Value + "' , '" + wp + "'  )", Main.Con);
                        cmd.ExecuteNonQuery();
                        
                        SqlCommand da = new SqlCommand("select i_name from item where i_id='" + ids + "'", Main.Con);
                        SqlDataReader reader;
                        reader = da.ExecuteReader();
                        string name = "";
                        while (reader.Read())
                        {
                            name = reader["i_name"].ToString();
                        }
                        update_quan(name, quan);
                        Main.Con.Close();
                    }
                    MessageBox.Show("Updated Successfully");
                    all();
                    gr1.Visible = true;
                    gr1.BringToFront();
                }
            }

           catch { 
                Main.Con.Close();
                MessageBox.Show("Invalid Entries!");
            }
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
        public class bill_det
        {
            public int bd_id { get; set; }
            public long i_id { get; set; }
            public string i_name { get; set; }
            public string quantity { get; set; }
        }
        
        public List<bill_det> CompareLsit(List<bill_det> oldList,List<bill_det> newList)
        {
            //try
            //{
                var final = new List<bill_det>();
                //check length for both (if they hav same number of products)
                if (oldList.Count == newList.Count) // if same no of products
                {
                    foreach (var item in oldList)
                    {
                        Main.Con.Open();
                        double temp = 0;
                        SqlCommand sq = new SqlCommand("select stock from item where i_id ='" + item.i_id + "'", Main.Con);
                        SqlDataReader r;
                        r = sq.ExecuteReader();
                        while (r.Read())
                        {
                            temp = Convert.ToDouble(r["stock"].ToString());
                        }
                        r.Close();
                        Main.Con.Close();
                        item.quantity = Convert.ToString(Double.Parse(item.quantity) + temp);
                        //add old item count to table
                        Main.Con.Open();
                        SqlCommand sq1 = new SqlCommand("UPDATE item set stock ='" + item.quantity + "' where i_id = '" + item.i_id + "' ", Main.Con);
                        sq1.ExecuteNonQuery();
                        Main.Con.Close();
                    }
                    foreach (var item in newList)
                    {
                        Main.Con.Open();
                        double temp = 0;
                        SqlCommand sq = new SqlCommand("select stock from item where i_id ='" + item.i_id + "'", Main.Con);
                        SqlDataReader r;
                        r = sq.ExecuteReader();
                        while (r.Read())
                        {
                            temp = Convert.ToDouble(r["stock"].ToString());
                        }
                        r.Close();
                        Main.Con.Close();
                        item.quantity = Convert.ToString(temp - Double.Parse(item.quantity));
                        //update new item count to table
                        Main.Con.Open();
                        SqlCommand sq1 = new SqlCommand("UPDATE item set stock ='" + item.quantity + "' where i_id = '" + item.i_id + "' ", Main.Con);
                        sq1.ExecuteNonQuery();
                        Main.Con.Close();
                    }
                }
                return final;
            //}
            //catch { Main.Con.Close(); }
        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try
            { //Delete Button Code

                if (reg.Text == "")
                {
                    MessageBox.Show("Please Click Back And Select Order To Delete");
                }
                else
                {
                    if (MessageBox.Show("Do You Really Want To Delete Bill", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var oldList = new List<bill_det>();
                        //<--- This Postion For Subtraction All Previous Stock Data for Order --->

                        List<bill_det> model = new List<bill_det>();
                        Main.Con.Open();
                        SqlCommand sqlcmd = new SqlCommand("select bd_id, i_id,i_name, CAST(quantity AS varchar) from bill_det where bd_id = '" + reg.Text + "' ", Main.Con);
                        sqlcmd.CommandType = CommandType.Text;
                        using (SqlDataReader reader = sqlcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.Add(new bill_det()
                                {
                                    bd_id = reader.GetInt32(0),
                                    i_id = reader.GetInt64(1),
                                    i_name = reader.GetString(2),
                                    quantity = reader.GetString(3)

                                }); //Specify column index 
                            }
                        }
                        Main.Con.Close();
                        oldList = model;
                        foreach (var item in oldList)
                        {
                            Main.Con.Open();
                            double temp = 0;
                            SqlCommand sq = new SqlCommand("select stock from item where i_id ='" + item.i_id + "'", Main.Con);
                            SqlDataReader r;
                            r = sq.ExecuteReader();
                            while (r.Read())
                            {
                                temp = Convert.ToDouble(r["stock"].ToString());
                            }
                            r.Close();
                            Main.Con.Close();
                            item.quantity = Convert.ToString(Double.Parse(item.quantity.ToString()) + temp);
                            ////add old item count to table
                            Main.Con.Open();
                            SqlCommand sq1 = new SqlCommand("UPDATE item set stock ='" + item.quantity + "' where i_id = '" + item.i_id + "' ", Main.Con);
                            sq1.ExecuteNonQuery();
                            Main.Con.Close();
                        }

                        Main.Con.Open();
                        SqlCommand Cmd = new SqlCommand("delete from bill_det where bd_id = '" + reg.Text + "'", Main.Con);
                        Cmd.ExecuteNonQuery();
                        Main.Con.Close();

                        Main.Con.Open();
                        SqlCommand Cmd1 = new SqlCommand("delete from bill where b_id = '" + reg.Text + "'", Main.Con);
                        Cmd1.ExecuteNonQuery();
                        Main.Con.Close();

                        Main.Con.Open();
                        SqlCommand sqlCmd = new SqlCommand("select cast(c_due as float) from cust_reg where c_id = '" + cb1.SelectedValue + "'", Main.Con);
                        double rdu = double.Parse(sqlCmd.ExecuteScalar().ToString());
                        double ndu = rdu - due_up;
                        SqlCommand sqlCmd2 = new SqlCommand("update cust_reg set c_due=@c_due where  c_id = '" + cb1.SelectedValue + "'", Main.Con);
                        sqlCmd2.Parameters.Add(new SqlParameter("@c_due", ndu));
                        sqlCmd2.ExecuteNonQuery();
                        Main.Con.Close();
                        all();
                        gr1.Visible = true;
                        gr1.BringToFront();
                        MessageBox.Show("Deleted Successfully");
                        txtSum.Text = String.Empty;
                        pt.Text = String.Empty;
                        dts.Text = String.Empty;
                        reg.Text = String.Empty;
                        count = 0;
                        
                    }
                }
            }
            catch
            {
                Main.Con.Close(); }
        }

        private void pt_TextChanged(object sender, EventArgs e)
        {
            sum3();
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

        private void txtSum_TextChanged(object sender, EventArgs e)
        {
            sum3();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            gr1.Visible = true;
            gr1.BringToFront();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (reg.Text == "")
                {
                    MessageBox.Show("Please Click Back And Select Order To Update");
                }
                else if (double.Parse(txtSum.Text) < double.Parse(pt.Text))
                {
                    MessageBox.Show("Please recheck the Paid Amount.");
                }
                else
                {
                   // Update_btn.Click += new EventHandler(gunaAdvenceButton1_Click);
                    var oldList = new List<bill_det>();
                    //<--- This Postion For Subtraction All Previous Stock Data for Order --->

                    List<bill_det> model = new List<bill_det>();
                    Main.Con.Open();
                    SqlCommand sqlcmd = new SqlCommand("select bd_id, i_id,i_name, CAST(quantity AS varchar) from bill_det where bd_id = '" + reg.Text + "' ", Main.Con);
                    sqlcmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = sqlcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new bill_det()
                            {
                                bd_id = reader.GetInt32(0),
                                i_id = reader.GetInt64(1),
                                i_name = reader.GetString(2),
                                quantity = reader.GetString(3)

                            }); //Specify column index 
                        }
                    }
                    Main.Con.Close();
                    oldList = model;
                    foreach (var item in oldList)
                    {
                        Main.Con.Open();
                        double temp = 0;
                        SqlCommand sq = new SqlCommand("select stock from item where i_id ='" + item.i_id + "'", Main.Con);
                        SqlDataReader r;
                        r = sq.ExecuteReader();
                        while (r.Read())
                        {
                            temp = Convert.ToDouble(r["stock"].ToString());
                        }
                        r.Close();
                        Main.Con.Close();
                        item.quantity = Convert.ToString(Double.Parse(item.quantity.ToString()) + temp);
                        ////add old item count to table
                        Main.Con.Open();
                        SqlCommand sq1 = new SqlCommand("UPDATE item set stock ='" + item.quantity + "' where i_id = '" + item.i_id + "' ", Main.Con);
                        sq1.ExecuteNonQuery();
                        Main.Con.Close();
                    }

                    //<--- This Postion For Updating Data in Bill Table --->
                    Main.Con.Open();
                    SqlCommand sqlCmd1 = new SqlCommand("update bill set tot=@tot, paid=@paid, due=@due, b_date=@b_date, bill_by= @bill_by where b_id = '" + reg.Text + "'  ", Main.Con);
                    sqlCmd1.Parameters.Add(new SqlParameter("@tot", txtSum.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@paid", pt.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@due", dts.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@b_date", d1.Text));
                    sqlCmd1.Parameters.Add(new SqlParameter("@Bill_By", l99.Text));
                    sqlCmd1.ExecuteNonQuery();
                    Main.Con.Close();
                    Main.Con.Open();
                    SqlCommand sqlCmd = new SqlCommand("select cast(c_due as float) from cust_reg where c_id = '" + cb1.SelectedValue + "'", Main.Con);
                    double rdu = double.Parse(sqlCmd.ExecuteScalar().ToString());
                    double ndu = double.Parse(dts.Text) + rdu - due_up;
                    SqlCommand sqlCmd2 = new SqlCommand("update cust_reg set c_due=@c_due where  c_id = '" + cb1.SelectedValue + "'", Main.Con);
                    sqlCmd2.Parameters.Add(new SqlParameter("@c_due", ndu));
                    sqlCmd2.ExecuteNonQuery();
                    Main.Con.Close();

                    //<--- This Postion For Deleting All Previous Data in Bill_Dt Table For selected Order--->
                    Main.Con.Open();
                    SqlCommand Cmd = new SqlCommand("delete from bill_det where bd_id = '" + reg.Text + "'", Main.Con);
                    Cmd.ExecuteNonQuery();
                    Main.Con.Close();

                    //<--- This Postion For Adding Updated Data in Bill_Dt Table For selected Order--->
                    //for (int i = 0; i < g1.Rows.Count; i++)
                    //{
                    //    Main.Con.Open();
                    //    string name = g1.Rows[i].Cells[2].Value.ToString();
                    //    double quan = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                    //    SqlCommand cmd1 = new SqlCommand("select w_price from item where i_name = '" + name + "'", Main.Con);
                    //    double wp = (double)cmd1.ExecuteScalar();
                    //    SqlCommand cmd = new SqlCommand("insert into bill_det (bd_id, i_id, i_name, quantity, u_price, s_tot, dlt, w_price) values ('" + g1.Rows[i].Cells[0].Value + "', '" + g1.Rows[i].Cells[1].Value + "', '" + g1.Rows[i].Cells[2].Value + "', '" + g1.Rows[i].Cells[3].Value + "', '" + g1.Rows[i].Cells[4].Value + "', '" + g1.Rows[i].Cells[5].Value + "', '" + g1.Rows[i].Cells[6].Value + "' , '" + wp + "'  )", Main.Con);
                    //    cmd.ExecuteNonQuery();
                    //    Main.Con.Close();
                    //    update_quan(name, quan);
                    //}
                    for (int i = 0; i < g1.Rows.Count; i++)
                    {
                        Main.Con.Open();
                        int ids = int.Parse(g1.Rows[i].Cells[1].Value.ToString());


                        double quan = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                        SqlCommand cmd1 = new SqlCommand("select w_price from item where i_id = '" + ids + "'", Main.Con);
                        double wp = (double)cmd1.ExecuteScalar();
                        SqlCommand cmd = new SqlCommand("insert into bill_det (bd_id, i_id, i_name, quantity, u_price, s_tot, dlt, w_price) values ('" + g1.Rows[i].Cells[0].Value + "', '" + g1.Rows[i].Cells[1].Value + "', '" + g1.Rows[i].Cells[2].Value + "', '" + g1.Rows[i].Cells[3].Value + "', '" + g1.Rows[i].Cells[4].Value + "', '" + g1.Rows[i].Cells[5].Value + "', '" + g1.Rows[i].Cells[6].Value + "' , '" + wp + "'  )", Main.Con);
                        cmd.ExecuteNonQuery();

                        SqlCommand dac = new SqlCommand("select i_name from item where i_id='" + ids + "'", Main.Con);
                        SqlDataReader reader;
                        reader = dac.ExecuteReader();
                        string name = "";
                        while (reader.Read())
                        {
                            name = reader["i_name"].ToString();
                        }
                        update_quan(name, quan);
                        Main.Con.Close();
                    }
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
                    Main.Con.Close();
                    MessageBox.Show("Order Updated Successfully");
                    gr1.Visible = true;
                    gr1.BringToFront();
                    all();
                }
            }
            catch 
            { 
                Main.Con.Close();
                MessageBox.Show("Invalid Entries!");
            }

        }

        private void gr1_Enter(object sender, EventArgs e)
        {

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
                    double ax = Convert.ToDouble(g1.Rows[i].Cells[3].Value);
                    double bx = Convert.ToDouble(g1.Rows[i].Cells[4].Value);
                    double xx = ax * bx;
                    this.g1.Rows[i].Cells[5].Value = xx;
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

        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
            

            if (double.Parse(txtSum.Text) < double.Parse(pt.Text))
            {
                MessageBox.Show("Please recheck the Paid Amount.");

            }
            else
            {
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
                Main.Con.Close();

            }
        }

        private void g2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
