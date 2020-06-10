using APBD_tut13.DTOs.Requests;
using APBD_tut13.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Services
{
    public interface IService
    {
        showCustomerOrdersResponse showCustomerOrders(showCustomerOrdersRequest request);
        AddOrderResponse addOrder(addOrderRequest request);
    }
}
