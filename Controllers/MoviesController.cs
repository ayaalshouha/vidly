using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).FirstOrDefault((c) => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek"};
            var customers = new List<Customer>
            {
                new Customer {Name ="Mohammad", Id=100},
                new Customer {Name ="Ahmad", Id=101}
            };

            var viewModel = new RandomViewModelMovie
            {
                Movie = movie,
                Customers = customers,
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieForm = new MovieFormViewModel
            {
                Genres = genres,
            };
            return View("MovieForm",movieForm);
        }
        public ActionResult Edit(int id)
        {
            //edit process

            return Content("movie number " + id + " has been edited");
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}