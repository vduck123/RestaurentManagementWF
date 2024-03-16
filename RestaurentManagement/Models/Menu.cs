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
        public string nameFood {  get; set; }   

        public int Quantity { get; set; }
        public int priceFood { get; set; }

        public int totalMoney {  get; set; }

        public Menu(string name, int quantity,  int price, int totalmoney)
        {
            nameFood = name;
            Quantity = quantity;
            priceFood = price;
            totalMoney = totalMoney;
        }
        public Menu(DataRow row)
        {
            this.nameFood = row[""].ToString();
            this.Quantity = Convert.ToInt32(row[""]);
            this.priceFood= Convert.ToInt32(row[""]);
            this.totalMoney= Convert.ToInt32(row[""]);
        }


    }
}
