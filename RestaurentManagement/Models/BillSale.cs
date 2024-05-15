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
        public string voucherId { get; set; }

        public double totalMoney { get; set; }
        public string staffID { get; set; }
        public string tableID { get; set; }
        
        public BillSale() { }

        public BillSale(string id, DateTime dayin, DateTime dayout, string voucherid, double totalmoney, string staffid, string tableid)
        {
            this.Id = id;
            this.dayIn = dayin;
            this.dayOut = dayout;
            this.voucherId = voucherid;
            this.totalMoney = totalmoney;
            this.staffID = staffid;
            this.tableID = tableid;
        }

        public BillSale(DataRow row)
        {
            this.Id = row["boSale_id"].ToString();
            this.dayIn = row["dayIn"] != DBNull.Value ? (DateTime)row["dayIn"] : DateTime.MinValue;
            this.dayOut = row["dayOut"] != DBNull.Value ? (DateTime)row["dayOut"] : DateTime.MinValue;
            this.voucherId = row["voucher_id"] != DBNull.Value ? row["voucher_id"].ToString() : string.Empty;
            this.totalMoney = row["totalMoney"] != DBNull.Value ? Convert.ToDouble(row["totalMoney"]) : 0;
            this.staffID = row["staff_id"] != DBNull.Value ? row["staff_id"].ToString() : string.Empty;
            this.tableID = row["table_id"] != DBNull.Value ? row["table_id"].ToString() : string.Empty;
        }



    }
}
