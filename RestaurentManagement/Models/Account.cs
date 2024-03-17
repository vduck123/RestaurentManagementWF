using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace RestaurentManagement.Models
{
    internal class Account
    {
        public string ID;
        public string User;
        public string Password;
        public string Role;

        public Account(string id, string user, string password, string role)
        {
            this.ID = id;
            this.User = user;
            this.Password = password;
            this.Role = role;
        }

        public Account() { }

        public Account(DataRow row)
        {
            this.ID = (string)row["acc_id"];
            this.User = (string)row["username"];
            this.Password = (string)row["password"];
            this.Role = (string)row["role"];
        }


    }
}
