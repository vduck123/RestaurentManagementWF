using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurentManagement.Models
{
    internal class Menu
    {
        public string FoodID {  get; set; }   

        public int Quantity { get; set; }
        public int priceFood { get; set; }
        public int totalFood { get; set; }

        public int totalMoney {  get; set; }
        public string TableID { get; set; }

        public Menu(string id, int quantity,  int price, int totalfood, int totalmoney, string tableID)
        {
            FoodID = id;
            Quantity = quantity;
            priceFood = price;
            totalFood = totalfood;
            totalMoney = totalmoney;
            TableID = tableID;
        }
        public Menu(DataRow row)
        {
            this.FoodID = row["food_id"].ToString();
            this.priceFood = Convert.ToInt32(row["food_price"]);
            this.Quantity = Convert.ToInt32(row["food_quantity"]);
            this.totalFood = Convert.ToInt32(row["total"]);
            this.totalMoney = Convert.ToInt32(row["totalMoney"]);
            this.TableID = row["table_id"].ToString();
        }


    }
}
