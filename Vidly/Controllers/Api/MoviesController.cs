using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }


        // GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            // return _context.Customers.ToList().Select(Mapper.Map<Customer , CustomerDto>);
            var movieQuery = _context.Movies
                .Include(c => c.Genre);


               if (!string.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(c => c.Name.Contains(query));

            var movieDtos = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);

        }
        //REplace customerDto b IHttpActionResult
        // GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            // return customerDto ;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT api/movies/1
        [HttpPut]
        public IHttpActionResult updateMovie(MovieDto movieDto, int id)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            // customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.Name = customerDto.Name;
            //customerInDb.IsMale = customerDto.IsMale;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInDb.MemberShipTypeID = customerDto.MemberShipTypeID;

            _context.SaveChanges();

            return Ok();

        }

        //DELETE api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();


        }
    }
}
