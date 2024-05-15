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

namespace RestaurentManagement.Views
{
    public partial class frmData : Form
    {
        public frmData()
        {
            InitializeComponent();
        }

        private void btnAddBillImport_Click(object sender, EventArgs e)
        {
            Context.Instance.GetFakeBillImport(Convert.ToInt32(txtQuantity.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context.Instance.GetFakeStaff(Convert.ToInt32(txtQuantity.Text));  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Context.Instance.GetFakeSupplier(Convert.ToInt32(txtQuantity.Text));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Context.Instance.GetFakeBillSale(Convert.ToInt32(txtQuantity.Text));    
        }
    }
}
