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
    public partial class BillImportInfor_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _billID = null;
        public BillImportInfor_VIEW(string bill_id)
        {
            InitializeComponent();
            if(!string.IsNullOrEmpty(bill_id))
            {
                _billID = bill_id;
            }
        }

        private void BillImportInfor_Load(object sender, EventArgs e)
        {
            LoadItem();
            LoadBillByID(_billID);
            txtBillID.Text = _billID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"BIF00{BillImportInfoController.Instance.GetOrderNumBillImportInfo()}";
            BillImportInfo bill = new BillImportInfo()
            {
                ID = id,
                ItemID = WarehouseController.Instance.GetIDItemByName(cbbItem.SelectedItem.ToString()),
                Price = Convert.ToInt32(txtPrice.Value) ,
                Quantity = Convert.ToInt32(txtQuantity.Value) ,
                TotalMoney = Convert.ToInt32(txtSum.Text) ,
                BillID = _billID
            };

            int rs = BillImportInfoController.Instance.InsertBillImportInfor(bill);
            if(rs == 1)
            {
                int rs1 = BillImportController.Instance.UpdateTotalBillByID(_billID,Convert.ToInt32(txtTotal.Text));
                {
                    if (rs1 == 1)
                    {
                        mf.NotifySuss("Thêm hóa đơn thành công");
                        LoadBillByID(_billID);
                        LoadTotalBill();
                        Refresh();
                    }
                }              
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BillImportInfo bill = new BillImportInfo()
            {
                ID = txtID.Text,
                ItemID = WarehouseController.Instance.GetIDItemByName(cbbItem.SelectedItem.ToString()),
                Price = Convert.ToInt32(txtPrice.Value),
                Quantity = Convert.ToInt32(txtQuantity.Value),
                TotalMoney = Convert.ToInt32(txtSum.Text),
            };

            int rs = BillImportInfoController.Instance.UpdateBillImportInfo(bill);
            if (rs == 1)
            {
                int rs1 = BillImportController.Instance.UpdateTotalBillByID(txtBillID.Text, Convert.ToInt32(txtTotal.Text));
                {
                    if (rs1 == 1)
                    {
                        mf.NotifySuss("Cập nhật hóa đơn thành công");
                        LoadBillByID(_billID);
                        LoadTotalBill();
                        Refresh();
                    }
                }
            }
        }

        private void dgvBilImportInfo_Click(object sender, EventArgs e)
        {
            if(dgvBilImportInfo.Rows.Count > 0)
            {
                txtID.Text = dgvBilImportInfo.SelectedRows[0].Cells[0].Value.ToString();
                cbbItem.SelectedItem = dgvBilImportInfo.SelectedRows[0].Cells[1].Value.ToString();
                txtPrice.Value = Convert.ToInt32(dgvBilImportInfo.SelectedRows[0].Cells[2].Value);
                txtQuantity.Value = Convert.ToInt32(dgvBilImportInfo.SelectedRows[0].Cells[3].Value);
                txtSum.Text = dgvBilImportInfo.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            txtSum.Text = (Convert.ToInt32(txtPrice.Value) * Convert.ToInt32(txtQuantity.Value)).ToString();
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            txtSum.Text = (Convert.ToInt32(txtPrice.Value) * Convert.ToInt32(txtQuantity.Value)).ToString();
        }


        void LoadBillByID(string id)
        {
            if (!string.IsNullOrEmpty(_billID))
            {
                dgvBilImportInfo.Columns.Clear();
                List<BillImportInfo> list = BillImportInfoController.Instance.SelectBillImportInfo(id);
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Nguyên liệu");
                dt.Columns.Add("Giá cả");
                dt.Columns.Add("Số lượng");
                dt.Columns.Add("Thành tiền");
                dt.Columns.Add("Mã hóa đơn");

                foreach (BillImportInfo bill in list)
                {
                    dt.Rows.Add(bill.ID, WarehouseController.Instance.GetNameItemByID(bill.ItemID), bill.Price, bill.Quantity, bill.TotalMoney, bill.BillID);
                }
                dgvBilImportInfo.DataSource = dt;
            }
        }

        void LoadItem()
        {
            List<string> listNameItem = new List<string>();
            List<Warehouse> listItem = WarehouseController.Instance.GetListItem();

            foreach (Warehouse item in listItem)
            {
                listNameItem.Add(item.Name);
            }
            cbbItem.DataSource = listNameItem;
        }

        void LoadTotalBill()
        {
            int sum = 0;
            if (dgvBilImportInfo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvBilImportInfo.Rows)
                {
                    if (row.Cells.Count > 4 && row.Cells[4].Value != null)
                    {
                        int money;
                        if (int.TryParse(row.Cells[4].Value.ToString(), out money))
                        {
                            sum += money;
                        }
                    }
                }
            }
            txtTotal.Text = sum.ToString();
        }

        private void txtSum_TextChanged(object sender, EventArgs e)
        {
            LoadTotalBill();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        void Refresh()
        {
            LoadItem();
            LoadTotalBill();
            txtID.Text = "Dành cho chức năng cập nhật";
            txtPrice.Value = 0;
            txtQuantity.Value = 0;
            txtSum.Text = "0";
            txtBillID.Text = _billID;
        }

        
    }
}
