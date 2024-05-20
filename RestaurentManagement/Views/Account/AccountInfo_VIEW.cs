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
using _Staff = RestaurentManagement.Models.Staff;

namespace RestaurentManagement.Views.Account
{
    public partial class AccountInfo_VIEW : Form
    {
        string _ID;
        public AccountInfo_VIEW()
        {
            InitializeComponent();
        }

        private void AccountInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private DataGridViewRow rowSelected = null;

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               rowSelected = dgvAccount.Rows[e.RowIndex];
            }
            _ID = rowSelected.Cells[0].Value.ToString();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtParam.Text))
            {
                mf.NotifyErr("Giá trị tìm kiếm không hợp lệ");
                return;
            }

            if (_ID == null)
            {
                return;
            }
            dgvAccount.DataSource = handleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text);
        }

        private void sửaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }

            UpdateAccount_VIEW view = new UpdateAccount_VIEW(_ID);
            view.ShowDialog();
        }
        MainForm mf = new MainForm();
        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }

            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa tài khoản id = {_ID}");
            if (qs == DialogResult.OK)
            {
                string idStaff = StaffController.Instance.GetIDStaffByName(rowSelected.Cells[3].Value.ToString());
                if (idStaff != null)
                {
                    return;
                }

                SalaryController.Instance.DeleteSalaryBystaffId(idStaff);
                StaffController.Instance.DeleteStaff(idStaff);
                AccountController.Instance.DeleteAccount(_ID);
                mf.NotifySuss("Xóa tài khoản thành công");

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        void LoadData()
        {
            LoadAccount();
            LoadOption();
        }

        DataTable handleSearch(string option, string param)
        {
            dgvAccount.Columns.Clear();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã tài khoản");
            dt.Columns.Add("Tên đăng nhập");
            dt.Columns.Add("Mật khẩu");
            dt.Columns.Add("Vai trò");
            dt.Columns.Add("Tên nhân viên");
            List<_Staff> listStaff = StaffController.Instance.GetListStaff();
            List<_Account> listAcc = new List<_Account>();


            switch (option)
            {
                case "Tìm kiếm theo mã":
                    {
                        listAcc = AccountController.Instance.SelectAccountByParam("acc_id", param);
                        break;
                    }
                case "Tìm kiếm theo vai trò":
                    {
                        listAcc = AccountController.Instance.SelectAccountByParam("role", param);
                        break;
                    }
                case "Tìm kiếm theo tên nhân viên":
                    {
                        dt = ((DataTable)dgvAccount.DataSource).Clone();
                        foreach (DataRow row in ((DataTable)dgvAccount.DataSource).Rows)
                        {
                            if (row["Tên nhân viên"].ToString().Contains(param))
                            {
                                dt.ImportRow(row);
                            }
                        }
                        dgvAccount.DataSource = dt;
                        break;
                    }          
            }

            if(listAcc.Count > 0)
            {
                foreach (_Account acc in listAcc)
                {
                    DataRow row = dt.NewRow();
                    row["Mã tài khoản"] = acc.ID;
                    row["Tên đăng nhập"] = acc.User;
                    row["Mật khẩu"] = acc.Password;
                    row["Vai trò"] = acc.Role;
                    foreach (_Staff staff in listStaff)
                    {
                        if (staff.Acc_ID == acc.ID)
                        {
                            row["Tên nhân viên"] = staff.Name;
                        }
                    }
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        void LoadAccount()
        {
            dgvAccount.Columns.Clear();
            List<_Account> accList = AccountController.Instance.GetListAccount();
            List<_Staff> staffList = StaffController.Instance.GetListStaff();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã tài khoản");
            dt.Columns.Add("Tên đăng nhập");
            dt.Columns.Add("Mật khẩu");
            dt.Columns.Add("Vai trò");
            dt.Columns.Add("Tên nhân viên");

            foreach (_Account acc in accList)
            {
                DataRow row = dt.NewRow();
                row["Mã tài khoản"] = acc.ID;
                row["Tên đăng nhập"] = acc.User;
                row["Mật khẩu"] = acc.Password;
                row["Vai trò"] = acc.Role;
                foreach (_Staff staff in staffList)
                {
                    if (staff.Acc_ID == acc.ID)
                    {
                        row["Tên nhân viên"] = staff.Name;
                    }
                }
                dt.Rows.Add(row);
            }

            dgvAccount.DataSource = dt;
        }

        void LoadOption()
        {
            List<string> options = new List<string>
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên đăng nhập" ,
                "Tìm kiếm theo vai trò" 
            };

            cbbOption.DataSource = options;
        }

        void Refresh()
        {
            txtParam.ResetText();
            LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmData view = new frmData();
            view.Show();
        }
    }
}
