using Bogus.DataSets;
using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnXuatFile_Click(object sender, EventArgs e)
        {

        }

        

        private void btbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận thanh toán {lbTable.Text}");
            {
                if (qs == DialogResult.OK)
                {
                    //Thêm dữ liệu vào db

                    //Hóa đơn bán
                    int rdhours = new Random().Next(1, 4);
                    DateTime dayIn = DateTime.Now;
                    DateTime dayOut;

                    if (dayIn.Hour > 12)
                    {
                        dayOut = dayIn.AddDays(1).Date;
                    }
                    else
                    {
                        dayOut = dayIn.Date;
                    }

                    dayOut = dayOut.AddHours(rdhours);

                    string idBillSale = $"HDB00{BillSaleController.Instance.GetNumOrderBill() + 1}";
                    BillSale billSale = new BillSale()
                    {
                        Id = idBillSale,
                        dayIn = dayIn,
                        dayOut = dayOut,
                        voucherId = idBillSale,
                        totalMoney = Convert.ToDouble(lbTotal.Text),
                        staffID = _idStaff,
                        tableID = _idTable
                    };

                    int rs1 = BillSaleController.Instance.InsertBillSale(billSale);

                    if (dgvListFoodOrder.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
                        {
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
                        }
                    }
                }
            }
        }


        void GetData()
        {
            if(_idTable == null)
            {
                return;
            }
            int totalBill = 0;

            dgvListFoodOrder.Columns.Clear();
            List<_Menu> menus = MenuController.Instance.GetMenuByTableID(_idTable);
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Thành tiền");

            foreach (_Menu menu in menus)
            {
                dt.Rows.Add(FoodController.Instance.GetNameFoodByID(menu.foodID), menu.Quantity, menu.Price, menu.Total);
                totalBill += menu.Total;
            }

  
            int hours = new Random().Next(1, 3);

            lbThuNgan.Text = StaffController.Instance.GetNameStaffByID(_idStaff);
            lbNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbTimeIn.Text = DateTime.Now.ToString("HH:mm");
            lbTimeOut.Text = DateTime.Now.AddHours(hours).ToString("HH:mm");


            dgvListFoodOrder.DataSource = dt;
            lbTotal.Text = totalBill.ToString();


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"; // Corrected filter string
            saveFileDialog.Title = "Save a PDF File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Office.Instance.ExportPdf(dgvListFoodOrder, saveFileDialog.FileName);
                    mf.NotifySuss("Xuất file thành công");
                }
                catch (Exception exception)
                {
                    mf.NotifySuss($"Lỗi: {exception.Message}");
                }
            }
        }

    }
}
