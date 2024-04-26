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
    public partial class AddMaterial : Form
    {
        MainForm mf = new MainForm();
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận thêm nguyên liệu {txtName.Text}");
            {
                if(qs == DialogResult.OK)
                {
                    string id = $"NL000{WarehouseController.Instance.GetOrderNumInList()}";
                    Warehouse item = new Warehouse()
                    {
                        ID = id,
                        Name = txtName.Text,
                        Quantity = Convert.ToInt32(txtQuantity.Text),
                        CategoryID = FoodCategoryController.Instance.GetIDCatgoryFoodByName(cbbCategory.SelectedItem.ToString()),
                    };

                    int rs = WarehouseController.Instance.InsertItem(item);
                    if (rs == 1)
                    {
                        mf.NotifySuss($"Thêm nguyên liệu thành công");
                        this.Close();
                    }
                }
            }           
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
