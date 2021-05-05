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
    public partial class Rept_SalesMan : UserControl
    {
        public Rept_SalesMan()
        {
            InitializeComponent();
        }

        private void SalesMan_Load(object sender, EventArgs e)
        {
            try
            {
                rd1.Checked = true;
                cb1_load();
                cb1.SelectedIndex = 0;
                cb2.SelectedIndex = 0;
                d2.Value = System.DateTime.Now;
                dtd.Value = System.DateTime.Now;
                var today = DateTime.Today;
                var lastmonth = new DateTime(today.Year, today.Month, 1);
                d1.Value = lastmonth;
            }
            catch { Main.Con.Close(); }
        }
        private void cb1_load()
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
                cb2.DisplayMember = "c_name";
                cb2.ValueMember = "c_id";
                cb2.DataSource = dt;
                Main.Con.Close();
                cb2.SelectedIndex = 0;
            }
            catch { Main.Con.Close(); }
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb1.SelectedIndex == 0)
                {
                    label2.Visible = false;
                    cb2.Visible = false;
                }
                if (cb1.SelectedIndex == 1)
                {
                    label2.Visible = true;
                    cb2.Visible = true;
                }
            }
            catch { Main.Con.Close(); }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rd1.Checked)
                {
                    if (cb1.SelectedIndex == 0)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from bill where b_date = '" + dtd.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_SalesMan cr = new Rpt_SalesMan();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();

                    }
                    else if (cb1.SelectedIndex == 1)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from bill where b_date = '" + dtd.Text + "' and c_name ='" + cb2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_SalesMan cr = new Rpt_SalesMan();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();
                    }
                }
                else if (rd2.Checked)
                {
                    if (cb1.SelectedIndex == 0)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from bill where b_date between '" + d1.Text + "' and '" + d2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_SalesMan cr = new Rpt_SalesMan();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();
                    }
                    else if (cb1.SelectedIndex == 1)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from bill where b_date between '" + d1.Text + "' and '" + d2.Text + "' and c_name ='" + cb2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_SalesMan cr = new Rpt_SalesMan();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();
                    }
                }
            }
            catch { Main.Con.Close(); }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaSeparator1_Click(object sender, EventArgs e)
        {

        }
    }
}
