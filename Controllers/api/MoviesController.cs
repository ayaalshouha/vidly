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
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>));
        }

        [HttpGet]
        public IHttpActionResult Movie(int id) {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        public IHttpActionResult Create(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

    }
}
