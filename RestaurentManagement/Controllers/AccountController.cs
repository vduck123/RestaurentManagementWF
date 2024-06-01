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
    internal class AccountController
    {

        private static AccountController instance;

        public static AccountController Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new AccountController();
                }

                return instance;
            }
        }

        public List<Account> GetListAccount()
        {
            List<Account> accounts = new List<Account>();
            string query = "SELECT * FROM Account";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow account in dt.Rows)
            {
                Account acc = new Account(account);
                accounts.Add(acc);
            }

            return accounts;
        }

        public int InsertAccount(Account acc)
        {
            string query = $@"Insert Into Account 
                              VALUES (@id,@user,@pass,@role)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", acc.ID},
                {"@user", acc.User} ,
                {"pass", acc.Password} ,
                {"role", acc.Role}               
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateAccount(Account acc)
        {
            string query = $@"UPDATE Account
                              SET username = @user ,
                                  password = @pass ,
                                  role = @role
                              WHERE acc_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", acc.ID},
                {"@user", acc.User} ,
                {"pass", acc.Password} ,
                {"role", acc.Role}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteAccount(string id)
        {
            string query = "DELETE FROM Account WHERE acc_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id},
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query,parameters);
            return data;
        }

        public List<Account> SelectAccountByID(string id)
        {
            List<Account> accounts = new List<Account>();
            string query = $"SELECT * FROM Account WHERE acc_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow account in dt.Rows)
            {
                Account acc = new Account(account);
                accounts.Add(acc);
            }

            return accounts;

        }

        public List<Account> SelectAccountByParam(string option, string keyword)
        {
            List<Account> accounts = new List<Account>();
            string query = $"SELECT * FROM Account WHERE {option} = N'{keyword}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow account in dt.Rows)
            {
                Account acc = new Account(account);
                accounts.Add(acc);
            }

            return accounts;

        }

        public List<Account> GetAccountsNoOwner()
        {
            List<Account> accounts = new List<Account>();
            string query = $@"SELECT a.acc_id, a.username, a.password, a.role
                                FROM Account a
                                LEFT JOIN Staff s ON s.acc_id = a.acc_id
                                WHERE s.acc_id IS NULL;";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                Account acc = new Account(item);
                accounts.Add(acc);
            }
            return accounts;
        }

        public string GetIdAccountByUsername(string user)
        {
            string id = null;
            string query = $@"SELECT * FROM dbo.Account WHERE username = N'{user}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                id = row["acc_id"].ToString();
            }

            return id;
        }

        public int GetOrderNumInList()
        {
            string query = $"SELECT COUNT(acc_id) FROM Account";
            int orderNum = Convert.ToInt32(DBHelper.Instance.ExecuteScalar(query));
            return orderNum;
        }




    }
}
