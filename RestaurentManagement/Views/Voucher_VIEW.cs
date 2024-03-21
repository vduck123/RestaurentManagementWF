using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views
{
    public partial class Voucher_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Voucher_VIEW()
        {
            InitializeComponent();
        }

        #region Event
        private void Voucher_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadStatus();
        }
        private void dgvVoucher_Click(object sender, EventArgs e)
        {
            txtID.Text = dgvVoucher.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dgvVoucher.SelectedRows[0].Cells[1].Value.ToString();
            txtExpiry.Text = dgvVoucher.SelectedRows[0].Cells[2].Value.ToString();
            cbbStatus.DataSource = null;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Expiry = (int)txtExpiry.Value ,
                Status = cbbStatus.SelectedItem.ToString()
            };
            
            int rs = VoucherController.Instance.InsertVoucher(voucher);
            if(rs == 1)
            {
                mf.NotifySuss("Thêm voucher thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Expiry = (int)txtExpiry.Value,
                Status = cbbStatus.SelectedItem.ToString()
            };

            int rs = VoucherController.Instance.UpdateVoucher(voucher);
            if (rs == 1)
            {
                mf.NotifySuss("Cập nhật voucher thành công");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa thông tin");
            if(qs == DialogResult.OK)
            {
                int rs = VoucherController.Instance.DeleteVoucher(txtID.Text);
                if (rs == 1)
                {
                    mf.NotifySuss("Xóa voucher thành công");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvVoucher.Columns.Clear();
            List<Voucher> listVoucher = VoucherController.Instance.SelectVoucherByID(txtID.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên voucher");
            dt.Columns.Add("Expiry");
            dt.Columns.Add("Status");

            foreach (Voucher voucher in listVoucher)
            {
                dt.Rows.Add(voucher.ID, voucher.Name, voucher.Expiry, voucher.Status);
            }

            dgvVoucher.DataSource = dt;
        }

        private void btnTurnOn_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để cập nhật lại thông tin");
            if (qs == DialogResult.OK)
            {
                int rs = VoucherController.Instance.UpdateStatusAll("Bật");
                if (rs == 1)
                {
                    mf.NotifySuss("Cập nhật voucher thành công");
                    Refresh();
                }
            }
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để cập nhật lại thông tin");
            if (qs == DialogResult.OK)
            {
                int rs = VoucherController.Instance.UpdateStatusAll("Tắt");
                if (rs == 1)
                {
                    mf.NotifySuss("Cập nhật voucher thành công");
                    Refresh();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        
        #endregion

        #region Method
        void LoadData()
        {
            dgvVoucher.Columns.Clear();
            List<Voucher> listVoucher = VoucherController.Instance.GetListVoucher();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên voucher");
            dt.Columns.Add("Expiry");
            dt.Columns.Add("Status");

            foreach (Voucher voucher in listVoucher)
            {
                dt.Rows.Add(voucher.ID, voucher.Name, voucher.Expiry, voucher.Status);
            }

            dgvVoucher.DataSource = dt;
        }

        void LoadStatus()
        {
            List<string> listStatus = new List<string>()
            {
                "Bật" ,
                "Tắt"
            };
            cbbStatus.DataSource = listStatus;
        }

        void Refresh()
        {
            LoadData();
            LoadStatus();
            txtID.ResetText();
            txtName.ResetText();
            txtExpiry.Value = 0;
        }
        #endregion
    }
}
