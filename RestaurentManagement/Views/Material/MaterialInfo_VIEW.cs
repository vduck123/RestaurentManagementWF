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
using System.Xml.Linq;

namespace RestaurentManagement.Views.Material
{
    public partial class MaterialInfo_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public MaterialInfo_VIEW()
        {
            InitializeComponent();
        }

        private void sửaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }
            EditMaterial view = new EditMaterial(_ID);
            view.ShowDialog();
        }

        private void xóaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa nguyên liệu");
            if (qs == DialogResult.OK)
            {
                int rs = WarehouseController.Instance.DeleteItem(_ID);
                if (rs == 1)
                {
                    mf.NotifySuss($"Xóa nguyên liệu thành công");
                    Refresh();
                }
            }
        }

        private void MaterialInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgvMaterial.Columns.Clear();
            string opera = cbbOpera.SelectedItem != null ? cbbOpera.SelectedItem.ToString() : null;
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text, opera);
            dgvMaterial.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMaterial view = new AddMaterial();
            view.ShowDialog();
        }

        private DataGridViewRow rowSelected = null;
        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvMaterial.Rows[e.RowIndex];
            }

            _ID = rowSelected.Cells[0].Value.ToString();
        }

        void LoadData()
        {
            LoadMaterial();
            LoadOption();
        }

        void LoadMaterial()
        {
            dgvMaterial.Columns.Clear();
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

            dgvMaterial.DataSource = dt;
        }

        void LoadOption()
        {
            List<string> options = new List<string>()
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên" ,
                "Tìm kiếm theo số lượng" ,
                "Tìm kiếm theo loại"
            };
            cbbOption.DataSource = options;
        }

        void Refresh()
        {
            txtParam.ResetText();
            LoadData();
        }

        DataTable HandleSearch(string option, string param, string opera)
        {
            List<Warehouse> listItem = new List<Warehouse>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Loại hàng");


            switch(option)
            {
                case "Tìm kiếm theo mã":
                    {
                        listItem = WarehouseController.Instance.SelectItemByParam("item_id", $"'{param}'", "=");
                        break;
                    }
                case "Tìm kiếm theo tên":
                    {
                        listItem = WarehouseController.Instance.SelectItemByParam("item_name", $"N'%{param}%'", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo số lượng":
                    {
                        listItem = WarehouseController.Instance.SelectItemByParam("quantity", param, opera);
                        break;
                    }
                case "Tìm kiếm theo loại":
                    {
                        listItem = WarehouseController.Instance.SelectItemByParam("item_category", $"'{FoodCategoryController.Instance.GetIDCatgoryFoodByName(param)}'", "=");
                        break;
                    }
            }


            foreach (Warehouse item in listItem)
            {
                dt.Rows.Add(item.ID, item.Name, item.Quantity, FoodCategoryController.Instance.GetNameCatgoryFoodByID(item.CategoryID));
            }

            dgvMaterial.DataSource = dt;

            return dt;
        }

        private void cbbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            txtParam.ResetText();
            if(cbbOption.SelectedItem.ToString().Equals("Tìm kiếm theo số lượng"))
            {
                cbbOpera.Visible = true;
            }
            else
            {
                cbbOpera.Visible = false;
            }
        }
    }
}
