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
            this.ID = row["salary_id"].ToString();
            this.Month = (DateTime)row["salary_month"];
            this.salaryBasic = Convert.ToInt32(row["salary_basic"]);
            this.hsl = Convert.ToDouble(row["hsl"]);
            this.salaryHour = Convert.ToInt32(row["salary_hour"]);
            this.numHour = Convert.ToDouble(row["num_hour"]);
            this.Bonus = Convert.ToInt32(row["bonus"]);
            this.Fine = Convert.ToInt32(row["fine"]);
            this.Total = Convert.ToDouble(row["total"]);
            this.staffID = row["staff_id"].ToString();
        }


    }
}
