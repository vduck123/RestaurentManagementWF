using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.utils
{
    internal class DBHelper
    {
       
        private string conn = @"DataSource=CAOVIET;InitialCatalog=RestaurantManagement;IntegratedSecurity=True;TrustServerCertificate=True";

        private static DBHelper instance;

        public static DBHelper Instance { get => instance; set => instance = value; }

        public DBHelper() { }

        public int ExecuteNonQuery(string query, object obj)
        {
            int data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    if (obj != null)
                    {
                        data = cmd.ExecuteNonQuery();
                    }
                }
            }
            return data;
        }

        public int ExecuteScalar(string query, object obj)
        {
            int data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    if (obj != null)
                    {
                       
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

