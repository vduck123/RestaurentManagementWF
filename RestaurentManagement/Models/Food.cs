using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Models
{
    internal class Food
    {
        public string Name;
        public string ID;
        public int Price;
        public string materialID;
        public int numMaterial;
        public string categoryID;

        public Food()
        {

        }

        public Food(string id, string name, int price, string materialid, int nummaterial, string categoryid )
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.materialID = materialid;
            this.numMaterial = nummaterial;
            this.categoryID = categoryid;
        }

        public Food(DataRow row)
        {
            this.ID = row["food_id"].ToString();
            this.Name = row["food_name"].ToString();
            this.Price = (int)row["food_price"];
            this.materialID = (string)row["item_id"];
            this.numMaterial = (int)row["item_quantity"];
            this.categoryID = row["cgFood_id"].ToString();
        }



    }
}
