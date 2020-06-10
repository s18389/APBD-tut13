using APBD_tut13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.DTOs.Requests
{
    public class addOrderRequest
    {
        public int cliendId { set; get; }
        public Orders order { set; get; }
        public List<String> confectioneryProductsList { set; get; }
    }
}
