using Guna.UI2.WinForms;
using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                categoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString()),
                imageFood = ConvertImgToByte(txtImage.Text)
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

        private byte[] ConvertImgToByte(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] picture = new byte[fs.Length];
            fs.Read(picture, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return picture;
        }
    }
}
