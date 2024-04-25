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

namespace RestaurentManagement.Views.Vouchers
{
    public partial class EditVoucher_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public EditVoucher_VIEW(string iD)
        {
            InitializeComponent();
            _ID = iD;
        }

        private void EditVoucher_VIEW_Load(object sender, EventArgs e)
        {
            GetData();
            LoadOptionExpiry();
            LoadOptionStatus();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để cập nhật voucher {txtName.Text}");
            if(qs == DialogResult.OK)
            {
                string exprice = $"{txtExpiry.Value} {cbbOptionExpiry.SelectedItem}";
                Voucher voucher = new Voucher()
                {
                    ID = _ID,
                    Name = txtName.Text,
                    Expiry = exprice,
                    Status = cbbStatus.SelectedItem.ToString()
                };

                int rs = VoucherController.Instance.UpdateVoucher(voucher);
                if (rs == 1)
                {
                    mf.NotifySuss("Cập nhật voucher thành công");
                    this.Close();
                }
            }         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void GetData()
        {
            List<Voucher> listVoucher = VoucherController.Instance.SelectVoucherByID(_ID);
            foreach (Voucher voucher in listVoucher)
            {
                txtName.Text = voucher.Name;
                string expiry = voucher.Expiry;
                txtExpiry.Text = expiry.Split(' ')[0];
                cbbOptionExpiry.SelectedItem = expiry.Split(' ')[1];
                cbbStatus.SelectedItem = voucher.Status;
            }
        }
        void LoadOptionExpiry()
        {
            List<string> options = new List<string>
            {
                "%" ,
                "Vnđ"
            };
            cbbOptionExpiry.DataSource = options;
        }

        void LoadOptionStatus()
        {
            List<string> options = new List<string>
            {
                "Bật" ,
                "Tắt"
            };

            cbbStatus.DataSource = options;
        }
    }
}
