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
    public partial class EditProvider : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public EditProvider(string id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void EditProvider_Load(object sender, EventArgs e)
        {
            GetData();
        }

        void GetData()
        {
            if(_ID == null)
            {
                return;
            }

            List<Supplier> listSupplier = SupplierController.Instance.SelectSupplierByParam("supplier_id", _ID, "=");
            foreach (Supplier supplier in listSupplier)
            {
                txtName.Text = supplier.Name;
                txtAddress.Text = supplier.Address;
                txtPhone.Text = supplier.Phone;
                txtNote.Text = supplier.Note;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xác nhận thông tin");
            if (qs == DialogResult.OK)
            {
                Supplier supplier = new Supplier()
                {
                    ID = _ID,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Note = txtNote.Text
                };

                int rs = SupplierController.Instance.UpdateSupplier(supplier);
                if (rs == 1)
                {
                    mf.NotifySuss($"Cập nhật nhà cung cấp {txtName.Text} thành công");
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
    }
}
