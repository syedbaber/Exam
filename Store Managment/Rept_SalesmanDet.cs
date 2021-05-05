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
    public partial class Rept_SalesmanDet : UserControl
    {
        public Rept_SalesmanDet()
        {
            InitializeComponent();
        }

        private void Rept_SalesmanDet_Load(object sender, EventArgs e)
        {
            try
            {
                rd1.Checked = true;
                cb2_load();
                dtd.Value = System.DateTime.Now;
                cb1.SelectedIndex = 0;
                cb2.SelectedIndex = 0;
                d2.Value = System.DateTime.Now;
                var today = DateTime.Today;
                var lastmonth = new DateTime(today.Year, today.Month, 1);
                d1.Value = lastmonth;
            }
            catch { Main.Con.Close(); }
        }
        private void cb2_load()
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
                        SqlDataAdapter da = new SqlDataAdapter("Select * from Salesmen where b_date = '" + dtd.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Salesman_Dt cr = new Rpt_Salesman_Dt();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();

                    }
                    else if (cb1.SelectedIndex == 1)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from Salesmen where b_date = '" + dtd.Text + "' and c_name ='" + cb2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Salesman_Dt cr = new Rpt_Salesman_Dt();
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
                        SqlDataAdapter da = new SqlDataAdapter("Select * from Salesmen where b_date between '" + d1.Text + "' and '" + d2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Salesman_Dt cr = new Rpt_Salesman_Dt();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();
                    }
                    else if (cb1.SelectedIndex == 1)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from Salesmen where b_date between '" + d1.Text + "' and '" + d2.Text + "' and c_name ='" + cb2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Salesman_Dt cr = new Rpt_Salesman_Dt();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();
                    }
                }
            }
            catch { Main.Con.Close(); }
        }
    }
}
