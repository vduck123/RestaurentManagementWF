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
            if(Regex.IsMatch(str, @"^/d"))
            {
                return true;
            }
            return false;
        }


    }
}
