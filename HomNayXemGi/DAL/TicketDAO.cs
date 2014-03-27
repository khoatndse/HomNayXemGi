using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayXemGi.Models;

namespace HomNayXemGi.DAL
{
    public class TicketDAO :DAO<Models.Scheduler>
    {
        public List<RapChieu> GetAllRapChieu()
        {
            return GetAll().Select(sche => sche.RapChieu).Distinct().ToList();
        }

        public List<Scheduler> GetLichChieu(RapChieu Rap)
        {
            return GetAll().Where(sche => sche.RapChieu == Rap).ToList();
        }

        public void MergeMovieInfo(int mergeMovieID, List<int> selectedMovieID)
        {
            if (selectedMovieID.Contains(mergeMovieID))
            {
                 selectedMovieID.Remove(mergeMovieID);
            }
           
            var scheduleToChange = context.Schedulers.Where(sche => selectedMovieID.Contains(sche.MovieID.Value));

            foreach (var scheduler in scheduleToChange)
            {
                scheduler.MovieID = mergeMovieID;
            }

            var movieToDelete = context.Movies.Where(mv => selectedMovieID.Contains(mv.Id));

            foreach (var movie in movieToDelete)
            {
                context.Movies.DeleteObject(movie);
            }

            context.SaveChanges();
        }
    }
}