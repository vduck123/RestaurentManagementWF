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

namespace RestaurentManagement.Views.Material
{
    public partial class EditMaterial : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public EditMaterial(string id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void EditMaterial_Load(object sender, EventArgs e)
        {
            GetData();
            LoadCategory();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DialogResult qs = mf.NotifyConfirm($"Chọn OK thay đổi thông tin nguyên liệu {txtName.Text}");
            if(qs == DialogResult.OK)
            {
                Warehouse item = new Warehouse()
                {
                    ID = _ID,
                    Name = txtName.Text,
                    Quantity = Convert.ToInt32(txtQuantity.Value),
                    CategoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString())
                };

                int rs = WarehouseController.Instance.UpdateItem(item);
                if (rs == 1)
                {
                    mf.NotifySuss($"Cập nhật nguyên liệu thành công");
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

        void GetData()
        {
            List<Warehouse> listMaterial = WarehouseController.Instance.SelectItemByID(_ID);
            foreach (Warehouse item in listMaterial)
            {
                txtName.Text = item.Name;
                txtQuantity.Value = item.Quantity;
                cbbCategory.SelectedItem = FoodCategoryController.Instance.GetNameCatgoryFoodByID(item.CategoryID);
            }
        }

        void LoadCategory()
        {
            List<Warehouse> listMaterial = WarehouseController.Instance.GetListItem();
            List<string> listNameCategory = new List<string>();
            foreach (Warehouse item in listMaterial)
            {
                listNameCategory.Add(item.Name);
            }

            cbbCategory.DataSource = listNameCategory;
        }
    }
}
