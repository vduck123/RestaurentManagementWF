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
    public partial class Supplier_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Supplier_VIEW()
        {
            InitializeComponent();
        }
        #region Event

        private void Supplier_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Note = txtNote.Text
            };

            int rs = SupplierController.Instance.InsertSupplier(supplier);
            if(rs == 1)
            {
                mf.NotifySuss("Thêm nhà cung cấp thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Note = txtNote.Text
            };

            int rs = SupplierController.Instance.UpdateSupplier(supplier);
            if (rs == 1)
            {
                mf.NotifySuss("Cập nhật nhà cung cấp thành công");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận nhà cung cấp");
            if(qs == DialogResult.OK)
            {
                int rs = SupplierController.Instance.DeleteSupplier(txtID.Text);
                if(rs == 1)
                {
                    mf.NotifySuss("Xóa nhà cung cấp thành công");
                    Refresh();
                } 
                else
                {
                    mf.NotifyErr("Nhà cung cấp không tồn tại");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSupplier.Columns.Clear();
            List<Supplier> listSupplier = SupplierController.Instance.SelectSupplierByID(txtID.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên NCC");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Note");

            foreach (Supplier supplier in listSupplier)
            {
                dt.Rows.Add(supplier.ID, supplier.Name, supplier.Address, supplier.Phone, supplier.Note);
            }

            dgvSupplier.DataSource = dt;


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dgvSupplier_Click(object sender, EventArgs e)
        {
            txtID.Text = dgvSupplier.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dgvSupplier.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = dgvSupplier.SelectedRows[0].Cells[2].Value.ToString();
            txtPhone.Text = dgvSupplier.SelectedRows[0].Cells[3].Value.ToString();
            txtNote.Text = dgvSupplier.SelectedRows[0].Cells[4].Value.ToString();
        }
        #endregion

        #region Method
        void LoadData()
        {
            dgvSupplier.Columns.Clear();
            List<Supplier> listSupplier = SupplierController.Instance.GetListSupplier();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên NCC");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Note");

            foreach(Supplier supplier in listSupplier)
            {
                dt.Rows.Add(supplier.ID, supplier.Name, supplier.Address, supplier.Phone, supplier.Note);
            }

            dgvSupplier.DataSource = dt;
        }

        void Refresh()
        {
            LoadData();
            txtID.ResetText();
            txtName.ResetText();
            txtAddress.ResetText();
            txtPhone.ResetText();
            txtNote.ResetText();
        }
        #endregion

    }
}
