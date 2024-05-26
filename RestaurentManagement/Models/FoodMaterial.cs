using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class FoodMaterial
    {
        public string materialID { get; set;}
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string foodID { get; set; }


        public FoodMaterial() { }
        public FoodMaterial(string materialID, int quantity, string unit, string foodID)
        {
            this.materialID = materialID;
            this.Quantity = quantity;
            this.Unit = unit;
            this.foodID = foodID;
        }

        public FoodMaterial(DataRow row)
        {
            this.materialID = row["material_id"].ToString();
            this.Quantity = Convert.ToInt32(row["quantity"]);
            this.Unit = row["unit"].ToString();
            this.foodID = row["food_id"].ToString();
        }
    }
}
