using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().FirstOrDefault((c) => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 100, Name = "Baby Boss" },
                new Movie { Id = 101, Name = "The Italian Job" }
            };
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageInde={0}&sortBy={1}", pageIndex, sortBy));
        //'pli}
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