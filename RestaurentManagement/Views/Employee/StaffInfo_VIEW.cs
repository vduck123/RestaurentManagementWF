using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.Views.Salaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Account = RestaurentManagement.Models.Account;

namespace RestaurentManagement.Views.Employee
{
    public partial class StaffInfo_VIEW : Form
    {
        MainForm mf = new MainForm();
        public StaffInfo_VIEW()
        {
            InitializeComponent();
        }

        #region event

        private void StaffInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private DataGridViewRow selectedRow = null;
        string _ID = null;
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgvStaff.Rows[e.RowIndex];
            }
            _ID = selectedRow.Cells[0].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStaff_VIEW view = new AddStaff_VIEW();
            view.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }

            UpdateStaff_VIEW view = new UpdateStaff_VIEW(_ID);
            view.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = selectedRow.Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(_ID))
            {
                DialogResult qs = mf.NotifyConfirm($"Ấn OK để xác nhận xóa nhân viên có mã: {id}");
                if (qs == DialogResult.OK)
                {

                    int rs =  SalaryController.Instance.DeleteSalaryBystaffId(id);
                    if (rs == 1)
                    {
                        StaffController.Instance.DeleteStaff(id);
                        mf.NotifySuss("Xóa nhân viên thành công");
                    }
                }

            }
        }

        private void btnShowSalary_Click(object sender, EventArgs e)
        {
            SalaryInfo_VIEW view = new SalaryInfo_VIEW();
            view.ShowDialog();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }


        private void btnInfoSalary_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckSaleBill_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckBillImport_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Method
        void LoadData()
        {
            LoadListStaff();
            LoadOptionSearch();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParam.Text))
            {
                mf.NotifyErr("Giá trị tìm kiếm không hợp lệ");
                return;
            }
            dgvStaff.Columns.Clear();
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text);
            if (dt.Rows.Count > 0)
            {
                dgvStaff.DataSource = dt;
            }
        }

        void LoadListStaff()
        {
            dgvStaff.Columns.Clear();
            DataTable dt = StaffController.Instance.GetAllInfoStaff();

            DataTable dtDisplay = new DataTable();
            dtDisplay.Columns.Add("Mã nhân viên");
            dtDisplay.Columns.Add("Tên nhân viên");
            dtDisplay.Columns.Add("Giới tính");
            dtDisplay.Columns.Add("Ngày sinh");
            dtDisplay.Columns.Add("Địa chỉ");
            dtDisplay.Columns.Add("Số điện thoại");
            dtDisplay.Columns.Add("Chức vụ");
            dtDisplay.Columns.Add("Lương cơ bản");
            foreach (DataRow row in dt.Rows)
            {
                dtDisplay.Rows.Add(row["staff_id"], row["staff_name"], row["gender"], Convert.ToDateTime(row["birth"]).ToShortDateString(), row["address"], row["phone"], row["role"], row["salary_basic"]);
            }

            dgvStaff.DataSource = dtDisplay;
        }



        DataTable HandleSearch(string option, string keyword)
        {
            DataTable dt = new DataTable();
            DataTable dtDisplay = new DataTable();
            dtDisplay.Columns.Add("Mã nhân viên");
            dtDisplay.Columns.Add("Tên nhân viên");
            dtDisplay.Columns.Add("Giới tính");
            dtDisplay.Columns.Add("Ngày sinh");
            dtDisplay.Columns.Add("Địa chỉ");
            dtDisplay.Columns.Add("Số điện thoại");
            dtDisplay.Columns.Add("Chức vụ");
            dtDisplay.Columns.Add("Lương cơ bản");

            switch(option)
            {
                case"Tìm kiếm theo mã": 
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.staff_id", txtParam.Text, "=");
                        break;
                    }
                case "Tìm kiếm theo tên":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.staff_name", $"%{txtParam.Text}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo giới tính":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.gender", txtParam.Text, "=");
                        break;
                    }
                case "Tìm kiếm theo địa chỉ":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.address", $"%{txtParam.Text}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo số điện thoại":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.phone", $"%{txtParam.Text}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo chức vụ":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("acc.role", $"%{txtParam.Text}%", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo năm sinh":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("YEAR(sf.birth)", $"{txtParam.Text}", "=");
                        break;
                    }
            }

            foreach (DataRow row in dt.Rows)
            {
                dtDisplay.Rows.Add(row["staff_id"], row["staff_name"], row["gender"], Convert.ToDateTime(row["birth"]).ToShortDateString(), row["address"], row["phone"], row["role"], row["salary_basic"]);
            }
            return dtDisplay;
        }


        void LoadOptionSearch()
        {
            List<string> options = new List<string>
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên" ,
                "Tìm kiếm theo giới tính" ,
                "Tìm kiếm theo năm sinh" ,
                "Tìm kiếm theo địa chỉ" ,
                "Tìm kiếm theo số điện thoại" ,
                "Tìm kiếm theo chức vụ"
            };

            cbbOption.DataSource = options;
        }

        void Refresh()
        {
            txtParam.ResetText();
            LoadData();
        }
        #endregion

        
    }
}
