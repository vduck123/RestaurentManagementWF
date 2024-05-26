using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void EditFood_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFoodName.Text) ||
                string.IsNullOrEmpty(txtImage.Text) ||
                string.IsNullOrEmpty(txtUnitFood.Text))
            {
                mf.NotifyErr("Các trường thông tin không được để trống !");
                return;
            }
            DialogResult qs = mf.NotifyConfirm("Ấn Ok xác nhận thay đổi thông tin");
            if (qs == DialogResult.OK)
            {
                Food f = new Food()
                {
                    ID = _ID,
                    Name = txtFoodName.Text,
                    Price = Convert.ToInt32(txtPrice.Value),
                    Unit = txtUnitFood.Text,
                    categoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString()),
                    imageFood = ConvertImgToByte(txtImage.Text)
                };

                int data = FoodController.Instance.UpdateFood(f);
                if (data == 1)
                {
                    mf.NotifySuss($"Cập nhật món ăn {txtFoodName.Text} thành công");
                    this.Close();
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

        private void xóaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_IdMaterial == null)
            {
                return;
            }

            int rs = FoodMateialController.Instance.DeleteFoodMaterial(_IdMaterial, _ID);
            if (rs > 0)
            {
                LoadFoodMaterial(_ID);
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

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            FoodMaterial fm = new FoodMaterial()
            {
                materialID = WarehouseController.Instance.GetIDItemByName(cbbMaterial.SelectedItem.ToString()),
                Quantity = Convert.ToInt32(txtNumMaterial.Value),
                Unit = txtUnitMaterial.Text,
                foodID = _ID
            };

            int rs = FoodMateialController.Instance.InsertFoodMaterial(fm);
            if (rs > 0)
            {
                LoadFoodMaterial(_ID);
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
            GetData();
            LoadMaterial();
            LoadCategory();
            LoadFoodMaterial(_ID);
        }

        void GetData()
        {
            if (_ID == null)
            {
                return;
            }

            List<Food> listFood = FoodController.Instance.SelectFoodByParam("food_id", "=", $"'{_ID}'");
            foreach (Food food in listFood)
            {
                cbbCategory.SelectedItem = FoodCategoryController.Instance.GetNameCatgoryFoodByID(food.categoryID);
                txtFoodName.Text = food.Name;
                txtPrice.Value = Convert.ToInt32(food.Price);
                txtUnitFood.Text = food.Unit;
                txtImage.Text = food.imageFood != null ? ConvertByteToImgPath(food.imageFood) : string.Empty;
                if (food.imageFood != null)
                {
                    picture.Image = ByteArrayToImage(food.imageFood);
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                }

            }
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

        

        private byte[] ConvertImgToByte(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] picture = new byte[fs.Length];
            fs.Read(picture, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return picture;
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private string ConvertByteToImgPath(byte[] byteArray)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "tempImage.jpg");
            File.WriteAllBytes(tempPath, byteArray);
            return tempPath;
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
