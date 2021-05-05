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
    public partial class Rept_Supplier : UserControl
    {
        public Rept_Supplier()
        {
            InitializeComponent();
        }

        private void Rept_Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                Main.Con.Close();
                rd1.Checked = true;
                cb1_load();
                cb1.SelectedIndex = 0;
                // cb2.SelectedIndex = 0;
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
                Main.Con.Close();
                Main.Con.Open();
                SqlCommand da = new SqlCommand("select s_id, s_name from sup_reg", Main.Con);
                SqlDataReader reader;
                reader = da.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("s_name", typeof(string));
                dt.Load(reader);
                cb2.DisplayMember = "s_name";
                cb2.ValueMember = "s_id";
                cb2.DataSource = dt;
                Main.Con.Close();
                cb2.SelectedIndex = 0;
            }
            catch { Main.Con.Close(); }
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
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
                        SqlDataAdapter da = new SqlDataAdapter("Select * from supp_rp where t_date = '" + dtd.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Supplier cr = new Rpt_Supplier();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();

                    }
                    else if (cb1.SelectedIndex == 1)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from supp_rp where t_date = '" + dtd.Text + "' and s_name ='" + cb2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Supplier cr = new Rpt_Supplier();
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
                        SqlDataAdapter da = new SqlDataAdapter("Select * from supp_rp where t_date between '" + d1.Text + "' and '" + d2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Supplier cr = new Rpt_Supplier();
                        cr.SetDataSource(dt);
                        crv.ReportSource = cr;
                        cr.Refresh();
                        Main.Con.Close();
                    }
                    else if (cb1.SelectedIndex == 1)
                    {
                        Main.Con.Close();
                        Main.Con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from supp_rp where t_date between '" + d1.Text + "' and '" + d2.Text + "' and s_name ='" + cb2.Text + "' ", Main.Con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Rpt_Supplier cr = new Rpt_Supplier();
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
