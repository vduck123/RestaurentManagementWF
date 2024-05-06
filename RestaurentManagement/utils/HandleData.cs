using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


    }
}
