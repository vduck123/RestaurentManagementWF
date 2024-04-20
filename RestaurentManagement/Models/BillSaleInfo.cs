using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class BillSaleInfo
    {
        public string ID { get; set; }
        public string foodId { get; set; }
        public int Quantity { get; set; }
        public int foodPrice { get; set; }
        public int Total { get; set; }

        public string voucherId { get; set; }
        public string boSaleId { get; set; }    

        public BillSaleInfo() { }

        public BillSaleInfo(string iD, string foodId, int quantity, int foodprice, int total, string voucherId, string boSaleId)
        {
            this.ID = iD;
            this.foodId = foodId;
            this.Quantity = quantity;
            this.foodPrice = foodprice;
            this.Total = total;
            this.voucherId = voucherId;
            this.boSaleId = boSaleId;
        }

        public BillSaleInfo(DataRow row)
        {
            this.ID = (string)row["dboSale_id"];
            this.foodId = (string)row["food_id"];
            this.Quantity = (int)row["food_quantity"];
            this.foodPrice = (int)row["food_price"];
            this.Total = (int)row["food_total"]; ;
            this.voucherId = (string)row["voucher_id"];
            this.boSaleId = (string)row["BoSale_id"];
        }
    }
}
