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
    internal class WarehouseController
    {
        private static WarehouseController instance;
        public static WarehouseController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new WarehouseController();
                }
                return instance;
            }
        }

        public int InsertItem(Warehouse item)
        {
            string query = $@"INSERT INTO Material
                              VALUES (@id,@name,@quantity,@unit)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", item.ID},
                {"@name", item.Name} ,
                {"@quantity", item.Quantity},
                {"@unit", item.Unit }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateItem(Warehouse item)
        {
            string query = $@"UPDATE Material 
                              SET material_name = @name ,
                                  quantity = @quantity ,
                                    unit = @unit 
                              WHERE material_id = @id";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", item.ID},
                {"@name", item.Name} ,
                {"@quantity", item.Quantity},
                {"@unit", item.Unit }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteItem(string id)
        {
            string query = $@"DELETE FROM Material WHERE material_id = @id";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public List<Warehouse> SelectItemByID(string id)
        {
            List<Warehouse> listItem = new List<Warehouse>();

            string query = $"SELECT * FROM Material WHERE material_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                Warehouse item = new Warehouse(row);
                listItem.Add(item);

            }
            return listItem;
        }

        public List<Warehouse> SelectItemByParam(string option, string param, string opera)
        {
            List<Warehouse> listItem = new List<Warehouse>();

            string query = $"SELECT * FROM Material WHERE {option} {opera} {param}";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                Warehouse item = new Warehouse(row);
                listItem.Add(item);

            }
            return listItem;
        }


        public List<Warehouse> GetListItem()
        {
            List<Warehouse> listItem = new List<Warehouse>();

            string query = $"SELECT * FROM Material ORDER BY material_name";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                Warehouse item = new Warehouse(row);
                listItem.Add(item);

            }
            return listItem;
        }

        public int UpdateQuantityItemByName(string name, string opera, int quantity)
        {
            string query = $@"UPDATE Material 
                              SET quantity = quantity {opera} @quantity 
                              WHERE material_name = @name";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@name", name},
                {"@quantity", quantity }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public string GetUnitMaterialById(string id)
        {
            string unit = null;

            string query = $"SELECT * FROM Material WHERE material_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                unit = (string)row["unit"];
            }
            return unit;
        }

        public string GetNameItemByID(string id)
        {
            string name = null;

            string query = $"SELECT * FROM Material WHERE material_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                name = (string)row["material_name"];
            }
            return name;
        }

        public string GetIDItemByName(string name)
        {
            string id = null;

            string query = $"SELECT * FROM Material WHERE material_name = N'{name}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                id = (string)row["material_id"];
            }
            return id;
        }

        public int GetOrderNumInList()
        {
            string query = $"SELECT COUNT(material_id) FROM Material";
            int orderNum = Convert.ToInt32(DBHelper.Instance.ExecuteScalar(query));
            return orderNum;
        }

        public int CheckExitItem(string itemID, string billId)
        {
            string query = $"SELECT COUNT(*) FROM dbo.DetailBillOfImport WHERE material_id= N'{itemID}' AND boImport_id = N'{billId}'";
            int data = DBHelper.Instance.ExecuteScalar(query);
            return data;
        }

        public int GetQuantityItemByID(string id)
        {
            int quantity = 0;

            string query = $"SELECT * FROM Material WHERE material_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                quantity = Convert.ToInt32(row["quantity"]);
            }
            return quantity;
        }
    }
}
