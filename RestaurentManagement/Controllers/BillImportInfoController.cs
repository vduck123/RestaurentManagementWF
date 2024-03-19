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
    internal class BillImportInfoController
    {
        private static BillImportInfoController instance;
        public static BillImportInfoController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillImportInfoController();
                }
                return instance;
            }
        }

        public int InsertBillImportInfor(BillImportInfo billImportInfo)
        {
            string query = @"INSERT INTO DetailBillOfImport
                              VALUES (@id,@food_id,@price,@quantity,@totalmoney,@idBill)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImportInfo.ID } ,
                {"@food_id", billImportInfo.FoodID } ,
                {"@price", billImportInfo.Price } ,
                {"@quantity", billImportInfo.Quantity } ,
                {"@totalmoney", billImportInfo.TotalMoney } ,
                {"@idBill", billImportInfo.BillID } 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }
        public int UpdateBillImportInfo(BillImportInfo billImportInfo)
        {
            string query = @"UPDATE dbo.DetailBillOfImport
                            SET food_id = @staff_id ,
                                price = @supplier_id ,
                                quantity = @supplier_id ,
	                            totalmoney = @totalmoney
                                WHERE dboImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImportInfo.ID } ,
                {"@food_id", billImportInfo.FoodID } ,
                {"@price", billImportInfo.Price } ,
                {"@quantity", billImportInfo.Quantity } ,
                {"@totalmoney", billImportInfo.TotalMoney } 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }
        public int DeleteBillImportInfo(string id)
        {
            string query = @"DELETE FROM BillOfImport WHERE boImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }

        public List<BillImport> SelectBillImportInfo(string id)
        {
            List<BillImport> listbillImport = new List<BillImport>();

            string query = $"SELECT * FROM DetailBillOfImport WHERE boImport_id = {id}";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImport billImport = new BillImport(item);
                listbillImport.Add(billImport);
            }
            return listbillImport;
        }

        public List<BillImport> GetListBillImportInfot()
        {
            List<BillImport> listbillImport = new List<BillImport>();

            string query = $"SELECT * FROM DetailBillOfImport";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImport billImport = new BillImport(item);
                listbillImport.Add(billImport);
            }
            return listbillImport;
        }

        public int GetOrderNumBillImportInfo()
        {
            string query = $"SELECT COUNT(dboImport_id) FROM dbo.DetailBillOfImport";
            object orderNum = DBHelper.Instance.ExecuteScalar(query);
            return Convert.ToInt32(orderNum);

        }
    }
}
