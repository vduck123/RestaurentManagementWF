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

namespace RestaurentManagement.Views.Foods
{
    public partial class EditFood : Form
    {
        string _ID = null;
        MainForm mf = new MainForm();
        public EditFood(string id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn Ok xác nhận thay đổi thông tin");
            if(qs == DialogResult.OK)
            {
                Food f = new Food()
                {
                    ID = _ID,
                    Name = txtFoodName.Text,
                    Price = Convert.ToInt32(txtPrice.Value),
                    materialID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                    numMaterial = Convert.ToInt32(txtNumMaterial.Value),
                    categoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString())
                };

                int data = FoodController.Instance.UpdateFood(f);
                if (data == 1)
                {
                    mf.NotifySuss($"Cập nhật món ăn {txtFoodName.Text} thành công");
                    this.Close();
                }
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

        private void EditFood_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            GetData();
            LoadMaterial();
            LoadCategory();
        }

        void GetData()
        {
            if(_ID == null) 
            {
                return;
            }

            List<Food> listFood = FoodController.Instance.SelectFoodByParam("food_id", _ID);
            foreach (Food food in listFood)
            {
                cbbCategory.SelectedItem = FoodCategoryController.Instance.GetNameCatgoryFoodByID(food.categoryID);
                txtFoodName.Text = food.Name;
                txtPrice.Value = Convert.ToInt32(food.Price);
                cbbMaterial.SelectedItem = WarehouseController.Instance.GetNameItemByID(food.materialID);
                txtNumMaterial.Value = Convert.ToInt32(food.numMaterial);
            }
        }

        void LoadCategory()
        {
            List<string> listnameCategory = new List<string>();
            List<FoodCategory> foodCategories = FoodCategoryController.Instance.GetListCategoryFood();
            foreach(FoodCategory category in foodCategories)
            {
                listnameCategory.Add(category.Name);    
            }
            cbbCategory.DataSource = listnameCategory;
        }

        void LoadMaterial()
        {
            List<string> listNameMaterial = new List<string>();
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            foreach(Warehouse item in listMaterial)
            {
                listNameMaterial.Add(item.Name);    
            }

            cbbMaterial.DataSource = listNameMaterial;
        }
    }
}
