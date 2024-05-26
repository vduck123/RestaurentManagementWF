using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
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
using _EditView = RestaurentManagement.Views.Provider.EditProvider;

namespace RestaurentManagement.Views.Provider
{
    public partial class ProviderInfo_VIEW : Form
    {
        string _ID = null;
        MainForm mf = new MainForm();
        public ProviderInfo_VIEW()
        {
            InitializeComponent();
        }
        private void ProviderInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        DataGridViewRow rowSelected = null;
        private void dgvProvider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvProvider.Rows[e.RowIndex];
            }
            _ID = rowSelected.Cells[0].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProvider view = new AddProvider();
            view.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtParam.Text))
            {
                mf.NotifyErr("Giá trị tìm kiếm không hợp lệ");
                return;
            }
            dgvProvider.Columns.Clear();
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text);
            dgvProvider.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        void LoadData()
        {
            LoadProvider();
            LoadOption();
        }

        DataTable HandleSearch(string option, string param)
        {
            List<Supplier> listSupplier = new List<Supplier>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên NCC");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Note");
            switch(option)
            {
                case "Tìm kiếm theo mã":
                    {
                        listSupplier = SupplierController.Instance.SelectSupplierByParam("supplier_id", txtParam.Text, "=");
                         break;
                    }
                case "Tìm kiếm theo tên":
                    {
                        listSupplier = SupplierController.Instance.SelectSupplierByParam("supplier_name", $"%{txtParam.Text}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo địa chỉ":
                    {
                        listSupplier = SupplierController.Instance.SelectSupplierByParam("address", $"%{txtParam.Text}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo số điện thoại":
                    {
                        listSupplier = SupplierController.Instance.SelectSupplierByParam("phone", $"%{txtParam.Text}%", "=");
                        break;
                    }
                case "Tìm kiếm theo ghi chú":
                    {
                        listSupplier = SupplierController.Instance.SelectSupplierByParam("note", $"%{txtParam.Text}%", "=");
                        break;
                    }
            }

            foreach (Supplier supplier in listSupplier)
            {
                dt.Rows.Add(supplier.ID, supplier.Name, supplier.Address, supplier.Phone, supplier.Note);
            }
            return dt;
        }
        void LoadProvider()
        {
            dgvProvider.Columns.Clear();
            List<Supplier> listSupplier = SupplierController.Instance.GetListSupplier();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên NCC");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Ghi chú");

            foreach (Supplier supplier in listSupplier)
            {
                dt.Rows.Add(supplier.ID, supplier.Name, supplier.Address, supplier.Phone, supplier.Note);
            }

            dgvProvider.DataSource = dt;
        }

        void LoadOption()
        {
            List<string> options = new List<string>()
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên" ,
                "Tìm kiếm theo địa chỉ" ,
                "Tìm kiếm theo số điện thoại" ,
                "Tìm kiếm theo ghi chú"

            };

            cbbOption.DataSource = options;

        }

        void Refresh()
        {
            txtParam.ResetText();
            LoadData();
        }

        private void EditProvider_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }
            _EditView view = new _EditView(_ID);
            view.ShowDialog();
        }

        private void DelProvider_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }
            DialogResult qs = mf.NotifyConfirm($"Ấn OK để xác nhận xóa nhà cung cấp id = {_ID}");
            if (qs == DialogResult.OK)
            {
                int rs = SupplierController.Instance.DeleteSupplier(_ID);
                if (rs == 1)
                {
                    mf.NotifySuss("Xóa nhà cung cấp thành công");
                }
            }
        }

       
    }
}
