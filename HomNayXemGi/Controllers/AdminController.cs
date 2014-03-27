using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayXemGi.DAL;

namespace HomNayXemGi.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private MovieDAO Movies = new MovieDAO();
        private TicketDAO Tickets = new TicketDAO();

        public ActionResult Index(int? password)
        {
            if (password.HasValue && password.Value == 10111995)
            {
                var movies = Movies.GetAll().OrderBy(mv => mv.MovieType).ThenBy(mv => mv.Name).ToList();
                return View(movies);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Merge(int mergeMovieID, List<int> selectedMovieID)
        {
           Tickets.MergeMovieInfo(mergeMovieID,selectedMovieID);
           var movies = Movies.GetAll().OrderBy(mv => mv.MovieType).ThenBy(mv => mv.Name).ToList();
            return PartialView("_Movies", movies);
        }
    }
}
