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
        private static BillImportController instance;
        public static BillImportController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BillImportController();
                }
                return instance;
            }
        }

        public int InsertBillImport(BillImport billImport)
        {
            string query = @"INSERT INTO BillOfImport
                              VALUES (@id,@daycreated,@supplier_id,@staff_id,@totalmoney)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImport.ID } ,
                {"@daycreated", billImport.DayCreated} ,
                {"@supplier_id", billImport.SupplierID} ,
                {"@staff_id", billImport.StaffID} ,
                {"@totalmoney", billImport.TotalMoney }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
                
        }
        public int UpdateBillImport(BillImport billImport)
        {
            string query = @"UPDATE dbo.BillOfImport
                            SET staff_id = @staff_id ,
                                supplier_id = @supplier_id ,
	                            dayCreate = @daycreated
                                WHERE boImport_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", billImport.ID } ,
                {"@daycreated", billImport.DayCreated} ,
                {"@supplier_id", billImport.SupplierID} ,
                {"@staff_id", billImport.StaffID} ,
                {"@totalmoney", billImport.TotalMoney }
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

            string query = $"SELECT * FROM BillOfImport WHERE boImport_id = '{id}'";

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

        public int GetOrderNumInList()
        {
            string query = $"SELECT COUNT(boImport_id) FROM BillOfImport";
            int orderNum = Convert.ToInt32(DBHelper.Instance.ExecuteScalar(query));
            return orderNum;
        }
    }
}
