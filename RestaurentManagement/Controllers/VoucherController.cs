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
    internal class VoucherController
    {

        private static VoucherController instance;

        internal static VoucherController Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new VoucherController();
                }   
                return instance;
            }
        }

        public int InsertVoucher(Voucher voucher)
        {
            string query = @"INSERT INTO Voucher
                             VALUES (@id,@name,@expiry,@status)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", voucher.ID },
                {"@name", voucher.Name },
                {"@expiry", voucher.Expiry } ,
                {"@status", voucher.Status }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateVoucher(Voucher voucher)
        {
            string query = @"UPDATE Voucher
                             SET voucher_name = @name ,
                                 voucher_expiry = @expiry ,
                                 status = @status 
                             WHERE voucher_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", voucher.ID },
                {"@name", voucher.Name },
                {"@expiry", voucher.Expiry } ,
                {"@status", voucher.Status }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateStatusAll(string status)
        {
            string query = @"UPDATE Voucher
                             SET status = @status";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@status", status }
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteVoucher(string id)
        {
            string query = @"DELETE FROM Voucher WHERE voucher_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public List<Voucher> SelectVoucherByID(string id)
        {
            List<Voucher> vouchers = new List<Voucher>();
            string query = $"SELECT * FROM Voucher WHERE voucher_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Voucher voucher = new Voucher(dr);
                vouchers.Add(voucher);
            }
            return vouchers;
        }
        public List<Voucher> SelectVoucherByParam(string option, string param, string opera)
        {
            List<Voucher> vouchers = new List<Voucher>();
            string query = $"SELECT * FROM Voucher WHERE {option} {opera} N'{param}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Voucher voucher = new Voucher(dr);
                vouchers.Add(voucher);
            }
            return vouchers;
        }


        public List<Voucher> GetListVoucher()
        {
            List<Voucher> vouchers = new List<Voucher>();   
            string query = "SELECT * FROM Voucher";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Voucher voucher = new Voucher(dr);
                vouchers.Add(voucher);
            }
            return vouchers;
        }

        public string GetIdVoucherByName(string name)
        {
            string nameVoucher = null;
            string query = $"SELECT * FROM Voucher WHERE voucher_name = N'{name}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                nameVoucher = row["voucher_id"].ToString();
            }
            return nameVoucher;
        }
        public string GetExpiryById(string id)
        {
            string expiry = null;
            string query = $"SELECT * FROM Voucher WHERE voucher_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                expiry = row["voucher_expiry"].ToString();
            }
            return expiry;
        }
        public int GetOrderNumInList()
        {
            string query = $"SELECT COUNT(voucher_id) FROM Voucher";
            int orderNum = Convert.ToInt32(DBHelper.Instance.ExecuteScalar(query));
            return orderNum;
        }
    }
}
