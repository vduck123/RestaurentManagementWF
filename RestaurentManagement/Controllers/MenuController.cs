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
    internal class MenuController
    {
        private static MenuController instance;
        public static MenuController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuController();
                }
                return instance;
            }
        }
        public int InsertMenu(Menu menu)
        {
            string query1 = @"INSERT INTO Menu
                              VALUES (@food_id,@price,@quantity,@total,@table_id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@food_id",menu.foodID} ,
                {"price", menu.Price} ,
                {"@quantity", menu.Quantity } ,
                {"@total", menu.Total} ,
                {"@table_id", menu.tableID}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query1, parameters);
            return data;
        }

        public int DeleteMenu(string tableID)
        {
            string query1 = @"DELETE FROM Menu WHERE table_id = @tableID";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@tableID", tableID}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query1, parameters);
            return data;

        }

        public List<Menu> GetMenuByTableID(string id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = $@"SELECT * FROM Menu WHERE table_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Menu menu = new Menu(row);
                listMenu.Add(menu);
            }
            return listMenu;
        }

        public int UpdateMenu(Menu menu)
        {
            string query = @"UPDATE Menu
                            SET quantity = @quantity ,
                                total = @total
                            WHERE food_id = @food_id AND table_id = @table_id";
            Dictionary<string, object> paramaters = new Dictionary<string, object>
            {
                {"@table_id", menu.tableID },               
                {"@food_id", menu.foodID } ,
                {"@quantity", menu.Quantity } ,
                {"@total", menu.Total }
            };
            int rs = DBHelper.Instance.ExecuteNonQuery(query, paramaters);
            return rs;
        }

        public int DeleteFoodFromMenu(string foodId, string tableId)
        {
            string query = @"DELETE FROM Menu WHERE food_id = @foodId AND table_id = @tableId";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@foodId", foodId} ,
                {"@tableId", tableId }
            };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }
    }
}
