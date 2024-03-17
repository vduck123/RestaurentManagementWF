using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Staff
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birth {  get; set; }

        public string Phone {  get; set; }

        public string Acc_ID { get; set; }

        public Staff() { }

        public Staff(string iD, string name, string gender, DateTime birth, string phone, string acc_ID)
        {
            ID = iD;
            Name = name;
            Gender = gender;
            Birth = birth;
            Phone = phone;
            Acc_ID = acc_ID;
        }

        public Staff(DataRow row)
        {
            ID = (string)row["staff_id"];
            Name = (string)row["staff_name"];
            Gender = (string)row["gender"];
            Birth = (DateTime)row["birth"];
            Phone = (string)row["phone"];
            Acc_ID = (string)row["acc_id"];
        }
    }
}
