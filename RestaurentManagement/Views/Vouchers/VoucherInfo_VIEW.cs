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


namespace RestaurentManagement.Views.Vouchers
{
    public partial class VoucherInfo_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public VoucherInfo_VIEW()
        {
            InitializeComponent();
        }

        private void VoucherInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgvVoucher.Columns.Clear();
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text);
            dgvVoucher.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddVoucher_VIEW view = new AddVoucher_VIEW();
            view.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void EditVoucher_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }
            EditVoucher_VIEW view = new EditVoucher_VIEW(_ID);
            view.ShowDialog();
        }

        private void DelSalary_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xóa voucher id = {_ID}");
            if (qs == DialogResult.OK)
            {
                int rs = VoucherController.Instance.DeleteVoucher(_ID);
                if (rs == 1)
                {
                    mf.NotifySuss("Xóa voucher thành công");
                    Refresh();
                }
            }
        }

        private DataGridViewRow rowSelected = null;
        private void dgvVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowSelected = dgvVoucher.Rows[e.RowIndex];
            }

            _ID = rowSelected.Cells[0].Value.ToString();
        }
        
        DataTable HandleSearch(string option, string keyword)
        {
            List<Voucher> listVoucher = new List<Voucher>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên voucher");
            dt.Columns.Add("Khuyến mại");
            dt.Columns.Add("Trạng thái");

            switch(option)
            {
                case "Tìm kiếm theo mã":
                    {
                        listVoucher = VoucherController.Instance.SelectVoucherByParam("voucher_id", keyword, "=");
                        break;
                    }
                case "Tìm kiếm theo tên":
                    {
                        listVoucher = VoucherController.Instance.SelectVoucherByParam("voucher_name", $"%{keyword}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo khuyến mại":
                    {
                        listVoucher = VoucherController.Instance.SelectVoucherByParam("voucher_expiry", $"%{keyword}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo trạng thái":
                    {
                        listVoucher = VoucherController.Instance.SelectVoucherByParam("voucher_id", keyword, "=");
                        break;
                    }
            }

            foreach (Voucher voucher in listVoucher)
            {
                dt.Rows.Add(voucher.ID, voucher.Name, voucher.Expiry, voucher.Status);
            }

            return dt;
        }

        void LoadData()
        {
            LoadVoucher();
            LoadOption();
        }

        void LoadVoucher()
        {
            dgvVoucher.Columns.Clear();
            List<Voucher> listVoucher = VoucherController.Instance.GetListVoucher();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên voucher");
            dt.Columns.Add("Khuyến mại");
            dt.Columns.Add("Trạng thái");

            foreach (Voucher voucher in listVoucher)
            {
                dt.Rows.Add(voucher.ID, voucher.Name, voucher.Expiry, voucher.Status);
            }

            dgvVoucher.DataSource = dt;
        }

        void LoadOption()
        {
            List<string> options = new List<string>
            {
                "Tìm kiếm theo mã",
                "Tìm kiếm theo tên" ,
                "Tìm kiếm theo khuyến mại" ,
                "Tìm kiếm theo trạng thái"
            };

            cbbOption.DataSource = options;
        }


        void Refresh()
        {
            LoadData();
            txtParam.ResetText();
        }

        private void btnOnAll_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Bạn có muốn bật tất cả phiếu khuyến mại ?");
            if (qs == DialogResult.OK)
            {
                int rs = VoucherController.Instance.UpdateStatusAll("Bật");
                if (rs > 1)
                {
                    mf.NotifySuss("Cập nhật thành công");
                    Refresh();
                }
            }
        }

        private void btnOffAll_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Bạn có muốn tắt tất cả phiếu khuyến mại ?");
            if (qs == DialogResult.OK)
            {
                int rs = VoucherController.Instance.UpdateStatusAll("Tắt");
                if (rs > 1)
                {
                    mf.NotifySuss("Cập nhật thành công");
                    Refresh();
                }
            }
        }
    }
}
