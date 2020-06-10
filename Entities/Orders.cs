using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Entities
{
    public class Orders
    {
        public int IdOrder { set; get; }
        public DateTime DateAccepted { set; get; }
        public DateTime DateFinished { set; get; }
        public string Notes { set; get; }
        public int IdClient { set; get; }
        public virtual Customer Customer { set; get; }
        public int IdEmployee { set; get; }

        public virtual Employee Employee { set; get; }

        public ICollection<Confectionery_Order> Confectionery_Order { get; set; }
    }
}
