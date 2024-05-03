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

namespace RestaurentManagement.Views.BillSales
{
    public partial class BillSaleInfo_VIEW : Form
    {
        string _ID = null;
        MainForm mf = new MainForm();
        public BillSaleInfo_VIEW()
        {
            InitializeComponent();
        }

        private void BillSaleInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvBillSale.Columns.Clear();
            string opera = cbbOpera.SelectedItem == null ? null : cbbOpera.SelectedItem.ToString();
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text, opera);
            dgvBillSale.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        DataGridViewRow rowSelected = null;
        private void dgvBilImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvBillSale.Rows[e.RowIndex];
                _ID = rowSelected.Cells[0].Value.ToString();
            }
        }

        private void cbbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbOption.SelectedItem.ToString().Equals("Tìm kiếm theo khoảng thời gian"))
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

        private void xóaHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }


            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xóa hóa đơn bán id = {_ID}");
            if (qs == DialogResult.OK)
            {
                int rs = BillSaleInfoController.Instance.DeleteBillSaleInfo(_ID);
                if (rs > 0)
                {
                    BillSaleController.Instance.DeleteBillSale(_ID);
                    mf.NotifySuss("Xóa hóa đơn thành công");
                }
            }
        }

        private void xemChiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailBillSales_VIEW view = new DetailBillSales_VIEW(_ID);
            view.ShowDialog();
        }

        #region Method
        DataTable HandleSearch(string option, string param, string opera)
        {
            List<BillSale> listBillSale = new List<BillSale>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Thời gian vào");
            dt.Columns.Add("Thời gian ra");
            dt.Columns.Add("Tổng hóa đơn");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Bàn");
            switch (option)
            {
                case "Tìm kiếm theo mã":
                    {
                        listBillSale = BillSaleController.Instance.GetBillSaleByParam("boSale_id", $"'{param}'", "=");
                        break;
                    }
                case "Tìm kiếm theo nhân viên":
                    {
                        listBillSale = BillSaleController.Instance.GetBillSaleByParam("staff_id", $"'{StaffController.Instance.GetIDStaffByName(param)}'", "=");
                        break;
                    }
                case "Tìm kiếm theo bàn":
                    {
                        listBillSale = BillSaleController.Instance.GetBillSaleByParam("table_id", $"'{TableController.Instance.GetIDTableByName(param)}'", "=");
                        break;
                    }
                case "Tìm kiếm theo tổng hóa đơn":
                    {
                        listBillSale = BillSaleController.Instance.GetBillSaleByParam("totalMoney", param, opera);
                        break;
                    }
                case "Tìm kiếm theo khoảng thời gian vào":
                    {
                        listBillSale = BillSaleController.Instance.SelectBillSaleByTime("dayIn", dtprev.Value, dtNext.Value);
                        break;
                    }
                case "Tìm kiếm theo khoảng thời gian ra":
                    {
                        listBillSale = BillSaleController.Instance.SelectBillSaleByTime("dayOut", dtprev.Value, dtNext.Value);
                        break;
                    }
            }


            foreach (BillSale billSale in listBillSale)
            {
                dt.Rows.Add(
                    billSale.Id,
                    billSale.dayIn,
                    billSale.dayOut,
                    billSale.totalMoney,
                    StaffController.Instance.GetNameStaffByID(billSale.staffID),
                    TableController.Instance.GetNameTableById(billSale.tableID)
               );
            }

            return dt;
        }
        void LoadData()
        {
            LoadBill();
            LoadOption();
        }
        void LoadBill()
        {
            dgvBillSale.Columns.Clear();
            List<BillSale> listBillSale = BillSaleController.Instance.GetListBillSale();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Thời gian vào");
            dt.Columns.Add("Thời gian ra");
            dt.Columns.Add("Tổng hóa đơn");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Bàn");

            foreach (BillSale billSale in listBillSale)
            {
                dt.Rows.Add(
                    billSale.Id,
                    billSale.dayIn ,
                    billSale.dayOut ,
                    billSale.totalMoney,
                    StaffController.Instance.GetNameStaffByID(billSale.staffID) ,
                    TableController.Instance.GetNameTableById(billSale.tableID)
               );
            }

            dgvBillSale.DataSource = dt;
        }

        void LoadOption()
        {
            List<string> listOption = new List<string>()
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo nhân viên" ,
                "Tìm kiếm theo khoảng thời gian" ,
                "Tìm kiếm theo bàn" ,
                "Tìm kiếm theo tổng hóa đơn"
            };
            cbbOption.DataSource = listOption;
        }

        void Refresh()
        {
            LoadData();
            txtParam.ResetText();
        }

        #endregion
    }
}
