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

namespace RestaurentManagement.Views
{
    public partial class Account_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Account_VIEW()
        {
            InitializeComponent();
        }

        private void Account_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            txtAccID.Text = "Dành cho chức năng tìm kiếm";
        }

        #region Method
        void LoadData()
        {
            dgvAccount.Columns.Clear();
            List<Account> listAccount = AccountController.Instance.GetListAccount();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Role");

            foreach (Account acc in listAccount)
            {
                dt.Rows.Add(acc.ID, acc.User, acc.Password, acc.Role);
            }

            dgvAccount.DataSource = dt;
        }

        void Refresh()
        {
            LoadData();
            txtOwner.Text = "Nhân viên";
            txtAccID.Text = "Dành cho chức năng tìm kiếm";
            txtUser.ResetText();
            txtPass.ResetText();
            txtRole.ResetText();
        }
        #endregion


        #region Event
        private void dgvAccount_Click(object sender, EventArgs e)
        {
            txtAccID.Text = dgvAccount.SelectedRows[0].Cells[0].Value.ToString();
            txtUser.Text = dgvAccount.SelectedRows[0].Cells[1].Value.ToString();
            txtPass.Text = dgvAccount.SelectedRows[0].Cells[2].Value.ToString();
            txtRole.Text = dgvAccount.SelectedRows[0].Cells[3].Value.ToString();
            txtOwner.Text = StaffController.Instance.GetNameStaffByAccID(txtAccID.Text);

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"A000{AccountController.Instance.GetOrderNumInList()}";
            Account acc = new Account()
            {
                ID = id,
                User = txtUser.Text,
                Password = txtPass.Text,
                Role = txtRole.Text,
            };

            int rs = AccountController.Instance.InsertAccount(acc);

            if(rs == 1)
            {
                mf.NotifySuss($"Thêm tài khoản {txtUser.Text} thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Account acc = new Account()
            {
                ID = txtAccID.Text,
                User = txtUser.Text,
                Password = txtPass.Text,
                Role = txtRole.Text,
            };

            int rs = AccountController.Instance.UpdateAccount(acc);

            if (rs == 1)
            {
                mf.NotifySuss($"Cập nhật tài khoản {txtUser.Text} thành công");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa tài khoản");
            if(qs == DialogResult.OK)
            {
                int rs = AccountController.Instance.DeleteAccount(txtAccID.Text);
                if(rs == 1)
                {
                    mf.NotifySuss($"Xóa tài khoản {txtUser.Text} thành công");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvAccount.Columns.Clear();
            List<Account> listAccount = AccountController.Instance.SelectAccountByID(txtAccID.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Role");

            foreach (Account acc in listAccount)
            {
                dt.Rows.Add(acc.ID, acc.User, acc.Password, acc.Role);
            }
            dgvAccount.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void txtAccID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StaffController.Instance.GetNameStaffByAccID(txtAccID.Text)))
            {
                txtOwner.Text = "Nhân viên";
            }
            else
            {
                txtOwner.Text = StaffController.Instance.GetNameStaffByAccID(txtAccID.Text);
            }
        }

        #endregion


    }
}
