﻿using RestaurentManagement.Models;
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

        public int InsertCategory(FoodCategory category)
        {
            string query = @"INSERT INTO dbo.FoodCategory
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
                             SET cgFood_name = @name 
                             WHERE cgFood_id = @id";
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
            string query = "DELETE FROM dbo.FoodCategory WHERE cgFood_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id }               
            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public DataTable SearchCategory(string id)
        {
            string query = $@"SELECT * FROM dbo.FoodCategory WHERE cgFood_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}