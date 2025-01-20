using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1; 

            if(string.IsNullOrWhiteSpace(sortBy))
                sortBy  = "Name";

            return Content(string.Format("pageInde={0}&sortBy={1}", pageIndex, sortBy)); 
        }
        public ActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek"};
            return View(movie);
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