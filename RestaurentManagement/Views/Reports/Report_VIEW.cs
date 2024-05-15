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
        int click = 0;
        private void btnShowOption_Click(object sender, EventArgs e)
        {
            click++;
            if(click % 2 == 1)
            {
                dtPrev.Visible = true;
                dtNext.Visible = true;
                label9.Visible = true;
                btnExcute.Visible = true;
            }
            else
            {
                dtPrev.Visible = false;
                dtNext.Visible = false;
                label9.Visible = false;
                btnExcute.Visible = false;
            }
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
            Dictionary<string, int> list = ReportController.Instance.GetNumBillByTime(dt, dt);
            LoadNumBill(list);
            // 
            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dt, dt);
            LoadChartHotFood(dtHotFood, dt, dt);

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
            //
            Dictionary<string,int> list = ReportController.Instance.GetNumBillByTime(startOfWeek, endOfWeek);
            LoadNumBill(list);
            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dt1, dt2, "Tuần");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dt1, dt2, "Tuần");
            ChartReportOfWeek(BillSale, BillImport, startOfWeek, endOfWeek);
            
            
            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(startOfWeek, endOfWeek);
            LoadChartHotFood(dtHotFood, startOfWeek, endOfWeek);


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

            Dictionary<string, int> list = ReportController.Instance.GetNumBillByTime(dt1, dt2);
            LoadNumBill(list);

            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dt1, dt2);
            LoadChartHotFood(dtHotFood, dt1, dt2);



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

            Dictionary<string, int> list = ReportController.Instance.GetNumBillByTime(dt1, dt2);
            LoadNumBill(list);
            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dt1, dt2);
            LoadChartHotFood(dtHotFood, dt1, dt2);


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
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(dtPrev.Value, dtPrev.Value, "Mốc");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(dtPrev.Value, dtNext.Value, "Mốc");

            ChartReportMultiTime(BillSale, BillImport, dtPrev.Value, dtNext.Value);

            Dictionary<string, int> list = ReportController.Instance.GetNumBillByTime(dtPrev.Value, dtPrev.Value);
            LoadNumBill(list);

            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dtPrev.Value, dtNext.Value);
            LoadChartHotFood(dtHotFood, dtPrev.Value, dtNext.Value);

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

        void LoadChartHotFood(DataTable dtb, DateTime dt1, DateTime dt2)
        {
            chartFood.Datasets.Clear();
            chartFood.Title.Text = $"Top món ăn {dt1.ToString("dd/MM/yyyy")}";
            var dataset = new Guna.Charts.WinForms.GunaPieDataset();

            chartFood.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            foreach (DataRow row in dtb.Rows)
            {
                int quantity = Convert.ToInt32(row["Số lượng"]);
                dataset.DataPoints.Add(FoodController.Instance.GetNameFoodByID(row["food_id"].ToString()), quantity);
                dataset.Label = FoodController.Instance.GetNameFoodByID(row["food_id"].ToString());
            }

            

            chartFood.Datasets.Add(dataset);

            chartFood.Update();
        }

        void LoadNumBill(Dictionary<string, int> list)
        {
            if (list.Count > 0)
            {
                if (list.ContainsKey("Số hóa đơn nhập"))
                {
                    lbNumBillImport.Text = list["Số hóa đơn nhập"].ToString();
                }
                else
                {
                    lbNumBillImport.Text = "0";
                }

                if (list.ContainsKey("Số hóa đơn bán"))
                {
                    lbNumBillImSale.Text = list["Số hóa đơn bán"].ToString();
                }
                else
                {
                    lbNumBillImSale.Text = "0";
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
