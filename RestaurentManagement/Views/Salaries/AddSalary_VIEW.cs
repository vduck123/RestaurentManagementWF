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
    public partial class AddSalary_VIEW : Form
    {
        MainForm mf = new MainForm();
        public AddSalary_VIEW()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận thêm bảng lương");
            if(qs == DialogResult.OK)
            {
                string id = $"BL00{SalaryController.Instance.GetOrderNumInList()}";
                Salary s = new Salary()
                {
                    ID = id,
                    Month = dtMonth.Value,
                    salaryBasic = Convert.ToInt32(txtSalaryBasic.Value),
                    hsl = Convert.ToDouble(txtHsl.Value),
                    salaryHour = Convert.ToInt32(txtSalaryHour.Value),
                    numHour = Convert.ToDouble(txtNum.Value),
                    Fine = Convert.ToInt32(txtFine.Value),
                    Bonus = Convert.ToInt32(txtBonus.Value),
                    Total = Convert.ToDouble(txtTotal.Text),
                    staffID = StaffController.Instance.GetIDStaffByName(cbbStaff.SelectedItem.ToString())
                };

                int rs = SalaryController.Instance.InsertSalary(s);
                if (rs == 1)
                {
                    mf.NotifySuss($"Thêm bảng lương nhân viên {cbbStaff.SelectedItem.ToString()} thành công");
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSalary_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void txtFindStaff_TextChanged(object sender, EventArgs e)
        {
            if (txtFindStaff.Text.Length == 0)
            {
                LoadStaff();
                return;
            }

            listnameStaff = new List<string>();
            List<Staff> listStaff = StaffController.Instance.GetListStaff();
            foreach (Staff staff in listStaff)
            {
                if (staff.Name.Contains(txtFindStaff.Text))
                {
                    listnameStaff.Add(staff.Name);
                }
            }
            cbbStaff.DataSource = listnameStaff;
        }

        void LoadData()
        {
            LoadStaff();
        }

        List<string> listnameStaff = null;

        void LoadStaff()
        {
            listnameStaff = new List<string>();
            List<Staff> listStaff = StaffController.Instance.GetListStaff();
            foreach (Staff staff in listStaff)
            {
                listnameStaff.Add(staff.Name);
            }

            cbbStaff.DataSource = listnameStaff;
        }

        
    }
}
