using APBD_tut13.DTOs.Requests;
using APBD_tut13.DTOs.Responses;
using APBD_tut13.Entities;
using APBD_tut13.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_tut13.Services
{
    public class Service : ControllerBase, IService
    {
        private DbContextCreate _context;
        public Service(DbContextCreate dbContextCreate)
        {
            _context = dbContextCreate;
        }

        public showCustomerOrdersResponse showCustomerOrders(showCustomerOrdersRequest request)
        {
            var response = new showCustomerOrdersResponse();

            DbContextCreate clientContext = new DbContextCreate();

            if (request.NameCustomer != null)
            {
                var linqQuery = from customer in clientContext.Customers
                                join orders in clientContext.Orders on customer.IdClient equals orders.IdClient
                                where customer.Name == request.NameCustomer
                                select orders;
                if (linqQuery.Count() == 0)
                {
                    response.message = "There is no client with this name!";
                    response.code = 404;
                    return response;
                }

                List<Orders> ordersList = linqQuery.ToList();
                List<orderElement> orderElementsList = new List<orderElement>();

                foreach (var order in ordersList)
                {
                    var orderElement = new orderElement();
                    orderElement.IdOrder = order.IdOrder;
                    orderElement.DateAccepted = order.DateAccepted;
                    orderElement.DateFinished = order.DateFinished;
                    orderElement.Notes = order.IdOrder;

                    List<Confectionery_Order> confectioneryOrderList = _context.Confectionery_Order.Where(c => c.IdOrder == order.IdOrder).ToList();
                   

                    foreach (var confectionary_order in confectioneryOrderList)
                    {
                        confectionary_order.Confectionery = _context.Confectionery.Where(c => c.IdConfection == confectionary_order.IdConfection).First();
                    }

                    orderElement.confectionariesOrdersList = confectioneryOrderList;
                    orderElementsList.Add(orderElement);
                }

                response.ListOfOrders = orderElementsList;
                response.code = 200;


                return response;
            }
            else
            {
                var linqQuery = from customer in clientContext.Customers
                                join orders in clientContext.Orders on customer.IdClient equals orders.IdClient
                                select orders;

                List<Orders> ordersList = linqQuery.ToList();
                List<orderElement> orderElementsList = new List<orderElement>();

                foreach (var order in ordersList)
                {
                    var orderElement = new orderElement();
                    orderElement.IdOrder = order.IdOrder;
                    orderElement.DateAccepted = order.DateAccepted;
                    orderElement.DateFinished = order.DateFinished;
                    orderElement.Notes = order.IdOrder;

                    List<Confectionery_Order> confectioneryOrderList = _context.Confectionery_Order.Where(c => c.IdOrder == order.IdOrder).ToList();


                    foreach (var confectionary_order in confectioneryOrderList)
                    {
                        confectionary_order.Confectionery = _context.Confectionery.Where(c => c.IdConfection == confectionary_order.IdConfection).First();
                    }

                    orderElement.confectionariesOrdersList = confectioneryOrderList;
                    orderElementsList.Add(orderElement);
                }

                response.ListOfOrders = orderElementsList;
                response.code = 200;
                response.message = "You dont provide any name, listing all orders..";


                return response;
            }
        }

       public AddOrderResponse addOrder(addOrderRequest request)
        {
            AddOrderResponse response = new AddOrderResponse();

            if (isCustomerExist(request.cliendId) == false)
            {
                response.message = "CLIENT DOES NOT EXIST!!";
                response.code = 404;
                return response;
            }

            try
            {
                if ((request.confectioneryProductsList == null) || (request.confectioneryProductsList.Count()==0))
                {
                    response.message = "YOU DID NOT PROVIDE ANY NAME OF CONFECTIONARY!!";
                    response.code = 500;
                    return response;
                }
            }
            catch (System.ArgumentNullException)
            {
                response.message = "YOU DID NOT PROVIDE ANY NAME OF CONFECTIONARY!!";
                response.code = 500;
                return response;
            }
          

            foreach(string confectionaryName in request.confectioneryProductsList)
            {
                if(isProductExistInDatabase(confectionaryName) == false)
                {
                    response.message = "PRODUCT " + confectionaryName + " DOES NOT EXIST IN DATABASE!!";
                    response.code = 404;
                    return response;
                }
            }

            using (var orderContext = new DbContextCreate())
            {
                orderContext.Orders.Add(request.order);
                try
                {
                    orderContext.SaveChanges();
                    response.message = "SUCCESFULL ADDED ORDER";
                    response.code = 200;
                }
                catch (Exception)
                {
                    response.message = "ADDED FAILED... FROM SOME REASON XD";
                    response.code = 500;
                }
            }

            return response;
        }

        private bool isProductExistInDatabase(string confectionaryName)
        {
            return _context.Confectionery.Any(c => c.Name.Equals(confectionaryName));
        }

        private bool isCustomerExist(int cliendId)
        {
            return _context.Customers.Any(c => c.IdClient == cliendId);
        }
    }
}
