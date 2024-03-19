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
    internal class BillImportController
    {
        private static BillController instance;
        public static BillController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BillController();
                }
                return instance;
            }
        }

        public int InsertBillImport(BillImport billImport)
        {
            string query = @"INSERT INTO BillOfImport
                              VALUES (@id,@food_id,@price,@quantity,@daycreated,@supplier_id,@totalmoney)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImport.ID } ,
                {"@food_id", billImport.FoodID} ,
                {"@price", billImport.Price } ,
                {"@quantity", billImport.Quantity} ,
                {"@daycreated", billImport.DayCreated} ,
                {"@supplier_id", billImport.SupplierID} ,
                {"@totalmoney", billImport.TotalMoney }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
                
        }
        public int UpdateBillImport(BillImport billImport)
        {
            string query = @"UPDATE dbo.BillOfImport
                            SET food_id = @food_id ,
	                            price = @price,
	                            quantity = @quantity ,
	                            dayCreate = @daycreated
                                WHERE boImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImport.ID } ,
                {"@food_id", billImport.FoodID} ,
                {"@price", billImport.Price } ,
                {"@quantity", billImport.Quantity} ,
                {"@daycreated", billImport.DayCreated} 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }
        public int DeleteBillImport(string id)
        {
            string query = @"DELETE FROM BillOfImport WHERE boImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;

        }

        public List<BillImport> SelectBillImportByID(string id)
        {
            List<BillImport> listbillImport = new List<BillImport> ();

            string query = $"SELECT * FROM BillOfImport WHERE boImport_id = {id}";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImport billImport = new BillImport(item);
                listbillImport.Add(billImport);
            }
            return listbillImport;
        }

        public List<BillImport> GetListBillImport()
        {
            List<BillImport> listbillImport = new List<BillImport>();

            string query = $"SELECT * FROM BillOfImport";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                BillImport billImport = new BillImport(item);
                listbillImport.Add(billImport);
            }
            return listbillImport;
        }
    }
}
