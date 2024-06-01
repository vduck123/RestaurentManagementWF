using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views.Employee
{
    public partial class ReportBillByStaff : Form
    {
        DataTable _dt = new DataTable();
        public ReportBillByStaff(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;
        }

        private void ReportBillByStaff_Load(object sender, EventArgs e)
        {
            if(_dt.Rows.Count < 0)
            {
                return;
            }

            dgvReport.Columns.Clear();
            dgvReport.DataSource = _dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
