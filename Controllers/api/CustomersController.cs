using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web.Http;
using vidly.Models;

namespace vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context ;
            
        public CustomersController() {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id== id);
             if(customer == null) 
                throw new HttpResponseException(HttpStatusCode.NotFound) 
                    
                    
             return customer; 
        }

        [HttpPost]
        public Customer Create(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest); 


            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT
        [HttpPut]
        public Customer Update(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id== id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            
            customerInDb.Name = customer.Name;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
            return customerInDb;
        }

        //delete 
        [HttpDelete]
        public bool Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);

            if (_context.SaveChanges() > 0)
                return true;

            return false; 
        }
    }
}
