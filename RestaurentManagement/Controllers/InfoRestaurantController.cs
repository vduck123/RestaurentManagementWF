using Bogus.DataSets;
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
    internal class InfoRestaurantController
    {

        private static InfoRestaurantController instance;
        public static InfoRestaurantController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new InfoRestaurantController();
                }
                return instance;
            }
        }
        public int Edit(InForRestaurant info)
        {
            string query = $@"UPDATE Infomation
                                SET name = @name ,
                                    address = @address ,
                                    phone = @phone ,
                                    time_open = @timeOpen ,
                                    time_close = @timeClose";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@name", info.Name},
                {"@address", info.Address } ,
                {"@phone", info.Phone } ,
                {"@timeOpen", info.timeOpen } ,
                {"@timeClose", info.timeClose }
             };

            int rs = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return rs;
        }

        public List<InForRestaurant> GetData()
        {
            List<InForRestaurant> data = new List<InForRestaurant> { };
            string query = "SELECT * FROM Infomation";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                InForRestaurant info = new InForRestaurant()
                {
                    Name = row["name"].ToString() ,
                    Address = row["address"].ToString() ,
                    Phone = row["phone"].ToString() ,
                    timeOpen = row["time_open"].ToString() ,
                    timeClose = row["time_close"].ToString()

                };

                data.Add(info);
            }

            return data;
        }
    }
}
