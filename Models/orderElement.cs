using APBD_tut13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Models
{
    public class orderElement
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; internal set; }
        public DateTime DateFinished { get; internal set; }
        public int Notes { get; internal set; }
        public Orders order { set; get; }
        public List<Confectionery_Order> confectionariesOrdersList { set; get; }
    }
}
