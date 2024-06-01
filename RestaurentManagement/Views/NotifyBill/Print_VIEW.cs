using Microsoft.Reporting.WinForms;
using RestaurentManagement.Controllers;
using RestaurentManagement.Views._Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Menu = RestaurentManagement.Models.Menu;
using System.Xml;
using RestaurentManagement.Models;

namespace RestaurentManagement.Views.BillPdf
{
    public partial class Print_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _nameCus = null;
        string _nameStaff = null;
        string _idTable = null;
        string _dayCreate = null;
        string _timeIn = null;
        string _timeOut = null;
        string _total = null;
        string _expiry = null;
        string _paymoney = null;
        string _PhoneRes = null;
        string _AddressRes = null;
        public Print_VIEW(string nameCus, string nameStaff, string idTable, string expiry, string dayCreate, string timeIn, string timeOut, string total, string paymoney, string phoneRes, string addressRes)
        {
            InitializeComponent();
            _nameCus = nameCus;
            _nameStaff = nameStaff;
            _idTable = idTable;
            _dayCreate = dayCreate;
            _timeIn = timeIn;
            _timeOut = timeOut;
            _total = total;
            _expiry = expiry;
            _paymoney = paymoney;
            _PhoneRes = phoneRes;
            _AddressRes = addressRes;
        }



        private void Print_VIEW_Load(object sender, EventArgs e)
        {
            List<_Menu> menus = MenuController.Instance.GetMenuByTableID(_idTable);          
            DataTable dt = new DataTable();
            dt.Columns.Add("food_id");
            dt.Columns.Add("food_price");
            dt.Columns.Add("quantity");
            dt.Columns.Add("total");

            foreach (_Menu menu in menus)
            {
                dt.Rows.Add(FoodController.Instance.GetNameFoodByID(menu.foodID), menu.Quantity, menu.Price, menu.Total);
            }
            reportViewer1.LocalReport.ReportPath = Path.Combine(AppContext.BaseDirectory, "BillReport.rdlc");

            ReportDataSource detailDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = dt
            };

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                    new ReportParameter("customer", _nameCus),
                    new ReportParameter("staff", _nameStaff),
                    new ReportParameter("table", TableController.Instance.GetNameTableById(_idTable)),
                    new ReportParameter("totalBill", $"{_total} Vnđ"),            
                    new ReportParameter("dayCreate", _dayCreate),
                    new ReportParameter("timeIn", _timeIn),
                    new ReportParameter("timeOut", _timeOut),
                    new ReportParameter("expiry", _expiry),
                    new ReportParameter("moneyPay", $"{_paymoney} Vnđ"),
                    new ReportParameter("myAddress", _AddressRes),
                    new ReportParameter("myPhone", _PhoneRes)
            };

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(detailDataSource);
            reportViewer1.LocalReport.SetParameters(reportParameters);

            reportViewer1.RefreshReport();


            this.reportViewer1.RefreshReport();
        }
    }
}
