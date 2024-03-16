using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Controllers
{
    internal class MenuController
    {
        private static MenuController instance;
        public static MenuController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MenuController();
                }
                return instance;
            }
        }

        
    }
}
