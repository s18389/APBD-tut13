using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Entities
{
    public class Confectionery_Order
    {
        public int IdConfection { set; get; }
        public virtual Confectionery Confectionery { set; get; }
        public int IdOrder { set; get; }
        public virtual Orders Order { set; get; }
        public int Quantity { set; get; }
        public string Notes { set; get; }
    }
}
