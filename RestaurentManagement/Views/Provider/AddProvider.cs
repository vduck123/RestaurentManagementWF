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

namespace RestaurentManagement.Views.Provider
{
    public partial class AddProvider : Form
    {
        MainForm mf = new MainForm();
        public AddProvider()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xác nhận thông tin");
            {
                if(qs == DialogResult.OK)
                {
                    string id = $"NCC00{SupplierController.Instance.GetOrderNumInList()}";
                    Supplier supplier = new Supplier()
                    {
                        ID = id,
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Phone = txtPhone.Text,
                        Note = txtNote.Text
                    };

                    int rs = SupplierController.Instance.InsertSupplier(supplier);
                    if (rs == 1)
                    {
                        mf.NotifySuss($"Thêm nhà cung cấp {txtName.Text} thành công");
                        this.Close();
                    }
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
    }
}
