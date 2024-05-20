namespace RestaurentManagement.Views.Employee
{
    partial class StaffInfo_VIEW
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffInfo_VIEW));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbOption = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.txtParam = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCheckSaleBill = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.btnUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInfoSalary = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCheckBillImport = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStaff = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnShowSalary = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 6;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageSize = new System.Drawing.Size(40, 40);
            this.btnRefresh.Location = new System.Drawing.Point(564, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 36);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Gender";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Birth";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Address";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Phone";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Chức vụ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lương cơ bản";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // cbbOption
            // 
            this.cbbOption.BackColor = System.Drawing.Color.Transparent;
            this.cbbOption.BorderRadius = 10;
            this.cbbOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOption.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbOption.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOption.ForeColor = System.Drawing.Color.Black;
            this.cbbOption.ItemHeight = 30;
            this.cbbOption.Items.AddRange(new object[] {
            "Lựa chọn tìm kiếm"});
            this.cbbOption.Location = new System.Drawing.Point(220, 50);
            this.cbbOption.Name = "cbbOption";
            this.cbbOption.Size = new System.Drawing.Size(242, 36);
            this.cbbOption.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 6;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(705, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 36);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm nhân viên";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFind
            // 
            this.btnFind.BorderRadius = 6;
            this.btnFind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFind.Location = new System.Drawing.Point(481, 50);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(77, 36);
            this.btnFind.TabIndex = 14;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtParam
            // 
            this.txtParam.BorderRadius = 10;
            this.txtParam.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtParam.DefaultText = "";
            this.txtParam.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtParam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtParam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtParam.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtParam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam.ForeColor = System.Drawing.Color.Black;
            this.txtParam.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtParam.Location = new System.Drawing.Point(12, 44);
            this.txtParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParam.Name = "txtParam";
            this.txtParam.PasswordChar = '\0';
            this.txtParam.PlaceholderText = "";
            this.txtParam.SelectedText = "";
            this.txtParam.Size = new System.Drawing.Size(201, 36);
            this.txtParam.TabIndex = 13;
            // 
            // btnCheckSaleBill
            // 
            this.btnCheckSaleBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckSaleBill.Name = "btnCheckSaleBill";
            this.btnCheckSaleBill.Size = new System.Drawing.Size(244, 22);
            this.btnCheckSaleBill.Text = "Xem những hóa đơn bán";
            this.btnCheckSaleBill.Click += new System.EventHandler(this.btnCheckSaleBill_Click);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpdate,
            this.btnDel,
            this.btnInfoSalary,
            this.btnCheckSaleBill,
            this.btnCheckBillImport});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(245, 114);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(244, 22);
            this.btnUpdate.Text = "Sửa nhân viên";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(244, 22);
            this.btnDel.Text = "Xóa nhân viên";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnInfoSalary
            // 
            this.btnInfoSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoSalary.Name = "btnInfoSalary";
            this.btnInfoSalary.Size = new System.Drawing.Size(244, 22);
            this.btnInfoSalary.Text = "Thông tin bảng lương";
            this.btnInfoSalary.Click += new System.EventHandler(this.btnInfoSalary_Click);
            // 
            // btnCheckBillImport
            // 
            this.btnCheckBillImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckBillImport.Name = "btnCheckBillImport";
            this.btnCheckBillImport.Size = new System.Drawing.Size(244, 22);
            this.btnCheckBillImport.Text = "Xem những hóa đơn nhập";
            this.btnCheckBillImport.Click += new System.EventHandler(this.btnCheckBillImport_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaff.ColumnHeadersHeight = 40;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column5,
            this.Column6,
            this.Column8});
            this.dgvStaff.ContextMenuStrip = this.guna2ContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaff.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvStaff.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaff.Location = new System.Drawing.Point(0, 101);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowHeadersWidth = 40;
            this.dgvStaff.Size = new System.Drawing.Size(1085, 655);
            this.dgvStaff.TabIndex = 12;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStaff.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaff.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvStaff.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStaff.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStaff.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStaff.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvStaff.ThemeStyle.ReadOnly = true;
            this.dgvStaff.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStaff.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStaff.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStaff.ThemeStyle.RowsStyle.Height = 22;
            this.dgvStaff.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaff.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // btnShowSalary
            // 
            this.btnShowSalary.BorderRadius = 6;
            this.btnShowSalary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowSalary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowSalary.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnShowSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowSalary.ForeColor = System.Drawing.Color.White;
            this.btnShowSalary.Location = new System.Drawing.Point(905, 50);
            this.btnShowSalary.Name = "btnShowSalary";
            this.btnShowSalary.Size = new System.Drawing.Size(168, 36);
            this.btnShowSalary.TabIndex = 18;
            this.btnShowSalary.Text = "Bảng lương nhân viên";
            this.btnShowSalary.Click += new System.EventHandler(this.btnShowSalary_Click);
            // 
            // StaffInfo_VIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 756);
            this.Controls.Add(this.btnShowSalary);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbbOption);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.dgvStaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffInfo_VIEW";
            this.Text = "StaffInfo_VIEW";
            this.Load += new System.EventHandler(this.StaffInfo_VIEW_Load);
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private Guna.UI2.WinForms.Guna2ComboBox cbbOption;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2TextBox txtParam;
        private System.Windows.Forms.ToolStripMenuItem btnCheckSaleBill;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripMenuItem btnInfoSalary;
        private System.Windows.Forms.ToolStripMenuItem btnCheckBillImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStaff;
        private Guna.UI2.WinForms.Guna2Button btnShowSalary;
    }
}