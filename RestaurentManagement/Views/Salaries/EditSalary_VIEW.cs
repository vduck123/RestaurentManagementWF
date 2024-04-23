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

namespace RestaurentManagement.Views.Salaries
{
    public partial class EditSalary_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public EditSalary_VIEW(string id)
        {
            InitializeComponent();
            _ID = id;   
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận thay đổi thông tin bảng lương id = {_ID}");
            if(qs == DialogResult.OK)
            {
                Salary s = new Salary()
                {
                    ID = _ID,
                    Month = dtMonth.Value,
                    salaryBasic = Convert.ToInt32(txtSalaryBasic.Value),
                    hsl = Convert.ToDouble(txtHsl.Value),
                    salaryHour = Convert.ToInt32(txtSalaryHour.Value),
                    numHour = Convert.ToInt32(txtNum.Value),
                    Fine = Convert.ToInt32(txtFine.Value),
                    Bonus = Convert.ToInt32(txtBonus.Value),
                    Total = Convert.ToDouble(txtTotal.Text),
                    staffID = StaffController.Instance.GetIDStaffByName(txtStaff.Text)
                };

                int rs = SalaryController.Instance.UpdateSalary(s);
                if (rs == 1)
                {
                    mf.NotifySuss($"Cập nhật bảng lương thành công");
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditSalary_VIEW_Load(object sender, EventArgs e)
        {
            GetData();
        }

        void GetData()
        {
            if (_ID == null)
            {
                return;
            }
            
            List<Salary> listSalary = SalaryController.Instance.SelectSalaryByParam("salary_id", _ID);
            foreach(Salary salary in listSalary)
            {
                dtMonth.Value = Convert.ToDateTime(salary.Month);
                txtSalaryBasic.Value = Convert.ToInt32(salary.salaryBasic);
                txtHsl.Value = Convert.ToDecimal(salary.hsl);
                txtSalaryHour.Value = Convert.ToInt32(salary.salaryHour);
                txtNum.Value = Convert.ToDecimal(salary.numHour);
                txtFine.Value = Convert.ToInt32(salary.Fine);
                txtBonus.Value = Convert.ToInt32(salary.Bonus);
                txtTotal.Text = salary.Total.ToString();
                txtStaff.Text = StaffController.Instance.GetNameStaffByID(salary.staffID);
            }
        }

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

        void UpdateTotalSalary()
        {
            int salarybasic = Convert.ToInt32(txtSalaryBasic.Text);
            double hsl = Convert.ToDouble(txtHsl.Value);
            int salaryhour = Convert.ToInt32(txtSalaryHour.Value);
            int numHour = Convert.ToInt32(txtNum.Value);
            int fine = Convert.ToInt32(txtFine.Value);
            int bonus = Convert.ToInt32(txtBonus.Value);
            double total = (salarybasic * hsl) + (salaryhour * numHour) + bonus + fine;
            txtTotal.Text = total.ToString();
        }
    }
}
