using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
            
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Where(m => m.MovieId == id).SingleOrDefault();

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var vm = new MovieViewModel
            {
                Genres = genres
            };
            return View("MovieForm", vm);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
                return HttpNotFound();

            var genres = _context.Genres.ToList();
            var vm = new MovieViewModel(movie)
            {
                Genres = genres
            };

            return View("MovieForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.Where(m => m.MovieId == movie.MovieId).Single();
                    movieInDb.MovieName = movie.MovieName;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.RelaseDate = movie.RelaseDate;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                var vm = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", vm);
            }
        }



    }
}