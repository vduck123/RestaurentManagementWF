using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
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
            string query = @"INSERT INTO BillOfSale (boSale_id, dayIn, dayOut, totalMoney) 
                            VALUES (@Id, @DayIn, @DayOut, @TotalMoney)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Id", bill.Id },
                { "@DayIn", bill.dayIn },
                { "@DayOut", bill.dayOut },
                { "@TotalMoney", bill.totalMoney }
            };

            int result = Convert.ToInt16(DBHelper.Instance.ExecuteNonQuery(query, parameters));

            return result;
        }

        public int UpdateBillSale(BillSale bill)
        {
            string query = @"UPDATE dbo.BillOfSale
                                SET totalMoney = @total,
	                                dayIn = @dayin ,
	                                dayOut = @dayout
                            WHERE boSale_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id", bill.Id },
                { "@dayin", bill.dayIn },
                { "@dayout", bill.dayOut },
                { "@total", bill.totalMoney }
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
