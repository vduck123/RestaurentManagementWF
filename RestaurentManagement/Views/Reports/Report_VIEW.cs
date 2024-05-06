using Guna.Charts.WinForms;
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
using System.Windows.Forms.DataVisualization.Charting;


namespace RestaurentManagement.Views.Reports
{
    public partial class Report_VIEW : Form
    {
        public Report_VIEW()
        {
            InitializeComponent();
        }

        private void btnShowOption_Click(object sender, EventArgs e)
        {
            dtPrev.Visible = true;
            dtNext.Visible = true;
            label9.Visible = true;
            btnExcute.Visible = true;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //Post Data to datagridview
            dgvStaff.Columns.Clear();
            DataTable dt1 = ReportController.Instance.GetNumBillByStaffIdAndTime(dt, null);
            dgvStaff.DataSource = dt1;
            dgvSupplier.Columns.Clear();

            DataTable dt2 = ReportController.Instance.GetNumBillBySupplierIdAndTime(dt, null);
            dgvSupplier.DataSource = dt2;


            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dt, dt, "Hôm nay");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dt, dt, "Hôm nay");

            ChartReportOfToday(BillSale, BillImport, dt, dt);

            // Hiển thị số hóa đơn nhập và số hóa đơn bán
            LoadNumBill(dt1, dt2);

        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;

            DateTime startOfWeek = dt1.AddDays(-(int)dt1.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endOfWeek = dt1.AddDays(-(int)dt1.DayOfWeek + (int)DayOfWeek.Sunday).AddDays(7);


            //Post Data to datagridview
            dgvStaff.Columns.Clear();
            DataTable dtb1 = ReportController.Instance.GetNumBillByStaffIdAndTime(startOfWeek, endOfWeek);
            dgvStaff.DataSource = dtb1;
            dgvSupplier.Columns.Clear();

            DataTable dtb2 = ReportController.Instance.GetNumBillBySupplierIdAndTime(startOfWeek, endOfWeek);
            dgvSupplier.DataSource = dtb2;


            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dt1, dt2, "Tuần");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dt1, dt2, "Tuần");
            ChartReportOfWeek(BillSale, BillImport, startOfWeek, endOfWeek);
            LoadNumBill(dtb1, dtb2);


        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dt2 = dt1.AddMonths(1).AddDays(-1);

            //Post Data to datagridview
            dgvStaff.Columns.Clear();
            DataTable dtb1 = ReportController.Instance.GetNumBillByStaffIdAndTime(dt1, dt2);
            dgvStaff.DataSource = dtb1;
            
            dgvSupplier.Columns.Clear();
            DataTable dtb2 = ReportController.Instance.GetNumBillBySupplierIdAndTime(dt1, dt2);
            dgvSupplier.DataSource = dtb2;


            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dt1, dt2, "Tháng");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dt1, dt2, "Tháng");

            ChartReportOfMonth(BillSale, BillImport, dt1, dt2);

            LoadNumBill(dtb1, dtb2);


        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime dt2 = new DateTime(DateTime.Now.Year, 12, 31);

            //Post Data to datagridview
            dgvStaff.Columns.Clear();
            DataTable dtb1 = ReportController.Instance.GetNumBillByStaffIdAndTime(dt1, dt2);
            dgvStaff.DataSource = dtb1;

            dgvSupplier.Columns.Clear();
            DataTable dtb2 = ReportController.Instance.GetNumBillBySupplierIdAndTime(dt1, dt2);
            dgvSupplier.DataSource = dtb2;


            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dt1, dt2, "Năm");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dt1, dt2, "Năm");

            ChartReportMultiTime(BillSale, BillImport,dt1, dt2);

            LoadNumBill(dtb1, dtb2);



        }

        private void Report_VIEW_Load(object sender, EventArgs e)
        {

        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            //Post Data to datagridview
            dgvStaff.Columns.Clear();
            DataTable dtb1 = ReportController.Instance.GetNumBillByStaffIdAndTime(dtPrev.Value, dtNext.Value);
            dgvStaff.DataSource = dtb1;

            dgvSupplier.Columns.Clear();
            DataTable dtb2 = ReportController.Instance.GetNumBillBySupplierIdAndTime(dtPrev.Value, dtNext.Value);
            dgvSupplier.DataSource = dtb2;


            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dtPrev.Value, dtNext.Value, "Mốc");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dtPrev.Value, dtNext.Value, "Mốc");

            ChartReportMultiTime(BillSale, BillImport, dtPrev.Value, dtNext.Value);

            LoadNumBill(dtb1, dtb2);


            //

        }



        #region Method
        void ChartReportMultiTime(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu từ {dt1.ToShortDateString()} đến {dt2.ToShortDateString()}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            barDatasetExpense.Label = "Mục thu";
            barDatasetRevenue.Label = "Mục chi";

            foreach (DataRow row in dtb1.Rows)
            {
                int totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                barDatasetRevenue.DataPoints.Add($"Tháng {row["Tháng"]}", totalRevenue);
            }

            foreach (DataRow row in dtb2.Rows)
            {
                int totalExpense = Convert.ToInt32(row["Tổng chi"]);
                barDatasetExpense.DataPoints.Add($"Tháng {row["Tháng"]}", totalExpense);
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);
            
            charRevenue.Update();

        }

        void ChartReportOfMonth(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu tháng {dt1.Month} năm {dt1.Month}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            barDatasetExpense.Label = "Mục thu";
            barDatasetRevenue.Label = "Mục chi";

            foreach (DataRow row in dtb1.Rows)
            {
                int totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                barDatasetRevenue.DataPoints.Add($"Tháng {dt1.Month} ", totalRevenue);
            }

            foreach (DataRow row in dtb2.Rows)
            {
                int totalExpense = Convert.ToInt32(row["Tổng chi"]);
                barDatasetExpense.DataPoints.Add($"Tháng {dt1.Month}", totalExpense);
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);

            charRevenue.Update();

        }

        void ChartReportOfWeek(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu tuần từ ngày {dt1.ToString("dd/MM/yyyy")} đến {dt2.ToString("dd/MM/yyyy")}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            barDatasetExpense.Label = "Mục chi";
            barDatasetRevenue.Label = "Mục thu";

            foreach (DataRow row in dtb1.Rows)
            {
                int totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                barDatasetRevenue.DataPoints.Add($"Tháng {dt1.Month} ", totalRevenue);
            }

            foreach (DataRow row in dtb2.Rows)
            {
                int totalExpense = Convert.ToInt32(row["Tổng chi"]);
                barDatasetExpense.DataPoints.Add($"Tháng {dt1.Month}", totalExpense);
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);

            charRevenue.Update();
        }

        void ChartReportOfToday(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu ngày {dt1.ToString("dd/MM/yyyy")}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            barDatasetExpense.Label = "Mục thu";
            barDatasetRevenue.Label = "Mục chi";

            foreach (DataRow row in dtb1.Rows)
            {
                int totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                barDatasetRevenue.DataPoints.Add($"Ngày {dt1.ToString("dd/MM/yyyy")} ", totalRevenue);
            }

            foreach (DataRow row in dtb2.Rows)
            {
                int totalExpense = Convert.ToInt32(row["Tổng chi"]);
                barDatasetExpense.DataPoints.Add($"Ngày {dt1.ToString("dd/MM/yyyy")}", totalExpense);
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);

            charRevenue.Update();
        }

        void LoadNumBill(DataTable dt1, DataTable dt2)
        {
            if(dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
            {
                foreach (DataRow row1 in dt1.Rows)
                {
                    lbNumBillImport.Text = dt1.Rows[0]["Số hóa đơn nhập"].ToString();
                }
                foreach(DataRow row2 in dt2.Rows)
                {
                    lbNumBillImSale.Text = dt1.Rows[0]["Số hóa đơn bán"].ToString();
                }
            }
            else
            {
                lbNumBillImport.Text = "0";
                lbNumBillImSale.Text = "0";
            }

        }

        #endregion
    }
}
