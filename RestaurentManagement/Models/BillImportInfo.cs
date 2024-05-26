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
        public string ItemID { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }
        public string Unit {  get; set; }
        public int TotalMoney { get; set; }
        public string BillID { get; set; }

        public BillImportInfo() { }

        public BillImportInfo(string iD, string itemID, int price, int quantity, string unit, int totalMoney, string billID)
        {
            this.ID = iD;
            this.ItemID = itemID;
            this.Price = price;
            this.Quantity = quantity;
            this.Unit = unit;
            this.TotalMoney = totalMoney;
            this.BillID = billID;
        }

        public BillImportInfo(DataRow row)
        {
            this.ID = (string)row["dboImport_id"];
            this.ItemID = (string)row["material_id"];
            this.Price = (int)row["price"];
            this.Quantity = (int)row["quantity"];
            this.Unit = (string)row["unit"];
            this.TotalMoney = (int)row["total_money"];
            this.BillID = (string)row["boImport_id"];
        }
    }
}
