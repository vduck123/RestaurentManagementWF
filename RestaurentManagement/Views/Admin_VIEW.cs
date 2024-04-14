using RestaurentManagement.Controllers;
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
    public partial class Admin_VIEW : Form
    {
        public string _user;
        public Admin_VIEW(string user)
        {
            InitializeComponent();
            if(user != null)
            {
                _user = user;
            }
        }

        Form currentForm = null;

        void OpenChildForm(Form childForm)
        {
            if(currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = childForm;

            childForm.TopLevel = false;

            childForm.FormBorderStyle = FormBorderStyle.None;

            childForm.Dock = DockStyle.Fill;

            guna2Panel4.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home_VIEW());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Order_VIEW());

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FoodCategory_VIEW());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Account_VIEW());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Staff_VIEW());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Supplier_VIEW());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Warehouse_VIEW());
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Voucher_VIEW());
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Food_VIEW());
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Salary_VIEW());
        }

        private void btnBillImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillImport_VIEW(lbUser.Text));
        }

        private void Admin_VIEW_Load(object sender, EventArgs e)
        {
            lbUser.Text = StaffController.Instance.GetNameStaffByAccID(AccountController.Instance.GetIdAccountByUsername(_user));
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Order_VIEW());
        }
    }
}
