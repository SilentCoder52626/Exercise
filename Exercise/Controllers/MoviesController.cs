using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Exercise.Models.IdentityModel;
using Exercise.Models;
using System.Data.Entity;
using Exercise.ViewModel;

namespace Exercise.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult MoviesForm()
        {            
            var MoviesGenre = context.MoviesGenres.ToList();
            var ViewModel = new MoviesFormViewModel
            {
                MoviesGenres = MoviesGenre
            };
            return View("MoviesForm",ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movies)
                {             
                    MoviesGenres = context.MoviesGenres.ToList()
                };
                return View("MoviesForm", viewModel);
            }
            
            if(movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                context.Movies.Add(movies);              
            }
                
            else
            {
                var moviesinDb = context.Movies.Single(c => c.Id == movies.Id);
                moviesinDb.Name = movies.Name;                
                moviesinDb.DateCreated = movies.DateCreated;
                moviesinDb.NumberInStock = movies.NumberInStock;
                moviesinDb.MoviesGenreId = movies.MoviesGenreId;
            }
            context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movies = context.Movies.SingleOrDefault(c => c.Id == id);
            if (movies == null)
                return HttpNotFound();

            var viewModel = new MoviesFormViewModel(movies)
            {                
                MoviesGenres = context.MoviesGenres.ToList()
            };
            return View("MoviesForm", viewModel);
        }

        //Get Method
        public ActionResult Index()
        {
            var movies = context.Movies.Include(m => m.MoviesGenre).ToList();
             return View(movies);
        }
        public ActionResult Details(int id)
        {

            var movies = context.Movies.Include(m => m.MoviesGenre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();    
            return View(movies);
        }
    }
}