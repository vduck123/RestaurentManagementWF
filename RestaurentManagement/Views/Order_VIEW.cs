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
            LoadCategoryFood();
            LoadTables();
        }

        #region Method


        void LoadTables()
        {
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

                fpanelListTable.Controls.Add(btn);
            }
        }
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

        }
        #endregion


        #region Event
        void TableButton_Click(object sender, EventArgs e)
        {
            
        }

        private void cbbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listFoodName = new List<string>();
            List<Food> listfood = FoodController.Instance.GetListFood();
            string choose = cbbFoodCategory.SelectedItem.ToString();
            foreach (Food f in listfood)
            {
                if(choose.Equals(FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.FoodType)))
                {
                    listFoodName.Add(f.Name);
                }
            }

            cbbFood.DataSource = listFoodName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nameFoodChoose = cbbFood.SelectedItem.ToString();
            int quantity = Convert.ToInt32(cbbQuantity.SelectedItem);
            int priceFood = 0;
            int totalMoney = 0;
            int totalBill = 0;

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
                    totalMoney = existingQuantity * priceFood;
                    row.Cells["Column2"].Value = existingQuantity;
                    row.Cells["Column4"].Value = totalMoney;
                    totalBill += totalMoney;
                    txtTotalBill.Text = totalBill.ToString();
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
                    totalMoney = quantity * priceFood;
                    totalBill += totalMoney;
                }

                dgvListFoodOrder.Rows.Add(nameFoodChoose, quantity, priceFood, totalMoney);
                txtTotalBill.Text = totalBill.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int rdHours = new Random().Next(1, 4);
            int idBillNum = BillController.Instance.GetNumOrderBill();
            Bill bill = new Bill()
            {
                Id = $"BOS{idBillNum + 1}",
                dayIn = DateTime.Now,
                dayOut = DateTime.Now.AddHours(rdHours),
                totalMoney = Convert.ToInt32(txtTotalBill.Text)
            };

            int rs = BillController.Instance.InsertBill(bill);
            MessageBox.Show(rs.ToString());
        

        //foreach (DataGridViewRow row in dgvListFoodOrder.Rows)
        //{

        //    string foodName = row.Cells["Column2"].Value.ToString();
        //    int quantity = Convert.ToInt32(row.Cells["Column3"].Value);

        //    int idBillInfoNum = BillInfoController.Instance.GetNumOrderBillInfo();
        //    BillInfo billInfo = new BillInfo()
        //    {
        //        Id = $"DBOS{idBillInfoNum + 1}",
        //        IdFood = FoodController.Instance.GetIDFoodByName(foodName),
        //        Quantity = quantity,
        //        IdBill = bill.Id
        //    };
        //}
    }



        #endregion


    }
}
