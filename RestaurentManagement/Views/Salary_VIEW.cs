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
    public partial class Salary_VIEW : Form
    {
        MainForm mf = new MainForm();
        public Salary_VIEW()
        {
            InitializeComponent();
        }

        #region Event
        private void Salary_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            txtTotal.Enabled = false;
        }
        private void dgvSalary_Click(object sender, EventArgs e)
        {
            if (dgvSalary.Rows.Count > 0)
            {
                txtID.Text = dgvSalary.SelectedRows[0].Cells[0].Value.ToString();
                cbbStaff.SelectedItem = dgvSalary.SelectedRows[0].Cells[2].Value.ToString();
                txtSalaryBasic.Value = Convert.ToInt32(dgvSalary.SelectedRows[0].Cells[3].Value);
                txtHsl.Value = Convert.ToDecimal(dgvSalary.SelectedRows[0].Cells[4].Value);
                txtSalaryHour.Value = Convert.ToInt32(dgvSalary.SelectedRows[0].Cells[5].Value);
                txtNum.Value = Convert.ToInt32(dgvSalary.SelectedRows[0].Cells[6].Value);
                txtBonus.Value = Convert.ToInt32(dgvSalary.SelectedRows[0].Cells[7].Value);
                txtFine.Value = Convert.ToInt32(dgvSalary.SelectedRows[0].Cells[8].Value);
                txtTotal.Text = dgvSalary.SelectedRows[0].Cells[9].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = $"BL00{SalaryController.Instance.GetOrderNumInList()}";
            Salary s = new Salary()
            {
                ID = id ,
                Month = dtMonth.Value.Month ,
                salaryBasic = Convert.ToInt32(txtSalaryBasic.Value) ,
                hsl = Convert.ToDouble(txtHsl.Value),   
                salaryHour = Convert.ToInt32(txtSalaryHour.Value),
                numHour = Convert.ToInt32(txtNum.Value),
                Fine = Convert.ToInt32(txtFine.Value) ,
                Bonus = Convert.ToInt32(txtBonus.Value),
                Total = Convert.ToDouble(txtTotal.Text) ,
                staffID = StaffController.Instance.GetIDStaffByName(cbbStaff.SelectedItem.ToString())
            };

            int rs = SalaryController.Instance.InsertSalary(s);
            if(rs == 1)
            {
                mf.NotifySuss($"Thêm bảng lương nhân viên {cbbStaff.SelectedItem.ToString()} thành công");
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Salary s = new Salary()
            {
                ID = txtID.Text,
                Month = dtMonth.Value.Month,
                salaryBasic = Convert.ToInt32(txtSalaryBasic.Value),
                hsl = Convert.ToDouble(txtHsl.Value),
                salaryHour = Convert.ToInt32(txtSalaryHour.Value),
                numHour = Convert.ToInt32(txtNum.Value),
                Fine = Convert.ToInt32(txtFine.Value),
                Bonus = Convert.ToInt32(txtBonus.Value),
                Total = Convert.ToDouble(txtTotal.Text),
                staffID = StaffController.Instance.GetIDStaffByName(cbbStaff.SelectedItem.ToString())
            };

            int rs = SalaryController.Instance.UpdateSalary(s);
            if (rs == 1)
            {
                mf.NotifySuss($"Cập nhật bảng lương nhân viên {cbbStaff.SelectedItem.ToString()} thành công");
                Refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Ấn OK nhận xóa bảng lương id: {txtID.Text}");
            if(qs == DialogResult.OK)
            {
                int rs = SalaryController.Instance.DeleteSalary(txtID.Text);
                if (rs == 1)
                {
                    mf.NotifySuss($"Xóa bảng lương thành công");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSalary.Columns.Clear();
            List<Salary> listSalary = SalaryController.Instance.SelectSalaryByID(txtID.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tháng");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Lương cơ bản");
            dt.Columns.Add("Hsl");
            dt.Columns.Add("Lương giờ");
            dt.Columns.Add("số công");
            dt.Columns.Add("Tiền thưởng");
            dt.Columns.Add("Tiền phạt");
            dt.Columns.Add("Tổng lương");

            foreach (Salary s in listSalary)
            {
                dt.Rows.Add(s.ID, s.Month, StaffController.Instance.GetNameStaffByID(s.staffID), s.salaryBasic, s.hsl, s.salaryHour, s.numHour, s.Bonus, s.Fine, s.Total);
            }

            dgvSalary.DataSource = dt;
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Ấn OK nhận xóa tất cả bảng lương");
            if (qs == DialogResult.OK)
            {
                int rs = SalaryController.Instance.DeleteAll();
                if (rs == 1)
                {
                    mf.NotifySuss($"Xóa thành công");
                    Refresh();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string name = StaffController.Instance.GetNameStaffByID(txtID.Text);
            if(name != null)
            {
                cbbStaff.SelectedItem = name;
            }
        }

        #endregion

        #region Method
        void LoadData()
        {
            LoadStaff();
            LoadSalary();
        }
        void LoadStaff()
        {
            List<string> listnameStaff = new List<string>();
            List<Staff> listStaff = StaffController.Instance.GetListStaff();
            foreach (Staff staff in listStaff)
            {
                listnameStaff.Add(staff.Name);  
            }

            cbbStaff.DataSource = listnameStaff;
        }
       
        void LoadSalary()
        {
            dgvSalary.Columns.Clear();
            List<Salary> listSalary = SalaryController.Instance.GetListSalary();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tháng");
            dt.Columns.Add("Nhân viên");
            dt.Columns.Add("Lương cơ bản");
            dt.Columns.Add("Hsl");
            dt.Columns.Add("Lương giờ");
            dt.Columns.Add("Số công");
            dt.Columns.Add("Tiền thưởng");
            dt.Columns.Add("Tiền phạt");
            dt.Columns.Add("Tổng lương");

            foreach (Salary s in listSalary)
            {
                dt.Rows.Add(s.ID, s.Month, StaffController.Instance.GetNameStaffByID(s.staffID), s.salaryBasic, s.hsl, s.salaryHour, s.numHour, s.Bonus, s.Fine, s.Total);
            }

            dgvSalary.DataSource = dt;
        }

        void UpdateTotalSalary()
        {
            int s_basic = Convert.ToInt32(txtSalaryBasic.Value);
            double hsl = Convert.ToDouble(txtHsl.Value);
            int s_hour = Convert.ToInt32(txtSalaryHour.Value);
            int num = Convert.ToInt32(txtNum.Value);
            int fine = Convert.ToInt32(txtFine.Value);
            int bonus = Convert.ToInt32(txtBonus.Value);
            if (s_basic == null || hsl == null || s_basic == null || num == null || fine == num || bonus == null)
            {
                return;
            }
            else
            {
                txtTotal.Text = ((s_basic * hsl) + (s_hour * num) + bonus - fine).ToString();
            }
        }

        private void Refresh()
        {
            LoadData();
            txtID.Text = "Chức năng dành cho tìm kiếm";
            txtSalaryBasic.Value = 0;
            txtHsl.Value = 0;
            txtSalaryHour.Value = 0;
            txtNum.Value = 0;
            txtFine.Value = 0;
            txtBonus.Value = 0;
            txtTotal.Text = "0";
        }



        #endregion


        private void txtSalaryBasic_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSalary();
        }

        private void txtHsl_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSalary();
        }

        private void txtSalaryHour_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSalary();
        }

        private void txtNum_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSalary();
        }

        private void txtBonus_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSalary();
        }

        private void txtFine_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSalary();
        }
    }
}
