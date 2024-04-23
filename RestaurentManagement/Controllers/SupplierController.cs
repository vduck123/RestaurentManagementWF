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
    internal class SupplierController
    {
        private static SupplierController instance;
        public static SupplierController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SupplierController();
                }
                return instance;
            }
        }

        public int InsertSupplier(Supplier supplier)
        {
            string query = @"INSERT INTO Supplier
                             VALUES (@id,@name,@address,@phone,@note)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", supplier.ID} ,
                {"@name", supplier.Name} ,
                {"@address", supplier.Address} ,
                {"@phone", supplier.Phone} ,
                {"@note", supplier.Note} ,
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateSupplier(Supplier supplier)
        {
            string query = @"UPDATE Supplier
                             SET supplier_name = @name ,
                                 address = @address ,
                                 phone = @phone ,
                                 note = @note 
                             WHERE supplier_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", supplier.ID} ,
                {"@name", supplier.Name} ,
                {"@address", supplier.Address} ,
                {"@phone", supplier.Phone} ,
                {"@note", supplier.Note} ,
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteSupplier(string id)
        {
            string query = @"DELETE FROM Supplier WHERE supplier_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public List<Supplier> SelectSupplierByParam(string option, string param, string opera)
        {
            List<Supplier> suppliers = new List<Supplier>();
            string query = $"SELECT * FROM Supplier WHERE {option} {opera} N'{param}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Supplier supplier = new Supplier(row);
                suppliers.Add(supplier);
            }

            return suppliers;

        }

        public List<Supplier> GetListSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();
            string query = "SELECT * FROM Supplier";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Supplier supplier = new Supplier(row);
                suppliers.Add(supplier);
            }

            return suppliers;
        }

        public string GetNameSupplierByID(string id)
        {
            string nameSupplier = null;
            string query = $"SELECT * FROM Supplier WHERE supplier_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                nameSupplier = row["supplier_name"].ToString();
            }
            return nameSupplier;
        }

        public string GetIDSupplierByName(string name)
        {
            string id = null;
            string query = $"SELECT * FROM Supplier WHERE supplier_name = N'{name}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                id = row["supplier_id"].ToString();
            }
            return id;
        }

        public int GetOrderNumInList()
        {
            string query = $"SELECT COUNT(supplier_id) FROM Supplier";
            int orderNum = Convert.ToInt32(DBHelper.Instance.ExecuteScalar(query));
            return orderNum;
        }
    }
}
