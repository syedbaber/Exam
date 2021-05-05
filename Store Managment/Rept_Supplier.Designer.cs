namespace Store_Managment
{
    partial class Rept_Supplier
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rept_Supplier));
            this.dtd = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cb1 = new Guna.UI.WinForms.GunaComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb2 = new Guna.UI.WinForms.GunaComboBox();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gunaAdvenceButton1 = new Guna.UI.WinForms.GunaAdvenceButton();
            this.l1 = new System.Windows.Forms.Label();
            this.d2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.d1 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtd
            // 
            this.dtd.BackColor = System.Drawing.Color.Transparent;
            this.dtd.BaseColor = System.Drawing.Color.Transparent;
            this.dtd.BorderColor = System.Drawing.Color.Transparent;
            this.dtd.CustomFormat = "yyyy-MM-dd";
            this.dtd.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtd.FocusedColor = System.Drawing.Color.White;
            this.dtd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtd.ForeColor = System.Drawing.Color.Transparent;
            this.dtd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtd.Location = new System.Drawing.Point(1166, 50);
            this.dtd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtd.Name = "dtd";
            this.dtd.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.dtd.OnHoverBorderColor = System.Drawing.Color.White;
            this.dtd.OnHoverForeColor = System.Drawing.Color.Transparent;
            this.dtd.OnPressedColor = System.Drawing.Color.Transparent;
            this.dtd.Radius = 5;
            this.dtd.Size = new System.Drawing.Size(103, 29);
            this.dtd.TabIndex = 253;
            this.dtd.Text = "2020-01-01";
            this.dtd.Value = new System.DateTime(2020, 1, 1, 12, 21, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 252;
            this.label1.Text = "Search By";
            // 
            // cb1
            // 
            this.cb1.BackColor = System.Drawing.Color.Transparent;
            this.cb1.BaseColor = System.Drawing.Color.LightGray;
            this.cb1.BorderColor = System.Drawing.Color.Silver;
            this.cb1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb1.FocusedColor = System.Drawing.Color.Empty;
            this.cb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb1.ForeColor = System.Drawing.Color.Black;
            this.cb1.FormattingEnabled = true;
            this.cb1.Items.AddRange(new object[] {
            "All Supliers",
            "By One Suplier"});
            this.cb1.Location = new System.Drawing.Point(161, 95);
            this.cb1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb1.Name = "cb1";
            this.cb1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(185)))));
            this.cb1.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cb1.Radius = 5;
            this.cb1.Size = new System.Drawing.Size(253, 33);
            this.cb1.TabIndex = 251;
            this.cb1.SelectedIndexChanged += new System.EventHandler(this.cb1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 250;
            this.label2.Text = "Supplier Name";
            this.label2.Visible = false;
            // 
            // cb2
            // 
            this.cb2.BackColor = System.Drawing.Color.Transparent;
            this.cb2.BaseColor = System.Drawing.Color.LightGray;
            this.cb2.BorderColor = System.Drawing.Color.Silver;
            this.cb2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2.FocusedColor = System.Drawing.Color.Empty;
            this.cb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb2.ForeColor = System.Drawing.Color.Black;
            this.cb2.FormattingEnabled = true;
            this.cb2.Location = new System.Drawing.Point(455, 97);
            this.cb2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb2.Name = "cb2";
            this.cb2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(185)))));
            this.cb2.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cb2.Radius = 5;
            this.cb2.Size = new System.Drawing.Size(183, 33);
            this.cb2.TabIndex = 249;
            this.cb2.Visible = false;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.DisplayStatusBar = false;
            this.crv.Location = new System.Drawing.Point(9, 131);
            this.crv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(1256, 421);
            this.crv.TabIndex = 248;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // gunaAdvenceButton1
            // 
            this.gunaAdvenceButton1.AnimationHoverSpeed = 0.07F;
            this.gunaAdvenceButton1.AnimationSpeed = 0.03F;
            this.gunaAdvenceButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaAdvenceButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(185)))));
            this.gunaAdvenceButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton1.CheckedBaseColor = System.Drawing.Color.Gray;
            this.gunaAdvenceButton1.CheckedBorderColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton1.CheckedForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton1.CheckedImage = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton1.CheckedImage")));
            this.gunaAdvenceButton1.CheckedLineColor = System.Drawing.Color.DimGray;
            this.gunaAdvenceButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaAdvenceButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaAdvenceButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaAdvenceButton1.Font = new System.Drawing.Font("Arial", 9F);
            this.gunaAdvenceButton1.ForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton1.Image = null;
            this.gunaAdvenceButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaAdvenceButton1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(134)))));
            this.gunaAdvenceButton1.Location = new System.Drawing.Point(1169, 97);
            this.gunaAdvenceButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaAdvenceButton1.Name = "gunaAdvenceButton1";
            this.gunaAdvenceButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(134)))));
            this.gunaAdvenceButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(134)))));
            this.gunaAdvenceButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton1.OnHoverImage = null;
            this.gunaAdvenceButton1.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(134)))));
            this.gunaAdvenceButton1.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(134)))));
            this.gunaAdvenceButton1.Radius = 5;
            this.gunaAdvenceButton1.Size = new System.Drawing.Size(93, 29);
            this.gunaAdvenceButton1.TabIndex = 246;
            this.gunaAdvenceButton1.Text = "Search";
            this.gunaAdvenceButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaAdvenceButton1.Click += new System.EventHandler(this.gunaAdvenceButton1_Click);
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.Location = new System.Drawing.Point(891, 102);
            this.l1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(24, 18);
            this.l1.TabIndex = 247;
            this.l1.Text = "To";
            this.l1.Visible = false;
            // 
            // d2
            // 
            this.d2.BackColor = System.Drawing.Color.Transparent;
            this.d2.BaseColor = System.Drawing.Color.LightGray;
            this.d2.BorderColor = System.Drawing.Color.Silver;
            this.d2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d2.CustomFormat = "yyyy-MM-dd";
            this.d2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.d2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(154)))), ((int)(((byte)(250)))));
            this.d2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.d2.ForeColor = System.Drawing.Color.Black;
            this.d2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d2.Location = new System.Drawing.Point(919, 97);
            this.d2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.d2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.d2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.d2.Name = "d2";
            this.d2.OnHoverBaseColor = System.Drawing.Color.White;
            this.d2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(154)))), ((int)(((byte)(250)))));
            this.d2.OnHoverForeColor = System.Drawing.Color.Black;
            this.d2.OnPressedColor = System.Drawing.Color.Black;
            this.d2.Radius = 5;
            this.d2.Size = new System.Drawing.Size(150, 29);
            this.d2.TabIndex = 245;
            this.d2.Text = "2020-01-24";
            this.d2.Value = new System.DateTime(2020, 1, 24, 12, 21, 41, 838);
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.Transparent;
            this.d1.BaseColor = System.Drawing.Color.LightGray;
            this.d1.BorderColor = System.Drawing.Color.Silver;
            this.d1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d1.CustomFormat = "yyyy-MM-dd";
            this.d1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.d1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(154)))), ((int)(((byte)(250)))));
            this.d1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.d1.ForeColor = System.Drawing.Color.Black;
            this.d1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d1.Location = new System.Drawing.Point(737, 97);
            this.d1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.d1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.d1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.d1.Name = "d1";
            this.d1.OnHoverBaseColor = System.Drawing.Color.White;
            this.d1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(154)))), ((int)(((byte)(250)))));
            this.d1.OnHoverForeColor = System.Drawing.Color.Black;
            this.d1.OnPressedColor = System.Drawing.Color.Black;
            this.d1.Radius = 5;
            this.d1.Size = new System.Drawing.Size(150, 29);
            this.d1.TabIndex = 244;
            this.d1.Text = "2020-01-01";
            this.d1.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // rd2
            // 
            this.rd2.AutoSize = true;
            this.rd2.Location = new System.Drawing.Point(70, 104);
            this.rd2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(60, 17);
            this.rd2.TabIndex = 243;
            this.rd2.TabStop = true;
            this.rd2.Text = "Custom";
            this.rd2.UseVisualStyleBackColor = true;
            // 
            // rd1
            // 
            this.rd1.AutoSize = true;
            this.rd1.Location = new System.Drawing.Point(7, 106);
            this.rd1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(55, 17);
            this.rd1.TabIndex = 242;
            this.rd1.TabStop = true;
            this.rd1.Text = "Today";
            this.rd1.UseVisualStyleBackColor = true;
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.Silver;
            this.gunaSeparator1.Location = new System.Drawing.Point(239, 49);
            this.gunaSeparator1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(809, 13);
            this.gunaSeparator1.TabIndex = 255;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(503, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 35);
            this.label3.TabIndex = 254;
            this.label3.Text = "Supplier Report";
            // 
            // Rept_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.gunaSeparator1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.gunaAdvenceButton1);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.rd2);
            this.Controls.Add(this.rd1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Rept_Supplier";
            this.Size = new System.Drawing.Size(1275, 558);
            this.Load += new System.EventHandler(this.Rept_Supplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDateTimePicker dtd;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaComboBox cb1;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaComboBox cb2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private Guna.UI.WinForms.GunaAdvenceButton gunaAdvenceButton1;
        private System.Windows.Forms.Label l1;
        private Guna.UI.WinForms.GunaDateTimePicker d2;
        private Guna.UI.WinForms.GunaDateTimePicker d1;
        private System.Windows.Forms.RadioButton rd2;
        private System.Windows.Forms.RadioButton rd1;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private System.Windows.Forms.Label label3;
    }
}
