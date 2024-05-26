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
    internal class FoodMateialController
    {
        private static FoodMateialController instance;
        public static FoodMateialController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodMateialController();
                }
                return instance;
            }
        }

        public int InsertFoodMaterial(FoodMaterial foodMaterial)
        {
            string query = @"INSERT INTO FoodMaterial
                              VALUES (@materialID,@quantity,@unit,@foodID)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@materialID", foodMaterial.materialID } ,
                {"@quantity", foodMaterial.Quantity } ,
                {"@unit", foodMaterial.Unit } ,
                {"@foodID", foodMaterial.foodID }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateFoodMaterial(FoodMaterial foodMaterial)
        {
            string query = @"UPDATE dbo.FoodMaterial
                            SET quantity = @quantity ,
                                unit = @unit
                                WHERE material_id = @materialID AND food_id = @foodID";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@materialID", foodMaterial.materialID } ,
                {"@quantity", foodMaterial.Quantity } ,
                {"@unit", foodMaterial.Unit } ,
                {"@foodID", foodMaterial.foodID }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }   

        public int DeleteFoodMaterial(string materialID, string foodID)
        {
            string query = @"DELETE FROM dbo.FoodMaterial
                            WHERE material_id = @materialID AND food_id = @foodID";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@materialID", materialID } ,
                {"@foodID", foodID }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }
        public int DeleteFoodMaterialByFoodId(string foodID)
        {
            string query = @"DELETE FROM dbo.FoodMaterial
                                WHERE food_id = @foodID";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@foodID", foodID }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }


        public List<FoodMaterial> GetListFoodMaterialByFoodId(string id)
        {
            List<FoodMaterial> listFoodMaterial = new List<FoodMaterial>();
            string query = $"SELECT * FROM dbo.FoodMaterial WHERE food_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                FoodMaterial foodMaterial = new FoodMaterial(row);
                listFoodMaterial.Add(foodMaterial);
            }
            return listFoodMaterial;
        }
    }
}
