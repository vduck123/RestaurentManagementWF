using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class FoodCategory
    {
        public string Name;
        public string ID;
        public FoodCategory(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public FoodCategory(DataRow row)
        {
            this.ID = row["cgFood_id"].ToString();
            this.Name = row["cgFood_name"].ToString();
        }

        

        
    }
}
