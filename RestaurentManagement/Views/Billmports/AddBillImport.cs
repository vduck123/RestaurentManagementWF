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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace RestaurentManagement.Views.Billmports
{
    public partial class AddBillImport : Form
    {
        string _ID_Material = null;
        string _billImportID = null;
        string _nameStaff = null;
        MainForm mf = new MainForm();
        public AddBillImport(string idBillImport, string nameStaff)
        {
            InitializeComponent();
            _billImportID= idBillImport;
            _nameStaff = nameStaff;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isAddedBillImport = false;

            if(isAddedBillImport == false) 
            {
                BillImport billImport = new BillImport()
                {
                    ID = _billImportID,
                    StaffID = StaffController.Instance.GetIDStaffByName(_nameStaff),
                    SupplierID = SupplierController.Instance.GetIDSupplierByName(cbbSupplier.SelectedItem.ToString()),
                    DayCreated = DateTime.Now,
                    TotalMoney = Convert.ToInt32(txtTotalMoney.Text)
                };
                int rs = BillImportController.Instance.InsertBillImport(billImport);
                if(rs == 1)
                {
                    isAddedBillImport = true;
                }
            }
            

            string id = $"BIF00{BillImportInfoController.Instance.GetOrderNumBillImportInfo()}";
            BillImportInfo bill = new BillImportInfo()
            {
                ID = id,
                ItemID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                Price = Convert.ToInt32(txtPrice.Value),
                Quantity = Convert.ToInt32(txtQuantity.Value),
                TotalMoney = Convert.ToInt32(txtSum.Text),
                BillID  = _billImportID,
            };

            int rsCheckExit = WarehouseController.Instance.CheckExitItem(cbbMaterial.SelectedItem.ToString());
            if (rsCheckExit == 1)
            {
                BillImportInfoController.Instance.UpdateQuantityItem(WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()), Convert.ToInt32(txtQuantity.Value));
            }
            else
            {
                BillImportInfoController.Instance.InsertBillImportInfor(bill);
            }
            BillImportController.Instance.UpdateTotalBillByID(_billImportID, Convert.ToInt32(txtTotalMoney.Text));
            WarehouseController.Instance.UpdateQuantityItemByName(cbbMaterial.SelectedItem.ToString(), Convert.ToInt32(txtQuantity.Value));
            mf.NotifySuss("Thêm hóa đơn thành công");
            Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> listNameMaterial = new List<string>();
            List<Warehouse> list = WarehouseController.Instance.SelectItemByParam("item_name", $"N'%{txtMaterial.Text}%'", "LIKE");
            foreach (Warehouse item in list)
            {
                listNameMaterial.Add(item.Name);
            }

            cbbMaterial.DataSource = listNameMaterial;
        }

        private void AddBillImport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private DataGridViewRow rowSelected = null;
        private void dgvBilImportInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowSelected = dgvBilImportInfo.Rows[e.RowIndex];
            }

            _ID_Material = rowSelected.Cells[0].Value.ToString();
        }

        private void xóaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID_Material == null)
            {
                return;
            }

            int rs = BillImportInfoController.Instance.DeleteBillImportInfoByMaterialID(_ID_Material);
            if(rs == 1)
            {
                Refresh();
            }

        }

        void LoadData()
        {
            LoadMaterial();
            LoadProvider();
        }

        void LoadAllBillImportByBillImportID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                dgvBilImportInfo.Columns.Clear();
                List<BillImportInfo> list = BillImportInfoController.Instance.GetAllBillImportInfoByBillImportID(id);
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
        }

        void LoadMaterial()
        {
            List<string> listNameItem = new List<string>();
            List<Warehouse> listItem = WarehouseController.Instance.GetListItem();

            foreach (Warehouse item in listItem)
            {
                listNameItem.Add(item.Name);
            }
            cbbMaterial.DataSource = listNameItem;
        }

        

        void LoadProvider()
        {
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
            LoadAllBillImportByBillImportID(_billImportID);
            LoadTotalBill(_billImportID);
            txtMaterial.ResetText();
            txtPrice.Value = 0;
            txtQuantity.Value = 0;
        }

        void LoadTotalBill(string id)
        {
            txtTotalMoney.Text = CalcTotalBill(id).ToString();
        }

        int CalcTotalBill(string id)
        {
            if (id == null)
            {
                return -1;
            }
            int total = 0;
            List<BillImportInfo> list = BillImportInfoController.Instance.GetAllBillImportInfoByBillImportID(id);
            foreach (var item in list)
            {
                if (item != null)
                {
                    total += item.TotalMoney;
                }
            }

            return total;
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Value > 0 && txtPrice.Value > 0)
            {
                txtSum.Text = Convert.ToString(txtQuantity.Value * txtPrice.Value);
            }
            else
            {
                txtSum.Text = "0";
            }
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            if(txtMaterial.Text.Length == 0)
            {
                LoadMaterial();
            }
        }
    }
}
