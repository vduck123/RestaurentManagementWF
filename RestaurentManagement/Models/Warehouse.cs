using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Warehouse
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string CategoryID { get; set; }

        public Warehouse() { }

        public Warehouse(string iD, string name, int quantity, string categoryID)
        {
            ID = iD;
            Name = name;
            Quantity = quantity;
            CategoryID = categoryID;
        }

        public Warehouse(DataRow row)
        {
            ID = (string)row["item_id"];
            Name = (string)row["item_name"];
            Quantity = (int)row["quantity"];
            CategoryID = (string)row["item_category"];
        }
    }
}
