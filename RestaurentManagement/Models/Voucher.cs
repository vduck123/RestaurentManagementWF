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
        public int Expiry { get; set; }
        public string Status { get; set; }

        public Voucher() { }
        public Voucher(string iD, string name, int expiry, string status)
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
            Expiry = (int)row["voucher_expiry"];
            Status = (string)row["status"];
        }
    }
}
