using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_tut13.DTOs.Requests;
using APBD_tut13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_tut13.Controllers
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IService _service;

        public DefaultController(IService service)
        {
            _service = service;
        }

        [HttpGet("orders")]
        public IActionResult showCustomerOrders(showCustomerOrdersRequest request)
        {
            //request.NameCustomer = "Jakub";
            var response = _service.showCustomerOrders(request);
            if (response.code == 404) return NotFound(response);
            else if (response.code == 500) return BadRequest(response);
            else return Ok(response);
        }

        [HttpGet("addOrder/{idClient}")]
        public IActionResult addOrder(addOrderRequest request, int idClient)
        {
            request.cliendId = idClient;
            request.order = new Entities.Orders {
                DateAccepted = DateTime.Now,
                DateFinished = DateTime.Now.AddDays(3),
                Notes = "Some notes to order",
                IdClient = request.cliendId,
                IdEmployee = 1
            };
            request.confectioneryProductsList = new List<String> { "BirthadayCake" };

            var response = _service.addOrder(request);

            if (response.code == 404) return NotFound(response);
            else if (response.code == 500) return BadRequest(response);
            else return Ok(response);
        }
    }
}