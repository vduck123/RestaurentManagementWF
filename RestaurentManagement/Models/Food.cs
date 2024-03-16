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
        public string FoodType;
        public Food(string id, string name, int price, string foodType)
        {
            this.ID = id;
            this.Name = name;
            Price = price;
            FoodType = foodType;
        }

        public Food(DataRow row)
        {
            this.ID = row["food_id"].ToString();
            this.Name = row["food_name"].ToString();
            this.Price = (int)row["food_price"];
            this.FoodType = row["cgFood_id"].ToString();
        }



    }
}
