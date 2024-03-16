using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Controllers
{
    internal class FoodCategoryController
    {
        private static FoodCategoryController instance;

        public static FoodCategoryController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodCategoryController();
                }
                return instance;
            }
        }

        public List<FoodCategory> GetListCategoryFood()
        {
            List<FoodCategory> foodCategories = new List<FoodCategory>();
            string query = "SELECT * FROM FoodCategory";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach(DataRow dr in dt.Rows)
            {
                FoodCategory fcg = new FoodCategory(dr);
                foodCategories.Add(fcg);
            }
            return foodCategories;
        }

        public string GetNameCatgoryFoodByID(string id)
        {
            string name = null;

            string query = $"SELECT * FROM FoodCategory WHERE cgFood_id = '{id}'" ;

            DataTable data = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                name = item["cgFood_name"].ToString();
                break;
            }

            return name;
        }
    }
}
