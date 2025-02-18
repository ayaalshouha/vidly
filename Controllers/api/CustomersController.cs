
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using vidly.DTOs;
using vidly.Models;

namespace vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context ;
            
        public CustomersController() {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<CustomerDTO> GetCustomers()
        {
            //var customers = _context.Customers.ToList();
            //return customers;

            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id== id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //return customer; 
             return Mapper.Map<Customer, CustomerDTO>(customer); 
        }

        [HttpPost]
        public CustomerDTO Create(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest); 

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto); 
           
            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            customerDto.Id = customer.Id;
            return customerDto;
        }

        [HttpPut]
        public CustomerDTO Update(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb); 
            
            _context.SaveChanges();
            
            return customerDto;
        }

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
