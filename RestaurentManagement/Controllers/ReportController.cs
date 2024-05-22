using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace RestaurentManagement.Controllers
{
    internal class ReportController
    {
        private static ReportController instance;
        public static ReportController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReportController();
                }

                return instance;
            }
        }

        public DataTable GetNumBillByStaffIdAndTime(DateTime? time1, DateTime? time2)
        {
            string query = null;
            DataTable dt = new DataTable();
            if (time1 != null && time2 != null)
            {
                query = $@"SELECT 
                        sf.staff_id AS [Mã nhân viên], 
                        sf.staff_name AS [Tên nhân viên] ,
                        COUNT(DISTINCT boi.boImport_id) AS [Số hóa đơn nhập], 
                        COUNT(DISTINCT bos.boSale_id) AS [Số hóa đơn bán]
                    FROM 
                        dbo.Staff sf
                    LEFT JOIN 
                        dbo.BillOfImport boi ON sf.staff_id = boi.staff_id AND boi.dayCreate BETWEEN '{time1.Value.ToShortDateString()}' AND '{time2.Value.ToShortDateString()}'
                    LEFT JOIN 
                        dbo.BillOfSale bos ON sf.staff_id = bos.staff_id AND bos.dayIn BETWEEN '{time1.Value.ToShortDateString()}' AND '{time2.Value.ToShortDateString()}'
                    GROUP BY 
                        sf.staff_id, sf.staff_name
                    HAVING 
                        COUNT(DISTINCT boi.boImport_id) > 0 OR  COUNT(DISTINCT bos.boSale_id) > 0;";
            }
            else
            {
                query = $@"SELECT 
                        sf.staff_id AS [Mã nhân viên], 
                        sf.staff_name AS [Tên nhân viên] ,
                        COUNT(DISTINCT boi.boImport_id) AS [Số hóa đơn nhập], 
                        COUNT(DISTINCT bos.boSale_id) AS [Số hóa đơn bán]
                    FROM 
                        dbo.Staff sf
                    LEFT JOIN 
                        dbo.BillOfImport boi ON sf.staff_id = boi.staff_id AND boi.dayCreate = '{time1}'
                    LEFT JOIN 
                        dbo.BillOfSale bos ON sf.staff_id = bos.staff_id AND bos.dayIn = '{time1}'
                    GROUP BY 
                        sf.staff_id, sf.staff_name
                    HAVING 
                        COUNT(DISTINCT boi.boImport_id) > 0 OR  COUNT(DISTINCT bos.boSale_id) > 0;";
            }

            dt = DBHelper.Instance.ExecuteQuery(query);
            return dt;
        }


        public DataTable GetNumBillBySupplierIdAndTime(DateTime? time1, DateTime? time2)
        {
            string query = null;
            DataTable dt = new DataTable();
            if (time1 != null && time2 != null)
            {
                query = $@"SELECT 
                        spl.supplier_id AS [Mã nhà cung cấp], 
                        spl.supplier_name AS [Tên nhà cung cấp], 
                        COUNT(boi.boImport_id) AS [Số hóa đơn nhập]
                   FROM 
                        dbo.Supplier spl
                   LEFT JOIN 
                        dbo.BillOfImport boi ON boi.supplier_id = spl.supplier_id AND boi.dayCreate BETWEEN '{time1.Value.ToShortDateString()}' AND '{time2.Value.ToShortDateString()}'
                   GROUP BY 
                        spl.supplier_id, spl.supplier_name 
                   HAVING 
                        COUNT(boi.boImport_id) > 0";
            }
            else
            {
                query = $@"SELECT 
                        spl.supplier_id AS [Mã nhà cung cấp], 
                        spl.supplier_name AS [Tên nhà cung cấp], 
                        COUNT(boi.boImport_id) AS [Số hóa đơn nhập]
                   FROM 
                        dbo.Supplier spl
                   LEFT JOIN 
                        dbo.BillOfImport boi ON boi.supplier_id = spl.supplier_id AND boi.dayCreate = '{time1}'
                   GROUP BY 
                        spl.supplier_id, spl.supplier_name 
                   HAVING 
                        COUNT(boi.boImport_id) > 0";
            }
            dt = DBHelper.Instance.ExecuteQuery(query);
            return dt;
        }

        

        public DataTable ReportsBillImportOfTime(DateTime dt1, DateTime dt2, string type)
        {
            string query = "";
            switch(type)
            {
                case "Năm":
                    {
                        query = $@"SELECT MONTH(dayCreate) AS [Tháng],
                                    ISNULL(SUM(total_money), 0) AS [Tổng chi]
                                    FROM BillOfImport
                                    WHERE dayCreate BETWEEN '{dt1}' AND '{dt2}'
                                    GROUP BY MONTH(dayCreate)
                                    ORDER BY Tháng";
                        break;
                    }
                case "Tháng":
                    {
                        query = $@"SELECT dayCreate AS [Ngày],  ISNULL(SUM(total_money),0) AS [Tổng chi]
                                FROM dbo.BillOfImport
                               WHERE dayCreate BETWEEN '{dt1.ToShortDateString()}' AND '{dt2.ToShortDateString()}' 
                                GROUP BY dayCreate
                                    ORDER BY Ngày";
                        break;
                    }
                case "Tuần":
                    {
                        query = $@"SELECT dayCreate AS [Ngày], ISNULL(SUM(total_money), 0) AS [Tổng chi]
                                    FROM dbo.BillOfImport
                                    WHERE dayCreate BETWEEN '{dt1.ToString("yyyy-MM-dd")}' AND '{dt2.ToString("yyyy-MM-dd")}'
                                    GROUP BY dayCreate
                                    ORDER BY Ngày";

                        break;
                    }
                case "Hôm nay":
                    {
                        query = $@"SELECT ISNULL(SUM(total_money),0) AS [Tổng chi]
                                FROM dbo.BillOfImport
                               WHERE dayCreate BETWEEN '{dt1.ToShortDateString()}' AND '{dt2.ToShortDateString()}'";
                        break;
                    }
                case "Mốc":
                    {
                        query = $@"SELECT MONTH(dayCreate) AS [Tháng],
                                    ISNULL(SUM(total_money), 0) AS [Tổng chi]
                                    FROM BillOfImport
                                    WHERE dayCreate BETWEEN '{dt1}' AND '{dt2}'
                                    GROUP BY MONTH(dayCreate)
                                    ORDER BY Tháng";
                        break;
                    }
            }
            DataTable dt = new DataTable();
            dt = DBHelper.Instance.ExecuteQuery(query);
            return dt;

        }

        public DataTable ReportsBillSaleOfTime(DateTime dt1, DateTime dt2, string type)
        {
            string query = "";
            switch (type)
            {
                case "Năm":
                    {
                        query = $@"SELECT MONTH(dayOut) AS [Tháng],
                                    ISNULL(SUM(totalMoney), 0) AS [Tổng thu]
                                    FROM BillOfSale
                                    WHERE dayOut BETWEEN '{dt1}' AND '{dt2}'
                                    GROUP BY MONTH(dayOut)
                                    ORDER BY Tháng";
                        break;
                    }
                case "Tháng":
                    {
                        query = $@"SELECT dayOut AS [Ngày], ISNULL(SUM(totalMoney),0) AS [Tổng thu]
                                FROM dbo.BillOfSale
                                WHERE dayIn BETWEEN '{dt1.ToShortDateString()}' AND '{dt2.ToShortDateString()}'
                                GROUP BY dayOut
                                ORDER BY Ngày;"; 
                        break;
                    }
                case "Tuần":
                    {
                        query = $@"SELECT dayOut AS [Ngày], ISNULL(SUM(totalMoney),0) AS [Tổng thu] 
                                FROM dbo.BillOfSale
                                WHERE dayIn BETWEEN '{dt1.ToShortDateString()}' AND '{dt2.ToShortDateString()}'
                                GROUP BY dayOut
                                ORDER BY Ngày";
                                
                        break;
                    }
                case "Hôm nay":
                    {
                        query = $@"SELECT ISNULL(SUM(totalMoney),0) AS [Tổng thu]
                                FROM dbo.BillOfSale
                                WHERE dayIn BETWEEN '{dt1.ToShortDateString()}' AND '{dt2.ToShortDateString()}'"; ;
                        break;
                    }
                case "Mốc":
                    {
                        query = $@"SELECT MONTH(dayOut) AS [Tháng],
                                    ISNULL(SUM(totalMoney), 0) AS [Tổng thu]
                                    FROM BillOfSale
                                    WHERE dayOut BETWEEN '{dt1}' AND '{dt2}'
                                    GROUP BY MONTH(dayOut)
                                    ORDER BY Tháng";
                        break;
                    }
            }
            DataTable dt = new DataTable();
            dt = DBHelper.Instance.ExecuteQuery(query);
            return dt;

        }


        public int GetBillCount(string columnName, string tableName, string dateColumn, DateTime dt1, DateTime dt2)
        {
            string query = $@"SELECT COUNT({columnName}) 
                      FROM {tableName} 
                      WHERE {dateColumn} BETWEEN '{dt1}' AND '{dt2}'";
            return DBHelper.Instance.ExecuteScalar(query);
        }

        public DataTable GetTopFoodByTime(DateTime dt1, DateTime dt2)
        {
            string query = $@"SELECT TOP(5) COUNT(dbos.food_id) [Số lượng], 
                                            dbos.food_id
                                            FROM dbo.BillOfSale bos
                                            INNER JOIN dbo.DetailBillOfSale dbos ON dbos.boSale_id = bos.boSale_id
                             WHERE bos.dayOut BETWEEN '{dt1}' AND '{dt2}'
                             GROUP BY dbos.food_id
                            ORDER BY COUNT(dbos.food_id) DESC";
            DataTable dt = new DataTable();
            dt = DBHelper.Instance.ExecuteQuery(query);
            return dt;
        }

    }
}
