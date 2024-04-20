using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Controllers
{
    internal class BillSaleController
    {
        private static BillSaleController instance;
        public static BillSaleController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillSaleController();
                }

                return instance;
            }
        }

        public int InsertBillSale(BillSale bill)
        {
            string query = @"INSERT INTO BillOfSale (boSale_id, dayIn, dayOut, totalMoney, staff_id, table_id) 
                            VALUES (@Id, @DayIn, @DayOut, @TotalMoney, @staffId, @tableId)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Id", bill.Id },
                { "@DayIn", bill.dayIn },
                { "@DayOut", bill.dayOut },               
                { "@TotalMoney", bill.totalMoney } ,
                { "@staffId", bill.staffID } ,
                { "@tableId", bill.tableID } 
            };

            int result = Convert.ToInt16(DBHelper.Instance.ExecuteNonQuery(query, parameters));

            return result;
        }

        public int UpdateBillSale(BillSale bill)
        {
            string query = @"UPDATE dbo.BillOfSale
                                SET totalMoney = @total,
	                                dayIn = @dayin ,
	                                dayOut = @dayout ,
                                    staff_id = @staffId ,
                                    table_id = @tableId ,
                            WHERE boSale_id = @id";
  
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Id", bill.Id },
                { "@DayIn", bill.dayIn },
                { "@DayOut", bill.dayOut },
                { "@TotalMoney", bill.totalMoney } ,
                { "@staffId", bill.staffID } ,
                { "@tableId", bill.tableID }
            };
     

            int result = Convert.ToInt16(DBHelper.Instance.ExecuteNonQuery(query, parameters));
            return result;
        }

        public int DeleteBillSale(BillSale bill)
        {
            string query = @"DELETE FROM dbo.BillOfSale WHERE boSale_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id", bill.Id }
            };

            int result = Convert.ToInt16(DBHelper.Instance.ExecuteNonQuery(query, parameters));
            return result;
        }

        public List<BillSale> GetBillSaleById(string id)
        {
            List<BillSale> listBillSale = new List<BillSale>();
            string query = $"SELECT * FROM BillOfSale WHERE boSale_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                BillSale b = new BillSale(item);
                listBillSale.Add(b);
            }

            return listBillSale;
        }

        public List<BillSale> GetListBillSale()
        {
            List<BillSale> listBillSale = new List<BillSale>();
            string query = $"SELECT * FROM BillOfSale'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                BillSale b = new BillSale(item);
                listBillSale.Add(b);
            }

            return listBillSale;
        }



        public int GetNumOrderBill()
        {
            string query = "SELECT COUNT(boSale_id) FROM dbo.BillOfSale";

            int num = DBHelper.Instance.ExecuteScalar(query);
            if (num == null)
            {
                return 0;
            }
            return num;
        }
        



    }
}
