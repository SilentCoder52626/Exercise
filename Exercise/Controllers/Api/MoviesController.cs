using AutoMapper;
using Exercise.Dtos;
using Exercise.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using static Exercise.Models.IdentityModel;

namespace Exercise.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext context;
        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        //Get /api/movies
        public IEnumerable<MoviesDto> GetMovies()
        {
            return context.Movies.Include(m => m.MoviesGenre)
                .ToList().Select(Mapper.Map<Movies, MoviesDto>);
            //return context.Movies
            //    .ToList().Select(Mapper.Map<Movies, MoviesDto>);
        }
        //Get /api/movies/id
        public MoviesDto GetMovies(int id)
        {
            var movies = context.Movies.SingleOrDefault(c => c.Id == id);
            if (movies == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Movies, MoviesDto>(movies);
        }
        //post /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movies = Mapper.Map<MoviesDto, Movies>(moviesDto);
            context.Movies.Add(movies);
            context.SaveChanges();
            moviesDto.Id = movies.Id;
            return Created(new Uri(Request.RequestUri + "/" + movies.Id), moviesDto);
        }
        //put /api/movies/id
        public IHttpActionResult UpdateMovie(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MoviesInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (MoviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(moviesDto, MoviesInDb);
            context.SaveChanges();
            return Ok();
        }
        //Delete /api/movies/id
        public IHttpActionResult DeleteMovie(int id)
        {
            var MoviesInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (MoviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Movies.Remove(MoviesInDb);
            context.SaveChanges();
            return Ok();
        }
    }
}