namespace RestaurentManagement.Views
{
    partial class Home_VIEW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_VIEW));
            this.btnSignOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangeAccount = new Guna.UI2.WinForms.Guna2Button();
            this.lbDay = new System.Windows.Forms.Label();
            this.lbCalendar = new System.Windows.Forms.Label();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbCLock = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSignOut
            // 
            this.btnSignOut.BorderRadius = 10;
            this.btnSignOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.ForeColor = System.Drawing.Color.White;
            this.btnSignOut.Image = ((System.Drawing.Image)(resources.GetObject("btnSignOut.Image")));
            this.btnSignOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSignOut.Location = new System.Drawing.Point(428, 448);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(197, 39);
            this.btnSignOut.TabIndex = 32;
            this.btnSignOut.Text = "Sign out";
            // 
            // btnChangeAccount
            // 
            this.btnChangeAccount.BorderRadius = 10;
            this.btnChangeAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnChangeAccount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeAccount.ForeColor = System.Drawing.Color.White;
            this.btnChangeAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeAccount.Image")));
            this.btnChangeAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangeAccount.Location = new System.Drawing.Point(428, 386);
            this.btnChangeAccount.Name = "btnChangeAccount";
            this.btnChangeAccount.Size = new System.Drawing.Size(197, 39);
            this.btnChangeAccount.TabIndex = 31;
            this.btnChangeAccount.Text = "Change Account";
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDay.Location = new System.Drawing.Point(671, 306);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(58, 32);
            this.lbDay.TabIndex = 30;
            this.lbDay.Text = "Thứ";
            // 
            // lbCalendar
            // 
            this.lbCalendar.AutoSize = true;
            this.lbCalendar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalendar.Location = new System.Drawing.Point(271, 306);
            this.lbCalendar.Name = "lbCalendar";
            this.lbCalendar.Size = new System.Drawing.Size(74, 32);
            this.lbCalendar.TabIndex = 29;
            this.lbCalendar.Text = "Ngày";
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.Location = new System.Drawing.Point(553, 259);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(40, 21);
            this.lbSecond.TabIndex = 28;
            this.lbSecond.Text = "giây";
            // 
            // lbCLock
            // 
            this.lbCLock.AutoSize = true;
            this.lbCLock.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCLock.Location = new System.Drawing.Point(451, 243);
            this.lbCLock.Name = "lbCLock";
            this.lbCLock.Size = new System.Drawing.Size(61, 37);
            this.lbCLock.TabIndex = 27;
            this.lbCLock.Text = "Giờ";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.InitialImage = null;
            this.guna2PictureBox1.Location = new System.Drawing.Point(428, 51);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(208, 176);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 26;
            this.guna2PictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Home_VIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 663);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnChangeAccount);
            this.Controls.Add(this.lbDay);
            this.Controls.Add(this.lbCalendar);
            this.Controls.Add(this.lbSecond);
            this.Controls.Add(this.lbCLock);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_VIEW";
            this.ShowIcon = false;
            this.Text = "Home_VIEW";
            this.Load += new System.EventHandler(this.Home_VIEW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSignOut;
        private Guna.UI2.WinForms.Guna2Button btnChangeAccount;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.Label lbCalendar;
        private System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.Label lbCLock;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}