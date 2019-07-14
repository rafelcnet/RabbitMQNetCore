using System;
using System.Collections.Generic;
using OnlineStoreWebApi.Messaging;
using OnlineStoreWebApi.Models;
using OnlineStoreWebApi.Repositories;

namespace OnlineStoreWebApi.Services
{
    public class CustomerService
    {

        private CustomerRepository _customerRepository;
        private  OnlineStoreMq _onlineStoreMq;

        public CustomerService()
        {
            
            _onlineStoreMq = new OnlineStoreMq();
        }

        public IList<Customer> GetRegisteredCustomers()
        {
            _customerRepository = new CustomerRepository();
            var datos = _customerRepository.GetAll();
            return datos;
        }

        public void RegisterCustomer(Customer customer)
        {
            _onlineStoreMq.SendMessage(customer);
        }
    }
}
