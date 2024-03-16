using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Table
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Table(string id, string name, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;

        }
        public Table(DataRow row)
        {
            this.Id = (string)row["table_id"].ToString();
            this.Name = row["table_name"].ToString();
            this.Status = row["status"].ToString();
        }
        public Table() {  }
    }
}
