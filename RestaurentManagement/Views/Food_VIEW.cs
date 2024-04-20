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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RestaurentManagement.Views
{
    public partial class Food_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Food_VIEW()
        {
            InitializeComponent();
        }

        private void Food_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            Refresh();
        }

        #region Method
        void LoadData()
        {
            LoadCategory();
            LoadMaterial();
            LoadFood();         
        }
        void LoadFood()
        {
            dgvFood.Columns.Clear();
            List<Food> foods = FoodController.Instance.GetListFood();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Loại");
            foreach (Food f in foods)
            {
                string category = FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.categoryID);
                string material = WarehouseController.Instance.GetNameItemByID(f.materialID);
                dt.Rows.Add(f.ID,f.Name,f.Price,material,f.numMaterial,category);
            }
            dgvFood.DataSource = dt;
        }
        void LoadMaterial()
        {
            
            
            

            
        }

        void LoadCategory()
        {
            List<string> listNameCategory = new List<string>();
            List<FoodCategory> listCategory = FoodCategoryController.Instance.GetListCategoryFood();
            foreach (FoodCategory fg in listCategory)
            {
                listNameCategory.Add(fg.Name);              
            }
            cbbCategory.DataSource = listNameCategory;
        }

        void Refresh()
        {
            LoadData();
            txtFoodID.Text = "Dành cho chức năng tìm kiếm";
            txtFoodName.ResetText();
            txtNumMaterial.Value = 0;
            txtPrice.Value = 0;
        }
        #endregion

        #region Event
        private void dgvFood_Click(object sender, EventArgs e)
        {
            if(dgvFood.SelectedRows.Count > 0)
            {
                txtFoodID.Text = dgvFood.SelectedRows[0].Cells[0].Value.ToString();
                txtFoodName.Text = dgvFood.SelectedRows[0].Cells[1].Value.ToString();
                txtPrice.Value = Convert.ToInt32(dgvFood.SelectedRows[0].Cells[2].Value);
                cbbMaterial.SelectedItem = dgvFood.SelectedRows[0].Cells[3].Value.ToString();
                txtNumMaterial.Value = Convert.ToInt32(dgvFood.SelectedRows[0].Cells[4].Value);
                cbbCategory.SelectedItem = dgvFood.SelectedRows[0].Cells[5].Value.ToString();              
            }
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
                mf.NotifySuss("Thêm món ăn thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Food f = new Food()
            {
                ID = txtFoodID.Text,
                Name = txtFoodName.Text,
                Price = Convert.ToInt32(txtPrice.Value),
                materialID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                numMaterial = Convert.ToInt32(txtNumMaterial.Value),
                categoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString())
            };

            int data = FoodController.Instance.UpdateFood(f);
            if (data == 1)
            {
                mf.NotifySuss("Cập nhật món ăn thành công");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa");
            if(qs == DialogResult.OK)
            {
                int data = FoodController.Instance.DeleteFood(txtFoodID.Text);
                if (data == 1)
                {
                    mf.NotifySuss("Xóa món ăn thành công");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvFood.Columns.Clear();
            List<Food> foods = FoodController.Instance.SelectFoodByID(txtFoodID.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Loại");
            foreach (Food f in foods)
            {
                string category = FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.categoryID);
                string material = WarehouseController.Instance.GetNameItemByID(f.materialID);
                dt.Rows.Add(f.ID, f.Name, f.Price, material, f.numMaterial, category);
            }
            dgvFood.DataSource = dt;
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listNameMaterial = new List<string>();
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            foreach(Warehouse material in listMaterial)
            {
                if (material.CategoryID.Equals(FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString())))
                {
                    listNameMaterial.Add(material.Name);
                }
            }

            cbbMaterial.DataSource = listNameMaterial;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }




        #endregion

        
    }
}
