﻿using RestaurentManagement.Models;
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
    internal class BillSaleInfoController
    {
        private static BillSaleInfoController instance;
        public static BillSaleInfoController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillSaleInfoController();
                }
                return instance;
            }
        }

        public int InsertBillSaleInfo(BillSaleInfo billInfo)
        {
            string query = $@"INSERT INTO DetailBillOfSale 
                              VALUES (@dboSaleId,@foodId,@quantity,@foodPrice,@total,@voucherId,@boSaleId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@dboSaleId", billInfo.ID} ,
                {"@foodId", billInfo.foodId } ,
                {"@quantity", billInfo.Quantity } ,
                {"@foodPrice", billInfo.foodPrice } ,
                {"@total", billInfo.Total } ,
                {"@voucherId", billInfo.voucherId } ,
                {"@boSaleId", billInfo.boSaleId }
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs ;
        }

        public int UpdateBillSaleInfo(BillSaleInfo billInfo)
        {
            string query = $@"INSERT INTO DetailBillOfSale 
                                SET food_id = @foodId ,
                                    food_quantity = @quantity ,
                                    food_price = @foodPrice ,
                                    food_total = @total ,
                                    voucher_id = @voucherId
                              WHERE dboSale_id = @dboSaleId";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@dboSaleId", billInfo.ID } ,
                {"@foodId", billInfo.foodId } ,
                {"@quantity", billInfo.Quantity } ,
                {"@foodPrice", billInfo.foodPrice } ,
                {"@total", billInfo.Total } ,
                {"@voucherId", billInfo.voucherId } 
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }

        public int DeleteBillSaleInfo(string id)
        {
            string query = "DELETE FROM DetailBillOfSale WHERE boSale_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@dboSaleId",id }
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }

        public int DeleteAll()
        {
            string query = "DELETE FROM DetailBillOfSale";
            int rs = DBHelper.Instance.ExecuteNonQuery(query, null);
            return rs;
        }

        public List<BillSaleInfo> GetBillSaleInfoById(string id)
        {
            List<BillSaleInfo> billSaleInfos = new List<BillSaleInfo>();
            string query = $"SELECT * FROM DetailBillOfSale WHERE dboSale_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                BillSaleInfo b = new BillSaleInfo(item);
                billSaleInfos.Add(b);
            }
            return billSaleInfos;
        }


        public int GetNumOrderBillInfo()
        {
            string query = "SELECT COUNT(dboSale_id) FROM dbo.DetailBillOfSale";

            int num = DBHelper.Instance.ExecuteScalar(query);
            if (num == null)
            {
                return 0;
            }
            return num;
        }



    }
}