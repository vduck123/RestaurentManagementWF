using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.utils
{
    internal class CheckNum
    {
        private static CheckNum instance;
        public static CheckNum Instance 
        { 
            get 
            { 
                if(instance == null)
                {
                    instance = new CheckNum();
                }    
                return instance; 
            } 
        }

        public bool IsNum(string str)
        {
            double rs = 0;
            return double.TryParse(str, out rs);
        }
    }
}
