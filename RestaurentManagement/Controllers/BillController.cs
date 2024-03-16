using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Controllers
{
    internal class BillController
    {
        private static BillController instance;
        public static BillController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillController();
                }
                return instance;
            }
        }

        public int InsertBill(Bill bill)
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

        //public bool UpdateBill(Bill bill,string tableID)
        //{
        //    string query = $@"";
        //}

        public int GetNumOrderBill()
        {
            string query = "SELECT COUNT(boSale_id) FROM dbo.BillOfSale";

            int num = DBHelper.Instance.ExecuteScalar(query, null);
            if (num == null)
            {
                return 0;
            }
            return num;
        }


    }
}
