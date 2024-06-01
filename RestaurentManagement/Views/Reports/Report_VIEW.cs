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

        private void Report_VIEW_Load(object sender, EventArgs e)
        {
            LoadAllToday();
            LoadA();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            LoadAllToday();
        }

        void LoadAllToday()
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
            LoadNumBill(dt, dt);

            // 
            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dt, dt);
            LoadChartHotFood2(dtHotFood, dt, dt);
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
            LoadNumBill(startOfWeek, endOfWeek);
            //Chart
            DataTable BillSale = ReportController.Instance.ReportsBillSaleOfTime(startOfWeek, endOfWeek, "Tuần");
            DataTable BillImport = ReportController.Instance.ReportsBillImportOfTime(startOfWeek, endOfWeek, "Tuần");
            ChartReportOfWeek(BillSale, BillImport, startOfWeek, endOfWeek);
            
            
            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(startOfWeek, endOfWeek);
            LoadChartHotFood2(dtHotFood, startOfWeek, endOfWeek);


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

            LoadNumBill(dt1,dt2);

            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dt1, dt2);
            LoadChartHotFood2(dtHotFood, dt1, dt2);



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

            LoadNumBill(dt1, dt2);

            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dt1, dt2);
            LoadChartHotFood2(dtHotFood, dt1, dt2);

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

            LoadNumBill(dtPrev.Value, dtNext.Value);

            DataTable dtHotFood = ReportController.Instance.GetTopFoodByTime(dtPrev.Value, dtNext.Value);
            LoadChartHotFood2(dtHotFood, dtPrev.Value, dtNext.Value);

            //

        }



        #region Method
        void ChartReportMultiTime(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu từ {dt1.ToShortDateString()} đến {dt2.ToShortDateString()}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetProfit = new Guna.Charts.WinForms.GunaBarDataset();

            barDatasetRevenue.Label = "Mục thu";
            barDatasetExpense.Label = "Mục chi";
            barDatasetProfit.Label = "Lợi nhuận";

            int totalRevenue = 0;
            int totalExpense = 0;
            int revenue = 0;
            int expense = 0;

            Dictionary<string, int> revenueByMonth = new Dictionary<string, int>();

            foreach (DataRow row in dtb1.Rows)
            {
                totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                
                revenue += totalRevenue;
                string month = $"Tháng {row["Tháng"]}";
                revenueByMonth[month] = totalRevenue;
                barDatasetRevenue.DataPoints.Add(month, totalRevenue);
            }

            foreach (DataRow row in dtb2.Rows)
            {
                totalExpense = Convert.ToInt32(row["Tổng chi"]);
                expense += totalExpense;
                string month = $"Tháng {row["Tháng"]}";
                barDatasetExpense.DataPoints.Add(month, totalExpense);
                if (revenueByMonth.ContainsKey(month))
                {
                    int profit = revenueByMonth[month] - totalExpense;
                    if(profit < 0)
                    {
                        profit = 0;
                    }
                    barDatasetProfit.DataPoints.Add(month, profit);
                }
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));
            barDatasetProfit.FillColors.Add(Color.FromArgb(255, 165, 0)); 

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);
            charRevenue.Datasets.Add(barDatasetProfit);

            LoadTotalRevenueExpenseProfit(revenue, expense);
            charRevenue.Update();
        }


        void ChartReportOfMonth(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu tháng {dt1.Month} năm {dt1.Year}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetProfit = new Guna.Charts.WinForms.GunaBarDataset();

            barDatasetRevenue.Label = "Mục thu";
            barDatasetExpense.Label = "Mục chi";
            barDatasetProfit.Label = "Lợi nhuận";

            int totalRevenue = 0;
            int totalExpense = 0;

            var dailyRevenueDict = new Dictionary<string, int>();
            var dailyExpenseDict = new Dictionary<string, int>();
            foreach (DataRow row in dtb1.Rows)
            {
                string dayOut = Convert.ToDateTime(row["Ngày"]).ToString("dd/MM/yyyy");
                int dailyRevenue = Convert.ToInt32(row["Tổng thu"]);
                totalRevenue += dailyRevenue;
                dailyRevenueDict[dayOut] = dailyRevenue;
                barDatasetRevenue.DataPoints.Add(dayOut, dailyRevenue);
            }

            foreach (DataRow row in dtb2.Rows)
            {
                string dayOut = Convert.ToDateTime(row["Ngày"]).ToString("dd/MM/yyyy");
                int dailyExpense = Convert.ToInt32(row["Tổng chi"]);
                totalExpense += dailyExpense;
                dailyExpenseDict[dayOut] = dailyExpense;
                barDatasetExpense.DataPoints.Add(dayOut, dailyExpense);
            }

            foreach (var date in dailyRevenueDict.Keys)
            {
                int dailyProfit = dailyRevenueDict[date] - (dailyExpenseDict.ContainsKey(date) ? dailyExpenseDict[date] : 0);
                if (dailyProfit < 0)
                {
                    dailyProfit = 0;
                }
                barDatasetProfit.DataPoints.Add(date, dailyProfit);
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));
            barDatasetProfit.FillColors.Add(Color.FromArgb(255, 165, 0));

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);
            charRevenue.Datasets.Add(barDatasetProfit);

            LoadTotalRevenueExpenseProfit(totalRevenue, totalExpense);

            charRevenue.Update();
        }



        void ChartReportOfWeek(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu tuần từ ngày {dt1:dd/MM/yyyy} đến {dt2:dd/MM/yyyy}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetProfit = new Guna.Charts.WinForms.GunaBarDataset();

            barDatasetRevenue.Label = "Mục thu";
            barDatasetExpense.Label = "Mục chi";
            barDatasetProfit.Label = "Lợi nhuận";

            int totalRevenue = 0;
            int totalExpense = 0;

            Dictionary<DateTime, int> revenueByDate = new Dictionary<DateTime, int>();
            Dictionary<DateTime, int> expenseByDate = new Dictionary<DateTime, int>();
            foreach (DataRow row in dtb1.Rows)
            {
                DateTime date = Convert.ToDateTime(row["Ngày"]);
                int revenue = Convert.ToInt32(row["Tổng thu"]);
                totalRevenue += revenue;
                revenueByDate[date] = revenue;
                barDatasetRevenue.DataPoints.Add(date.ToString("dd/MM"), revenue);
            }

 
            foreach (DataRow row in dtb2.Rows)
            {
                DateTime date = Convert.ToDateTime(row["Ngày"]);
                int expense = Convert.ToInt32(row["Tổng chi"]);
                totalExpense += expense;
                expenseByDate[date] = expense;
                barDatasetExpense.DataPoints.Add(date.ToString("dd/MM"), expense);
            }

            foreach (var date in revenueByDate.Keys)
            {
                int revenue = revenueByDate[date];
                int expense = expenseByDate.ContainsKey(date) ? expenseByDate[date] : 0;
                int profit = revenue - expense;
                if(profit < 0)
                {
                    profit = 0;
                }
                barDatasetProfit.DataPoints.Add(date.ToString("dd/MM"), profit);
            }

            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));
            barDatasetProfit.FillColors.Add(Color.FromArgb(255, 165, 0)); 

            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);
            charRevenue.Datasets.Add(barDatasetProfit);

            LoadTotalRevenueExpenseProfit(totalRevenue, totalExpense);
            charRevenue.Update();
        }


        void ChartReportOfToday(DataTable dtb1, DataTable dtb2, DateTime dt1, DateTime dt2)
        {
            charRevenue.Datasets.Clear();
            charRevenue.Title.Text = $"Thống kê doanh thu và chi tiêu ngày {dt1.ToString("dd/MM/yyyy")}";

            var barDatasetRevenue = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetExpense = new Guna.Charts.WinForms.GunaBarDataset();
            var barDatasetProfit = new Guna.Charts.WinForms.GunaBarDataset();

            barDatasetRevenue.Label = "Mục thu";
            barDatasetExpense.Label = "Mục chi";
            barDatasetProfit.Label = "Lợi nhuận";

            int totalRevenue = 0;
            int totalExpense = 0;

            foreach (DataRow row in dtb1.Rows)
            {
                totalRevenue = Convert.ToInt32(row["Tổng thu"]);
                barDatasetRevenue.DataPoints.Add($"Ngày {dt1:dd/MM/yyyy}", totalRevenue);
            }
            foreach (DataRow row in dtb2.Rows)
            {
                totalExpense = Convert.ToInt32(row["Tổng chi"]);
                barDatasetExpense.DataPoints.Add($"Ngày {dt1:dd/MM/yyyy}", totalExpense);
            }

     
            int profit = totalRevenue - totalExpense;
            if(profit < 0)
            {
                profit = 0;
            }
            barDatasetProfit.DataPoints.Add($"Ngày {dt1:dd/MM/yyyy}", profit);

           
            barDatasetRevenue.FillColors.Add(Color.FromArgb(0, 122, 204));
            barDatasetExpense.FillColors.Add(Color.FromArgb(0, 166, 90));
            barDatasetProfit.FillColors.Add(Color.FromArgb(255, 165, 0)); 

            
            charRevenue.Datasets.Add(barDatasetRevenue);
            charRevenue.Datasets.Add(barDatasetExpense);
            charRevenue.Datasets.Add(barDatasetProfit);

            LoadTotalRevenueExpenseProfit(totalRevenue, totalExpense);
            charRevenue.Update();
        }


        void LoadChartHotFood2(DataTable dtb, DateTime dt1, DateTime dt2)
        {

            chartHotFood.Series.Clear();
            chartHotFood.Titles.Clear();
            chartHotFood.ChartAreas.Clear();
            chartHotFood.Titles.Add($"Top món ăn bán chạy");
            ChartArea chartArea = new ChartArea();
            chartHotFood.ChartAreas.Add(chartArea);
            Series series = new Series
            {
                Name = "FoodSeries",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Doughnut
            };
            chartHotFood.Series.Add(series);


            foreach (DataRow row in dtb.Rows)
            {
                int quantity = Convert.ToInt32(row["Số lượng"]);
                string foodName = FoodController.Instance.GetNameFoodByID(row["food_id"].ToString());
                series.Points.AddXY(foodName, quantity);
            }

            chartHotFood.Invalidate();
        }

        void LoadNumBill(DateTime dt1, DateTime dt2)
        {
            int num1 =  ReportController.Instance.GetBillCount("boSale_id", "BillOfSale", "dayOut", dt1, dt2);
            int num2 = ReportController.Instance.GetBillCount("boImport_id", "BillOfImport", "dayCreate", dt1, dt2);
            if (num1 == null)
            {
                lbNumBillImSale.Text = "0";
            }
            else
            {
                lbNumBillImSale.Text = num1.ToString();
            }

            if (num2 == null)
            {
                lbNumBillImport.Text = "0";
            }
            else
            {
                lbNumBillImport.Text = num2.ToString();
            }
        }

        void LoadTotalRevenueExpenseProfit(int revenue, int expense)
        {
            lbExpense.Text = $"{expense.ToString()} VNĐ";
            lbRevenue.Text = $"{revenue.ToString()} VNĐ";
            int profit = revenue - expense;
            if(profit < 0)
            {
                profit = 0;
            }

            lbProfit.Text = $"{profit.ToString()} VNĐ";
        }

        void LoadA()
        {
            int numStaff = StaffController.Instance.GetOrderNumInList();
            int numSupplier = SupplierController.Instance.GetOrderNumInList();
            int numFood = FoodController.Instance.GetOrderNumInList();

            lbNumStaff.Text = numStaff.ToString();
            lbNumSupplier.Text = numSupplier.ToString();
            lbNumFood.Text = numFood.ToString();
        }




        #endregion
    }
}
