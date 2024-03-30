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
    public partial class Staff_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Staff_VIEW()
        {
            InitializeComponent();
        }

        private void Staff_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadAccount();
            txtStaffID.Text = "Dành cho chức năng tìm kiếm";
        }

        #region Method
        void LoadData()
        {
            dgvStaff.Columns.Clear();

            List<Staff> listStaff = StaffController.Instance.GetListStaff();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("ID Acc");

            foreach (Staff staff in listStaff)
            {
                dt.Rows.Add(staff.ID, staff.Name, staff.Gender, staff.Birth, staff.Address, staff.Phone, staff.Acc_ID);
            }

            dgvStaff.DataSource = dt;
        }

        void LoadAccount()
        {
            cbbAcc.Items.Clear();
            List<Account> listAccount = AccountController.Instance.GetAccountsNoOwner();
            List<string> listUsername = new List<string>();
            
            foreach(Account acc in listAccount)
            {
                listUsername.Add(acc.User);
            }
            cbbAcc.DataSource = listUsername;
        }

        void Refresh()
        {
            LoadData();
            txtStaffID.Text = "Dành cho chức năng tìm kiếm";
            txtNameStaff.ResetText();
            txtPhone.ResetText();
            txtAddress.ResetText();
        }
        #endregion

        #region Event
        private void dgvStaff_Click(object sender, EventArgs e)
        {
            if(dgvStaff.Rows.Count > 0)
            {
                txtStaffID.Text = dgvStaff.SelectedRows[0].Cells[0].Value.ToString();
                txtNameStaff.Text = dgvStaff.SelectedRows[0].Cells[1].Value.ToString();
                cbbGender.SelectedItem = dgvStaff.SelectedRows[0].Cells[2].Value.ToString();
                dtBirth.Text = dgvStaff.SelectedRows[0].Cells[3].Value.ToString();
                txtAddress.Text = dgvStaff.SelectedRows[0].Cells[4].Value.ToString();
                txtPhone.Text = dgvStaff.SelectedRows[0].Cells[5].Value.ToString();
                cbbAcc.SelectedItem = dgvStaff.SelectedRows[0].Cells[6].Value.ToString();
            }           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ID = $"NV00{StaffController.Instance.GetOrderNumInList()}";
            Staff staff = new Staff()
            {
                ID = ID,
                Name = txtNameStaff.Text,
                Gender = cbbGender.SelectedItem.ToString(),
                Birth = dtBirth.Value,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Acc_ID = AccountController.Instance.GetIdAccountByUsername(cbbAcc.SelectedItem.ToString())
            };

            int rs = StaffController.Instance.InsertStaff(staff);
            if (rs == 1)
            {
                mf.NotifySuss($"Thêm nhân viên {txtNameStaff.Text} thành công !");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff()
            {
                ID = txtStaffID.Text,
                Name = txtNameStaff.Text,
                Gender = cbbGender.SelectedItem.ToString(),
                Birth = dtBirth.Value,
                Address = txtAddress.Text ,
                Phone = txtPhone.Text,
                Acc_ID = AccountController.Instance.GetIdAccountByUsername(cbbAcc.SelectedItem.ToString())
            };

            int rs = StaffController.Instance.UpdateStaff(staff);
            if (rs == 1)
            {
                mf.NotifySuss($"Cập nhật nhân viên {txtNameStaff.Text} thành công !");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xóa nhân viên");
            if(qs == DialogResult.OK)
            {
                int rs = StaffController.Instance.DeleteStaff(txtStaffID.Text);
                if(rs == 1)
                {
                    mf.NotifySuss($"Xóa nhân viên {txtNameStaff.Text} thành công !");
                    Refresh();
                }
                else
                {
                    mf.NotifySuss("Nhân viên không tồn tại !");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvStaff.Columns.Clear();
            List<Staff> listStaff = StaffController.Instance.SelectStaffByID(txtStaffID.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("ID Acc");

            foreach (Staff staff in listStaff)
            {
                dt.Rows.Add(staff.ID, staff.Name, staff.Gender, staff.Birth, staff.Address, staff.Phone, staff.Acc_ID);
            }

            dgvStaff.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            string name = StaffController.Instance.GetNameStaffByID(txtStaffID.Text);
            if(name != null)
            {
                txtNameStaff.Text = name;
            }
        }


        #endregion


    }
}
