namespace RestaurentManagement.Views.BillSales
{
    partial class BillSaleInfo_VIEW
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillSaleInfo_VIEW));
            this.lbDt = new System.Windows.Forms.Label();
            this.dtNext = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbbOpera = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbOption = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtParam = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvBillSale = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaHóaĐơnBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtPrev = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillSale)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDt
            // 
            this.lbDt.AutoSize = true;
            this.lbDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDt.Location = new System.Drawing.Point(225, 97);
            this.lbDt.Name = "lbDt";
            this.lbDt.Size = new System.Drawing.Size(31, 16);
            this.lbDt.TabIndex = 44;
            this.lbDt.Text = "Đến";
            this.lbDt.Visible = false;
            // 
            // dtNext
            // 
            this.dtNext.Checked = true;
            this.dtNext.FillColor = System.Drawing.Color.Gray;
            this.dtNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNext.ForeColor = System.Drawing.Color.White;
            this.dtNext.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNext.Location = new System.Drawing.Point(267, 92);
            this.dtNext.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNext.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNext.Name = "dtNext";
            this.dtNext.Size = new System.Drawing.Size(172, 25);
            this.dtNext.TabIndex = 42;
            this.dtNext.Value = new System.DateTime(2024, 4, 27, 2, 46, 4, 963);
            this.dtNext.Visible = false;
            // 
            // cbbOpera
            // 
            this.cbbOpera.BackColor = System.Drawing.Color.Transparent;
            this.cbbOpera.BorderRadius = 10;
            this.cbbOpera.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOpera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOpera.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbOpera.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbOpera.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOpera.ForeColor = System.Drawing.Color.Black;
            this.cbbOpera.ItemHeight = 30;
            this.cbbOpera.Items.AddRange(new object[] {
            ">",
            "=",
            "<"});
            this.cbbOpera.Location = new System.Drawing.Point(221, 8);
            this.cbbOpera.Name = "cbbOpera";
            this.cbbOpera.Size = new System.Drawing.Size(109, 36);
            this.cbbOpera.TabIndex = 41;
            this.cbbOpera.Visible = false;
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
            this.cbbOption.Location = new System.Drawing.Point(221, 50);
            this.cbbOption.Name = "cbbOption";
            this.cbbOption.Size = new System.Drawing.Size(318, 36);
            this.cbbOption.TabIndex = 40;
            this.cbbOption.SelectedValueChanged += new System.EventHandler(this.cbbOption_SelectedValueChanged);
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
            this.txtParam.Location = new System.Drawing.Point(13, 50);
            this.txtParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParam.Name = "txtParam";
            this.txtParam.PasswordChar = '\0';
            this.txtParam.PlaceholderText = "";
            this.txtParam.SelectedText = "";
            this.txtParam.Size = new System.Drawing.Size(201, 36);
            this.txtParam.TabIndex = 39;
            // 
            // dgvBillSale
            // 
            this.dgvBillSale.AllowUserToAddRows = false;
            this.dgvBillSale.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvBillSale.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillSale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBillSale.ColumnHeadersHeight = 30;
            this.dgvBillSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBillSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvBillSale.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBillSale.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBillSale.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBillSale.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBillSale.Location = new System.Drawing.Point(0, 131);
            this.dgvBillSale.Name = "dgvBillSale";
            this.dgvBillSale.ReadOnly = true;
            this.dgvBillSale.RowHeadersVisible = false;
            this.dgvBillSale.RowHeadersWidth = 51;
            this.dgvBillSale.Size = new System.Drawing.Size(1085, 625);
            this.dgvBillSale.TabIndex = 34;
            this.dgvBillSale.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBillSale.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBillSale.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBillSale.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBillSale.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBillSale.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBillSale.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBillSale.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBillSale.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBillSale.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBillSale.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBillSale.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBillSale.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvBillSale.ThemeStyle.ReadOnly = true;
            this.dgvBillSale.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBillSale.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBillSale.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBillSale.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBillSale.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBillSale.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBillSale.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBillSale.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBilImport_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Day in";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Day out";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Giảm giá";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total money";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Staff name";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Table id";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaHóaĐơnBánToolStripMenuItem,
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(239, 48);
            // 
            // xóaHóaĐơnBánToolStripMenuItem
            // 
            this.xóaHóaĐơnBánToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaHóaĐơnBánToolStripMenuItem.Name = "xóaHóaĐơnBánToolStripMenuItem";
            this.xóaHóaĐơnBánToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.xóaHóaĐơnBánToolStripMenuItem.Text = "Xóa hóa đơn bán";
            this.xóaHóaĐơnBánToolStripMenuItem.Click += new System.EventHandler(this.xóaHóaĐơnBánToolStripMenuItem_Click);
            // 
            // xemChiTiếtHóaĐơnBánToolStripMenuItem
            // 
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem.Name = "xemChiTiếtHóaĐơnBánToolStripMenuItem";
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem.Text = "Xem chi tiết hóa đơn bán";
            this.xemChiTiếtHóaĐơnBánToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtHóaĐơnBánToolStripMenuItem_Click);
            // 
            // dtPrev
            // 
            this.dtPrev.Checked = true;
            this.dtPrev.FillColor = System.Drawing.Color.DimGray;
            this.dtPrev.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPrev.ForeColor = System.Drawing.Color.White;
            this.dtPrev.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPrev.Location = new System.Drawing.Point(34, 92);
            this.dtPrev.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtPrev.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtPrev.Name = "dtPrev";
            this.dtPrev.Size = new System.Drawing.Size(180, 25);
            this.dtPrev.TabIndex = 43;
            this.dtPrev.Value = new System.DateTime(2024, 4, 27, 2, 46, 4, 957);
            this.dtPrev.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 7;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Location = new System.Drawing.Point(545, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 36);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 7;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageSize = new System.Drawing.Size(40, 40);
            this.btnRefresh.Location = new System.Drawing.Point(657, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 36);
            this.btnRefresh.TabIndex = 35;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Lime;
            this.btnExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExcel.FillColor = System.Drawing.Color.ForestGreen;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(933, 49);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(135, 36);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // BillSaleInfo_VIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 756);
            this.Controls.Add(this.lbDt);
            this.Controls.Add(this.dtNext);
            this.Controls.Add(this.cbbOpera);
            this.Controls.Add(this.cbbOption);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.dgvBillSale);
            this.Controls.Add(this.dtPrev);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExcel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BillSaleInfo_VIEW";
            this.Text = "BillSaleInfo_VIEW";
            this.Load += new System.EventHandler(this.BillSaleInfo_VIEW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillSale)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDt;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNext;
        private Guna.UI2.WinForms.Guna2ComboBox cbbOpera;
        private Guna.UI2.WinForms.Guna2ComboBox cbbOption;
        private Guna.UI2.WinForms.Guna2TextBox txtParam;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBillSale;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtPrev;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaHóaĐơnBánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtHóaĐơnBánToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}