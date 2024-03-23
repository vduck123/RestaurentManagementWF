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
                              VALUES (@food_id,@price,@quantity,@total,@totalTable,@table_id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@food_id",menu.FoodID} ,
                {"price", menu.priceFood } ,
                {"@quantity", menu.Quantity } ,
                {"@total", menu.totalFood} ,
                {"@totalTable", menu.totalMoney} ,
                {"@table_id", menu.TableID }

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

        public List<Menu> GetListBillInfoByTableID(string id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = @"SELECT f.food_name, f.food_price , dbos.food_quantity, bos.totalMoney
                                FROM Food f 
                                INNER JOIN dbo.DetailBillOfSale dbos ON dbos.food_id = f.food_id
                                INNER JOIN dbo.BillOfSale bos ON bos.boSale_id = dbos.boSale_id
                                INNER JOIN dbo._TABLE t ON t.table_id = bos.table_id
                                WHERE t.table_id = @id";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Menu menu = new Menu(row);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
