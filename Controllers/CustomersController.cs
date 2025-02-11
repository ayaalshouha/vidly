using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

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
        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            //Customers prop is a dbSet in dbContext
            //deferred exexution: doesn't run until you enumerate the results  
            //var customers = _context.Customers; 
            //immediate execution
            //inlclude is eager loading so objects in customer object are not null
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
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