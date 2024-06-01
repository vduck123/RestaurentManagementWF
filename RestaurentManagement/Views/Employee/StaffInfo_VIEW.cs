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
            DataTable dt = StaffController.Instance.GetAllBillSaleByStaffId(_ID);

            dt.Columns[0].ColumnName = "Mã hóa đơn";
            dt.Columns[1].ColumnName = "Ngày tạo";
            dt.Columns[2].ColumnName = "Tổng tiền";
            dt.Columns[3].ColumnName = "Tên nhân viên";

            if (dt.Rows.Count > 0)
            {
                ReportBillByStaff view = new ReportBillByStaff(dt);
                view.ShowDialog();
            }
            else
            {
                mf.NotifySuss("Nhân viên này chưa có hóa đơn bán");
            }
        }

        private void btnCheckBillImport_Click(object sender, EventArgs e)
        {
            DataTable dt = StaffController.Instance.GetAllBillImportByStaffId(_ID);
            dt.Columns[0].ColumnName = "Mã hóa đơn";
            dt.Columns[1].ColumnName = "Ngày tạo";
            dt.Columns[2].ColumnName = "Tổng tiền";
            dt.Columns[3].ColumnName = "Tên nhân viên";
            dt.Columns[4].ColumnName = "Tên nhà cung cấp";


            if(dt.Rows.Count > 0)
            {
                ReportBillByStaff view = new ReportBillByStaff(dt);
                view.ShowDialog();
            }
            else
            {
                mf.NotifySuss("Nhân viên này chưa có hóa đơn nhập");
            }
        }
        #endregion

        #region Method
        void LoadData()
        {
            LoadListStaff();
            LoadOptionSearch();
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
                dtDisplay.Rows.Add(row["staff_id"], row["staff_name"], row["gender"], Convert.ToDateTime(row["birth"]).ToString("dd/MM/yyyy"), row["address"], row["phone"], row["role"], row["salary_basic"]);
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
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.staff_id", "=", $"'{keyword}'");
                        break;
                    }
                case "Tìm kiếm theo tên":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.staff_name", "LIKE", $"N'%{keyword}%'");
                        break;
                    }
                case "Tìm kiếm theo giới tính":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.gender", "=", $"'{keyword}'");
                        break;
                    }
                case "Tìm kiếm theo địa chỉ":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.address", "LIKE", $"N'%{keyword}%'");
                        break;
                    }
                case "Tìm kiếm theo số điện thoại":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.phone", "LIKE", $"'%{keyword}%'");
                        break;
                    }
                case "Tìm kiếm theo chức vụ":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("acc.role", "LIKE", $"N'%{keyword}%'");
                        break;
                    }
                case "Tìm kiếm theo năm sinh":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("YEAR(sf.birth)", "=", $"'{keyword}'");
                        break;
                    }
                case "Tìm kiếm theo mốc thời gian":
                    {
                        dt = StaffController.Instance.GetAllInfoStaffByParam("sf.birth", "BETWEEN", $"'{dtPrev.Value}' AND '{dtNext.Value}'");
                        break;
                    }
            }

            foreach (DataRow row in dt.Rows)
            {
                dtDisplay.Rows.Add(row["staff_id"], row["staff_name"], row["gender"], Convert.ToDateTime(row["birth"]).ToString("dd/MM/yyyy"), row["address"], row["phone"], row["role"], row["salary_basic"]);
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
                "Tìm kiếm theo mốc thời gian" ,
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

        private void cbbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbOption.SelectedItem.ToString().Contains("mốc thời gian"))
            {
                dtNext.Visible = true;
                dtPrev.Visible = true;
                lbDt.Visible = true;
            }
            else
            {
                dtNext.Visible = false;
                dtPrev.Visible = false;
                lbDt.Visible = false;
            }
        }
    }
}
