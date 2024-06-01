using Bogus.DataSets;
using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
using RestaurentManagement.Views.BillPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using _Menu = RestaurentManagement.Models.Menu;

namespace RestaurentManagement.Views.NotifyBill
{
    public partial class NotifyBill : Form
    {
        MainForm mf = new MainForm();
        string _nameCus = null;
        string _idStaff = null;
        string _idTable = null;
        string _idVoucher = null;
        string _PhoneRes = null;
        string _AddressRes = null;
        DateTime dayIn = DateTime.Now;
        DateTime dayOut = DateTime.Now.AddHours(new Random().Next(1,4));
        public NotifyBill(string nameCus, string idStaff, string idTable, string idVoucher)
        {
            InitializeComponent();
            _nameCus = nameCus;
            _idStaff = idStaff;
            _idTable = idTable;
            _idVoucher = idVoucher;
        }

        private void NotifyBill_Load(object sender, EventArgs e)
        {
            GetData();
        }


        private void btbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        int _totalBill = 0;
        void GetData()
        {

            if (_idTable == null)
            {
                return;
            }

            dgvListFoodOrder.Columns.Clear();
            List<_Menu> menus = MenuController.Instance.GetMenuByTableID(_idTable);
            List<InForRestaurant> info = InfoRestaurantController.Instance.GetData();          
            foreach (InForRestaurant res in info)
            {
                _PhoneRes = res.Phone;
                _AddressRes = res.Address;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Thành tiền");

            foreach (_Menu menu in menus)
            {
                dt.Rows.Add(FoodController.Instance.GetNameFoodByID(menu.foodID), menu.Quantity, menu.Price, menu.Total);
                _totalBill += menu.Total;
            }



            dgvListFoodOrder.DataSource = dt;
            lbThuNgan.Text = StaffController.Instance.GetNameStaffByID(_idStaff);
            lbTable.Text = TableController.Instance.GetNameTableById(_idTable);
            lbNgay.Text = dayOut.ToString("dd/MM/yyyy");
            lbTimeIn.Text = dayIn.ToString("HH:mm");
            lbTimeOut.Text = dayOut.ToString("HH:mm");
            lbTotal.Text = _totalBill.ToString();
            lbExpiry.Text = CalcExpiry();
            lbPayMoney.Text = CalcBill(_totalBill).ToString();
            lbCusname.Text = _nameCus;
            lbPhone.Text = _PhoneRes;
            lbAddress.Text = _AddressRes;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print_VIEW view = new Print_VIEW(lbCusname.Text, lbThuNgan.Text, TableController.Instance.GetIDTableByName(lbTable.Text), lbExpiry.Text, lbNgay.Text, lbTimeIn.Text, lbTimeOut.Text , lbTotal.Text, lbPayMoney.Text, _PhoneRes, _AddressRes)  ;
            view.Show();
        }

        double CalcBill(double totalBill)
        {
            string voucherChoose = VoucherController.Instance.GetExpiryById(_idVoucher);
            string[] a = voucherChoose.Split(' ');
            if (a[1] == "Vnđ")
            {
                totalBill = totalBill - Convert.ToDouble(a[0]);               
            }
            else
            {
                totalBill = totalBill - (totalBill * Convert.ToDouble(a[0]) / 100); 
            }
            return totalBill;
        }

        string CalcExpiry()
        {
            string voucherChoose = VoucherController.Instance.GetExpiryById(_idVoucher);
            string output = null;
            string[] a = voucherChoose.Split(' ');
            if (a[1] == "Vnđ")
            {
                output = voucherChoose;
            }
            else
            {
                int gg = _totalBill * Convert.ToInt32(a[0]) / 100;
                output = $"{gg} Vnđ";
            }

            return output;
        }


        private void btnPay_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận thanh toán {lbTable.Text}");
            {
                if (qs == DialogResult.OK)
                {

                    string idBillSale = $"HDB00{BillSaleController.Instance.GetNumOrderBill() + 1}";
                    BillSale billSale = new BillSale()
                    {
                        Id = idBillSale,
                        dayIn = dayIn,
                        dayOut = dayOut,
                        voucherId = _idVoucher,
                        totalMoney = Convert.ToDouble(lbTotal.Text),
                        Customer = lbCusname.Text,
                        staffID = _idStaff,
                        tableID = _idTable
                    };

                    BillSaleController.Instance.InsertBillSale(billSale);

                    if (dgvListFoodOrder.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
                        {
                            if (row == null || row.Cells == null)
                            {
                                break;
                            }

                            if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null)
                            {
                                break;
                            }

                            string idBillSaleInfo = $"CTHDB0{BillSaleInfoController.Instance.GetNumOrderBillInfo() + 1}";
                            string nameFood = row.Cells[0].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells[1].Value);
                            int price = Convert.ToInt32(row.Cells[2].Value);
                            int total = Convert.ToInt32(row.Cells[3].Value);

                            BillSaleInfo billSaleInfo = new BillSaleInfo()
                            {
                                ID = idBillSaleInfo,
                                foodId = FoodController.Instance.GetIDFoodByName(nameFood),
                                Quantity = quantity,
                                foodPrice = price,
                                Total = total,
                                boSaleId = idBillSale
                            };

                            BillSaleInfoController.Instance.InsertBillSaleInfo(billSaleInfo);
                            
                            List<FoodMaterial> listFoodMaterial = FoodMateialController.Instance.GetListFoodMaterialByFoodId(FoodController.Instance.GetIDFoodByName(nameFood));
                            foreach (FoodMaterial fm in listFoodMaterial)
                            {
                                int rs3 = WarehouseController.Instance.UpdateQuantityItemByName(WarehouseController.Instance.GetNameItemByID(fm.materialID), "-" ,fm.Quantity);
                            }
                        }
                    }
                    mf.NotifySuss("Thanh toán hóa đơn thành công !");
                    MenuController.Instance.DeleteMenu(_idTable);
                    TableController.Instance.UpdateStatusTable(_idTable, "Trống");
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
