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
            Refresh();
        }
        private void dgvVoucher_Click(object sender, EventArgs e)
        {
            if(dgvVoucher.Rows.Count > 0)
            {
                string[] expiry = dgvVoucher.SelectedRows[0].Cells[2].Value.ToString().Split(' ');
                txtID.Text = dgvVoucher.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvVoucher.SelectedRows[0].Cells[1].Value.ToString();
                txtExpiry.Value = Convert.ToInt32(expiry[0]);
                cbbOptionExpiry.SelectedItem = expiry[1];
                cbbStatus.SelectedItem = dgvVoucher.SelectedRows[0].Cells[3].Value.ToString();
            }            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"PGG00{VoucherController.Instance.GetOrderNumInList()}";
            string exprice = $"{txtExpiry.Value} {cbbOptionExpiry.SelectedItem}";
            Voucher voucher = new Voucher()
            {
                ID = id,
                Name = txtName.Text,
                Expiry = exprice,
                Status = cbbStatus.SelectedItem.ToString()
            };

            int rs = VoucherController.Instance.InsertVoucher(voucher);
            if (rs == 1)
            {
                mf.NotifySuss("Thêm voucher thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string exprice = $"${txtExpiry.Value} {cbbOptionExpiry.SelectedItem}";
            Voucher voucher = new Voucher()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Expiry = exprice,
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

        void LoadOptionExpiry()
        {
            List<string> options = new List<string>
            {
                "%" ,
                "Vnđ"
            };
            cbbOptionExpiry.DataSource = options;
        }

        void Refresh()
        {
            LoadData();
            LoadStatus();
            LoadOptionExpiry();
            txtID.Text = "Dành cho chức năng tìm kiếm";
            txtName.ResetText();
            txtExpiry.Value = 0;
        }
        #endregion
    }
}
