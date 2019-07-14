using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreWebApi.Models;
using OnlineStoreWebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {

        [HttpGet]
        public IList<Customer> Get()
        {
            CustomerService _customerService = new CustomerService();
            return _customerService.GetRegisteredCustomers();
        }

        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            CustomerService _customerService = new CustomerService();
            _customerService.RegisterCustomer(customer);
        }
    }
}
