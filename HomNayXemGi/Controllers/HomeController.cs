using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayXemGi.DAL;

namespace HomNayXemGi.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private MovieDAO Movies = new MovieDAO();
        private TicketDAO Tickets = new TicketDAO();

        public ActionResult Index()
        {
            IList<Models.Movie> OnShowingMovies = Movies.GetAll();
            return View(OnShowingMovies);
        }

        public ActionResult Detail(int id)
        {
            Models.Movie mv = Movies.GetSingle(d => d.Id == id);
            return View(mv);
        }
    }
}
