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

        public ActionResult Index(int? id)
        {
            int resultPerPage = 8;
            IList<Models.Movie> OnShowingMovies = Movies.GetAll();

            if (!Request.Browser.IsMobileDevice)
            {
                return View(OnShowingMovies);
            }

            int page = id ?? 1;
            if (page == 1)
            {
                return View(OnShowingMovies.Take(resultPerPage).ToList());
            }
            else
            {
                var PagingMovies = OnShowingMovies
                                  .Skip((page - 1) * resultPerPage)
                                  .Take(resultPerPage).ToList();

                if (page * resultPerPage < OnShowingMovies.Count)
                {
                    ViewBag.Page = page + 1;
                }
                return View("PartialMovies", PagingMovies);
            }
        }

        public ActionResult Detail(int id)
        {
            Models.Movie mv = Movies.GetSingle(d => d.Id == id);
            return View(mv);
        }
    }
}
