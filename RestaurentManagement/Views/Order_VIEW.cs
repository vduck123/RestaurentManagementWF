using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
using RestaurentManagement.Views.NotifyBill;
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
using Table = RestaurentManagement.Models.Table;


namespace RestaurentManagement.Views
{
    public partial class Order_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _nameStaff = string.Empty;
        public Order_VIEW(string nameStaff)
        {
            InitializeComponent();
            _nameStaff = nameStaff;
        }

        private void Order_VIEW_Load(object sender, EventArgs e)
        {
            LoadVoucher();
            LoadCategoryFood();
            LoadTables();
            LoadFood();
        }

        #region Method
        void LoadVoucher()
        {
            List<Voucher> vouchers = VoucherController.Instance.GetListVoucher();
            List<string> nameVouchers = new List<string>() { };
            string nameVoucher = null;
            foreach (Voucher voucher in vouchers)
            {
                if (voucher.Status.Equals("Bật"))
                {
                    nameVoucher = $"{voucher.Name} giảm {voucher.Expiry}";
                    nameVouchers.Add(nameVoucher);
                }

            }
            cbbVoucher.DataSource = nameVouchers;
        }

        void LoadTables()
        {
            fpanelListTable.Controls.Clear();
            List<string> listNameTable = new List<string>();
            List<Table> tables = TableController.Instance.GetListTable();
            foreach (Table table in tables)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button()
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

        void DisplayMenuForTable(string name)
        {
            dgvListFoodOrder.Columns.Clear();
            List<Menu> menus = MenuController.Instance.GetMenuByTableID(TableController.Instance.GetIDTableByName(name));
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Thành tiền");

            foreach (Menu menu in menus)
            {
                dt.Rows.Add(FoodController.Instance.GetNameFoodByID(menu.foodID), menu.Quantity, menu.Price, menu.Total);

                txtCus.Text = menu.Customer;

            }

            if(menus.Count == 0)
            {
                txtCus.ResetText();
            }

            dgvListFoodOrder.DataSource = dt;
        }

        void LoadFood()
        {
            dgvFood.Columns.Clear();
            List<Food> foods = FoodController.Instance.GetListFood();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Hình ảnh", typeof(byte[]));
            foreach (Food f in foods)
            {
                dt.Rows.Add(f.Name, f.Price, f.imageFood);
            }

            dgvFood.RowTemplate.Height = 70;
            dgvFood.DataSource = dt;

            var imageColumn = dgvFood.Columns["Hình ảnh"] as DataGridViewImageColumn;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            var btnAdd = new DataGridViewButtonColumn();
            btnAdd.Name = "Tùy chọn";
            btnAdd.Text = "Thêm";
            btnAdd.UseColumnTextForButtonValue = true;
            btnAdd.Width = 10;
            dgvFood.Columns.Add(btnAdd);

            dgvFood.CellContentClick += dgvFood_CellContentClick;
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lbTable.Text.Equals("bàn"))
            {
                mf.NotifyErr("Vui lòng chọn bàn");
                return;
            }
            if (string.IsNullOrEmpty(txtCus.Text) || HandleData.Instance.ExitNumber(txtCus.Text))
            {
                mf.NotifyErr("Tên khách hàng không hợp lệ");
                return;
            }

            if (e.ColumnIndex == dgvFood.Columns["Tùy chọn"].Index && e.RowIndex >= 0)
            {
                string nameFoodChoose = dgvFood.Rows[e.RowIndex].Cells["Tên món ăn"].Value.ToString();
                int quantity = Convert.ToInt32(txtNumOrder.Value);
                int priceFood = 0;
                int total = 0;

                if (quantity == 0)
                {
                    mf.NotifyErr("Vui lòng chọn số lượng");
                    return;
                }

                if (lbTable.Text.Equals("bàn"))
                {
                    mf.NotifyErr("Vui lòng chọn bàn");
                    return;
                }

                bool foodExists = false;


                foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == nameFoodChoose)
                    {
                        int existingQuantity = Convert.ToInt32(row.Cells[1].Value);
                        int existingTotalMoney = Convert.ToInt32(row.Cells[3].Value);
                        existingQuantity += quantity;
                        priceFood = Convert.ToInt32(row.Cells[2].Value);
                        total = existingQuantity * priceFood;
                        row.Cells[1].Value = existingQuantity;
                        row.Cells[3].Value = total;
                        Menu menu = new Menu()
                        {
                            foodID = FoodController.Instance.GetIDFoodByName(nameFoodChoose),
                            Quantity = existingQuantity,
                            Total = total,
                            Customer = txtCus.Text,
                            tableID = TableController.Instance.GetIDTableByName(lbTable.Text)
                        };
                        int rs = MenuController.Instance.UpdateMenu(menu);
                        if (rs == 1)
                        {
                            DisplayMenuForTable(lbTable.Text);

                        }
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
                    }
                    Menu menu = new Menu()
                    {
                        foodID = FoodController.Instance.GetIDFoodByName(nameFoodChoose),
                        Price = priceFood,
                        Quantity = quantity,
                        Total = total,
                        Customer = txtCus.Text,
                        tableID = TableController.Instance.GetIDTableByName(lbTable.Text)
                    };
                    int rs = MenuController.Instance.InsertMenu(menu);
                    if (rs == 1)
                    {
                        DisplayMenuForTable(lbTable.Text);
                        int rs1 = TableController.Instance.UpdateStatusTable(TableController.Instance.GetIDTableByName(lbTable.Text), "Đầy");
                        if (rs1 == 1)
                        {
                            LoadTables();
                        }
                    }
                }
                txtTotalBill.Text = LoadTotalBill().ToString();
                txtNumOrder.Value = 0;
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
                        if (total < 0)
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
            foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
            {
                int money = Convert.ToInt32(row.Cells[3].Value);
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

        //Làm mới
        #endregion


        #region Event
        private void cbbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listFoodName = new List<string>();
            List<Food> listfood = FoodController.Instance.GetListFood();
            string choose = cbbFoodCategory.SelectedItem.ToString();
            foreach (Food f in listfood)
            {
                if (choose.Equals(FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.categoryID)))
                {
                    listFoodName.Add($"{f.Name} : {f.Price} vnđ");
                }
            }

            cbbFood.DataSource = listFoodName;
            txtNumOrder.Value = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCus.Text) || HandleData.Instance.ExitNumber(txtCus.Text))
            {
                mf.NotifyErr("Tên khách hàng không hợp lệ!");
                return;
            }

            string nameFoodChoose = GetNameFood(cbbFood.SelectedItem.ToString().Split(' '));
            int quantity = Convert.ToInt32(txtNumOrder.Value);
            int priceFood = 0;
            int total = 0;

            if (quantity == 0)
            {
                mf.NotifyErr("Vui lòng chọn số lượng");
                return;
            }

            if (lbTable.Text.Equals("bàn"))
            {
                mf.NotifyErr("Vui lòng chọn bàn");
                return;
            }

            bool foodExists = false;


            foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == nameFoodChoose)
                {
                    int existingQuantity = Convert.ToInt32(row.Cells[1].Value);
                    int existingTotalMoney = Convert.ToInt32(row.Cells[3].Value);
                    existingQuantity += quantity;
                    priceFood = Convert.ToInt32(row.Cells[2].Value);
                    total = existingQuantity * priceFood;
                    row.Cells[1].Value = existingQuantity;
                    row.Cells[3].Value = total;
                    Menu menu = new Menu()
                    {
                        foodID = FoodController.Instance.GetIDFoodByName(nameFoodChoose),
                        Quantity = existingQuantity,
                        Total = total,
                        tableID = TableController.Instance.GetIDTableByName(lbTable.Text)
                    };
                    int rs = MenuController.Instance.UpdateMenu(menu);
                    if (rs == 1)
                    {
                        DisplayMenuForTable(lbTable.Text);

                    }
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
                }
                Menu menu = new Menu()
                {
                    foodID = FoodController.Instance.GetIDFoodByName(nameFoodChoose),
                    Price = priceFood,
                    Quantity = quantity,
                    Total = total,
                    tableID = TableController.Instance.GetIDTableByName(lbTable.Text)
                };
                int rs = MenuController.Instance.InsertMenu(menu);
                if (rs == 1)
                {
                    DisplayMenuForTable(lbTable.Text);
                    int rs1 = TableController.Instance.UpdateStatusTable(TableController.Instance.GetIDTableByName(lbTable.Text), "Đầy");
                    if (rs1 == 1)
                    {
                        LoadTables();
                    }
                }
            }
            txtTotalBill.Text = LoadTotalBill().ToString();
        }

        //Chọn bàn 
        void TableButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            if (button != null && button.Tag is Table)
            {
                Table table = (Table)button.Tag;
                string id = table.Id;
                lbTable.Text = TableController.Instance.GetNameTableById(id);
                DisplayMenuForTable(lbTable.Text);
                txtTotalBill.Text = LoadTotalBill().ToString();
                txtNumOrder.Value = 0;
            }
        }

        //Thanh toán
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCus.Text))
            {
                mf.NotifyErr("Vui lòng nhập tên khách hàng!");
                return;
            }
            string voucherName = cbbVoucher.SelectedItem.ToString().Split(' ')[0];
            NotifyBill.NotifyBill view = new NotifyBill.NotifyBill(txtCus.Text,
                StaffController.Instance.GetIDStaffByName(_nameStaff),
                TableController.Instance.GetIDTableByName(lbTable.Text),
                VoucherController.Instance.GetIdVoucherByName(voucherName)
                );
            if (view.ShowDialog() == DialogResult.OK)
            {
                LoadVoucher();
                LoadCategoryFood();
                LoadTables();
                LoadFood();
                DisplayMenuForTable(lbTable.Text);
                txtNumOrder.Value = 0;
                txtTotalBill.Text = "0";
            }
            else
            {
                mf.NotifyErr("Thanh toán thất bại");
                return;
            }



            //DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận thanh toán {lbTable.Text}");
            //{
            //    if(qs == DialogResult.OK)
            //    {
            //        //Thêm dữ liệu vào db

            //        //Hóa đơn bán
            //        int rdhours = new Random().Next(1, 4);
            //        DateTime dayIn = DateTime.Now;
            //        DateTime dayOut;

            //        if (dayIn.Hour > 12)
            //        {
            //            dayOut = dayIn.AddDays(1).Date;
            //        }
            //        else
            //        {
            //            dayOut = dayIn.Date;
            //        }

            //        dayOut = dayOut.AddHours(rdhours);

            //        string idBillSale = $"HDB00{BillSaleController.Instance.GetNumOrderBill() + 1}";
            //        string voucherName = cbbVoucher.SelectedItem.ToString().Split(' ')[0];
            //        BillSale billSale = new BillSale()
            //        {
            //            Id = idBillSale,
            //            dayIn = dayIn,
            //            dayOut = dayOut,
            //            voucherId = VoucherController.Instance.GetIdVoucherByName(voucherName),
            //            totalMoney = Convert.ToDouble(txtTotalBill.Text),
            //            staffID = StaffController.Instance.GetIDStaffByName(_nameStaff),
            //            tableID = TableController.Instance.GetIDTableByName(lbTable.Text)
            //        };

            //        int rs1 = BillSaleController.Instance.InsertBillSale(billSale);

            //        //Chi tiết hóa đơn bán
            //        if(dgvListFoodOrder.Rows.Count > 0 )
            //        {
            //            foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
            //            {
            //                string idBillSaleInfo = $"CTHDB0{BillSaleInfoController.Instance.GetNumOrderBillInfo() + 1}";
            //                string nameFood = row.Cells[0].Value.ToString();
            //                int quantity = Convert.ToInt32(row.Cells[1].Value);
            //                int price = Convert.ToInt32(row.Cells[2].Value);
            //                int total = Convert.ToInt32(row.Cells[3].Value);

            //                BillSaleInfo billSaleInfo = new BillSaleInfo()
            //                {
            //                    ID = idBillSaleInfo,
            //                    foodId = FoodController.Instance.GetIDFoodByName(nameFood),
            //                    Quantity = quantity,
            //                    foodPrice = price,
            //                    Total = total,
            //                    boSaleId = idBillSale
            //                };

            //                BillSaleInfoController.Instance.InsertBillSaleInfo(billSaleInfo);
            //            }
            //        }


            //        if (rs1 == 1)
            //        {
            //            mf.NotifySuss("Thanh toán hóa đơn thành công");
            //            //re-render giao diện
            //            TableController.Instance.UpdateStatusTable(TableController.Instance.GetIDTableByName(lbTable.Text), "Trống");
            //            MenuController.Instance.DeleteMenu(TableController.Instance.GetIDTableByName(lbTable.Text));
            //            LoadTables();
            //            DisplayMenuForTable(lbTable.Text);
            //            
            //        }


            //    }
            //}



        }

        //Sử dụng phiếu giảm giá
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
                foreach (var i in a)
                {
                    if (CheckNum.Instance.IsNum(i))
                    {
                        expiry = Convert.ToInt32(i);
                    }
                    if (i.Contains("%"))
                    {
                        expriryOption = "%";
                    }
                    else if (i.Contains("Vnd"))
                    {
                        expriryOption = "Vnd";
                    }
                }


                txtTotalBill.Text = CalcBill(totalBill, expiry, expriryOption).ToString();
            }


            if (Convert.ToDouble(txtTotalBill.Text) < 0)
            {
                txtTotalBill.Text = "0";
            }
        }

        //Chuyển bàn
        private void btnNextTable_Click(object sender, EventArgs e)
        {
            DisplayMenuForTable(cbbTable.SelectedItem.ToString());
            lbTable.Text = cbbTable.SelectedItem.ToString();
        }

        //
        private void cbbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumOrder.Value = 0;
        }


        #endregion


        private DataGridViewRow selectedRow = null;
        private void dgvListFoodOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgvListFoodOrder.Rows[e.RowIndex];
            }
        }

        //Xóa món ăn
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                return;
            }


            int rs = MenuController.Instance.DeleteFoodFromMenu(FoodController.Instance.GetIDFoodByName(selectedRow.Cells[0].Value.ToString()),
                                                                TableController.Instance.GetIDTableByName(lbTable.Text));
            if (rs == 1)
            {
                DisplayMenuForTable(lbTable.Text);
                txtTotalBill.Text = LoadTotalBill().ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
