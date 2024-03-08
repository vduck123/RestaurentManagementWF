using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.DTO
{
    internal class Test
    {

        public string ID { get; set; }
        public string Name { get; set; }

        public Test(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Test() { }   
    }
}
