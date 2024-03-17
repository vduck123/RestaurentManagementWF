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
    internal class FoodController
    {
        private static FoodController instance;

        public static FoodController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodController();
                }
                return instance;
            }
        }

        public List<Food> GetListFood()
        {
            List<Food> listFood = new List<Food>();
            string query = @"SELECT * FROM Food";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Food f = new Food(dr);
                listFood.Add(f);
            }

            return listFood;

        }

        public List<Food> GetFoodByName(string name)
        {

            List<Food> list = new List<Food>();

            string query = $@"SELECT * FROM Food f WHERE f.food_name = N'{name}'";
            DataTable data = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public string GetIDFoodByName(string name)
        {
            string idFood = null;
            string query = $@"SELECT * FROM Food f WHERE f.food_name = N'{name}'";
            DataTable data = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                idFood = item["food_id"].ToString();
            }

            return idFood;
        }

        public string GetNameFoodByID(string id)
        {
            string nameFood = null;
            string query = $@"SELECT * FROM Food f WHERE f.food_id = N'{id}'";
            DataTable data = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                nameFood = item["food_name"].ToString();
            }

            return nameFood;
        }

        //
        public int InsertFood(Food food)
        {
            string query = @"INSERT INTO Food
                             VALUES (@id,@name,@price,@category)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", food.ID},
                {"@name", food.Name},
                {"price", food.Price},
                {"category", food.FoodType}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateFood(Food food)
        {
            string query = @"UPDATE dbo.Food
		                     SET food_name = @name ,
			                    food_price = @price 
		                     WHERE food_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", food.ID},
                {"@name", food.Name},
                {"price", food.Price}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query,parameters);

            return data;
        }

        public int DeleteFood(string id)
        {
            string query = "DELETE FROM dbo.Food WHERE food_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);

            return data;
        }

        public DataTable SelectFood(string id)
        {
            string query = $@"SELECT * FROM dbo.Food WHERE food_id = '{id}'";
            DataTable data = DBHelper.Instance.ExecuteQuery(query);
            return data;
        }
    }
}
