
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
using System.IO;
using RestaurentManagement.utils;


namespace RestaurentManagement.Views.Salaries
{
    public partial class SalaryInfo_VIEW : Form
    {
        string _ID = null;
        MainForm mf = new MainForm();
        public SalaryInfo_VIEW()
        {
            InitializeComponent();
        }

        private void SalaryInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string opera = cbbOpera.SelectedItem == null ? null : cbbOpera.SelectedItem.ToString();
            if (string.IsNullOrEmpty(txtParam.Text))
            {
                mf.NotifyErr("Giá trị tìm kiếm không hợp lệ");
                return;
            }
            
            dgvSalary.Columns.Clear();
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), opera, txtParam.Text);
            dgvSalary.DataSource = dt;
        }  

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSalary_VIEW view = new AddSalary_VIEW();
            view.ShowDialog();
        }

        private DataGridViewRow rowSelected = null;

        private void dgvSalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvSalary.Rows[e.RowIndex];
            }

            _ID = rowSelected.Cells[0].Value.ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Office.Instance.ExportExcel(dgvSalary, saveFileDialog.FileName);
                    mf.NotifySuss("Xuất file thành công");
                }
                catch (Exception exception)
                {
                    mf.NotifySuss($"Lỗi: {exception.Message}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            txtParam.ResetText();
        }

        DataTable HandleSearch(string option, string opera, string keyword)
        {
            List<Salary> listSalary = new List<Salary>();
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

            switch (option)
            {
                case "Tìm kiếm theo mã":
                    {
                        listSalary = SalaryController.Instance.SelectSalaryByParam("salary_id", "=", $"'{keyword}'");
                        break;
                    }
                case "Tìm kiếm theo tên nhân viên":
                    {
                        listSalary = SalaryController.Instance.SelectSalaryByParam("staff_id", "=", $"'{StaffController.Instance.GetIDStaffByName(keyword)}'");
                        break;
                    }
                case "Tìm kiếm theo tháng":
                    {
                        listSalary = SalaryController.Instance.SelectSalaryByParam("MONTH(salary_month)", "=", keyword);
                        break;
                    }
                case "Tìm kiếm theo lương cơ bản":
                    {
                        listSalary = SalaryController.Instance.SelectSalaryByParam("salary_basic", opera , keyword);
                        break;
                    }
                case "Tìm kiếm theo tổng lương":
                    {
                        listSalary = SalaryController.Instance.SelectSalaryByParam("total", opera , keyword);
                        break;
                    }
                case "Tìm kiếm theo mốc thời gian":
                    {
                        listSalary = SalaryController.Instance.SelectSalaryByParam("salary_month", "BETWEEN", $"'{dtPrev.Value}' AND '{dtNext.Value}'");
                        break;
                    }
            }

            foreach (Salary s in listSalary)
            {
                dt.Rows.Add(s.ID, s.Month.ToString("dd/MM/yyy"), StaffController.Instance.GetNameStaffByID(s.staffID), s.salaryBasic, s.hsl, s.salaryHour, s.numHour, s.Bonus, s.Fine, s.Total);
            }

            return dt;
        }

        void LoadData()
        {
            LoadSalary();
            LoadOption();
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
                dt.Rows.Add(s.ID, s.Month.ToString("dd/MM/yyy"), StaffController.Instance.GetNameStaffByID(s.staffID), s.salaryBasic, s.hsl, s.salaryHour, s.numHour, s.Bonus, s.Fine, s.Total);
            }

            dgvSalary.DataSource = dt;
        }

        void LoadOption()
        {
            List<string> options = new List<string>
            {
                "Tìm kiếm theo mã" ,
                "Tìm kiếm theo tên nhân viên" ,
                "Tìm kiếm theo tháng" ,
                "Tìm kiếm theo mốc thời gian" ,
                "Tìm kiếm theo lương cơ bản" ,
                "Tìm kiếm theo tổng lương" 
            };

            cbbOption.DataSource = options; 
        }


        private void EditSalary_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }
            EditSalary_VIEW view = new EditSalary_VIEW(_ID);
            view.ShowDialog();
        }

        private void DelSalary_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }

            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận xóa bảng lương id = {_ID}");
            if (qs == DialogResult.OK)
            {
                int rs = SalaryController.Instance.DeleteSalary(_ID);
                if (rs == 1)
                {
                    mf.NotifySuss("Xóa bảng lương thành công");
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbOption.SelectedItem.ToString().Contains("lương"))
            {
                cbbOpera.Visible = true;
                dtNext.Visible = false;
                dtPrev.Visible = false;
                lbDt.Visible = false;
            }
            else if(cbbOption.SelectedItem.ToString().Contains("mốc thời gian"))
            {
                dtNext.Visible = true;
                dtPrev.Visible = true;
                lbDt.Visible = true;
                cbbOpera.Visible = false;
            }
            else
            {
                cbbOpera.Visible = false;
                dtNext.Visible = false;
                dtPrev.Visible = false;
                lbDt.Visible = false;
            }
        }

        private void cbbOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
