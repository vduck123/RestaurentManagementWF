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
    public partial class Warehouse_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Warehouse_VIEW()
        {
            InitializeComponent();
        }
        #region Event
        private void Warehouse_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCategory();
        }

        private void dgvWarehouse_Click(object sender, EventArgs e)
        {
            if(dgvWarehouse.SelectedRows.Count > 0)
            {
                txtID.Text = dgvWarehouse.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvWarehouse.SelectedRows[0].Cells[1].Value.ToString();
                txtQuantity.Value = Convert.ToInt32(dgvWarehouse.SelectedRows[0].Cells[2].Value);
                cbbCategory.SelectedItem = dgvWarehouse.SelectedRows[0].Cells[3].Value.ToString();
            }
            else
            {
                return;
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Warehouse item = new Warehouse()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                CategoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString()),
            };

            int rs = WarehouseController.Instance.InsertItem(item);
            if(rs == 1)
            {
                mf.NotifySuss("Thêm nguyên liệu thành công");
                Refresh();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Warehouse item = new Warehouse()
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Value) ,
                CategoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString())
            };

            int rs = WarehouseController.Instance.UpdateItem(item);
            if (rs == 1)
            {
                mf.NotifySuss("Cập nhật nguyên liệu thành công");
                Refresh();

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa nguyên liệu");
            if(qs == DialogResult.OK)
            {
                int rs = WarehouseController.Instance.DeleteItem(txtID.Text);
                if (rs == 1)
                {
                    mf.NotifySuss("Xóa nguyên liệu thành công");
                    Refresh();

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {           
            dgvWarehouse.Columns.Clear();
            List<Warehouse> listItem = WarehouseController.Instance.SelectItemByID(txtID.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Loại hàng");

            foreach (Warehouse item in listItem)
            {
                dt.Rows.Add(item.ID, item.Name, item.Quantity, FoodCategoryController.Instance.GetNameCatgoryFoodByID(item.CategoryID));
            }

            dgvWarehouse.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion

        #region Method
        void LoadData()
        {
            dgvWarehouse.Columns.Clear();
            List<Warehouse> listItem = WarehouseController.Instance.GetListItem();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Loại hàng");

            foreach (Warehouse item in listItem)
            {
                dt.Rows.Add(item.ID, item.Name, item.Quantity, FoodCategoryController.Instance.GetNameCatgoryFoodByID(item.CategoryID));
            }

            dgvWarehouse.DataSource = dt;
        }

        void LoadCategory()
        {
            List<string> listNameCategory = new List<string>();
            List<FoodCategory> listCategory = FoodCategoryController.Instance.GetListCategoryFood();

            foreach(FoodCategory category in listCategory)
            {
                listNameCategory.Add(category.Name);
            }

            cbbCategory.DataSource = listNameCategory;
        }

        void Refresh()
        {
            LoadData();
            txtID.ResetText();
            txtName.ResetText();
            txtQuantity.Value = 0;
        }
        #endregion
    }
}
