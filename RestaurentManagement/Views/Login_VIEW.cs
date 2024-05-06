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
namespace RestaurentManagement.Views
{
    public partial class Login_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Login_VIEW()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbbRole.SelectedItem == null || string.IsNullOrEmpty(cbbRole.SelectedItem.ToString()))
            {
                mf.NotifyErr("Vui lòng chọn quyền!");
                return;
            }

            string user = txtUser.Text;
            string pass = txtPass.Text;
            string role = cbbRole.SelectedItem.ToString();

            
            List<_Account> accounts = AccountController.Instance.GetListAccount();

            foreach (_Account acc in accounts)
            {
                
                if(acc.User.Contains(user) && acc.Password.Contains(pass) && role.Contains("Quản trị viên"))
                {
                    Admin_VIEW admin_VIEW = new Admin_VIEW(user);
                    admin_VIEW.ShowDialog();
                } 
                else if(acc.User.Contains(user) && acc.Password.Contains(pass) && role.Contains("Nhân viên"))
                {
                    Admin_VIEW admin_VIEW = new Admin_VIEW(user);
                    admin_VIEW.ShowDialog();
                    return;
                }
                else
                {
                    mf.NotifyErr("Thông tin tài khoản và mật khẩu không chính xác!");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbForgetPass_Click(object sender, EventArgs e)
        {
            ForgetPassword_VIEW forgetPassword_VIEW = new ForgetPassword_VIEW();
            forgetPassword_VIEW.ShowDialog();
        }


        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
