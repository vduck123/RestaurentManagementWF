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
    public partial class BillImportAdmin_VIEW : Form
    {
        MainForm mf = new MainForm();
        public BillImportAdmin_VIEW()
        {
            InitializeComponent();
        }

        #region Event

        private void BillImport_VIEW_Click(object sender, EventArgs e)
        {
            txtID.Text = dgvBilImport.SelectedRows[0].Cells[0].Value.ToString();
            txtStaff.Text = dgvBilImport.SelectedRows[0].Cells[1].Value.ToString();
            dtDayCreated.Text = dgvBilImport.SelectedRows[0].Cells[2].Value.ToString();
            txtSupplier.Text = dgvBilImport.SelectedRows[0].Cells[3].Value.ToString();
            txtTotalMoney.Text = dgvBilImport.SelectedRows[0].Cells[4].Value.ToString();

        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Ấn OK để xác nhận xóa thông tin");
            if(qs == DialogResult.OK)
            {
                int rs = BillImportController.Instance.DeleteBillImport(txtID.Text);
                if(rs == 1)
                {
                    mf.NotifySuss("Xóa hóa đơn thành công");
                    Refresh();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<BillImport> listbillImport = BillImportController.Instance.GetListBillImport();
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void BillImport_VIEW_Load(object sender, EventArgs e)
        {

        }

        private void btnBillDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region
        void LoadData()
        {
            dgvBilImport.Columns.Clear();
            List<BillImport> listbillImport = BillImportController.Instance.GetListBillImport();
        }
        #endregion

    }
}
