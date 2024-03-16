using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurentManagement.Controllers
{
    internal class BillInfoController
    {
        private static BillInfoController instance;
        public static BillInfoController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillInfoController();
                }
                return instance;
            }
        }

        public bool InsertBillInfo(BillInfo billInfo)
        {
            string query = $@"INSERT INTO DetailBillOfSale 
                              VALUES ('${billInfo.Id}','${billInfo.IdFood}','${billInfo.Quantity}','${billInfo.IdBill}')";
            int result = Convert.ToInt16(DBHelper.Instance.ExecuteNonQuery(query, null));

            return result > 0;
        }

        


        public int GetNumOrderBillInfo()
        {
            string query = "SELECT COUNT(dboSale_id) FROM dbo.DetailBillOfSale";

            int num = DBHelper.Instance.ExecuteScalar(query, null);
            if (num == null)
            {
                return 0;
            }
            return num;
        }



    }
}
