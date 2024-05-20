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
    public partial class EditDetailBillSale : Form
    {
        string _foodID, _billID;
        MainForm mf = new MainForm();
        public EditDetailBillSale(string foodId, string billID)
        {
            InitializeComponent();
            _foodID = foodId;
            _billID = billID;
        }

        private void EditDetailBillSale_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtPrice.Value <= 0 || txtQuantity.Value <= 0)
            {
                mf.NotifyErr("Giá trị nhập vào không hợp lệ");
                return;
            }
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xác nhân thông tin");
            if (qs == DialogResult.OK)
            {
                BillSaleInfo bill = new BillSaleInfo()
                {
                    foodId = _foodID,
                    foodPrice = Convert.ToInt32(txtPrice.Value),
                    Quantity = Convert.ToInt32(txtQuantity.Value),
                    Total = Convert.ToInt32(txtSum.Text),
                    boSaleId = _billID
                };
                int rs = BillSaleInfoController.Instance.UpdateBillSaleInfoWithChangeFood(bill);
                if (rs > 0)
                {
                    BillSaleInfoController.Instance.AutoUpdateTotalBill();
                    mf.NotifySuss("Cập nhật thông tin thành công");
                    this.Close();
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            LoadSum();
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            LoadSum();
        }


        void LoadData()
        {

            List<BillSaleInfo> list = BillSaleInfoController.Instance.GetBillSaleInfosByFoodIdAndBillID(_foodID, _billID);
            foreach (BillSaleInfo info in list)
            {
                txtName.Text = FoodController.Instance.GetNameFoodByID(info.foodId);
                txtPrice.Value = Convert.ToInt32(info.foodPrice);
                txtQuantity.Value = Convert.ToInt32(info.Quantity);
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
    }
}
