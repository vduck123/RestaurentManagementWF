using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class BillSale
    {
        public string Id { get; set; }
        public DateTime dayIn {  get; set; }
        public DateTime dayOut { get; set; }

        public double totalMoney { get; set; }
        public string staffID { get; set; }
        public string tableID { get; set; }
        
        public BillSale() { }

        public BillSale(string id, DateTime dayin, DateTime dayout, double totalmoney, string staffid, string tableid)
        {
            this.Id = id;
            this.dayIn = dayin;
            this.dayOut = dayout;
            this.totalMoney = totalmoney;
            this.staffID = staffid;
            this.tableID = tableid;
        }

        public BillSale(DataRow row)
        {
            this.Id = (string)row["boSale_id "];
            this.dayIn = (DateTime)row["dayIn"];
            this.dayOut = (DateTime)row["dayOut"];
            this.totalMoney = (double)row["totalMoney"];
            this.staffID = (string)row["staff_id"];
            this.tableID = (string)row["table_id"];
        }

    }
}
