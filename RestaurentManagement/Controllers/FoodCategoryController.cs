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
            string query = "SELECT * FROM Category";
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

            string query = $"SELECT * FROM Category WHERE category_id = '{id}'" ;

            DataTable data = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                name = item["category_name"].ToString();
                break;
            }

            return name;
        }

        public string GetIDCatgoryFoodByName(string name)
        {
            string id = null;

            string query = $"SELECT * FROM Category WHERE category_name = N'{name}'";

            DataTable data = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                id = item["category_id"].ToString();
                break;
            }

            return id;
        }

        public int InsertCategory(FoodCategory category)
        {
            string query = @"INSERT INTO dbo.Category
                             VALUES (@id,@name)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", category.ID },
                {"@name", category.Name }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateCategory(FoodCategory category)
        {
            string query = @"UPDATE dbo.FoodCategory 
                             SET category_name = @name 
                             WHERE catogory_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", category.ID },
                {"@name", category.Name }
            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteCategory(string id)
        {
            string query = "DELETE FROM dbo.Category WHERE category_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id }               
            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public List<FoodCategory> SearchCategory(string id)
        {
            List<FoodCategory> foodCategories = new List<FoodCategory>();   
            string query = $@"SELECT * FROM dbo.Category WHERE category_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                FoodCategory fg = new FoodCategory(item);
                foodCategories.Add(fg);
            }
            return foodCategories;
        }

        public int GetOrderNumInList()
        {
            string query = @"SELECT COUNT(category_id) FROM Category";
            int data = DBHelper.Instance.ExecuteScalar(query);
            return data;
        }
    }
}
