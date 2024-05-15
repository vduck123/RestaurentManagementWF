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
                              VALUES (@dboSaleId,@foodId,@quantity,@foodPrice,@total,@boSaleId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@dboSaleId", billInfo.ID} ,
                {"@foodId", billInfo.foodId } ,
                {"@quantity", billInfo.Quantity } ,
                {"@foodPrice", billInfo.foodPrice } ,
                {"@total", billInfo.Total } ,
                {"@boSaleId", billInfo.boSaleId }
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs ;
        }

        public int UpdateBillSaleInfo(BillSaleInfo billInfo)
        {
            string query = $@"UPDATE DetailBillOfSale 
                                SET food_id = @foodId ,
                                    food_quantity = @quantity ,
                                    food_price = @foodPrice ,
                                    food_total = @total ,
                              WHERE dboSale_id = @dboSaleId";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@dboSaleId", billInfo.ID } ,
                {"@foodId", billInfo.foodId } ,
                {"@quantity", billInfo.Quantity } ,
                {"@foodPrice", billInfo.foodPrice } ,
                {"@total", billInfo.Total } ,
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }

        public int UpdateBillSaleInfoWithChangeFood(BillSaleInfo billInfo)
        {
            string query = $@"UPDATE DetailBillOfSale 
                                SET food_quantity = @quantity ,
                                    food_price = @foodPrice ,
                                    food_total = @total 
                              WHERE boSale_id = @boSaleId AND food_id = @foodId";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@boSaleId", billInfo.boSaleId } ,
                {"@foodId", billInfo.foodId } ,
                {"@quantity", billInfo.Quantity } ,
                {"@foodPrice", billInfo.foodPrice } ,
                {"@total", billInfo.Total } 
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }

        public int AutoUpdateTotalBill()
        {
            string query3 = @"UPDATE BillOfSale
                                SET totalMoney = (
                                SELECT SUM(food_total)
                                FROM DetailBillOfSale
                                WHERE DetailBillOfSale.boSale_id = BillOfSale.boSale_id
                                )";
            int data3 = DBHelper.Instance.ExecuteNonQuery(query3, null);
            return data3;
        }

        public int DeleteBillSaleInfo(string id)
        {
            string query = "DELETE FROM DetailBillOfSale WHERE boSale_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id",id }
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }

        public int DeleteBillSaleInfoByFoodIdAndBillId(string foodid, string billid)
        {
            string query = "DELETE FROM DetailBillOfSale WHERE boSale_id = @billID AND food_id = @foodId";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@billID", billid } ,
                {"@foodId", foodid }
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
            string query = $"SELECT * FROM DetailBillOfSale WHERE boSale_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                BillSaleInfo b = new BillSaleInfo(item);
                billSaleInfos.Add(b);
            }
            return billSaleInfos;
        }

        public List<BillSaleInfo> GetBillSaleInfosByFoodIdAndBillID(string idfood, string billId)
        {
            List<BillSaleInfo> billSaleInfos = new List<BillSaleInfo>();
            string query = $"SELECT * FROM DetailBillOfSale WHERE boSale_id = '{billId}' AND food_id = '{idfood}'";
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
