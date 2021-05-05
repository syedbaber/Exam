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
    public partial class Backup : UserControl
    {
        public Backup()
        {
            InitializeComponent();
        }
        string folder = null;

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                folder = dlg.SelectedPath;
            }
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (folder == "Null")
                {
                    MessageBox.Show("Please Select Folder First");
                }
                else
                {
                    Main.Con.Close();
                    Main.Con.Open();
                    string sql = "BACKUP DATABASE storedb TO DISK= '" + folder + "\\StoreBackup-" + System.DateTime.Now.Ticks.ToString() + ".bak'";
                    SqlCommand command = new SqlCommand(sql, Main.Con);
                    command.ExecuteNonQuery();
                    Main.Con.Close();
                    MessageBox.Show("Backup Completed Successfully to ('" + folder + "')");
                    folder = "Null";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Main.Con.Close();
            }
        }
    }
}
