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
        MainForm mf = new MainForm();
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

        

        DataGridViewRow rowSelected = null;
        string idEdit = null;
        private void dgvBilImportInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvBilImportInfo.Rows[e.RowIndex];
                idEdit = WarehouseController.Instance.GetIDItemByName(rowSelected.Cells[0].Value.ToString());
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idEdit != null)
            {
                EditDetailBillImport view = new EditDetailBillImport(idEdit, _ID);
                view.ShowDialog();
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(idEdit != null)
            {
                DialogResult qs = mf.NotifyConfirm($"Chọn OK để xóa nguyên liệu {rowSelected.Cells[0].Value.ToString()}");
                if(qs == DialogResult.OK)
                {
                    int rs = BillImportInfoController.Instance.DeleteBillImportInfoByMaterialID(idEdit, _ID);
                    if(rs > 0)
                    {
                        BillImportInfoController.Instance.UpdateMoneyBillImport();
                        mf.NotifySuss("Xóa thành công");
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
