using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;

internal class DBProvider
{
    private static string conn = "Data Source=CAOVIET;Initial Catalog=RestaurantManagement;Integrated Security=True;TrustServerCertificate=True";

    public static int ExecuteNonQuery(string query, object obj)
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

    public static DataTable ExecuteDataAdapter(string query)
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
