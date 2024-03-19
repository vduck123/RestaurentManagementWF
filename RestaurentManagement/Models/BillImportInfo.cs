using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class BillImportInfo
    {
        public string ID { get; set; }
        public string FoodID { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }
        public int TotalMoney { get; set; }
        public string BillID { get; set; }

        public BillImportInfo() { }

        public BillImportInfo(string iD, string foodID, int price, int quantity, int totalMoney, string billID)
        {
            ID = iD;
            FoodID = foodID;
            Price = price;
            Quantity = quantity;
            TotalMoney = totalMoney;
            BillID = billID;
        }

        public BillImportInfo(DataRow row)
        {
            ID = (string)row["dboImport_id"];
            FoodID = (string)row["food_id"];
            Price = (int)row["price"];
            Quantity = (int)row["quantity"];
            TotalMoney = (int)row["total_money"];
            BillID = (string)row["boImport_id"];
        }
    }
}
