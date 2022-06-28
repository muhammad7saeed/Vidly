using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ViewResult index()
        {
            //var movie = db.Movies.Include(c => c.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");

        }

        
        public IEnumerable<Movie> getMovies() //h3ml function tgebly list of customer w b3d kda hwdeha ll view 3shan a3rdha...... IEnumerable Generic data type//
        {

            var Movies = db.Movies.ToList();
            return Movies;

        }
    

    [HttpGet]
    public ActionResult AddMovie()
    {
        var Genres = db.Genres.ToList();
        MovieGenre mg = new MovieGenre
        {
            
            Genres = Genres
        };
        
        return View(mg);
    }
    [HttpPost] //submit form
    [ValidateAntiForgeryToken]
    public ActionResult AddMovie(MovieGenre mg) //bst2bl el form
    {
        var MovieGenre = db.Genres.ToList();
        mg.Genres = MovieGenre;
        mg.Movie.DataAdded = DateTime.Now;

            if (!ModelState.IsValid)
        {
            return View("AddMovie", mg);
        }
        db.Movies.Add(mg.Movie);
        db.SaveChanges();
        return RedirectToAction("index");
    }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult EditMovie(int id )
    {

        var Genres = db.Genres.ToList();
        var Movie = db.Movies.SingleOrDefault(c => c.Id == id);


            MovieGenre mg = new MovieGenre
        {

            Genres = Genres,
            Movie = Movie,
            
        };
        
        return View(mg);
    }
    [HttpPost]
    public ActionResult EditMovie(MovieGenre mg)
    {
            if (!ModelState.IsValid)
        {
            var Genres = db.Genres.ToList();
            mg.Genres = Genres;
            mg.Movie.DataAdded=DateTime.Now;
            return View("EditMovie", mg);
        }

        var MovieDB = db.Movies.Single(c => c.Id == mg.Movie.Id);
        MovieDB.ReleaseDate = mg.Movie.ReleaseDate;
        MovieDB.NumberInStocks = mg.Movie.NumberInStocks;
        MovieDB.GenreId = mg.Movie.GenreId;
        MovieDB.Name = mg.Movie.Name;
        db.SaveChanges();


        return RedirectToAction("index");
    }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieDetails(int id )
        {
            var Movie = db.Movies.SingleOrDefault(c => c.Id == id);
             db.Movies.Include(c => c.Genre).ToList();





            return View(Movie);
        }
        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Delete(int id) //bst2bl el form
        {
            var Movie = db.Movies.Single(c => c.Id == id);

            db.Movies.Remove(Movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: Movies/random
        public ActionResult Random()
        {
          //  var movie = new Movie() {Name = "Shrek!  " ,Id = 1};
          //  return View(movie); 
         // return Json(new { Name = "Mohamed Saeed", Id = "20160353", Age = "22" },JsonRequestBehavior.AllowGet);
        // return RedirectToAction("Index", "Home", new { pageIndex = "12", Name = "hassan" });
        /*
        List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "Mohamed", Id = 5 },
            new Customer { Name = "abass", Id = 10 },
            new Customer { Name = "saeed", Id = 15 },


        };
        
        Movie movie = new Movie {Id = 12, Name = "Shrek"};

        Movie movie1 = new Movie { Id = 5, Name = "Titanic" };

        MovieCustomerModel mcm = new MovieCustomerModel
        {

            Customers = customers,
            Movie = movie1

        };
        ViewData["Movie"] = movie;
        ViewBag.Mymovie = movie;

       // return View(movie);
       return View(mcm);
       */
        return View();
        }
        
        /*
        public ActionResult Edit(int movieId)
        {
            return Content("movieId=" + movieId);
        }
        */
        //movies
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));//0 refer to---> first paramter and 1 refer to second paramter 
        }
        */

        /*
        [Route("Movies/released/{year:range(2010,2020)}/{month:min(1):max(12)}")]
        
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/"+ month);

        }
        */

    }
}