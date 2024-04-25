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
    public partial class AddVoucher_VIEW : Form
    {
        MainForm mf = new MainForm();
        public AddVoucher_VIEW()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để thêm voucher {txtName.Text}");
            if(qs == DialogResult.OK)
            {
                string id = $"PGG00{VoucherController.Instance.GetOrderNumInList()}";
                string exprice = $"{txtExpiry.Value} {cbbOptionExpiry.SelectedItem}";
                Voucher voucher = new Voucher()
                {
                    ID = id,
                    Name = txtName.Text,
                    Expiry = exprice,
                    Status = cbbStatus.SelectedItem.ToString()
                };

                int rs = VoucherController.Instance.InsertVoucher(voucher);
                if (rs == 1)
                {
                    mf.NotifySuss("Thêm voucher thành công");
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

        private void AddVoucher_VIEW_Load(object sender, EventArgs e)
        {
            LoadOptionExpiry();
            LoadOptionStatus();
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
