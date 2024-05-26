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
        public string ID { get; set; }
        public string Name { get; set; }
        
        public int Price { get; set; }
        public string Unit { get; set; }
        public string categoryID { get; set; }
        public byte[] imageFood { get; set; }

        public Food()
        {

        }

        public Food(string id, string name, int price, string unit, string categoryid , byte[] imagefood)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Unit = unit;
            this.imageFood = imagefood;
            this.categoryID = categoryid;
        }

        public Food(DataRow row)
        {
            this.ID = row["food_id"].ToString();
            this.Name = row["food_name"].ToString();
            this.Price = Convert.ToInt32(row["food_price"]);
            this.Unit = row["unit"].ToString();
            this.categoryID = row["cgFood_id"].ToString();
            this.imageFood = (byte[])row["image"];
        }



    }
}
