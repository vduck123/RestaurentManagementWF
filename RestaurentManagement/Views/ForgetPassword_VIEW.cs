using RestaurentManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Account = RestaurentManagement.Models.Account;
using static System.Net.WebRequestMethods;
using RestaurentManagement.utils;
using RestaurentManagement.Services;

namespace RestaurentManagement.Views
{
    public partial class ForgetPassword_VIEW : Form
    {
        public ForgetPassword_VIEW()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbForgetPass_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login_VIEW view = new Login_VIEW();
            view.ShowDialog();
        }

        int _OTP = 0;
        private void btnGetOTP_Click(object sender, EventArgs e)
        {
            List<_Account> accounts = AccountController.Instance.GetListAccount();

            foreach (_Account acc in accounts)
            {
                if (acc.User.Contains(txtUser.Text))
                {

                    //MessageBox.Show("OTP đang gửi đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Thread.Sleep(3000);
                    //otp = new Random().Next(1000, 9999);
                    //MessageBox.Show($"OTP : {otp}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _OTP = EmailService.Instance.SendEmail(txtUser.Text);
                    return;
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(txtPass.Text.Length < 5)
            {
                MessageBox.Show($"Mật khẩu lớn hơn 5 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_OTP.ToString().Equals(txtOTP.Text))
            {
                string idAcc = AccountController.Instance.GetIdAccountByUsername(txtUser.Text);
                _Account a = new _Account(idAcc, txtUser.Text, txtPass.Text, "Quản trị viên");
                int rs = AccountController.Instance.UpdateAccount(a);
                if (rs > 0)
                {          
                    MessageBox.Show("Cập nhật mật khẩu mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login_VIEW view = new Login_VIEW();
                    view.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show($"OTP không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (!HandleData.Instance.CheckEmail(txtUser.Text))
            {
                ttNotify.Text = "Email không hợp lệ!";
            }
            if (txtUser.Text.Length == 0 || HandleData.Instance.CheckEmail(txtUser.Text))
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

        
    }
}
