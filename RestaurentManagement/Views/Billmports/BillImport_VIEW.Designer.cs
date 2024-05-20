namespace RestaurentManagement.Views
{
    partial class BillImport_VIEW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillImport_VIEW));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.sửaHóaĐơnNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaHóaĐơnNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemChiTiếtHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBilImport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbOption = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtParam = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbbOpera = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtNext = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtPrev = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbDt = new System.Windows.Forms.Label();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilImport)).BeginInit();
            this.SuspendLayout();
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
            this.btnSearch.Location = new System.Drawing.Point(525, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 36);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(707, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(162, 36);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Tạo hóa đơn";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnExcel.Location = new System.Drawing.Point(975, 55);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(98, 37);
            this.btnExcel.TabIndex = 24;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            this.btnRefresh.Location = new System.Drawing.Point(610, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 36);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaHóaĐơnNhậpToolStripMenuItem,
            this.xóaHóaĐơnNhậpToolStripMenuItem,
            this.xemChiTiếtHóaĐơnToolStripMenuItem});
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
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(211, 70);
            // 
            // sửaHóaĐơnNhậpToolStripMenuItem
            // 
            this.sửaHóaĐơnNhậpToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sửaHóaĐơnNhậpToolStripMenuItem.Name = "sửaHóaĐơnNhậpToolStripMenuItem";
            this.sửaHóaĐơnNhậpToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.sửaHóaĐơnNhậpToolStripMenuItem.Text = "Sửa hóa đơn nhập";
            this.sửaHóaĐơnNhậpToolStripMenuItem.Click += new System.EventHandler(this.sửaHóaĐơnNhậpToolStripMenuItem_Click);
            // 
            // xóaHóaĐơnNhậpToolStripMenuItem
            // 
            this.xóaHóaĐơnNhậpToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaHóaĐơnNhậpToolStripMenuItem.Name = "xóaHóaĐơnNhậpToolStripMenuItem";
            this.xóaHóaĐơnNhậpToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.xóaHóaĐơnNhậpToolStripMenuItem.Text = "Xóa hóa đơn nhập";
            this.xóaHóaĐơnNhậpToolStripMenuItem.Click += new System.EventHandler(this.xóaHóaĐơnNhậpToolStripMenuItem_Click);
            // 
            // xemChiTiếtHóaĐơnToolStripMenuItem
            // 
            this.xemChiTiếtHóaĐơnToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemChiTiếtHóaĐơnToolStripMenuItem.Name = "xemChiTiếtHóaĐơnToolStripMenuItem";
            this.xemChiTiếtHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.xemChiTiếtHóaĐơnToolStripMenuItem.Text = "Xem chi tiết hóa đơn";
            this.xemChiTiếtHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtHóaĐơnToolStripMenuItem_Click);
            // 
            // dgvBilImport
            // 
            this.dgvBilImport.AllowUserToAddRows = false;
            this.dgvBilImport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBilImport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBilImport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBilImport.ColumnHeadersHeight = 30;
            this.dgvBilImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBilImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvBilImport.ContextMenuStrip = this.guna2ContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBilImport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBilImport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBilImport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBilImport.Location = new System.Drawing.Point(0, 131);
            this.dgvBilImport.Name = "dgvBilImport";
            this.dgvBilImport.ReadOnly = true;
            this.dgvBilImport.RowHeadersVisible = false;
            this.dgvBilImport.RowHeadersWidth = 51;
            this.dgvBilImport.Size = new System.Drawing.Size(1085, 625);
            this.dgvBilImport.TabIndex = 0;
            this.dgvBilImport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBilImport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBilImport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBilImport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBilImport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBilImport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBilImport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBilImport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBilImport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBilImport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBilImport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBilImport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBilImport.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvBilImport.ThemeStyle.ReadOnly = true;
            this.dgvBilImport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBilImport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBilImport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBilImport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBilImport.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBilImport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBilImport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBilImport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBilImport_CellClick);
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
            this.Column2.HeaderText = "Staff created";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Supplier";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "CreatedDay";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "TotalMoney";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
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
            this.cbbOption.Location = new System.Drawing.Point(252, 57);
            this.cbbOption.Name = "cbbOption";
            this.cbbOption.Size = new System.Drawing.Size(267, 36);
            this.cbbOption.TabIndex = 29;
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
            this.txtParam.Location = new System.Drawing.Point(34, 56);
            this.txtParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParam.Name = "txtParam";
            this.txtParam.PasswordChar = '\0';
            this.txtParam.PlaceholderText = "";
            this.txtParam.SelectedText = "";
            this.txtParam.Size = new System.Drawing.Size(201, 36);
            this.txtParam.TabIndex = 28;
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
            this.cbbOpera.Location = new System.Drawing.Point(410, 12);
            this.cbbOpera.Name = "cbbOpera";
            this.cbbOpera.Size = new System.Drawing.Size(109, 36);
            this.cbbOpera.TabIndex = 30;
            this.cbbOpera.Visible = false;
            // 
            // dtNext
            // 
            this.dtNext.Checked = true;
            this.dtNext.FillColor = System.Drawing.Color.Gray;
            this.dtNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNext.ForeColor = System.Drawing.Color.White;
            this.dtNext.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNext.Location = new System.Drawing.Point(267, 99);
            this.dtNext.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNext.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNext.Name = "dtNext";
            this.dtNext.Size = new System.Drawing.Size(172, 25);
            this.dtNext.TabIndex = 31;
            this.dtNext.Value = new System.DateTime(2024, 4, 27, 2, 46, 4, 963);
            this.dtNext.Visible = false;
            // 
            // dtPrev
            // 
            this.dtPrev.Checked = true;
            this.dtPrev.FillColor = System.Drawing.Color.DimGray;
            this.dtPrev.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPrev.ForeColor = System.Drawing.Color.White;
            this.dtPrev.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPrev.Location = new System.Drawing.Point(34, 99);
            this.dtPrev.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtPrev.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtPrev.Name = "dtPrev";
            this.dtPrev.Size = new System.Drawing.Size(180, 25);
            this.dtPrev.TabIndex = 32;
            this.dtPrev.Value = new System.DateTime(2024, 4, 27, 2, 46, 4, 957);
            this.dtPrev.Visible = false;
            // 
            // lbDt
            // 
            this.lbDt.AutoSize = true;
            this.lbDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDt.Location = new System.Drawing.Point(225, 104);
            this.lbDt.Name = "lbDt";
            this.lbDt.Size = new System.Drawing.Size(31, 16);
            this.lbDt.TabIndex = 33;
            this.lbDt.Text = "Đến";
            this.lbDt.Visible = false;
            // 
            // BillImport_VIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 756);
            this.Controls.Add(this.lbDt);
            this.Controls.Add(this.dtPrev);
            this.Controls.Add(this.dtNext);
            this.Controls.Add(this.cbbOpera);
            this.Controls.Add(this.cbbOption);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvBilImport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillImport_VIEW";
            this.Text = "BillImportStaff_VIEW";
            this.Load += new System.EventHandler(this.BillImportStaff_VIEW_Load);
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilImport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sửaHóaĐơnNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaHóaĐơnNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtHóaĐơnToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBilImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Guna.UI2.WinForms.Guna2ComboBox cbbOption;
        private Guna.UI2.WinForms.Guna2TextBox txtParam;
        private Guna.UI2.WinForms.Guna2ComboBox cbbOpera;
        private System.Windows.Forms.Label lbDt;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtPrev;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNext;
    }
}