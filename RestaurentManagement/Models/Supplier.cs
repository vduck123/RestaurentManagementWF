using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Supplier
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address {  get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }

        public Supplier() { }

        public Supplier(string iD, string name, string address, string phone, string note)
        {
            ID = iD;
            Name = name;
            Address = address;
            Phone = phone;
            Note = note;
        }

        public Supplier(DataRow row)
        {
            ID = (string)row["supplier_id"];
            Name = (string)row["supplier_name"];
            Address = (string)row["address"];
            Phone = (string)row["phone"];
            Note = (string)row["note"];
        }
    }
}
