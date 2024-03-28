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
            string query = $@"INSERT INTO Warehouse 
                              VALUES (@id,@name,@quantity,@categoryID)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", item.ID},
                {"@name", item.Name} ,
                {"@quantity", item.Quantity} ,
                {"@categoryID", item.CategoryID }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateItem(Warehouse item)
        {
            string query = $@"UPDATE Warehouse 
                              SET item_name = @name ,
                                  quantity = @quantity ,
                                  item_category = @category
                              WHERE item_id = @id";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", item.ID},
                {"@name", item.Name} ,
                {"@quantity", item.Quantity} ,
                {"@category", item.CategoryID }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteItem(string id)
        {
            string query = $@"DELETE FROM Warehouse WHERE item_id = @id";

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

            string query = $"SELECT * FROM Warehouse WHERE item_id = '{id}'";

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

            string query = $"SELECT * FROM Warehouse";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                Warehouse item = new Warehouse(row);
                listItem.Add(item);

            }
            return listItem;
        }

        public string GetNameItemByID(string id)
        {
            string name = null;

            string query = $"SELECT * FROM Warehouse WHERE item_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                name = (string)row["item_name"];
            }
            return name;
        }

        public string GetIDItemByName(string name)
        {
            string id = null;

            string query = $"SELECT * FROM Warehouse WHERE item_name = N'{name}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                id = (string)row["item_id"];
            }
            return id;
        }
    }
}
