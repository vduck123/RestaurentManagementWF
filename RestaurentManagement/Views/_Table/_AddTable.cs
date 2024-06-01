using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views._Table
{
    public partial class _AddTable : Form
    {
        MainForm mf = new MainForm();
        public _AddTable()
        {
            InitializeComponent();
        }

        private void _AddTable_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                mf.NotifyErr("Tên không hợp lệ");
                return;
            }
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xác nhận thông tin");
            if (qs == DialogResult.OK)
            {
                string id = $"BA000{TableController.Instance.GetOrderNumInList() + 1}";
                Table tb = new Table(id, txtName.Text, cbbStatus.SelectedItem.ToString());
                int rs = TableController.Instance.InsertTable(tb);
                if (rs > 0)
                {
                    mf.NotifySuss("Thêm thông tin thành công");
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadData()
        {
            LoadStatus();
        }

        void LoadStatus()
        {
            List<string> status = new List<string>
            {
                "Trống" ,
                "Đầy"
            };
            cbbStatus.DataSource = status;
        }
    }
}
