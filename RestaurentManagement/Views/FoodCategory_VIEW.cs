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

namespace RestaurentManagement.Views
{
    public partial class FoodCategory_VIEW : Form
    {
        MainForm mf = new MainForm();
        public FoodCategory_VIEW()
        {
            InitializeComponent();
        }

        private void FoodCategory_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Method
        void LoadData()
        {
            dgvFoodCategory.Columns.Clear();
            List<FoodCategory> foodCategories = FoodCategoryController.Instance.GetListCategoryFood();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã danh mục");
            dt.Columns.Add("Tên danh mục");
            foreach (FoodCategory foodCategory in foodCategories)
            {
                dt.Rows.Add(foodCategory.ID, foodCategory.Name);
            }
            dgvFoodCategory.DataSource = dt; 
        }

        void Refresh()
        {
            LoadData();
            txtCategoryID.Text = "Dành cho chức năng tìm kiếm";
            txtCategoryName.ResetText();
        }
        #endregion

        #region Event
        private void dgvFood_Click(object sender, EventArgs e)
        {
            if(dgvFoodCategory.Rows.Count > 0)
            {
                txtCategoryID.Text = dgvFoodCategory.SelectedRows[0].Cells[0].Value.ToString();
                txtCategoryName.Text = dgvFoodCategory.SelectedRows[0].Cells[1].Value.ToString();
            }
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCategoryName.Text))
            {
                mf.NotifyErr("Tên danh mục không hợp lệ");
                return;
            }
            string id = $"MA000{FoodCategoryController.Instance.GetOrderNumInList()}";
            FoodCategory foodCategory = new FoodCategory()
            {
                ID = id,
                Name = txtCategoryName.Text,
            };

            int rs = FoodCategoryController.Instance.InsertCategory(foodCategory);
            if(rs == 1)
            {
                mf.NotifySuss($"Thêm danh mục {txtCategoryName.Text} thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                mf.NotifyErr("Tên danh mục không hợp lệ");
                return;
            }

            FoodCategory foodCategory = new FoodCategory()
            {
                ID = txtCategoryID.Text,
                Name = txtCategoryName.Text,
            };

            int rs = FoodCategoryController.Instance.UpdateCategory(foodCategory);
            if (rs == 1)
            {
                mf.NotifySuss($"Cập nhật danh mục {txtCategoryName.Text} thành công");
                Refresh();
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qt = mf.NotifyConfirm("Ấn OK để xác nhận xóa");
            if (qt == DialogResult.OK)
            {
                int rs = FoodCategoryController.Instance.DeleteCategory(txtCategoryID.Text);
                if(rs == 1)
                {
                    mf.NotifySuss($"Xóa danh mục {txtCategoryName.Text} thành công");
                    Refresh();
                } 
                else
                {
                    mf.NotifyErr("Không thể xóa vì còn dữ liệu liên quan");
                    return;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvFoodCategory.Columns.Clear();
            List<FoodCategory> foodCategories = FoodCategoryController.Instance.SearchCategory(txtCategoryID.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã danh mục");
            dt.Columns.Add("Tên danh mục");
            foreach (FoodCategory foodCategory in foodCategories)
            {
                dt.Rows.Add(foodCategory.ID, foodCategory.Name);
            }
            dgvFoodCategory.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }




        #endregion

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
