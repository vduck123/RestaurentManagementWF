using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Account = RestaurentManagement.Models.Account;
namespace RestaurentManagement.Views.Employee
{
    public partial class AddStaff_VIEW : Form
    {
        MainForm mf = new MainForm();
        public AddStaff_VIEW()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNameStaff.Text) || 
                HandleData.Instance.ExitNumber(txtNameStaff.Text) ||
                txtNameStaff.Text.Length < 6
                )
            {
                mf.NotifyErr("Tên nhân viên không hợp lê!");
                return;
            }

            if(!HandleData.Instance.CheckEmail(txtUsername.Text))
            {
                mf.NotifyErr("Tài khoản nhân viên là một email!");
                return;
            }

            if(string.IsNullOrEmpty(txtUsername.Text) || txtUsername.Text.Length < 5 ||
                string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 5) 
            {
                mf.NotifyErr("Tài khoản và mật khẩu phải dài hơn 5 kí tự!");
                return;
            }

            string idAcc = $"ACC00{AccountController.Instance.GetOrderNumInList() + 1}";
            _Account acc = new _Account()
            {
                ID = idAcc,
                User = txtUsername.Text,
                Password = txtPassword.Text,
                Role = "Nhân viên"
            };
            int rs = AccountController.Instance.InsertAccount(acc);

            if(rs == 1)
            {
                string idStaff = $"NV000{StaffController.Instance.GetOrderNumInList()}";
                Staff staff = new Staff()
                {
                    ID = idStaff,
                    Name = txtNameStaff.Text,
                    Gender = cbbGender.SelectedItem.ToString(),
                    Birth = dtBirth.Value,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Acc_ID = idAcc,
                };
                int rs1 = StaffController.Instance.InsertStaff(staff);
                if(rs1 == 1)
                {
                    string idSalary = $"BL000{SalaryController.Instance.GetOrderNumInList()}";
                    Salary salary = new Salary()
                    {
                        ID = idSalary,
                        Month = dtMonth.Value,
                        salaryBasic = Convert.ToInt32(txtSalaryBasic.Value),
                        hsl = Convert.ToDouble(txtHsl.Value),
                        salaryHour = Convert.ToInt32(txtSalaryHour.Value),
                        numHour = Convert.ToDouble(txtNum.Value),
                        Fine = Convert.ToInt32(txtFine.Value),
                        Bonus = Convert.ToInt32(txtBonus.Value),
                        Total = Convert.ToDouble(txtTotal.Text),
                        staffID = idStaff
                    };

                    int rs2 = SalaryController.Instance.InsertSalary(salary);
                    if (rs2 == 1)
                    {
                        mf.NotifySuss($"Thêm nhân viên {txtNameStaff.Text} thành công!");
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStaff_VIEW_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSalaryBasic_ValueChanged(object sender, EventArgs e)
        {
            LoadTotalSalary();
        }

        private void txtHsl_ValueChanged(object sender, EventArgs e)
        {
            LoadTotalSalary();
        }

        private void txtNum_ValueChanged(object sender, EventArgs e)
        {
            LoadTotalSalary();
        }

        private void txtSalaryHour_ValueChanged(object sender, EventArgs e)
        {
            LoadTotalSalary();
        }

        void LoadTotalSalary()
        {
            txtTotal.Text = ((txtSalaryBasic.Value * txtHsl.Value) + (txtSalaryHour.Value * txtNum.Value) + txtBonus.Value - txtFine.Value).ToString();
        }
    }
}
