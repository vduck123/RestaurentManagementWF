using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class BillInfo
    {
        public string Id { get; set; }
        public string IdFood { get; set; }
        public int Quantity { get; set; }
        public string IdBill { get; set; }

        public BillInfo() { }

        public BillInfo(string id, string idFood, int quantity, string idBill)
        {
            Id = id;
            IdFood = idFood;
            Quantity = quantity;
            IdBill = idBill;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (string)row["dboSale_id"];
            this.IdFood = (string)row["food_id"];
            this.Quantity = (int)row["food_quantity"];
            this.IdBill = (string)row["boSale_id"];
        }
    }
}
