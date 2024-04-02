﻿using RestaurentManagement.Controllers;
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
    public partial class BillImport_VIEW : Form
    {
        MainForm mf = new MainForm();
        public BillImport_VIEW()
        {
            InitializeComponent();
        }
        #region Event
        private void BillImportStaff_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBilImport_Click(object sender, EventArgs e)
        {
            if (dgvBilImport.Rows.Count > 0)
            {
                txtID.Text = dgvBilImport.Rows[0].Cells[0].Value.ToString();
                txtStaff.Text = dgvBilImport.Rows[0].Cells[1].Value.ToString();
                cbbSupplier.SelectedItem = dgvBilImport.Rows[0].Cells[2].Value.ToString();
                dtDayCreated.Value = Convert.ToDateTime(dgvBilImport.Rows[0].Cells[3].Value);
                txtTotalMoney.Text = dgvBilImport.Rows[0].Cells[4].Value.ToString();
            }
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"HDN00{BillImportController.Instance.GetOrderNumInList()}";
            BillImport billImport = new BillImport()
            {
                ID = id,
                StaffID = StaffController.Instance.GetIDStaffByName(txtStaff.Text),
                SupplierID = SupplierController.Instance.GetIDSupplierByName(cbbSupplier.SelectedItem.ToString()),
                DayCreated = dtDayCreated.Value,
                TotalMoney = Convert.ToInt32(txtTotalMoney.Text)
            };   
            int rs = BillImportController.Instance.InsertBillImport(billImport);
            if(rs == 1)
            {
                BillImportInfor_VIEW view = new BillImportInfor_VIEW(id);
                view.Show();

            }

        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BillImport billImport = new BillImport()
            {
                ID = txtID.Text,
                StaffID = StaffController.Instance.GetIDStaffByName(txtStaff.Text),
                SupplierID = SupplierController.Instance.GetIDSupplierByName(cbbSupplier.SelectedItem.ToString()),
                DayCreated = dtDayCreated.Value,
                TotalMoney = Convert.ToInt32(txtTotalMoney.Text)
            };
            int rs = BillImportController.Instance.UpdateBillImport(billImport);
            if (rs == 1)
            {
                mf.NotifySuss("Cập nhật hóa đơn thành công");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xóa hóa đơn id={}");
            if(qs == DialogResult.OK)
            {
                int rs = BillImportController.Instance.DeleteBillImport(txtID.Text);
                if (rs == 1)
                {
                    mf.NotifySuss("Xóa hóa đơn thành công");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvBilImport.Columns.Clear();
            List<BillImport> listBillImport = BillImportController.Instance.SelectBillImportByID(txtID.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Nhà cung cấp");
            dt.Columns.Add("Ngày tạo");
            dt.Columns.Add("Tổng hóa đơn");

            foreach (BillImport billImport in listBillImport)
            {
                dt.Rows.Add(
                    billImport.ID,
                    StaffController.Instance.GetNameStaffByID(billImport.StaffID),
                    SupplierController.Instance.GetNameSupplierByID(cbbSupplier.SelectedIndex.ToString()),
                    billImport.DayCreated,
                    billImport.TotalMoney
               );
            }

            dgvBilImport.DataSource = dt;
        }

        private void btnShowBillInfo_Click(object sender, EventArgs e)
        {
            BillImportInfor_VIEW view = new BillImportInfor_VIEW(txtID.Text);
            view.Show();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Method
        void LoadData()
        {
            LoadBill();
            LoadSupplier();
        }

        void LoadBill()
        {
            dgvBilImport.Columns.Clear();
            List<BillImport> listBillImport = BillImportController.Instance.GetListBillImport();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Nhà cung cấp");
            dt.Columns.Add("Ngày tạo");
            dt.Columns.Add("Tổng hóa đơn");

            foreach(BillImport billImport in listBillImport)
            {
                dt.Rows.Add(
                    billImport.ID,
                    StaffController.Instance.GetNameStaffByID(billImport.StaffID),
                    SupplierController.Instance.GetNameSupplierByID(cbbSupplier.SelectedIndex.ToString()),
                    billImport.DayCreated,
                    billImport.TotalMoney
               );
            }

            dgvBilImport.DataSource = dt;
        }

        void LoadSupplier()
        {
            cbbSupplier.Items.Clear();
            List<string> listnameSupplier = new List<string>();
            List<Supplier> listSupplier = SupplierController.Instance.GetListSupplier();
            foreach (Supplier supplier in listSupplier)
            {
                listnameSupplier.Add(supplier.Name);
            }

            cbbSupplier.DataSource = listnameSupplier;
        }

        void Refresh()
        {
            LoadData();
            txtID.Text = "Dnahf cho chức năng tìm kiếm";
            txtTotalMoney.Text = "0";
        }
        #endregion
    }
}