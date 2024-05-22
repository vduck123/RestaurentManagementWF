
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void NotifyErr(string mess)
        {
            MessageBox.Show("Lỗi: " + mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifySuss(string mess)
        {
            MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult NotifyConfirm(string mess)
        {
            return MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


        }
    } 
}
