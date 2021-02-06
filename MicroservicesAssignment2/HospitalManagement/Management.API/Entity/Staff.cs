using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.API.Entities
{
    public class Staff
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public long Salary { get; set; }
        public String Role { get; set; }
        public long Address { get; set; }

    }
}
