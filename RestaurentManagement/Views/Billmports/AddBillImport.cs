
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
        
        string _billImportID = null;
        string _nameStaff = null;
        MainForm mf = new MainForm();
        public AddBillImport(string idBillImport, string nameStaff)
        {
            InitializeComponent();
            _billImportID= idBillImport;
            _nameStaff = nameStaff;
        }

        bool isAddedBillImport = false;
        string nameSupplier = null;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtQuantity.Value <= 0 || txtPrice.Value <= 0) 
            {
                mf.NotifyErr("Vui lòng nhập số lớn hơn 0");
                return;
            }

            if(txtUnit.Text.Equals("Đơn vị"))
            {
                mf.NotifyErr("Vui lòng nhập đơn vị tính");
                return;
            }


            LoadTotalBill(_billImportID);
            nameSupplier = cbbSupplier.SelectedItem.ToString();
            if (isAddedBillImport == false) 
            {
                BillImport billImport = new BillImport()
                {
                    ID = _billImportID,
                    StaffID = StaffController.Instance.GetIDStaffByName(_nameStaff),
                    SupplierID = SupplierController.Instance.GetIDSupplierByName(nameSupplier),
                    DayCreated = DateTime.Now,
                    TotalMoney = Convert.ToInt32(txtTotalMoney.Text)
                };
                int rs = BillImportController.Instance.InsertBillImport(billImport);
                if(rs == 1)
                {
                    isAddedBillImport = true;
                }
            }
            

            string id = $"BIF00{BillImportInfoController.Instance.GetOrderNumBillImportInfo() + 1}";
            BillImportInfo bill = new BillImportInfo()
            {
                ID = id,
                ItemID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                Price = Convert.ToInt32(txtPrice.Value),
                Quantity = Convert.ToInt32(txtQuantity.Value),
                Unit = txtUnit.Text,
                TotalMoney = Convert.ToInt32(txtSum.Text),
                BillID  = _billImportID,
            };

            int rsCheckExit = WarehouseController.Instance.CheckExitItem(WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()), _billImportID);
            int rs2 = 0;
            if (rsCheckExit == 1)
            {
                rs2 = BillImportInfoController.Instance.UpdateQuantityItem(WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()), Convert.ToInt32(txtQuantity.Value));

            }
            else
            {
                rs2 = BillImportInfoController.Instance.InsertBillImportInfor(bill);
            }

           if(rs2 > 0)
           {
                BillImportController.Instance.UpdateTotalBillByID(_billImportID, Convert.ToInt32(txtTotalMoney.Text));
                WarehouseController.Instance.UpdateQuantityItemByName(cbbMaterial.SelectedItem.ToString(), "+", Convert.ToInt32(txtQuantity.Value));
                mf.NotifySuss("Thêm hóa đơn thành công");
                Refresh();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaterial.Text))
            {
                mf.NotifyErr("Vui lòng nhập tên nguyên liệu");
                return;
            }
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
        string _ID_Material = null;
        int _numMaterial = 0;
        private void dgvBilImportInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowSelected = dgvBilImportInfo.Rows[e.RowIndex];
                _ID_Material = WarehouseController.Instance.GetIDItemByName(rowSelected.Cells[0].Value.ToString());
                _numMaterial = Convert.ToInt32(rowSelected.Cells[2].Value);
            } 
        }

        private void xóaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID_Material == null)
            {
                return;
            }
            int rs = BillImportInfoController.Instance.DeleteBillImportInfoByMaterialID(_ID_Material, _billImportID);
            if(rs > 0)
            {
                WarehouseController.Instance.UpdateQuantityItemByName(WarehouseController.Instance.GetNameItemByID(_ID_Material), "-", _numMaterial);
                Refresh();
                BillImportController.Instance.UpdateTotalBillByID(_billImportID, Convert.ToInt32(txtTotalMoney.Text));
            }

        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            if (txtMaterial.Text.Length == 0)
            {
                LoadMaterial();
            }
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
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

        private void txtQuantity_ValueChanged_1(object sender, EventArgs e)
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

        private void cbbMaterial_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            foreach (Warehouse material in listMaterial)
            {
                if (cbbMaterial.SelectedValue.ToString().Equals(material.Name))
                {
                    txtUnit.Text = material.Unit;
                }
            }
        }

        private void btnExportBill_Click(object sender, EventArgs e)
        {
            NotifyBill.NotifyBillImport view = new NotifyBill.NotifyBillImport(_nameStaff, cbbSupplier.SelectedItem.ToString(), _billImportID);
            if (view.ShowDialog() == DialogResult.OK)
            {
                this.Close();
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
            A();
            txtMaterial.ResetText();
            txtPrice.Value = 0;
            txtQuantity.Value = 0;
        }

        void A()
        {
            if(nameSupplier != null)
            {
                List<string> a = new List<string>()
                {
                    nameSupplier
                };
                cbbSupplier.DataSource = a;
            }
            
        }

        void ResetDgvBillImport()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Giá cả");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Thành tiền");
            dgvBilImportInfo.DataSource = dt;
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
    }
}
