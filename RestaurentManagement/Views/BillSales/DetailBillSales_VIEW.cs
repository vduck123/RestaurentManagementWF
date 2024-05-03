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

namespace RestaurentManagement.Views.BillSales
{
    public partial class DetailBillSales_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID;
        public DetailBillSales_VIEW(string id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void DetailBillSales_VIEW_Load(object sender, EventArgs e)
        {
            GetData();
        }
        
        void GetData()
        {
            dgvBillSaleInfo.Columns.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Thành tiền");
            List<BillSaleInfo> bills = BillSaleInfoController.Instance.GetBillSaleInfoById(_ID);
            foreach (BillSaleInfo bill in bills)
            {
                dt.Rows.Add(FoodController.Instance.GetNameFoodByID(bill.foodId), bill.foodPrice, bill.Quantity, bill.Total);
            }

            dgvBillSaleInfo.DataSource = dt;

        }

        DataGridViewRow rowSelected = null;
        string foodId = null;
        private void dgvBillSaleInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowSelected = dgvBillSaleInfo.Rows[e.RowIndex];
                foodId = FoodController.Instance.GetIDFoodByName(rowSelected.Cells[0].Value.ToString());
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để món ăn {rowSelected.Cells[0].Value.ToString()}");
            if (qs == DialogResult.OK)
            {
                int rs = BillSaleInfoController.Instance.DeleteBillSaleInfoByFoodIdAndBillId(foodId, _ID);
                if (rs > 0)
                {
                    BillSaleInfoController.Instance.AutoUpdateTotalBill();
                    mf.NotifySuss("Xóa thành công");
                    GetData();
                }
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }

            EditDetailBillSale view = new EditDetailBillSale(foodId, _ID);
            view.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
