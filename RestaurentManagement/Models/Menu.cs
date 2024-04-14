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
        public string foodID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total{ get; set; }

        public string tableID { get; set; }


        public Menu() { }

        public Menu(string foodID, int quantity, int price, int total, string tableID)
        {
            this.foodID = foodID;
            this.Quantity = quantity;
            this.Price = price;
            this.Total = total;
            this.tableID = tableID;
        }

        public Menu(DataRow row)
        {
            this.foodID = (string)row["food_id"];
            this.Price = (int)row["food_price"];
            this.Quantity = (int)row["quantity"];
            this.Total = (int)row["total"];
            this.tableID = (string)row["table_id"];
        }


    }
}
