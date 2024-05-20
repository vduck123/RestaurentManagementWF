using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views.Employee
{
    public partial class UpdateStaff_VIEW : Form
    {
        string _ID = null;
        MainForm mf = new MainForm();
        public UpdateStaff_VIEW(string iD)
        {
            InitializeComponent();
            _ID = iD;
        }

        private void UpdateStaff_VIEW_Load(object sender, EventArgs e)
        {
            GetData();
        }

        void GetData()
        {
            List<Staff> listStaff = StaffController.Instance.SelectStaffByID(_ID);
            foreach (Staff s in listStaff)
            {
                txtNameStaff.Text = s.Name;
                cbbGender.SelectedItem = s.Gender;
                dtBirth.Value = s.Birth;
                txtAddress.Text = s.Address;
                txtPhone.Text = s.Phone;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNameStaff.Text) ||
                txtNameStaff.Text.Length < 5 ||
                HandleData.Instance.ExitNumber(txtNameStaff.Text))
            {
                mf.NotifyErr("Tên nhân viên không hợp lệ");
                return;
            }
            Staff staff = new Staff()
            {
                ID = _ID,
                Name = txtNameStaff.Text,   
                Gender = cbbGender.SelectedItem.ToString(),
                Birth = dtBirth.Value ,
                Address = txtAddress.Text ,
                Phone = txtPhone.Text 
            };
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xấc nhận thông tin");
            if(qs == DialogResult.OK)
            {
                int rs = StaffController.Instance.UpdateStaff(staff);
                if(rs == 1)
                {
                    mf.NotifySuss($"Cập nhật thông tin nhân viên {txtNameStaff.Text} thành công !");
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
