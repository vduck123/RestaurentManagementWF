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

namespace RestaurentManagement.Views.NotifyBill
{
    public partial class NotifyBillImport : Form
    {
        string _nameStaff = null;
        string _nameSupplier = null;
        string _idBill = null;
        public NotifyBillImport(string nameStaff, string nameSupplier, string idBill)
        {
            InitializeComponent();
            _nameStaff = nameStaff;
            _nameSupplier = nameSupplier;
            _idBill = idBill;
        }

        private void NotifyBillImport_Load(object sender, EventArgs e)
        {
            GetData();
        }

        void GetData()
        {
            if(_idBill == null)
            {
                return;
            }
            dgvBillInfo.Columns.Clear();
            List<BillImportInfo> list = BillImportInfoController.Instance.GetAllBillImportInfoByBillImportID(_idBill);
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên nguyên liệu");         
            dt.Columns.Add("Đơn giá");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Đơn vị tính");
            dt.Columns.Add("Thành tiền");
            foreach (BillImportInfo item in list)
            {
                dt.Rows.Add(WarehouseController.Instance.GetNameItemByID(item.ItemID), item.Price, item.Quantity, item.Unit, item.TotalMoney);
            }

            dgvBillInfo.DataSource = dt;

            lbNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbThuNgan.Text = _nameStaff;
            lbProviderName.Text = _nameSupplier;

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult qs = MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(qs == DialogResult.Yes)
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintBillImport view = new PrintBillImport(_nameStaff, _nameSupplier, _idBill);
            view.ShowDialog();
        }
    }
}
