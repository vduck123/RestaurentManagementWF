using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.Views.Billmports;
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
        string _ID = null;
        string _nameStaff = null;
        public BillImport_VIEW(string nameStaff)
        {
            InitializeComponent();
            if(!string.IsNullOrEmpty(nameStaff))
            {
                 _nameStaff = nameStaff;
            }
        }
        #region Event
        private void BillImportStaff_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"HDN00{BillImportController.Instance.GetOrderNumInList()}";           
            AddBillImport view = new AddBillImport(id,_nameStaff);
            view.Show();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //dgvBilImport.Columns.Clear();
            //List<BillImport> listBillImport = BillImportController.Instance.SelectBillImportByID(txtID.Text);
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            //dt.Columns.Add("Nhân viên");
            //dt.Columns.Add("Nhà cung cấp");
            //dt.Columns.Add("Ngày tạo");
            //dt.Columns.Add("Tổng hóa đơn");

            //foreach (BillImport billImport in listBillImport)
            //{
            //    dt.Rows.Add(
            //        billImport.ID,
            //        StaffController.Instance.GetNameStaffByID(billImport.StaffID),
            //        SupplierController.Instance.GetNameSupplierByID(billImport.SupplierID),
            //        billImport.DayCreated,
            //        billImport.TotalMoney
            //   );
            //}

            //dgvBilImport.DataSource = dt;
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion

        private void sửaHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }
            DetailBillImport_VIEW view = new DetailBillImport_VIEW(_ID);
            view.Show();
        }

        private void xóaHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Ấn OK để xóa hóa đơn id={_ID}");
            if (qs == DialogResult.OK)
            {
                int rs = BillImportController.Instance.DeleteBillImport(_ID);
                if (rs == 1)
                {
                    BillImportInfoController.Instance.DeleteAll(_ID);
                    mf.NotifySuss("Xóa hóa đơn thành công");
                    Refresh();
                }
            }
        }

        private void xemChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }
            DetailBillImport_VIEW view = new DetailBillImport_VIEW(_ID);
            view.Show();
        }

        private DataGridViewRow rowSelected = null;
        private void dgvBilImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvBilImport.Rows[e.RowIndex];
            }
            _ID = rowSelected.Cells[0].Value.ToString();
        }

        #region Method
        void LoadData()
        {
            LoadBill();
            LoadOption();
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

            foreach (BillImport billImport in listBillImport)
            {
                dt.Rows.Add(
                    billImport.ID,
                    StaffController.Instance.GetNameStaffByID(billImport.StaffID),
                    SupplierController.Instance.GetNameSupplierByID(billImport.SupplierID),
                    billImport.DayCreated,
                    billImport.TotalMoney
               );
            }

            dgvBilImport.DataSource = dt;
        }     

        void LoadOption()
        {
            List<string> listOption = new List<string>()
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên nhân viên" ,
                "Tìm kiếm theo khoảng thời gian" ,
                "Tìm kiếm theo nhà cung cấp" ,
                "Tìm kiếm theo tổng tiền"
            };
            cbbOption.DataSource = listOption;
        }

        void Refresh()
        {
            LoadData();
            txtParam.ResetText();
        }

        #endregion

        private void cbbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbOption.SelectedItem.ToString().Equals("Tìm kiếm theo khoảng thời gian"))
            {
                dtprev.Visible = true;
                lbDt.Visible = true;
                dtNext.Visible = true;
            }
            else if (cbbOption.SelectedItem.ToString().Equals("Tìm kiếm theo tổng tiền"))
            {
                cbbOpera.Visible = true;
            }
            else
            {
                dtprev.Visible = false;
                lbDt.Visible = false;
                dtNext.Visible = false;
                cbbOpera.Visible = false;
            }
        }
    }
}
