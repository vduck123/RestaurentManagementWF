using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Controllers
{
    internal class AccountController
    {
        public void InsertAccount(Account acc)
        {
            string query = $@"Insert Into Account 
                              VALUES ({acc.ID}, {acc.User}, {acc.Password}, {acc.Role})";

            DBHelper.Instance.ExecuteNonQuery(query, null);    
        }

        public void LoadDataAccount()
        {
            string query = @"Select * from Account";

        }
    }
}
