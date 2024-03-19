using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class BillImport
    {
        public string ID { get; set; }
        public DateTime DayCreated { get; set; }

        public string SupplierID { get; set; }
        public string StaffID { get; set; }
        public int TotalMoney { get; set; }

        public BillImport() { }

        public BillImport(string iD, DateTime dayCreated, string supplierID, string staffID, int totalMoney)
        {
            ID = iD;
            DayCreated = dayCreated;
            SupplierID = supplierID;
            StaffID = staffID;
            TotalMoney = totalMoney;
        }

        public BillImport(DataRow row)
        {
            ID = (string)row["boImport_id"];
            DayCreated = (DateTime)row["dayCreate"];
            SupplierID = (string)row["supplier_id"];
            StaffID = (string)row["staff_id"];
            TotalMoney = (int)row["total_money"];          
        }

        
    }
}
