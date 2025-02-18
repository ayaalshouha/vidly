using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;
using AutoMapper;
using vidly.DTOs;

namespace vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController() { 
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult Movies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map(Movie, MovieDTO)));
        }

    }
}
