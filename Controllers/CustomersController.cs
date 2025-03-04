using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;
using System.Data.Entity.Validation;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //disposable object
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            // Dispose of managed resources like the context.
            _context.Dispose();

            // Call base Dispose to clean up any other resources.
            base.Dispose(disposing);
        }


        [Route("Customers")]
        public ActionResult Index()
        {
            //    //Customers prop is a dbSet in dbContext
            //    //deferred exexution: doesn't run until you enumerate the results  
            //    //var customers = _context.Customers; 
            //    //immediate execution
            //    //inlclude is eager loading so objects in customer object are not null
            //    var customers = _context.Customers.Include(c => c.MembershipType).ToList();
                //return View(customers);

            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer,
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); 
                //security halls 
                //TryUpdateModel(customerInDb);
                
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
               
                //Mapper.Map(customerDTO, customerInDb);

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
              
        public ActionResult Details(int id)
        {
            //immediate execution beacuse using single or default method
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault((c) => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}