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
            dgvFood.Columns.Clear();
            List<FoodCategory> foodCategories = FoodCategoryController.Instance.GetListCategoryFood();

            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryId");
            dt.Columns.Add("CategoryName");
            foreach (FoodCategory foodCategory in foodCategories)
            {
                dt.Rows.Add(foodCategory.ID, foodCategory.Name);
            }
            dgvFood.DataSource = dt; 
        }

        void Refresh()
        {
            LoadData();
            txtCategoryID.ResetText();
            txtCategoryName.ResetText();
        }
        #endregion

        #region Event
        private void dgvFood_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = dgvFood.SelectedRows[0].Cells[0].Value.ToString();
            txtCategoryName.Text = dgvFood.SelectedRows[0].Cells[1].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FoodCategory foodCategory = new FoodCategory()
            {
                ID = txtCategoryID.Text,
                Name = txtCategoryName.Text,
            };

            int rs = FoodCategoryController.Instance.InsertCategory(foodCategory);
            if(rs == 1)
            {
                mf.NotifySuss("Thêm loại hàng thành công");
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FoodCategory foodCategory = new FoodCategory()
            {
                ID = txtCategoryID.Text,
                Name = txtCategoryName.Text,
            };

            int rs = FoodCategoryController.Instance.UpdateCategory(foodCategory);
            if (rs == 1)
            {
                mf.NotifySuss("Cập nhật loại hàng thành công");
                LoadData();
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
                    mf.NotifySuss("Xóa loại hàng thành công");
                    LoadData();
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
            DataTable dt = FoodCategoryController.Instance.SearchCategory(txtCategoryID.Text);
            dgvFood.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }



        #endregion

        
    }
}
