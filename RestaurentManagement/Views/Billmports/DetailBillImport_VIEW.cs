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

namespace RestaurentManagement.Views.Billmports
{
    public partial class DetailBillImport_VIEW : Form
    {
        string _ID = null;
        public DetailBillImport_VIEW(string id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void DetailBillImport_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            dgvBilImportInfo.Columns.Clear();
            List<BillImportInfo> list = BillImportInfoController.Instance.GetAllBillImportInfoByBillImportID(_ID);
            DataTable dt = new DataTable();
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Giá cả");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Thành tiền");
            foreach (BillImportInfo bill in list)
            {
                dt.Rows.Add(WarehouseController.Instance.GetNameItemByID(bill.ItemID), bill.Price, bill.Quantity, bill.TotalMoney);
            }
            dgvBilImportInfo.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
