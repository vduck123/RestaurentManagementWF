using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = RestaurentManagement.Models.Menu;


namespace RestaurentManagement.Views
{
    public partial class Order_VIEW : Form
    {
        public Order_VIEW()
        {
            InitializeComponent();
        }

        private void Order_VIEW_Load(object sender, EventArgs e)
        {          
            txtTotalBill.Enabled = false;
            LoadVoucher();
            LoadCategoryFood();
            LoadTables();
        }

        #region Method
        void LoadVoucher()
        {
            List<Voucher> vouchers = VoucherController.Instance.GetListVoucher();
            List<string> nameVouchers = new List<string>()
            {
                "Không dùng"
            };
            string nameVoucher = null;
            foreach (Voucher voucher in vouchers)
            {
                nameVoucher = $"{voucher.Name} giảm {voucher.Expiry}";
                nameVouchers.Add(nameVoucher);
            }
            cbbVoucher.DataSource  = nameVouchers;
        }

        void LoadTables()
        {
            List<string> listNameTable = new List<string>();
            List<Table> tables = TableController.Instance.GetListTable();         
            foreach (Table table in tables)
            {
                Button btn = new Button()
                {
                    Width = TableController.tableWidth,
                    Height = TableController.tableHeight,
                    Text = table.Name + Environment.NewLine + table.Status,
                    Font = TableController.FontMain,
                    Tag = table
                };
                              

                switch (table.Status)
                {
                    case "Trống":
                        {
                            btn.BackColor = TableController.status0;
                            break;
                        }
                    default:
                        {
                            btn.BackColor = TableController.status1;
                            break;
                        }
                }

                btn.Click += TableButton_Click;

                //
                fpanelListTable.Controls.Add(btn);

                //
                listNameTable.Add(table.Name);
            }

            cbbTable.DataSource = listNameTable;
        }

        //Event click button 
        void TableButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;          
            if (button != null && button.Tag is Table)
            {
                Table table = (Table)button.Tag;               
                string id = table.Id;
                cbbTable.SelectedItem = TableController.Instance.GetNameTableById(id);
                DisplayBillForTable(id);
            }       
        }
        //

        void LoadCategoryFood()
        {
            List<FoodCategory> foodCategories = FoodCategoryController.Instance.GetListCategoryFood();
            List<string> categoryNames = new List<string>();
            foreach (FoodCategory category in foodCategories)
            {
                categoryNames.Add(category.Name);
            }
            cbbFoodCategory.DataSource = categoryNames;
        }

        void DisplayBillForTable(string id)
        {
            dgvListFoodOrder.Rows.Clear();
            List<Menu> menus = MenuController.Instance.GetListBillInfoByTableID(id);
            foreach (Menu menu in menus)
            {
                foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
                {
                    row.Cells["Column1"].Value = FoodController.Instance.GetNameFoodByID(menu.foodID);
                    row.Cells["Column2"].Value = menu.Quantity;
                    row.Cells["Column3"].Value = menu.Price;
                    row.Cells["Column4"].Value = (menu.Quantity * menu.Price);
                }
            }
        }

        private double CalcBill(double priceOriginal, double expiry, string expiryOption)
        {
            double total = priceOriginal;
            switch (expiryOption.Trim())
            {
                case "%":
                    {
                        total -= priceOriginal * (expiry / 100.0);
                        break;
                    }
                case "Vnd":
                    {
                        total -= expiry;
                        if(total < 0)
                        {
                            total = 0;
                        }
                        break;
                    }
                default:
                    {
                        total = priceOriginal;
                        break;
                    }
            }

            return total;
        }


        double LoadTotalBill()
        {
            double total = 0;
            foreach(DataGridViewRow row in dgvListFoodOrder.Rows)
            {
                int money = Convert.ToInt32(row.Cells["Column4"].Value);
                total += money;
            }

            return total;
        }

        string GetNameFood(string[] arr)
        {
            string nameFood = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ":")
                {
                    break; 
                }
                nameFood += arr[i];
                if (i < arr.Length - 1 && arr[i + 1] != ":")
                {
                    nameFood += " ";
                }
            }
            return nameFood; 
        }

        #endregion


        #region Event
        private void cbbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listFoodName = new List<string>();
            List<Food> listfood = FoodController.Instance.GetListFood();
            string choose = cbbFoodCategory.SelectedItem.ToString();
            foreach (Food f in listfood)
            {
                if(choose.Equals(FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.categoryID)))
                {
                    listFoodName.Add($"{f.Name} : {f.Price} vnđ");
                }
            }

            cbbFood.DataSource = listFoodName;
            txtNumOrder.Value = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nameFoodChoose = GetNameFood(cbbFood.SelectedItem.ToString().Split(' '));
            int quantity = Convert.ToInt32(txtNumOrder.Value);
            int priceFood = 0;
            int total = 0;
            double totalTable = 0;

            if(quantity == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng");
                return;
            }

            bool foodExists = false;

            foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
            {
                if (row.Cells["Column1"].Value != null && row.Cells["Column1"].Value.ToString() == nameFoodChoose)
                {
                    int existingQuantity = Convert.ToInt32(row.Cells["Column2"].Value);
                    int existingTotalMoney = Convert.ToInt32(row.Cells["Column4"].Value);
                    existingQuantity += quantity;
                    priceFood = Convert.ToInt32(row.Cells["Column3"].Value);
                    total  = existingQuantity * priceFood;
                    row.Cells["Column2"].Value = existingQuantity;
                    row.Cells["Column4"].Value = total;                  
                    foodExists = true;
                    break;
                }
            }


            if (!foodExists)
            {
                List<Food> selectedFood = FoodController.Instance.GetFoodByName(nameFoodChoose);
                foreach (Food f in selectedFood)
                {
                    priceFood = f.Price;
                    total = quantity * priceFood;
                    totalTable = Convert.ToDouble(txtTotalBill.Text) + total;
                }

                dgvListFoodOrder.Rows.Add(nameFoodChoose, quantity, priceFood, total);
            }

            txtTotalBill.Text = LoadTotalBill().ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int rdHours = new Random().Next(1, 4);
            int idBillNum = BillSaleController.Instance.GetNumOrderBill();
            BillSale bill = new BillSale()
            {
                Id = $"HDB00{idBillNum + 1}",
                dayIn = DateTime.Now,
                dayOut = DateTime.Now.AddHours(rdHours),
                totalMoney = Convert.ToInt32(txtTotalBill.Text) ,
                
            };

            int rs = BillSaleController.Instance.InsertBillSale(bill);
            MessageBox.Show(rs.ToString());


            foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
            {

                string foodName = row.Cells["Column2"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["Column3"].Value);

                int idBillInfoNum = BillSaleInfoController.Instance.GetNumOrderBillInfo();
                BillInfo billInfo = new BillInfo()
                {
                    Id = $"DBOS{idBillInfoNum + 1}",
                    IdFood = FoodController.Instance.GetIDFoodByName(foodName),
                    Quantity = quantity,
                    IdBill = bill.Id
                };
            }
        }

        private void cbbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            string voucherChoose = cbbVoucher.SelectedItem.ToString();
            double totalBill = LoadTotalBill();
            string[] a = voucherChoose.Split(' ');
            
            if (a[0].StartsWith("Không"))
            {
                txtTotalBill.Text = totalBill.ToString();
                return;
            }

            if (a.Length > 0)
            {
                int expiry = 0;
                string expriryOption = string.Empty;
                foreach(var i in a)
                {
                    if(CheckNum.Instance.IsNum(i))
                    {
                        expiry = Convert.ToInt32(i);
                    }
                    if(i.Contains("%"))
                    {
                        expriryOption = "%";
                    }
                    else if(i.Contains("Vnd"))
                    {
                        expriryOption = "Vnd";
                    }
                }


                txtTotalBill.Text = CalcBill(totalBill, expiry, expriryOption).ToString();
            }
            

            if (Convert.ToInt32(txtTotalBill.Text) < 0)
            {
                txtTotalBill.Text = "0";
            }



        }
        private void btnNextTable_Click(object sender, EventArgs e)
        {

        }

        private void cbbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumOrder.Value = 0;
        }


       
        
        #endregion
        

       
    }
}
