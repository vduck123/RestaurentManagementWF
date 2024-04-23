using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views.Foods
{
    public partial class AddFood : Form
    {
        MainForm mf = new MainForm();
        public AddFood()
        {
            InitializeComponent();
        }
        private void AddFood_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"F0000{FoodController.Instance.GetOrderNumInList()}";
            Food f = new Food()
            {
                ID = id,
                Name = txtFoodName.Text,
                Price = Convert.ToInt32(txtPrice.Value),
                materialID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                numMaterial = Convert.ToInt32(txtNumMaterial.Value),
                categoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString())
            };

            int data = FoodController.Instance.InsertFood(f);
            if (data == 1)
            {
                mf.NotifySuss($"Thêm món ăn {txtFoodName.Text} thành công");
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadData()
        {
            LoadMaterial();
            LoadCategory();
        }

        void LoadCategory()
        {
            List<string> listnameCategory = new List<string>();
            List<FoodCategory> foodCategories = FoodCategoryController.Instance.GetListCategoryFood();
            foreach (FoodCategory category in foodCategories)
            {
                listnameCategory.Add(category.Name);
            }
            cbbCategory.DataSource = listnameCategory;
        }

        void LoadMaterial()
        {
            List<string> listNameMaterial = new List<string>();
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            foreach (Warehouse item in listMaterial)
            {
                listNameMaterial.Add(item.Name);
            }

            cbbMaterial.DataSource = listNameMaterial;
        }


    }
}
