using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace RestaurentManagement.utils
{
    internal class DBHelper
    {
        public static string conn = @"Data Source=CAOVIET;Initial Catalog=RestaurantManagement;Integrated Security=True;TrustServerCertificate=True";

        private static DBHelper instance;

        public static DBHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBHelper();
                }
                return instance;
            }
        }

        public DBHelper() { }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    data = cmd.ExecuteNonQuery();
                }
            }
            return data;
        }


        public int ExecuteScalar(string query)
        {
            int data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        data = Convert.ToInt16(result);
                    }
                }
            }
            return data;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                sqlConnection.Close();
                return dt;
            }
        }
    }
}

