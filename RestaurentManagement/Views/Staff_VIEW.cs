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
        }

        #region Method
        void LoadData()
        {
            List<Staff> listStaff = StaffController.Instance.GetListStaff();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("ID Acc");

            foreach (Staff staff in listStaff)
            {
                dt.Rows.Add(staff.ID, staff.Name, staff.Gender, staff.Birth.ToShortDateString(), staff.Phone, staff.Acc_ID);
            }
            dgvStaff.DataSource = dt;
        }

        void LoadAccount()
        {
            dgvStaff.Columns.Clear();
            List<string> listAccount = AccountController.Instance.GetAccountsNoOwner();
            DataTable dt = new DataTable();
            dt.Columns.Add("AccountName", typeof(string)); 

            foreach (string accName in listAccount)
            {
                dt.Rows.Add(accName);
            }

            cbbAcc.DataSource = dt;
            cbbAcc.DisplayMember = "AccountName"; 
        }

        void Refresh()
        {
            LoadData();
            txtStaffID.ResetText();
            txtNameStaff.ResetText();
            txtPhone.ResetText();
        }
        #endregion

        #region Event
        private void dgvStaff_Click(object sender, EventArgs e)
        {
            txtStaffID.Text = dgvStaff.SelectedRows[0].Cells[0].Value.ToString();
            txtNameStaff.Text = dgvStaff.SelectedRows[0].Cells[1].Value.ToString();
            cbbGender.SelectedItem = dgvStaff.SelectedRows[0].Cells[2].Value.ToString();
            dtBirth.Text = dgvStaff.SelectedRows[0].Cells[3].Value.ToString();
            txtPhone.Text = dgvStaff.SelectedRows[0].Cells[4].Value.ToString();
            cbbAcc.SelectedItem = dgvStaff.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff()
            {
                ID = txtStaffID.Text,
                Name = txtNameStaff.Text,
                Gender = cbbGender.SelectedItem.ToString(),
                Birth = dtBirth.Value ,
                Phone = txtPhone.Text ,
                Acc_ID = AccountController.Instance.GetIdAccountByUsername(cbbAcc.SelectedItem.ToString())
            };

            int rs = StaffController.Instance.InsertStaff(staff);
            if(rs == 1)
            {
                mf.NotifySuss("Thêm nhân viên thành công !");
                LoadData();
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
                Phone = txtPhone.Text,
                Acc_ID = AccountController.Instance.GetIdAccountByUsername(cbbAcc.SelectedItem.ToString())
            };

            int rs = StaffController.Instance.UpdateStaff(staff);
            if (rs == 1)
            {
                mf.NotifySuss("Cập nhật nhân viên thành công !");
                LoadData();
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
                    mf.NotifySuss("Xóa nhân viên thành công !");
                    LoadData();
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
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("ID Acc");

            foreach (Staff staff in listStaff)
            {
                dt.Rows.Add(staff.ID, staff.Name, staff.Gender, staff.Birth, staff.Phone, staff.Acc_ID);
            }

            dgvStaff.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        #endregion

        
    }
}
