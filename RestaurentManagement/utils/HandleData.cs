using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurentManagement.utils
{
    internal class HandleData
    {
        private static HandleData instance;
        
        public static HandleData Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new HandleData();
                }
                return instance;
            }
        }


        public bool ExitNumber(string str)
        {
            if(Regex.IsMatch(str, @"[0,9]"))
            {
                return true;
            }
            return false;
        }

        public bool CheckEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return true;
            }
            return false;
        }

        public bool checkCharacter(string str)
        {
            if (Regex.IsMatch(str, @"[$'~@#$]"))
            {
                return true;
            }
            return false;
        }


    }
}
