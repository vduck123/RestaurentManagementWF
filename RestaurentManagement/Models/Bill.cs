using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Bill
    {
        public string Id { get; set; }
        public DateTime dayIn {  get; set; }
        public DateTime dayOut { get; set; }

        public int totalMoney { get; set; }
        public string tableID { get; set; }
        
        public Bill() { }

        public Bill(string id, DateTime dayin, DateTime dayout, int totalmoney, string tableid)
        {
            this.Id = id;
            this.dayIn = dayin;
            this.dayOut = dayout;
            this.totalMoney = totalmoney;
            this.tableID = tableid;
        }

        public Bill(DataRow row)
        {
            this.Id = (string)row["boSale_id "];
            this.dayIn = (DateTime)row["dayIn"];
            this.dayOut = (DateTime)row["dayOut"];
            this.totalMoney = (int)row["totalMoney"];
            this.tableID = (string)row["table-id"];
        }

    }
}
