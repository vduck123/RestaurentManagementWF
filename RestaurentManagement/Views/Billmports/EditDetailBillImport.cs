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
    public partial class EditDetailBillImport : Form
    {
        MainForm mf = new MainForm();
        string _IdItem = null;
        string _IdBill = null;
        public EditDetailBillImport(string idItem, string idBill)
        {
            InitializeComponent();
            _IdItem = idItem;
            _IdBill = idBill;
        }

        private void EditDetailBillImport_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text) || txtPrice.Value <= 0 || txtQuantity.Value <= 0)
            {
                mf.NotifyErr("Giá trị nhập vào không hợp lệ");
                return;
            }
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xác nhân thông tin");
            if(qs == DialogResult.OK)
            {
                int rs = BillImportInfoController.Instance.UpdateItem(_IdItem, Convert.ToInt32(txtQuantity.Value), Convert.ToInt32(txtPrice.Value), _IdBill);
                if(rs >0)
                {
                    BillImportInfoController.Instance.UpdateMoneyBillImport();
                    mf.NotifySuss("Cập nhật thông tin thành công");
                    this.Close();
                }
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void GetData()
        {
            if(_IdItem != null && _IdBill != null)
            {
                List<BillImportInfo> list = BillImportInfoController.Instance.GetBillImportByMaterialAndIDBill(_IdItem,_IdBill);
                foreach (BillImportInfo info in list)
                {
                    txtName.Text = WarehouseController.Instance.GetNameItemByID(info.ItemID);
                    txtPrice.Value = Convert.ToInt32(info.Price);
                    txtQuantity.Value = Convert.ToInt32(info.Quantity);
                }
            }
        }

        void LoadSum()
        {
            if (txtQuantity.Value > 0 && txtPrice.Value > 0)
            {
                txtSum.Text = (txtQuantity.Value * txtPrice.Value).ToString();
            }
            else
            {
                txtSum.Text = "0";
            }
        }
        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            LoadSum();
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            LoadSum();
        }      
    }
}
