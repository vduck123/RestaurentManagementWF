using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Voucher
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Expiry { get; set; }
        public string Status { get; set; }

        public Voucher() { }
        public Voucher(string iD, string name, string expiry, string status)
        {
            ID = iD;
            Name = name;
            Expiry = expiry;
            Status = status;
        }   

        public Voucher(DataRow row)
        {
            ID = (string)row["voucher_id"];
            Name = (string)row["voucher_name"];
            Expiry = (string)row["voucher_expiry"];
            Status = (string)row["status"];
        }
    }
}
