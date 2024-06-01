using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            if(!isAddedFood)
            {
                mf.NotifyErr("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            mf.NotifySuss($"Thêm món ăn {txtFoodName.Text} thành công");
            this.Close();

        }

        bool isAddedFood = false;
        string idFood = null;
        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFoodName.Text) ||
                string.IsNullOrEmpty(txtImage.Text) ||
                string.IsNullOrEmpty(txtUnitFood.Text))
            {
                mf.NotifyErr("Vui lòng không được để trống các trường !");
                return;
            }

            if (txtNumMaterial.Value <= 0)
            {
                mf.NotifyErr("Số lượng nguyên liệu phải lớn hơn 0 !");
                return;
            }

            if (!isAddedFood)
            {
                idFood = $"F0000{FoodController.Instance.GetOrderNumInList() + 1}";
                Food f = new Food()
                {
                    ID = idFood,
                    Name = txtFoodName.Text,
                    Price = Convert.ToInt32(txtPrice.Value),
                    Unit = txtUnitFood.Text,
                    categoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString()),
                    imageFood = ConvertImgToByte(txtImage.Text)
                };
                int data = FoodController.Instance.InsertFood(f);
                if (data > 0)
                {
                    isAddedFood = true;
                }
            }


            FoodMaterial fm = new FoodMaterial()
            {
                materialID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                Quantity = Convert.ToInt32(txtNumMaterial.Value),
                Unit = txtUnitMaterial.Text,
                foodID = idFood
            };

            int rs = FoodMateialController.Instance.InsertFoodMaterial(fm);
            if (rs > 0)
            {
                LoadFoodMaterial(idFood);            
            }

        }

        private void cbbMaterial_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            foreach (Warehouse item in listMaterial)
            {
                if (cbbMaterial.SelectedValue.ToString().Equals(item.Name))
                {
                    txtUnitMaterial.Text = item.Unit;
                }
            }

        }

        DataGridViewRow rowFoodMaterialSelected = null;
        string _IdMaterial = null;
        private void dgvFoodMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFoodMaterial.Rows.Count > 0)
            {
                rowFoodMaterialSelected = dgvFoodMaterial.Rows[e.RowIndex];
                _IdMaterial = WarehouseController.Instance.GetIDItemByName(rowFoodMaterialSelected.Cells[0].Value.ToString());
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_IdMaterial == null)
            {
                return;
            }

            int rs = FoodMateialController.Instance.DeleteFoodMaterial(_IdMaterial, idFood);
            if (rs > 0)
            {
                LoadFoodMaterial(idFood);
            }
        }

        private void btnChoosseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = openFileDialog.Filter = "JPG files (*.jpg) | *.jpg|All files (*.*) | *.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture.ImageLocation = openFileDialog.FileName;
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                txtImage.Text = openFileDialog.FileName;
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

        #region Method

        void LoadData()
        {
            LoadCategory();
            GetListMaterial();
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
        

        private byte[] ConvertImgToByte(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] picture = new byte[fs.Length];
            fs.Read(picture, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return picture;
        }



        void GetListMaterial()
        {
            List<string> listNameMaterial = new List<string>();
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            foreach (Warehouse item in listMaterial)
            {
                listNameMaterial.Add(item.Name);
            }
            cbbMaterial.DataSource = listNameMaterial;
        }

        void LoadFoodMaterial(string idFood)
        {
            if (idFood == null)
            {
                return;
            }
            dgvFoodMaterial.Columns.Clear();
            List<FoodMaterial> listFoodMaterial = FoodMateialController.Instance.GetListFoodMaterialByFoodId(idFood);
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên nguyên liệu");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Đơn vị tính");
            foreach (FoodMaterial item in listFoodMaterial)
            {
                dt.Rows.Add(WarehouseController.Instance.GetNameItemByID(item.materialID), item.Quantity, item.Unit);
            }

            dgvFoodMaterial.DataSource = dt;

        }
        #endregion


    }
}
