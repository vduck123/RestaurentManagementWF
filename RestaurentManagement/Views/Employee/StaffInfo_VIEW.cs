using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
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
            if (string.IsNullOrEmpty(_ID))
            {
                DialogResult qs = mf.NotifyConfirm($"Ấn OK để xác nhận xóa nhân viên có mã: {id}");
                if (qs == DialogResult.OK)
                {
                    int rs = StaffController.Instance.DeleteStaff(id);
                    if (rs == 1)
                    {
                        SalaryController.Instance.DeleteSalaryBystaffId(id);
                        mf.NotifySuss("Xóa nhân viên thành công");
                    }
                }

            }
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
            DataTable dt = new DataTable();
            List<_Account> listAccount = AccountController.Instance.GetListAccount();
            List<Staff> listStaff = StaffController.Instance.GetListStaff();
            List<Salary> listSalary = SalaryController.Instance.GetListSalary();

            dt.Columns.Add("Mã nhân viên");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Chức vụ");
            dt.Columns.Add("Lương cơ bản");


            foreach (Staff staff in listStaff)
            {
                DataRow row = dt.NewRow();
                row["Mã nhân viên"] = staff.ID;
                row["Tên nhân viên"] = staff.Name;
                row["Giới tính"] = staff.Gender;
                row["Ngày sinh"] = staff.Birth.ToShortDateString();
                row["Địa chỉ"] = staff.Address;
                row["Số điện thoại"] = staff.Phone;


                foreach (_Account account in listAccount)
                {
                    if (account.ID == staff.Acc_ID)
                    {
                        row["Chức vụ"] = account.Role;
                        break;
                    }
                }

                foreach (Salary salary in listSalary)
                {
                    if (salary.staffID == staff.ID)
                    {
                        row["Lương cơ bản"] = salary.salaryBasic;
                        break;
                    }
                }

                dt.Rows.Add(row);
            }

            dgvStaff.DataSource = dt;
        }

        DataTable HandleSearch(string option, string keyword)
        {
            DataTable dt = new DataTable();
            dt = ((DataTable)dgvStaff.DataSource).Clone();
            foreach (DataRow row in ((DataTable)dgvStaff.DataSource).Rows)
            {
                switch (option)
                {
                    case "Tìm kiếm theo mã":
                        if (row["Mã nhân viên"].ToString().Trim().Equals(keyword))
                            dt.ImportRow(row);
                        break;
                    case "Tìm kiếm theo tên":
                        if (row["Tên nhân viên"].ToString().Contains(keyword))
                            dt.ImportRow(row);
                        break;
                    case "Tìm kiếm theo giới tính":
                        if (row["Giới tính"].ToString() == keyword)
                            dt.ImportRow(row);
                        break;
                    case "Tìm kiếm theo ngày sinh":
                        if (row["Ngày sinh"].ToString() == keyword)
                            dt.ImportRow(row);
                        break;
                    case "Tìm kiếm theo địa chỉ":
                        if (row["Địa chỉ"].ToString().Contains(keyword))
                            dt.ImportRow(row);
                        break;
                    case "Tìm kiếm theo chức vụ":
                        if (row["Chức vụ"].ToString().Contains(keyword))
                            dt.ImportRow(row);
                        break;
                    case "Tìm kiếm theo số điện thoại":
                        if (row["Số điện thoại"].ToString().Trim().Equals(keyword))
                            dt.ImportRow(row);
                        break;
                    default:
                        break;
                }
            }

            return dt;
        }


        void LoadOptionSearch()
        {
            List<string> options = new List<string>
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên" ,
                "Tìm kiếm theo giới tính" ,
                "Tìm kiếm theo ngày sinh" ,
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
