using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Entities
{
    public class Customer
    {

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
