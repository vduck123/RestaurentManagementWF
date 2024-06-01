using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
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
namespace RestaurentManagement.Views
{
    public partial class Login_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Login_VIEW()
        {
            InitializeComponent();
        }
        private void Login_VIEW_Load(object sender, EventArgs e)
        {
            LoadRole();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbbRole.SelectedItem == null || string.IsNullOrEmpty(cbbRole.SelectedItem.ToString()))
            {
                mf.NotifyErr("Vui lòng chọn quyền!");
                return;
            }

            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                mf.NotifyErr("Vui lòng không được để trống các trường!");
                return;
            }



            string user = txtUser.Text;
            string pass = txtPass.Text;
            string role = cbbRole.SelectedItem.ToString();
            bool find = false;
            
            List<_Account> accounts = AccountController.Instance.GetListAccount();

            foreach (_Account acc in accounts)
            {

                if(acc.User.Trim().Equals(user) && acc.Password.Trim().Equals(pass))
                {
                    if(role.Equals("Quản lý") && acc.Role.Equals(role))
                    {
                        find = true;
                        this.Hide();
                        Admin_VIEW admin_VIEW = new Admin_VIEW(user);
                        admin_VIEW.ShowDialog();
                    }
                    else if(acc.Role.Equals(role))
                    {
                        find = true;
                        this.Hide();
                        FrmStaff_VIEW view = new FrmStaff_VIEW(user);
                        view.ShowDialog();
                    }
                    
                }
            }

            if(!find)
            {
                mf.NotifyErr("Tài khoản hoặc mật khẩu không đúng!");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbForgetPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgetPassword_VIEW forgetPassword_VIEW = new ForgetPassword_VIEW();
            forgetPassword_VIEW.ShowDialog();
        }


        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (!HandleData.Instance.CheckEmail(txtUser.Text))
            {
                ttNotify.Text = "Email không hợp lệ!";
            }
            if(txtUser.Text.Length == 0 || HandleData.Instance.CheckEmail(txtUser.Text))
            {
                ttNotify.Text = "Hello";
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text.Length < 6)
            {
                ttNotify.Text = "Mật khẩu phải lớn hơn 6 ký tự!";
            }

            if (txtPass.Text.Length == 0 || txtPass.Text.Length >= 6)
            {
                ttNotify.Text = "Hello";
            }
        }


        void LoadRole()
        {
            List<string> listRole = new List<string>();
            List<_Account> accounts = AccountController.Instance.GetListAccount();
            foreach (_Account acc in accounts)
            {
                if (!listRole.Contains(acc.Role))
                {
                    listRole.Add(acc.Role);
                }
            }
            cbbRole.DataSource = listRole;
        }

    }
}
