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
    public partial class FoodInfo : Form
    {
        string _ID;
        MainForm mf = new MainForm();
        public FoodInfo()
        {
            InitializeComponent();
        }

        private void FoodInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtParam.Text))
            {
                mf.NotifyErr("Vui lòng nhập giá tri tìm kiếm");
                return;
            }
            string optionPrice = cbbOptionPrice.SelectedItem != null ? cbbOptionPrice.SelectedItem.ToString() : null;
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text);
            dgvFood.DataSource = dt;
            dgvFood.RowTemplate.Height = 100;
            dgvFood.DataSource = dt;

            var imageColumn = dgvFood.Columns["Hình ảnh"] as DataGridViewImageColumn;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFood view = new AddFood();
            view.ShowDialog();
        }

        private void sửaMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }

            EditFood view = new EditFood(_ID);
            view.ShowDialog();
        }

        private void xóaMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Ấn OK để xác nhận xóa món ăn id = {_ID}");
            if(qs == DialogResult.OK)
            {
                int rs = FoodController.Instance.DeleteFood(_ID);
                if(rs == 1)
                {
                    mf.NotifySuss("Xóa món ăn thành công");
                }
            }
        }

        private DataGridViewRow rowSelected = null;
        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowSelected = dgvFood.Rows[e.RowIndex];
            }
            _ID = rowSelected.Cells[0].Value.ToString();
        }


        void LoadData()
        {
            LoadFood();
            LoadOption();
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
            dt.Columns.Add("Số lượng NL");
            dt.Columns.Add("Loại món ăn");
            dt.Columns.Add("Hình ảnh", typeof(byte[]));
            foreach (Food f in foods)
            {
                string category = FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.categoryID);
                string material = WarehouseController.Instance.GetNameItemByID(f.materialID);
                dt.Rows.Add(f.ID, f.Name, f.Price, material, f.numMaterial, category, f.imageFood);
            }

            dgvFood.RowTemplate.Height = 100;
            dgvFood.DataSource = dt;

            var imageColumn = dgvFood.Columns["Hình ảnh"] as DataGridViewImageColumn;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }



        void LoadOption()
        {
            List<string> options = new List<string>()
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên món ăn" ,
                "Tìm kiếm theo giá bán" ,
                "Tìm kiếm theo nguyên liệu" ,
                "Tìm kiếm theo loại món ăn"
            };

            cbbOption.DataSource = options;
        }

        void Refresh()
        {
            txtParam.ResetText();
            LoadData();
        }


        DataTable HandleSearch(string option, string keyword)
        {
            dgvFood.Columns.Clear();
            List<Food> foods = new List<Food>();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên món ăn");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Nguyên liệu");
            dt.Columns.Add("Số lượng NL");
            dt.Columns.Add("Loại món ăn");
            dt.Columns.Add("Hình ảnh", typeof(byte[]));
            switch (option)
            {
                case "Tìm kiếm theo mã":
                    {
                        foods = FoodController.Instance.SelectFoodByParam("food_id", "=" , $"'{keyword}'");
                        break;
                    }
                case "Tìm kiếm theo tên món ăn":
                    {
                        foods = FoodController.Instance.SelectFoodByParam("food_name", "LIKE", $"N'%{keyword}%'");
                        break;
                    }
                case "Tìm kiếm theo giá bán":
                    {
                        foods = FoodController.Instance.SelectFoodByParam("food_price", cbbOptionPrice.SelectedItem.ToString(), keyword);
                        break;
                    }
                case "Tìm kiếm theo nguyên liệu":
                    {
                        foods = FoodController.Instance.SelectFoodByParam("item_id", "=", $"'{WarehouseController.Instance.GetIDItemByName(keyword)}'");
                        break;
                    }
                case "Tìm kiếm theo loại món ăn":
                    {
                        foods = FoodController.Instance.SelectFoodByParam("cgFood_id", "=", $"N'{FoodCategoryController.Instance.GetIDCatgoryFoodByName(keyword)}'");
                        break;
                    }
            }

            foreach (Food f in foods)
            {
                string category = FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.categoryID);
                string material = WarehouseController.Instance.GetNameItemByID(f.materialID);
                dt.Rows.Add(f.ID, f.Name, f.Price, material, f.numMaterial, category, f.imageFood);
            }

            

            return dt;
        }

        private void cbbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbOption.SelectedValue.ToString().Equals("Tìm kiếm theo giá bán"))
            {
                cbbOptionPrice.Visible = true;
            }
            else
            {
                cbbOptionPrice.Visible = false;
            }
        }
    }
}
