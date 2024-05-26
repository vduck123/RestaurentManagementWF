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

        public string Unit { get; set; }

        public Warehouse() { }

        public Warehouse(string iD, string name, int quantity, string unit)
        {
            ID = iD;
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public Warehouse(DataRow row)
        {
            ID = (string)row["material_id"];
            Name = (string)row["material_name"];
            Quantity = (int)row["quantity"];
            Unit = (string)row["unit"];
        }
    }
}
