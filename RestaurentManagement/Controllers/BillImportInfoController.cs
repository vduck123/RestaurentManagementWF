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
                              VALUES (@id,@item_id,@price,@quantity,@unit,@totalmoney,@idBill)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImportInfo.ID } ,
                {"@item_id", billImportInfo.ItemID } ,
                {"@price", billImportInfo.Price } ,
                {"@quantity", billImportInfo.Quantity } ,
                {"@unit", billImportInfo.Unit },
                {"@totalmoney", billImportInfo.TotalMoney } ,
                {"@idBill", billImportInfo.BillID } 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }
        public int UpdateBillImportInfo(BillImportInfo billImportInfo)
        {
            string query = @"UPDATE dbo.DetailBillOfImport
                            SET material_id = @item_id ,
                                price = @price ,
                                quantity = @quantity ,
                                unit = @unit ,
	                            total_money = @totalmoney
                                WHERE dboImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImportInfo.ID } ,
                {"@item_id" , billImportInfo.ItemID } ,
                {"@price", billImportInfo.Price } ,
                {"@quantity", billImportInfo.Quantity } ,
                {"@unit", billImportInfo.Unit },
                {"@totalmoney", billImportInfo.TotalMoney } 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }

        public int DeleteAll(string id)
        {
            string query = @"DELETE FROM DetailBillOfImport WHERE boImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteBillImportInfoByMaterialID(string idItem, string idBill)
        {
            string query = @"DELETE FROM DetailBillOfImport WHERE material_id = @iditem AND boImport_id = @idbill ";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@iditem", idItem },
                {"@idbill", idBill }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }
     

        public List<BillImportInfo> SelectBillImportInfoByID(string id)
        {
            List<BillImportInfo> list = new List<BillImportInfo>();

            string query = $"SELECT * FROM DetailBillOfImport WHERE dboImport_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImportInfo bill = new BillImportInfo(item);
                list.Add(bill);
            }
            return list;
        }

        public List<BillImportInfo> GetAllBillImportInfoByBillImportID(string id)
        {
            List<BillImportInfo> list = new List<BillImportInfo>();

            string query = $"SELECT * FROM DetailBillOfImport WHERE boImport_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImportInfo bill = new BillImportInfo(item);
                list.Add(bill);
            }
            return list;
        }

        public List<BillImportInfo> GetBillImportByParam(string option, string param, string opera)
        {
            List<BillImportInfo> list = new List<BillImportInfo>();

            string query = $"SELECT * FROM DetailBillOfImport WHERE {option} {opera} {param}";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImportInfo bill = new BillImportInfo(item);
                list.Add(bill);
            }
            return list;
        }

        public List<BillImportInfo> GetBillImportByMaterialAndIDBill(string iditem, string idBill)
        {
            List<BillImportInfo> list = new List<BillImportInfo>();

            string query = $"SELECT * FROM DetailBillOfImport WHERE material_id = '{iditem}' AND boImport_id = '{idBill}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImportInfo bill = new BillImportInfo(item);
                list.Add(bill);
            }
            return list;
        }


        public List<BillImport> GetListBillImportInfo()
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

        public int UpdateQuantityItem(string id, int quantity)
        {
            string query = $@"UPDATE dbo.DetailBillOfImport
                              SET quantity = quantity + @quantity
                              WHERE material_id = @id";

            string query2 = @"UPDATE dbo.DetailBillOfImport
                              SET total_money = quantity * price";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id } ,
                {"@quantity", quantity } 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            int data2 = DBHelper.Instance.ExecuteNonQuery(query2, null);
            return data;
        }

        public int UpdateItem(string itemID, int quantity, int price, string billID)
        {
            string query = $@"UPDATE dbo.DetailBillOfImport
                              SET quantity = @quantity ,
                                  price = @price
                              WHERE material_id = @itemid AND boImport_id = @idBill";

            string query2 = @"UPDATE dbo.DetailBillOfImport
                              SET total_money = quantity * price";

            

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@itemid", itemID } ,
                {"@idBill", billID } ,
                {"@quantity", quantity } ,
                {"@price", price }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            int data2 = DBHelper.Instance.ExecuteNonQuery(query2, null);
            return data;
        }

        public int UpdateMoneyBillImport()
        {
            string query3 = @"UPDATE BillOfImport
                                SET total_money = (
                                SELECT SUM(total_money)
                                FROM DetailBillOfImport
                                WHERE DetailBillOfImport.boImport_id = BillOfImport.boImport_id 
                                )";
            int data3 = DBHelper.Instance.ExecuteNonQuery(query3, null);
            return data3;
        }


    }
}
