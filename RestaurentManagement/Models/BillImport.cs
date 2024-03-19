using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class BillImport
    {
        public string ID { get; set; }
        public string FoodID { get; set; }    
        public int Price { get; set; }

        public int Quantity { get; set; }
        public DateTime DayCreated { get; set; }

        public string SupplierID { get; set; }
        public int TotalMoney { get; set; }

        public BillImport() { }

        public BillImport(string iD, string foodID, int price, int quantity, DateTime dayCreated, string supplierID, int totalMoney)
        {
            ID = iD;
            FoodID = foodID;
            Price = price;
            Quantity = quantity;
            DayCreated = dayCreated;
            SupplierID = supplierID;
            TotalMoney = totalMoney;
        }

        public BillImport(DataRow row)
        {
            ID = (string)row["boImport_id"];
            FoodID = (string)row["food_id"];
            Price = (int)row["price"];
            Quantity = (int)row["quantity"];
            DayCreated = (DateTime)row["dayCreate"];
            SupplierID = (string)row["supplier_id"];
            TotalMoney = (int)row["total_money"];
          
        }
    }
}
