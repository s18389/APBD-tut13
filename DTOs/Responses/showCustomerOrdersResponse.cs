using APBD_tut13.Entities;
using APBD_tut13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.DTOs.Responses
{
    public class showCustomerOrdersResponse
    {
        public string message { set; get; }
        public int code { set; get; }
        public ICollection<orderElement> ListOfOrders { get; set; }
    }
}
