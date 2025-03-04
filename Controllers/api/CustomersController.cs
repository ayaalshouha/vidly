
using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
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


        public IHttpActionResult GetCustomers()
        {
            //var customers = _context.Customers.ToList();
            //return customers;
            var customerDTO = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);
            
            return Ok(customerDTO);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id== id);
            if (customer == null)
                NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            //return customer; 
             return Ok(Mapper.Map<Customer, CustomerDTO>(customer)); 
        }

        [HttpPost]
        public IHttpActionResult Create(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest); 

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto); 
           
            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb); 
            
            _context.SaveChanges();
            
            return Ok(customerDto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                NotFound();

            _context.Customers.Remove(customerInDb);

            if (_context.SaveChanges() > 0)
                return Ok();

            return BadRequest("Could not delete the customer.");
        }
    }
}
