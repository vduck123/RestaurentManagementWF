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
    public partial class FrmStaff_VIEW : Form
    {
        string _user = null;
        public FrmStaff_VIEW(string user)
        {
            InitializeComponent();
            if (user != null)
            {
                _user = user;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmStaff_VIEW_Load(object sender, EventArgs e)
        {
            lbUser.Text = StaffController.Instance.GetNameStaffByAccID(AccountController.Instance.GetIdAccountByUsername(_user));
        }

        

        private void btnSignOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login_VIEW view = new Login_VIEW();
            view.ShowDialog();
        }

        Form currentForm = null;

        void OpenChildForm(Form childForm)
        {
            if (currentForm != null)
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reports.Report_VIEW());   
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Order_VIEW(lbUser.Text));
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            OpenChildForm(new _Table._TableInfo_VIEW());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Provider.ProviderInfo_VIEW());
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Material.MaterialInfo_VIEW());
        }

        private void btnBillImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillImport_VIEW(lbUser.Text));
        }

        private void btnBillSale_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillSales.BillSaleInfo_VIEW());
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Foods.FoodInfo());
        }
    }
}
