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
            string idAcc = $"ACC00{AccountController.Instance.GetOrderNumInList()}";
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
                        Month = dtMonth.Value.Month,
                        salaryBasic = Convert.ToInt32(txtSalaryBasic.Value),
                        hsl = Convert.ToDouble(txtHsl.Value),
                        salaryHour = Convert.ToInt32(txtSalaryHour.Value),
                        numHour = Convert.ToInt32(txtNum.Value),
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
    }
}
