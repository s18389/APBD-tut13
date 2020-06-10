using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Entities
{
    public class Confectionery
    {
        public int IdConfection { get; set; }
        public string Name { get; set; }
        public double PricePerlte { get; set; }
        public string Type { get; set; }

        public ICollection<Confectionery_Order> Confectionery_Order { get; set; }
    }
}
