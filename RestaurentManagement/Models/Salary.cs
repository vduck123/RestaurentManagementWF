using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Salary
    {
        public string ID { get; set; }
        public DateTime Month { get; set; }
        public int salaryBasic {  get; set; }
        public double hsl { get; set; }
        public int salaryHour { get; set; }
        public double numHour { get; set; }
        public int Bonus { get; set; }
        public int Fine { get; set; }
        public double Total { get; set; }
        public string staffID { get; set; }

        public Salary() { }

        public Salary(string iD, DateTime month, int salaryBasic, double hsl, int salaryHour, double numHour, int bonus, int fine, double total, string staffID)
        {
            this.ID = iD;
            this.Month = month;
            this.salaryBasic = salaryBasic;
            this.hsl = hsl;
            this.salaryHour = salaryHour;
            this.numHour = numHour;
            this.Bonus = bonus;
            this.Fine = fine;
            this.Total = total;
            this.staffID = staffID;
        }

        public Salary(DataRow row)
        {
            this.ID = (string)row["salary_id"];
            this.Month = (DateTime)row["salary_month"];
            this.salaryBasic = (int)row["salary_basic"];
            this.hsl = (double)row["hsl"]; ;
            this.salaryHour = (int)row["salary_hour"];
            this.numHour = (double)row["num_hour"]; ;
            this.Bonus = (int)row["bonus"]; ;
            this.Fine = (int)row["fine"]; ;
            this.Total = (double)row["total"]; ;
            this.staffID = (string)row["staff_id"]; ;
        }

    }
}
