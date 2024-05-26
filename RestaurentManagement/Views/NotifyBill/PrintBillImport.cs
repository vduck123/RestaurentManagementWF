using Microsoft.Reporting.WinForms;
using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using RestaurentManagement.Views._Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views.NotifyBill
{
    public partial class PrintBillImport : Form
    {
        string _nameStaff = null;
        string _nameProvider = null;
        string _idBill = null;
        public PrintBillImport(string nameStaff, string nameProvider, string idBill)
        {
            InitializeComponent();
            _nameStaff = nameStaff;
            _nameProvider = nameProvider;
            _idBill = idBill;
        }

        private void PrintBillImport_Load(object sender, EventArgs e)
        {
            int totalBill = 0;
            List<BillImportInfo> list = BillImportInfoController.Instance.GetAllBillImportInfoByBillImportID(_idBill);
            DataTable dt = new DataTable();
            dt.Columns.Add("item_id");
            dt.Columns.Add("price");
            dt.Columns.Add("quantity");
            dt.Columns.Add("unit");
            dt.Columns.Add("total_money");

            foreach (BillImportInfo bill in list)
            {
                dt.Rows.Add(WarehouseController.Instance.GetNameItemByID(bill.ItemID), bill.Price, bill.Quantity, bill.Unit, bill.TotalMoney);
                totalBill += bill.TotalMoney;
            }
            reportViewer1.LocalReport.ReportPath = Path.Combine(AppContext.BaseDirectory, "BilImportReport.rdlc");

            ReportDataSource detailDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = dt
            };

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                    new ReportParameter("staff", _nameStaff),
                    new ReportParameter("supplier", _nameProvider),
                    new ReportParameter("dayCreate", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("total", $"{totalBill} Vnđ")
            };

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(detailDataSource);
            reportViewer1.LocalReport.SetParameters(reportParameters);

            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
