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

namespace RestaurentManagement.Views.Setting
{
    public partial class Setting_VIEW : Form
    {
        public Setting_VIEW()
        {
            InitializeComponent();
        }

        int clicked = 0;
        private void btnInfo_Click(object sender, EventArgs e)
        {
            clicked++;
            if(clicked % 2 == 1)
            {
                guna2Panel1.Visible = true;
            }
            else
            {
                guna2Panel1.Visible =false;
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_VIEW view = new Login_VIEW();
            view.ShowDialog();
        }

        private void btnFakeData_Click(object sender, EventArgs e)
        {
            frmData view = new frmData();
            view.Show();
        }

        private void Setting_VIEW_Load(object sender, EventArgs e)
        {
            GetInFo();
        }

        void GetInFo()
        {
            List<InForRestaurant> data = InfoRestaurantController.Instance.GetData();
            foreach (var item in data)
            {
                txtName.Text = item.Name;
                txtPhone.Text = item.Phone;
                txtAddress.Text = item.Address;
                txtTimeOpen.Text = item.timeOpen;
                txtTimeClose.Text = item.timeClose;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult qs = MessageBox.Show("Chọn OK để xác nhận thay đổi thông tin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(qs == DialogResult.OK)
            {
                InForRestaurant info = new InForRestaurant()
                {
                    Name = txtName.Text ,
                    Phone = txtPhone.Text ,
                    Address = txtAddress.Text ,
                    timeOpen = txtTimeOpen.Text ,
                    timeClose = txtTimeClose.Text 
                };

                int rs = InfoRestaurantController.Instance.Edit(info);
                if(rs > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
