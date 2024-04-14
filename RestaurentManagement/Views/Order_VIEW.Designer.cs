namespace RestaurentManagement.Views
{
    partial class Order_VIEW
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_VIEW));
            this.fpanelListTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbVoucher = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListFoodOrder = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextTable = new Guna.UI2.WinForms.Guna2Button();
            this.cbbTable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTotalBill = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbFood = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.cbbFoodCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumOrder = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFoodOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // fpanelListTable
            // 
            this.fpanelListTable.Location = new System.Drawing.Point(4, 5);
            this.fpanelListTable.Margin = new System.Windows.Forms.Padding(4);
            this.fpanelListTable.Name = "fpanelListTable";
            this.fpanelListTable.Size = new System.Drawing.Size(761, 921);
            this.fpanelListTable.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNumOrder);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbbVoucher);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvListFoodOrder);
            this.panel1.Controls.Add(this.btnPay);
            this.panel1.Controls.Add(this.btnNextTable);
            this.panel1.Controls.Add(this.cbbTable);
            this.panel1.Controls.Add(this.txtTotalBill);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbbFood);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cbbFoodCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Location = new System.Drawing.Point(767, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 921);
            this.panel1.TabIndex = 1;
            // 
            // cbbVoucher
            // 
            this.cbbVoucher.BackColor = System.Drawing.Color.Transparent;
            this.cbbVoucher.BorderRadius = 10;
            this.cbbVoucher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbVoucher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVoucher.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbVoucher.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbVoucher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbVoucher.ForeColor = System.Drawing.Color.Black;
            this.cbbVoucher.ItemHeight = 25;
            this.cbbVoucher.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbbVoucher.Location = new System.Drawing.Point(187, 789);
            this.cbbVoucher.Margin = new System.Windows.Forms.Padding(4);
            this.cbbVoucher.Name = "cbbVoucher";
            this.cbbVoucher.Size = new System.Drawing.Size(444, 31);
            this.cbbVoucher.TabIndex = 14;
            this.cbbVoucher.SelectedIndexChanged += new System.EventHandler(this.cbbVoucher_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 794);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Voucher:";
            // 
            // dgvListFoodOrder
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvListFoodOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListFoodOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvListFoodOrder.ColumnHeadersHeight = 30;
            this.dgvListFoodOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListFoodOrder.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvListFoodOrder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListFoodOrder.Location = new System.Drawing.Point(4, 181);
            this.dgvListFoodOrder.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListFoodOrder.Name = "dgvListFoodOrder";
            this.dgvListFoodOrder.RowHeadersVisible = false;
            this.dgvListFoodOrder.RowHeadersWidth = 51;
            this.dgvListFoodOrder.Size = new System.Drawing.Size(671, 528);
            this.dgvListFoodOrder.TabIndex = 11;
            this.dgvListFoodOrder.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListFoodOrder.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListFoodOrder.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListFoodOrder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListFoodOrder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListFoodOrder.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListFoodOrder.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListFoodOrder.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListFoodOrder.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListFoodOrder.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListFoodOrder.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListFoodOrder.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListFoodOrder.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvListFoodOrder.ThemeStyle.ReadOnly = false;
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.Height = 22;
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListFoodOrder.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Món ăn";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Số lượng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Đơn giá";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Thành tiền";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 6;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(462, 863);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(161, 38);
            this.btnPay.TabIndex = 10;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnNextTable
            // 
            this.btnNextTable.BorderRadius = 6;
            this.btnNextTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextTable.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextTable.ForeColor = System.Drawing.Color.White;
            this.btnNextTable.Location = new System.Drawing.Point(239, 863);
            this.btnNextTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextTable.Name = "btnNextTable";
            this.btnNextTable.Size = new System.Drawing.Size(187, 38);
            this.btnNextTable.TabIndex = 9;
            this.btnNextTable.Text = "Chuyển bàn";
            this.btnNextTable.Click += new System.EventHandler(this.btnNextTable_Click);
            // 
            // cbbTable
            // 
            this.cbbTable.BackColor = System.Drawing.Color.Transparent;
            this.cbbTable.BorderRadius = 10;
            this.cbbTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbTable.ItemHeight = 30;
            this.cbbTable.Location = new System.Drawing.Point(51, 865);
            this.cbbTable.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTable.Name = "cbbTable";
            this.cbbTable.Size = new System.Drawing.Size(159, 36);
            this.cbbTable.TabIndex = 8;
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.BorderRadius = 10;
            this.txtTotalBill.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalBill.DefaultText = "0";
            this.txtTotalBill.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalBill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalBill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalBill.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalBill.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalBill.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.ForeColor = System.Drawing.Color.Black;
            this.txtTotalBill.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalBill.Location = new System.Drawing.Point(187, 748);
            this.txtTotalBill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.PasswordChar = '\0';
            this.txtTotalBill.PlaceholderText = "";
            this.txtTotalBill.SelectedText = "";
            this.txtTotalBill.Size = new System.Drawing.Size(445, 33);
            this.txtTotalBill.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 753);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tổng tiền:";
            // 
            // cbbFood
            // 
            this.cbbFood.BackColor = System.Drawing.Color.Transparent;
            this.cbbFood.BorderRadius = 10;
            this.cbbFood.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFood.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFood.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFood.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbFood.ForeColor = System.Drawing.Color.Black;
            this.cbbFood.ItemHeight = 30;
            this.cbbFood.Location = new System.Drawing.Point(17, 129);
            this.cbbFood.Margin = new System.Windows.Forms.Padding(4);
            this.cbbFood.Name = "cbbFood";
            this.cbbFood.Size = new System.Drawing.Size(408, 36);
            this.cbbFood.TabIndex = 4;
            this.cbbFood.SelectedIndexChanged += new System.EventHandler(this.cbbFood_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 6;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(480, 78);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(187, 38);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm món";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbbFoodCategory
            // 
            this.cbbFoodCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbbFoodCategory.BorderRadius = 10;
            this.cbbFoodCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFoodCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFoodCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFoodCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFoodCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbFoodCategory.ForeColor = System.Drawing.Color.Black;
            this.cbbFoodCategory.ItemHeight = 30;
            this.cbbFoodCategory.Location = new System.Drawing.Point(17, 78);
            this.cbbFoodCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbbFoodCategory.Name = "cbbFoodCategory";
            this.cbbFoodCategory.Size = new System.Drawing.Size(408, 36);
            this.cbbFoodCategory.TabIndex = 2;
            this.cbbFoodCategory.SelectedIndexChanged += new System.EventHandler(this.cbbFoodCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(133, 23);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(33, 25);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.guna2Panel1.Location = new System.Drawing.Point(763, 5);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(4, 921);
            this.guna2Panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(477, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Số lượng:";
            // 
            // txtNumOrder
            // 
            this.txtNumOrder.BackColor = System.Drawing.Color.Transparent;
            this.txtNumOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOrder.Location = new System.Drawing.Point(577, 136);
            this.txtNumOrder.Name = "txtNumOrder";
            this.txtNumOrder.Size = new System.Drawing.Size(90, 29);
            this.txtNumOrder.TabIndex = 16;
            // 
            // Order_VIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 930);
            this.ControlBox = false;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fpanelListTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(300, 399);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Order_VIEW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Order_VIEW";
            this.Load += new System.EventHandler(this.Order_VIEW_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFoodOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpanelListTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbFood;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2ComboBox cbbFoodCategory;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnNextTable;
        private Guna.UI2.WinForms.Guna2ComboBox cbbTable;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListFoodOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbbVoucher;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalBill;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtNumOrder;
        private System.Windows.Forms.Label label4;
    }
}