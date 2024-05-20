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
using _Account = RestaurentManagement.Models.Account;

namespace RestaurentManagement.Views.Account
{
    public partial class UpdateAccount_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID;
        public UpdateAccount_VIEW(string id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void UpdateAccount_VIEW_Load(object sender, EventArgs e)
        {
            GetData();
            LoadRole();
        }

        void GetData()
        {
            string name = StaffController.Instance.GetNameStaffByAccID(_ID);
            List<_Account> accounts = AccountController.Instance.SelectAccountByID(_ID);
            txtOwner.Text = name;
            foreach (_Account acc in accounts)
            {
                txtUser.Text = acc.User;
                txtPass.Text = acc.Password;
                txtRole.Text = acc.Role;
            }

        }

        void LoadRole()
        {
            List<string> roles = new List<string>()
            {
                "Quản lý" , 
                "Nhân viên" ,
                "Khác"
            };
            cbbRole.DataSource = roles;
        }

       
        private void cbbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbRole.SelectedItem.ToString().Equals("Khác"))
            {
                txtRole.Visible = true;
            }  
            else
            {
                txtRole.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUser.Text) ||
                txtUser.Text.Length < 5 ||
                txtPass.Text.Length < 5 ||
                string.IsNullOrEmpty(txtPass.Text))
                    
            {
                mf.NotifyErr("Giá trị nhập khác rỗng và lớn hơn 5 kí tự");
                return;
            }
            DialogResult qs = mf.NotifyConfirm("Ấn OK xác nhận thay đổi thông tin");
            if(qs == DialogResult.OK)
            {
                _Account acc = new _Account()
                {
                    ID = _ID,
                    User = txtUser.Text,
                    Password = txtPass.Text,    
                    Role = cbbRole.SelectedItem.ToString().Equals("Khác") ? txtRole.Text : cbbRole.SelectedItem.ToString(),
                };
                int rs = AccountController.Instance.UpdateAccount(acc);
                if(rs == 1)
                {
                    mf.NotifySuss($"Cập nhật tài khoản {txtUser.Text} thành công");
                    this.Close();
                }
            }
            
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
